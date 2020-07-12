// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="MEDIA_TYPE"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Represents the various forms of device media.
        /// </summary>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-media_type"/>
        public enum MEDIA_TYPE
        {
            /// <summary>
            /// Format is unknown
            /// </summary>
            Unknown,

            /// <summary>
            /// A 5.25" floppy, with 1.2MB and 512 bytes/sector.
            /// </summary>
            F5_1Pt2_512,

            /// <summary>
            /// A 3.5" floppy, with 1.44MB and 512 bytes/sector.
            /// </summary>
            F3_1Pt44_512,

            /// <summary>
            /// A 3.5" floppy, with 2.88MB and 512 bytes/sector.
            /// </summary>
            F3_2Pt88_512,

            /// <summary>
            /// A 3.5" floppy, with 20.8MB and 512 bytes/sector.
            /// </summary>
            F3_20Pt8_512,

            /// <summary>
            /// A 3.5" floppy, with 720KB and 512 bytes/sector.
            /// </summary>
            F3_720_512,

            /// <summary>
            /// A 5.25" floppy, with 360KB and 512 bytes/sector.
            /// </summary>
            F5_360_512,

            /// <summary>
            /// A 5.25" floppy, with 320KB and 512 bytes/sector.
            /// </summary>
            F5_320_512,

            /// <summary>
            /// A 5.25" floppy, with 320KB and 1024 bytes/sector.
            /// </summary>
            F5_320_1024,

            /// <summary>
            /// A 5.25" floppy, with 180KB and 512 bytes/sector.
            /// </summary>
            F5_180_512,

            /// <summary>
            /// A 5.25" floppy, with 160KB and 512 bytes/sector.
            /// </summary>
            F5_160_512,

            /// <summary>
            /// Removable media other than floppy.
            /// </summary>
            RemovableMedia,

            /// <summary>
            /// Fixed hard disk media.
            /// </summary>
            FixedMedia,

            /// <summary>
            /// A 3.5" floppy, with 120MB and 512 bytes/sector.
            /// </summary>
            F3_120M_512,

            /// <summary>
            /// A 3.5" floppy, with 640KB and 512 bytes/sector.
            /// </summary>
            F3_640_512,

            /// <summary>
            /// A 5.25" floppy, with 640KB and 512 bytes/sector.
            /// </summary>
            F5_640_512,

            /// <summary>
            /// A 5.25" floppy, with 720KB and 512 bytes/sector.
            /// </summary>
            F5_720_512,

            /// <summary>
            /// A 3.5" floppy, with 1.2MB and 512 bytes/sector.
            /// </summary>
            F3_1Pt2_512,

            /// <summary>
            /// A 3.5" floppy, with 1.23MB and 1024 bytes/sector.
            /// </summary>
            F3_1Pt23_1024,

            /// <summary>
            /// A 5.25" floppy, with 1.23MB and 1024 bytes/sector.
            /// </summary>
            F5_1Pt23_1024,

            /// <summary>
            /// A 3.5" floppy, with 128MB and 512 bytes/sector.
            /// </summary>
            F3_128Mb_512,

            /// <summary>
            /// A 3.5" floppy, with 230MB and 512 bytes/sector.
            /// </summary>
            F3_230Mb_512,

            /// <summary>
            /// An 8" floppy, with 256KB and 128 bytes/sector.
            /// </summary>
            F8_256_128,

            /// <summary>
            /// A 3.5" floppy, with 200MB and 512 bytes/sector. (HiFD).
            /// </summary>
            F3_200Mb_512,

            /// <summary>
            /// A 3.5" floppy, with 240MB and 512 bytes/sector. (HiFD).
            /// </summary>
            F3_240M_512,

            /// <summary>
            /// A 3.5" floppy, with 32MB and 512 bytes/sector.
            /// </summary>
            F3_32M_512,
        }
    }
}
