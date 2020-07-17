// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="EnumDisplaySettingsExFlags"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Flags for <see cref="EnumDisplaySettingsEx(char*, uint, DEVMODE*, EnumDisplaySettingsExFlags)"/>.
        /// </summary>
        [Flags]
        public enum EnumDisplaySettingsExFlags : uint
        {
            /// <summary>
            /// If set, the function will return all graphics modes reported by the adapter driver, regardless of monitor capabilities.
            /// Otherwise, it will only return modes that are compatible with current monitors.
            /// </summary>
            EDS_RAWMODE = 0x00000002,

            /// <summary>
            /// If set, the function will return graphics modes in all orientations.
            /// Otherwise, it will only return modes that have the same orientation as the one currently set for the requested display.
            /// </summary>
            EDS_ROTATEDMODE = 0x00000004,
        }
    }
}
