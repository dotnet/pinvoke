// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="GetModuleHandleExFlags"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Flags that may be passed to the <see cref="GetModuleHandleEx"/> function.
        /// </summary>
        [Flags]
        public enum GetModuleHandleExFlags
        {
            /// <summary>
            /// Define no flags.
            /// </summary>
            None = 0,

            /// <summary>
            /// The lpModuleName parameter is an address in the module.
            /// </summary>
            GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS = 0x00000004,

            /// <summary>
            /// The module stays loaded until the process is terminated, no matter how many times <see cref="FreeLibrary"/> is called.
            /// </summary>
            /// <remarks>This option cannot be used with <see cref="GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT"/>.</remarks>
            GET_MODULE_HANDLE_EX_FLAG_PIN = 0x00000001,

            /// <summary>
            /// The reference count for the module is not incremented. This option is equivalent to the behavior of <see cref="GetModuleHandle"/>.
            /// Do not pass the retrieved module handle to the <see cref="FreeLibrary"/> function; doing so can cause the DLL to be unmapped prematurely.
            /// </summary>
            /// <remarks>
            /// This option cannot be used with <see cref="GET_MODULE_HANDLE_EX_FLAG_PIN" />.
            /// </remarks>
            GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT = 0x00000002
        }
    }
}
