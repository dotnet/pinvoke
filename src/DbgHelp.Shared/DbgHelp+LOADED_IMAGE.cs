// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="LOADED_IMAGE"/> nested type.
    /// </content>
    public static partial class DbgHelp
    {
        /// <summary>
        /// Contains information about the loaded image.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct LOADED_IMAGE
        {
            /// <summary>
            /// The file name of the mapped file.
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string ModuleName;

            /// <summary>
            /// A handle to the mapped file.
            /// </summary>
            public IntPtr hFile;

            /// <summary>
            /// The base address of the mapped file.
            /// </summary>
            public byte* MappedAddress;

            /// <summary>
            /// A pointer to an IMAGE_NT_HEADERS structure.
            /// </summary>
            public IMAGE_NT_HEADERS* FileHeader;

            /// <summary>
            /// A pointer to an IMAGE_SECTION_HEADER structure.
            /// </summary>
            public IMAGE_SECTION_HEADER* LastRvaSection;

            /// <summary>
            /// The number of COFF section headers.
            /// </summary>
            public int NumberOfSections;

            /// <summary>
            /// A pointer to an IMAGE_SECTION_HEADER structure.
            /// </summary>
            public IMAGE_SECTION_HEADER* Sections;

            /// <summary>
            /// The image characteristics value.
            /// </summary>
            public Characteristics Characteristics;

            /// <summary>
            /// If the image is a kernel mode executable image, this value is TRUE.
            /// </summary>
            [MarshalAs(UnmanagedType.Bool)]
            public bool fSystemImage;

            /// <summary>
            /// If the image is a 16-bit executable image, this value is TRUE.
            /// </summary>
            [MarshalAs(UnmanagedType.Bool)]
            public bool fDOSImage;

            /// <summary>
            /// If the image is read-only, this value is TRUE.
            /// Prior to Windows Vista:  This member is not included in the structure.
            /// </summary>
            [MarshalAs(UnmanagedType.Bool)]
            public bool fReadOnly;

            /// <summary>
            /// The version string.
            /// Prior to Windows Vista:  This member is not included in the structure.
            /// </summary>
            public byte Version;

            /// <summary>
            /// The list of loaded images.
            /// </summary>
            public LIST_ENTRY Links;

            /// <summary>
            /// The size of the image, in bytes.
            /// </summary>
            public int SizeOfImage;
        }
    }
}
