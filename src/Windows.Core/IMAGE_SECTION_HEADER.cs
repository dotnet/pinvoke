// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Represents the image section header format.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe partial struct IMAGE_SECTION_HEADER
    {
        /// <summary>
        /// An 8-byte, null-padded UTF-8 string. There is no terminating null character if the string is exactly eight characters long. For longer names, this member contains a forward slash (/) followed by an ASCII representation of a decimal number that is an offset into the string table. Executable images do not use a string table and do not support section names longer than eight characters.
        /// </summary>
        public fixed byte Name[Constants.IMAGE_SIZEOF_SHORT_NAME];

        /// <summary>
        /// EITHER:
        /// <list type="bullet">
        /// <item>The file address.</item>
        /// <item>The total size of the section when loaded into memory, in bytes. If this value is greater than the <see cref="SizeOfRawData"/> member, the section is filled with zeroes. This field is valid only for executable images and should be set to 0 for object files.</item>
        /// </list>
        /// </summary>
        public uint PhysicalAddressOrVirtualSize;

        /// <summary>
        /// The address of the first byte of the section when loaded into memory, relative to the image base. For object files, this is the address of the first byte before relocation is applied.
        /// </summary>
        public uint VirtualAddress;

        /// <summary>
        /// The size of the initialized data on disk, in bytes. This value must be a multiple of the <see cref="IMAGE_OPTIONAL_HEADER.FileAlignment"/> member of the <see cref="IMAGE_OPTIONAL_HEADER"/> structure. If this value is less than the VirtualSize member, the remainder of the section is filled with zeroes. If the section contains only uninitialized data, the member is zero.
        /// </summary>
        public uint SizeOfRawData;

        /// <summary>
        /// A file pointer to the first page within the COFF file. This value must be a multiple of the <see cref="IMAGE_OPTIONAL_HEADER.FileAlignment"/> member of the <see cref="IMAGE_OPTIONAL_HEADER "/> structure. If a section contains only uninitialized data, set this member is zero.
        /// </summary>
        public uint PointerToRawData;

        /// <summary>
        /// A file pointer to the beginning of the relocation entries for the section.If there are no relocations, this value is zero.
        /// </summary>
        public uint PointerToRelocations;

        /// <summary>
        /// A file pointer to the beginning of the line-number entries for the section. If there are no COFF line numbers, this value is zero.
        /// </summary>
        public uint PointerToLinenumbers;

        /// <summary>
        /// The number of relocation entries for the section. This value is zero for executable images.
        /// </summary>
        public ushort NumberOfRelocations;

        /// <summary>
        /// The number of line-number entries for the section.
        /// </summary>
        public ushort NumberOfLinenumbers;

        /// <summary>
        /// The characteristics of the image.
        /// </summary>
        public CharacteristicsType Characteristics;
    }
}
