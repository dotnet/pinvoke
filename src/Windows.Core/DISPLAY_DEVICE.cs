// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <summary>
    /// Receives information about the display device specified by the <c>iDevNum</c> parameter of the <c>User32.EnumDisplayDevices</c> function.
    /// </summary>
    public unsafe struct DISPLAY_DEVICE
    {
        /// <summary>
        /// Size, in bytes, of the DISPLAY_DEVICE structure. This must be initialized prior to calling <c>User32.EnumDisplayDevices</c>.
        /// </summary>
        public uint cb;

        /// <summary>
        /// An array of characters identifying the device name. This is either the adapter device or the monitor device.
        /// </summary>
        public fixed char DeviceName[32];

        /// <summary>
        /// An array of characters containing the device context string. This is either a description of the display adapter or of the display monitor.
        /// </summary>
        public fixed char DeviceString[128];

        /// <summary>
        /// Device state flags.
        /// </summary>
        public DisplayDeviceFlags StateFlags;

        /// <summary>
        /// Not used.
        /// </summary>
        public fixed char DeviceID[128];

        /// <summary>
        /// Reserved.
        /// </summary>
        public fixed char DeviceKey[128];

        /// <summary>
        /// Initializes a new instance of the <see cref="DISPLAY_DEVICE"/> struct
        /// with the <see cref="cb" /> field initialized.
        /// </summary>
        /// <returns>
        /// An instance of the structure.
        /// </returns>
        public static DISPLAY_DEVICE Create() => new DISPLAY_DEVICE { cb = (uint)sizeof(DISPLAY_DEVICE) };
    }
}
