// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="RegNotifyFilter"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// A value that indicates the changes that should be reported when using <see cref="RegNotifyChangeKeyValue "/>.
        /// </summary>
        [Flags]
        public enum RegNotifyFilter
        {
            /// <summary>Notify the caller if a subkey is added or deleted.</summary>
            REG_NOTIFY_CHANGE_NAME = 0x00000001,

            /// <summary>Notify the caller of changes to the attributes of the key, such as the security descriptor information.</summary>
            REG_NOTIFY_CHANGE_ATTRIBUTES = 0x00000002,

            /// <summary>
            ///     Notify the caller of changes to a value of the key. This can include adding or deleting a value, or changing
            ///     an existing value.
            /// </summary>
            REG_NOTIFY_CHANGE_LAST_SET = 0x00000004,

            /// <summary>Notify the caller of changes to the security descriptor of the key.</summary>
            REG_NOTIFY_CHANGE_SECURITY = 0x00000008,

            /// <summary>
            ///     Indicates that the lifetime of the registration must not be tied to the lifetime of the thread issuing the
            ///     <see cref="RegNotifyChangeKeyValue" /> call.
            ///     <para>Note  This flag value is only supported in Windows 8 and later.</para>
            ///     .
            /// </summary>
            REG_NOTIFY_THREAD_AGNOSTIC = 0x10000000
        }
    }
}
