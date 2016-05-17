// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="HiddAttributes"/> nested type.
    /// </content>
    public static partial class Hid
    {
        /// <summary>
        /// The HIDD_ATTRIBUTES structure contains vendor information about a HIDClass device.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct HiddAttributes
        {
            /// <summary>
            /// Specifies the size, in bytes, of a HIDD_ATTRIBUTES structure.
            /// </summary>
            public int Size;

            /// <summary>
            /// Specifies a HID device's vendor ID.
            /// </summary>
            public ushort VendorId;

            /// <summary>
            /// Specifies a HID device's product ID.
            /// </summary>
            public ushort ProductId;

            /// <summary>
            /// Specifies the manufacturer's revision number for a HIDClass device.
            /// </summary>
            public ushort VersionNumber;

            public static HiddAttributes Create()
            {
                var result = default(HiddAttributes);
                result.Size = Marshal.SizeOf(result);
                return result;
            }
        }
    }
}