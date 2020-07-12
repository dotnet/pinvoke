// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="CreateThreadFlags"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Flags that may be passed to the <see cref="CreateThread(SECURITY_ATTRIBUTES*, UIntPtr, THREAD_START_ROUTINE, void*, CreateThreadFlags, uint*)"/> function.
        /// </summary>
        [Flags]
        public enum CreateThreadFlags
        {
            None = CreateProcessFlags.None,

            /// <summary>
            /// The primary thread of the new process is created in a suspended state, and does not run until the <see cref="ResumeThread"/> function is called.
            /// </summary>
            CREATE_SUSPENDED = CreateProcessFlags.CREATE_SUSPENDED,

            /// <summary>
            /// The dwStackSize parameter in <see cref="CreateThread(SECURITY_ATTRIBUTES*, UIntPtr, THREAD_START_ROUTINE, void*, CreateThreadFlags, uint*)"/>
            /// specifies the initial reserve size of the stack. If this flag is not specified,
            /// dwStackSize specifies the commit size.
            /// </summary>
            STACK_SIZE_PARAM_IS_A_RESERVATION = 0x00010000,
        }
    }
}
