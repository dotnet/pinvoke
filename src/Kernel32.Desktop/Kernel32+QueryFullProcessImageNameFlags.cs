// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="QueryFullProcessImageNameFlags" /> nested type.
    /// </content>
    public partial class Kernel32
    {
        [Flags]
        public enum QueryFullProcessImageNameFlags
        {
            /// <summary>
            /// The name should use the Win32 path format.
            /// </summary>
            None = 0,

            /// <summary>
            /// The name should use the native system path format.
            /// </summary>
            PROCESS_NAME_NATIVE = 0x00000001
        }
    }
}
