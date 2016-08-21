// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="WindowStationCreationFlags"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Controls the behaviour of <see cref="CreateWindowStation(string, WindowStationCreationFlags, Kernel32.ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES?)" /> when a window station with the desired name already exists/>
        /// </summary>
        public enum WindowStationCreationFlags : uint
        {
            None = 0x0000,

            /// <summary>
            /// Enables processes running in other accounts on the desktop to set hooks in this process
            /// </summary>
            CWF_CREATE_ONLY = 0x0001
        }
    }
}