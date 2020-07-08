// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="DISK_GEOMETRY"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Describes the geometry of disk devices and media.
        /// </summary>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-disk_geometry"/>
        public struct DISK_GEOMETRY
        {
            /// <summary>
            /// The number of cylinders.
            /// </summary>
            public long Cylinders;

            /// <summary>
            /// The type of media.
            /// </summary>
            public MEDIA_TYPE MediaType;

            /// <summary>
            /// The number of tracks per cylinder.
            /// </summary>
            public uint TracksPerCylinder;

            /// <summary>
            /// The number of sectors per track.
            /// </summary>
            public uint SectorsPerTrack;

            /// <summary>
            /// The number of bytes per sector.
            /// </summary>
            public uint BytesPerSector;
        }
    }
}
