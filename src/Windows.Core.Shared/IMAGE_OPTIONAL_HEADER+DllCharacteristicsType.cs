// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="DllCharacteristicsType"/> nested type.
    /// </content>
    public partial struct IMAGE_OPTIONAL_HEADER
    {
        /// <summary>
        /// Enumerates flags that may be found in the <see cref="DllCharacteristics"/> field.
        /// </summary>
        [Flags]
        public enum DllCharacteristicsType : ushort
        {
            /// <summary>
            /// Reserved.
            /// </summary>
            Reserved1 = 0x0001,

            /// <summary>
            /// Reserved.
            /// </summary>
            Reserved2 = 0x0002,

            /// <summary>
            /// Reserved.
            /// </summary>
            Reserved3 = 0x0004,

            /// <summary>
            /// Reserved.
            /// </summary>
            Reserved4 = 0x0008,

            /// <summary>
            /// The DLL can be relocated at load time.
            /// </summary>
            IMAGE_DLLCHARACTERISTICS_DYNAMIC_BASE = 0x0040,

            /// <summary>
            /// Code integrity checks are forced. If you set this flag and a section contains only uninitialized data, set the PointerToRawData member of <see cref="IMAGE_SECTION_HEADER"/> for that section to zero; otherwise, the image will fail to load because the digital signature cannot be verified.
            /// </summary>
            IMAGE_DLLCHARACTERISTICS_FORCE_INTEGRITY = 0x0080,

            /// <summary>
            /// The image is compatible with data execution prevention (DEP).
            /// </summary>
            IMAGE_DLLCHARACTERISTICS_NX_COMPAT = 0x0100,

            /// <summary>
            /// The image is isolation aware, but should not be isolated.
            /// </summary>
            IMAGE_DLLCHARACTERISTICS_NO_ISOLATION = 0x0200,

            /// <summary>
            /// The image does not use structured exception handling (SEH). No handlers can be called in this image.
            /// </summary>
            IMAGE_DLLCHARACTERISTICS_NO_SEH = 0x0400,

            /// <summary>
            /// Do not bind the image.
            /// </summary>
            IMAGE_DLLCHARACTERISTICS_NO_BIND = 0x0800,

            /// <summary>
            /// Reserved.
            /// </summary>
            Reserved5 = 0x1000,

            /// <summary>
            /// A WDM driver.
            /// </summary>
            IMAGE_DLLCHARACTERISTICS_WDM_DRIVER = 0x2000,

            /// <summary>
            /// Reserved.
            /// </summary>
            Reserved6 = 0x4000,

            /// <summary>
            /// The image is terminal server aware.
            /// </summary>
            IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE = 0x8000,
        }
    }
}
