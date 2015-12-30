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
    public unsafe struct IMAGE_OPTIONAL_HEADER
    {
        public ushort Magic;
        public byte MajorLinkerVersion;
        public byte MinorLinkerVersion;
        public uint SizeOfCode;
        public uint SizeOfInitializedData;
        public uint SizeOfUninitializedData;
        public uint AddressOfEntryPoint;
        public uint BaseOfCode;
        public uint BaseOfData;
        public UIntPtr ImageBase;
        public uint SectionAlignment;
        public uint FileAlignment;
        public ushort MajorOperatingSystemVersion;
        public ushort MinorOperatingSystemVersion;
        public ushort MajorImageVersion;
        public ushort MinorImageVersion;
        public ushort MajorSubsystemVersion;
        public ushort MinorSubsystemVersion;
        public uint Win32VersionValue;
        public uint SizeOfImage;
        public uint SizeOfHeaders;
        public uint CheckSum;
        public ushort Subsystem;
        public ushort DllCharacteristics;
        public UIntPtr SizeOfStackReserve;
        public UIntPtr SizeOfStackCommit;
        public UIntPtr SizeOfHeapReserve;
        public UIntPtr SizeOfHeapCommit;
        public uint LoaderFlags;
        public uint NumberOfRvaAndSizes;
        public IMAGE_OPTIONAL_HEADER_DIRECTORIES DataDirectory;
    }
}
