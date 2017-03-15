// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="FOCUS_EVENT_RECORD"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Describes a focus event in a console <see cref="INPUT_RECORD"/> structure.
        /// </summary>
        /// <remarks>
        /// These events are used internally and should be ignored.
        /// </remarks>
        [StructLayout(LayoutKind.Sequential)]
        public struct FOCUS_EVENT_RECORD
        {
            /// <summary>
            /// Reserved.
            /// </summary>
            [MarshalAs(UnmanagedType.Bool)]
            public bool bSetFocus;
        }
    }
}
