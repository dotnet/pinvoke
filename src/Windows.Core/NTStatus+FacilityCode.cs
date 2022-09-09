// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// The <see cref="FacilityCode"/> nested type.
    /// </content>
    public partial struct NTSTATUS
    {
        /// <summary>
        /// The <see cref="NTSTATUS"/> facility codes.
        /// </summary>
        public enum FacilityCode
        {
            FACILITY_VOLSNAP = 0x50,
            FACILITY_VOLMGR = 0x38,
            FACILITY_VIRTUALIZATION = 0x37,
            FACILITY_VIDEO = 0x1B,
            FACILITY_USB_ERROR_CODE = 0x10,
            FACILITY_TRANSACTION = 0x19,
            FACILITY_TPM = 0x29,
            FACILITY_TERMINAL_SERVER = 0xA,
            FACILITY_SXS_ERROR_CODE = 0x15,
            FACILITY_NTSSPI = 0x9,
            FACILITY_SPACES = 0xE7,
            FACILITY_SHARED_VHDX = 0x5C,
            FACILITY_SECUREBOOT = 0x43,
            FACILITY_SDBUS = 0x51,
            FACILITY_RPC_STUBS = 0x3,
            FACILITY_RPC_RUNTIME = 0x2,
            FACILITY_RESUME_KEY_FILTER = 0x40,
            FACILITY_RDBSS = 0x41,
            FACILITY_NTWIN32 = 0x7,
            FACILITY_WIN32K_NTUSER = 0x3E,
            FACILITY_WIN32K_NTGDI = 0x3F,
            FACILITY_NDIS_ERROR_CODE = 0x23,
            FACILTIY_MUI_ERROR_CODE = 0xB, // Yes! the typo in "FACILTIY" is actually in the original ntstatus.h file
            FACILITY_MONITOR = 0x1D,
            FACILITY_MAXIMUM_VALUE = 0xE8,
            FACILITY_IPSEC = 0x36,
            FACILITY_IO_ERROR_CODE = 0x4,
            FACILITY_INTERIX = 0x99,
            FACILITY_HYPERVISOR = 0x35,
            FACILITY_HID_ERROR_CODE = 0x11,
            FACILITY_GRAPHICS_KERNEL = 0x1E,
            FACILITY_FWP_ERROR_CODE = 0x22,
            FACILITY_FVE_ERROR_CODE = 0x21,
            FACILITY_FIREWIRE_ERROR_CODE = 0x12,
            FACILITY_FILTER_MANAGER = 0x1C,
            FACILITY_DRIVER_FRAMEWORK = 0x20,
            FACILITY_DEBUGGER = 0x1,
            FACILITY_COMMONLOG = 0x1A,
            FACILITY_CODCLASS_ERROR_CODE = 0x6,
            FACILITY_CLUSTER_ERROR_CODE = 0x13,
            FACILITY_NTCERT = 0x8,
            FACILITY_BTH_ATT = 0x42,
            FACILITY_BCD_ERROR_CODE = 0x39,
            FACILITY_AUDIO_KERNEL = 0x44,
            FACILITY_ACPI_ERROR_CODE = 0x14,
        }
    }
}
