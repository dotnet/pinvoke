// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="PROCESS_MEMORY_EXHAUSTION_INFO"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Allows applications to configure a process to terminate if an allocation fails to commit memory.
        /// This structure is used by the <see cref="PROCESS_INFORMATION_CLASS"/> class.
        /// </summary>
        public struct PROCESS_MEMORY_EXHAUSTION_INFO
        {
            /// <summary>
            /// The only valid value for <see cref="PROCESS_MEMORY_EXHAUSTION_INFO.Version"/>
            /// </summary>
            public const ushort PME_CURRENT_VERSION = 1;

            /// <summary>
            /// Value for <see cref="PROCESS_MEMORY_EXHAUSTION_INFO.Value"/> field to disable
            /// the <see cref="PROCESS_MEMORY_EXHAUSTION_TYPE.PMETypeFailFastOnCommitFailure"/> feature
            /// </summary>
            public static UIntPtr PME_FAILFAST_ON_COMMIT_FAIL_DISABLE = UIntPtr.Zero;

            /// <summary>
            /// Value for <see cref="PROCESS_MEMORY_EXHAUSTION_INFO.Value"/> field to enable
            /// the <see cref="PROCESS_MEMORY_EXHAUSTION_TYPE.PMETypeFailFastOnCommitFailure"/> feature
            /// </summary>
            public static UIntPtr PME_FAILFAST_ON_COMMIT_FAIL_ENABLE = new UIntPtr(0x1);

            /// <summary>
            /// This should be set to <see cref="PME_CURRENT_VERSION"/>
            /// </summary>
#pragma warning disable IDE1006 // Naming Styles
            public ushort Version;
#pragma warning restore IDE1006 // Naming Styles

            /// <summary>
            /// Reserved
            /// </summary>
#pragma warning disable IDE1006 // Naming Styles
            public ushort Reserved;
#pragma warning restore IDE1006 // Naming Styles

            /// <summary>
            /// Type should be set to <see cref="PROCESS_MEMORY_EXHAUSTION_TYPE.PMETypeFailFastOnCommitFailure"/> (this is the only
            /// type available).
            /// </summary>
#pragma warning disable IDE1006 // Naming Styles
            public PROCESS_MEMORY_EXHAUSTION_TYPE Type;
#pragma warning restore IDE1006 // Naming Styles

            /// <summary>
            /// Used to turn the feature on or off
            ///  <list type="table">
            ///  <listheader><term>Function</term><term>Setting</term></listheader>
            ///  <item><term>Enable</term><term><see cref="PME_FAILFAST_ON_COMMIT_FAIL_ENABLE"/></term></item>
            ///  <item><term>Disable</term><term><see cref="PME_FAILFAST_ON_COMMIT_FAIL_ENABLE"/></term></item>
            ///  </list>
            /// </summary>
#pragma warning disable IDE1006 // Naming Styles
            public UIntPtr Value;
#pragma warning restore IDE1006 // Naming Styles

            public static PROCESS_MEMORY_EXHAUSTION_INFO Create(PROCESS_MEMORY_EXHAUSTION_TYPE pmeType, bool enable)
            {
                return pmeType switch
                {
                    PROCESS_MEMORY_EXHAUSTION_TYPE.PMETypeFailFastOnCommitFailure => new PROCESS_MEMORY_EXHAUSTION_INFO
                    {
                        Version = PME_CURRENT_VERSION,
                        Reserved = 0,
                        Type = PROCESS_MEMORY_EXHAUSTION_TYPE.PMETypeFailFastOnCommitFailure,
                        Value = enable ? PME_FAILFAST_ON_COMMIT_FAIL_ENABLE : PME_FAILFAST_ON_COMMIT_FAIL_DISABLE
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(pmeType)),
                };
            }
        }
    }
}
