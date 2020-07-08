// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="InstallFlags"/> nested type.
    /// </content>
    public partial class NewDev
    {
        /// <summary>
        /// Defines how a device driver is installed.
        /// </summary>
        [Flags]
        public enum InstallFlags : uint
        {
            /// <summary>
            /// If this flag is set and the function finds a device that matches the HardwareId value,
            /// the function installs new drivers for the device whether better drivers already exist on the computer.
            /// </summary>
            Force = 0x1,

            /// <summary>
            /// If this flag is set, the function will not copy, rename, or delete any installation
            /// files. Use of this flag should be limited to environments in which file access is
            /// restricted or impossible, such as an "embedded" operating system.
            /// </summary>
            ReadOnly = 0x2,

            /// <summary>
            /// If this flag is set, the function will return <see langword="false"/> when any attempt to display UI is
            /// detected. Set this flag only if the function will be called from a component (such as a
            /// service) that cannot display UI.
            /// </summary>
            NonInteractive = 0x4,
        }
    }
}
