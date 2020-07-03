// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <summary>
    /// Device state flags.
    /// </summary>
    [Flags]
    public enum DisplayDeviceFlags : uint
    {
        /// <summary>
        ///     Specifies whether a monitor is presented as being "on" by the respective GDI view.
        ///     Windows Vista: EnumDisplayDevices will only enumerate monitors that can be presented as being "on".
        /// </summary>
        DISPLAY_DEVICE_ACTIVE = 0x00000001,

        /// <summary>
        ///     Represents a pseudo device used to mirror application drawing for remoting or other purposes. An invisible pseudo monitor is associated with this device.
        ///     For example, NetMeeting uses it. Note that <c>User32.GetSystemMetrics</c> (<c>SM_MONITORS</c>) only accounts for visible display monitors.
        /// </summary>
        DISPLAY_DEVICE_MIRRORING_DRIVER = 0x00000008,

        /// <summary>The device has more display modes than its output devices support.</summary>
        DISPLAY_DEVICE_MODESPRUNED = 0x08000000,

        /// <summary>
        ///     The primary desktop is on the device. For a system with a single display card, this is always set.
        ///     For a system with multiple display cards, only one device can have this set.
        /// </summary>
        DISPLAY_DEVICE_PRIMARY_DEVICE = 0x00000004,

        /// <summary>The device is removable; it cannot be the primary display.</summary>
        DISPLAY_DEVICE_REMOVABLE = 0x00000020,

        /// <summary>The device is VGA compatible.</summary>
        DISPLAY_DEVICE_VGA_COMPATIBLE = 0x00000010,
    }
}
