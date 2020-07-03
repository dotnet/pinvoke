// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;

    /// <content>
    /// Contains the <see cref="SP_DRVINFO_DETAIL_DATA" /> nested type.
    /// </content>
    public partial class SetupApi
    {
        /// <summary>
        /// Contains detailed information about a particular driver information structure.
        /// </summary>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_drvinfo_detail_data_w"/>
        public unsafe struct SP_DRVINFO_DETAIL_DATA
        {
            /// <summary>
            /// The size, in bytes, of the <see cref="SP_DRVINFO_DETAIL_DATA"/> structure.
            /// </summary>
            public int cbSize;

            /// <summary>
            /// Date of the INF file for this driver.
            /// </summary>
            public Kernel32.FILETIME InfDate;

            /// <summary>
            /// The offset, in characters, from the beginning of the <see cref="HardwareID"/> buffer where the CompatIDs list begins.
            /// </summary>
            /// <remarks>
            /// This value can also be used to determine whether there is a hardware ID that precedes the CompatIDs list.
            /// If this value is greater than 1, the first string in the HardwareID buffer is the hardware ID.
            /// If this value is less than or equal to 1, there is no hardware ID.
            /// </remarks>
            public int CompatIDsOffset;

            /// <summary>
            /// The length, in characters, of the CompatIDs list starting at offset <see cref="CompatIDsOffset"/> from the beginning of the <see cref="HardwareID"/> buffer.
            /// </summary>
            /// <remarks>
            /// If <see cref="CompatIDsLength"/> is nonzero, the CompatIDs list contains one or more <see langword="null"/>-terminated strings with an additional
            /// <see langword="null"/> character at the end of the list.
            /// If <see cref="CompatIDsLength"/> is zero, the CompatIDs list is empty. In that case, there is no additional <see langword="null"/> character at the end of the list.
            /// </remarks>
            public int CompatIDsLength;

            /// <summary>
            /// Reserved. For internal use only.
            /// </summary>
            public UIntPtr Reserved;

            /// <summary>
            /// A <see langword="null"/>-terminated string that contains the name of the INF DDInstall section for this driver.
            /// This must be the basic DDInstall section name, such as InstallSec, without any OS/architecture-specific extensions.
            /// </summary>
            public fixed char SectionName[SetupApi.LINE_LEN];

            /// <summary>
            /// A <see langword="null"/>-terminated string that contains the full-qualified name of the INF file for this driver.
            /// </summary>
            public fixed char InfFileName[Kernel32.MAX_PATH];

            /// <summary>
            /// A <see langword="null"/>-terminated string that describes the driver.
            /// </summary>
            public fixed char DrvDescription[SetupApi.LINE_LEN];

            /// <summary>
            /// A buffer that contains a list of IDs (a single hardware ID followed by a list of compatible IDs).
            /// These IDs correspond to the hardware ID and compatible IDs in the INF Models section.
            /// </summary>
            /// <remarks>
            /// Each ID in the list is a <see langword="null"/>-terminated string.
            /// If the hardware ID exists (that is, if <see cref="CompatIDsOffset"/> is greater than one), this single <see langword="null"/>-terminated
            /// string is found at the beginning of the buffer.
            /// If the CompatIDs list is not empty (that is, if <see cref="CompatIDsLength"/> is not zero), the CompatIDs list starts at offset
            /// <see cref="CompatIDsOffset"/> from the beginning of this buffer, and is terminated with an additional <see langword="null"/>
            /// character at the end of the list.
            /// </remarks>
            public fixed char HardwareID[1];

            /// <summary>
            /// Initializes a new instance of the <see cref="SP_DRVINFO_DETAIL_DATA" /> struct
            /// with <see cref="cbSize" /> set to the correct value.
            /// </summary>
            /// <returns>An instance of <see cref="SP_DRVINFO_DETAIL_DATA"/>.</returns>
            /// <devremarks>
            /// The numbers are hard-coded because due to alignment issues, .NET reports 2 bytes more than the Win32 API is expecting and it won't accept a struct that is too large.
            /// </devremarks>
            public static SP_DRVINFO_DETAIL_DATA Create() => new SP_DRVINFO_DETAIL_DATA { cbSize = IntPtr.Size == 4 ? 0x622 : 0x630 };
        }
    }
}
