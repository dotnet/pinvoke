// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Represents the optional header format.
    /// </summary>
    /// <remarks>
    /// <para>The <see cref="UIntPtr"/> fields are typed such so that their size in memory
    /// changes according to the bitness of the process, as it must be.
    /// This allows this one struct to play the role of both IMAGE_OPTIONAL_HEADER32
    /// and IMAGE_OPTIONAL_HEADER64 from native code.
    /// </para>
    /// <para>The number of directories is not fixed. Check the NumberOfRvaAndSizes member before looking for a specific directory.</para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe partial struct IMAGE_OPTIONAL_HEADER
    {
        /// <summary>
        /// The state of the image file.
        /// </summary>
        public MagicType Magic;

        /// <summary>
        /// The major version number of the linker.
        /// </summary>
        public byte MajorLinkerVersion;

        /// <summary>
        /// The minor version number of the linker.
        /// </summary>
        public byte MinorLinkerVersion;

        /// <summary>
        /// The size of the code section, in bytes, or the sum of all such sections if there are multiple code sections.
        /// </summary>
        public uint SizeOfCode;

        /// <summary>
        /// The size of the initialized data section, in bytes, or the sum of all such sections if there are multiple initialized data sections.
        /// </summary>
        public uint SizeOfInitializedData;

        /// <summary>
        /// The size of the uninitialized data section, in bytes, or the sum of all such sections if there are multiple uninitialized data sections.
        /// </summary>
        public uint SizeOfUninitializedData;

        /// <summary>
        /// A pointer to the entry point function, relative to the image base address. For executable files, this is the starting address. For device drivers, this is the address of the initialization function. The entry point function is optional for DLLs. When no entry point is present, this member is zero.
        /// </summary>
        public uint AddressOfEntryPoint;

        /// <summary>
        /// A pointer to the beginning of the code section, relative to the image base.
        /// </summary>
        public uint BaseOfCode;

        /// <summary>
        /// A pointer to the beginning of the data section, relative to the image base.
        /// </summary>
        public uint BaseOfData;

        /// <summary>
        /// The preferred address of the first byte of the image when it is loaded in memory. This value is a multiple of 64K bytes. The default value for DLLs is 0x10000000. The default value for applications is 0x00400000, except on Windows CE where it is 0x00010000.
        /// </summary>
        public UIntPtr ImageBase;

        /// <summary>
        /// The alignment of sections loaded in memory, in bytes. This value must be greater than or equal to the FileAlignment member. The default value is the page size for the system.
        /// </summary>
        public uint SectionAlignment;

        /// <summary>
        /// The alignment of the raw data of sections in the image file, in bytes. The value should be a power of 2 between 512 and 64K (inclusive). The default is 512. If the SectionAlignment member is less than the system page size, this member must be the same as SectionAlignment.
        /// </summary>
        public uint FileAlignment;

        /// <summary>
        /// The major version number of the required operating system.
        /// </summary>
        public ushort MajorOperatingSystemVersion;

        /// <summary>
        /// The minor version number of the required operating system.
        /// </summary>
        public ushort MinorOperatingSystemVersion;

        /// <summary>
        /// The major version number of the image.
        /// </summary>
        public ushort MajorImageVersion;

        /// <summary>
        /// The minor version number of the image.
        /// </summary>
        public ushort MinorImageVersion;

        /// <summary>
        /// The major version number of the subsystem.
        /// </summary>
        public ushort MajorSubsystemVersion;

        /// <summary>
        /// The minor version number of the subsystem.
        /// </summary>
        public ushort MinorSubsystemVersion;

        /// <summary>
        /// This member is reserved and must be 0.
        /// </summary>
        public uint Win32VersionValue;

        /// <summary>
        /// The size of the image, in bytes, including all headers. Must be a multiple of SectionAlignment.
        /// </summary>
        public uint SizeOfImage;

        /// <summary>
        /// The combined size of the following items, rounded to a multiple of the value specified in the FileAlignment member.
        /// <list type="bullet">
        /// <item>e_lfanew member of IMAGE_DOS_HEADER</item>
        /// <item>4 byte signature</item>
        /// <item>size of IMAGE_FILE_HEADER</item>
        /// <item>size of optional header</item>
        /// <item>size of all section headers</item>
        /// </list>
        /// </summary>
        public uint SizeOfHeaders;

        /// <summary>
        /// The image file checksum. The following files are validated at load time: all drivers, any DLL loaded at boot time, and any DLL loaded into a critical system process.
        /// </summary>
        public uint CheckSum;

        /// <summary>
        /// The subsystem required to run this image.
        /// </summary>
        public SubsystemType Subsystem;

        /// <summary>
        /// The DLL characteristics of the image.
        /// </summary>
        public DllCharacteristicsType DllCharacteristics;

        /// <summary>
        /// The number of bytes to reserve for the stack. Only the memory specified by the <see cref="SizeOfStackCommit"/> member is committed at load time; the rest is made available one page at a time until this reserve size is reached.
        /// </summary>
        public UIntPtr SizeOfStackReserve;

        /// <summary>
        /// The number of bytes to commit for the stack.
        /// </summary>
        public UIntPtr SizeOfStackCommit;

        /// <summary>
        /// The number of bytes to reserve for the local heap. Only the memory specified by the <see cref="SizeOfHeapCommit"/> member is committed at load time; the rest is made available one page at a time until this reserve size is reached.
        /// </summary>
        public UIntPtr SizeOfHeapReserve;

        /// <summary>
        /// The number of bytes to commit for the local heap.
        /// </summary>
        public UIntPtr SizeOfHeapCommit;

        /// <summary>
        /// This member is obsolete.
        /// </summary>
        [Obsolete]
        public uint LoaderFlags;

        /// <summary>
        /// The number of directory entries in the remainder of the optional header. Each entry describes a location and size.
        /// </summary>
        public uint NumberOfRvaAndSizes;

        /// <summary>
        /// A pointer to the first <see cref="IMAGE_DATA_DIRECTORY"/> structure in the data directory.
        /// </summary>
        public IMAGE_OPTIONAL_HEADER_DIRECTORIES DataDirectory;
    }
}
