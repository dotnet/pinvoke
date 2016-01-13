// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

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
            FACILITY_VOLSNAP = 0x50 << FacilityShift,
            FACILITY_VOLMGR = 0x38 << FacilityShift,
            FACILITY_VIRTUALIZATION = 0x37 << FacilityShift,
            FACILITY_VIDEO = 0x1B << FacilityShift,
            FACILITY_USB_ERROR_CODE = 0x10 << FacilityShift,
            FACILITY_TRANSACTION = 0x19 << FacilityShift,
            FACILITY_TPM = 0x29 << FacilityShift,
            FACILITY_TERMINAL_SERVER = 0xA << FacilityShift,
            FACILITY_SXS_ERROR_CODE = 0x15 << FacilityShift,
            FACILITY_NTSSPI = 0x9 << FacilityShift,
            FACILITY_SPACES = 0xE7 << FacilityShift,
            FACILITY_SHARED_VHDX = 0x5C << FacilityShift,
            FACILITY_SECUREBOOT = 0x43 << FacilityShift,
            FACILITY_SDBUS = 0x51 << FacilityShift,
            FACILITY_RPC_STUBS = 0x3 << FacilityShift,
            FACILITY_RPC_RUNTIME = 0x2 << FacilityShift,
            FACILITY_RESUME_KEY_FILTER = 0x40 << FacilityShift,
            FACILITY_RDBSS = 0x41 << FacilityShift,
            FACILITY_NTWIN32 = 0x7 << FacilityShift,
            FACILITY_WIN32K_NTUSER = 0x3E << FacilityShift,
            FACILITY_WIN32K_NTGDI = 0x3F << FacilityShift,
            FACILITY_NDIS_ERROR_CODE = 0x23 << FacilityShift,
            FACILTIY_MUI_ERROR_CODE = 0xB << FacilityShift, // Yes! the typo in "FACILTIY" is actually in the original ntstatus.h file
            FACILITY_MONITOR = 0x1D << FacilityShift,
            FACILITY_MAXIMUM_VALUE = 0xE8 << FacilityShift,
            FACILITY_IPSEC = 0x36 << FacilityShift,
            FACILITY_IO_ERROR_CODE = 0x4 << FacilityShift,
            FACILITY_INTERIX = 0x99 << FacilityShift,
            FACILITY_HYPERVISOR = 0x35 << FacilityShift,
            FACILITY_HID_ERROR_CODE = 0x11 << FacilityShift,
            FACILITY_GRAPHICS_KERNEL = 0x1E << FacilityShift,
            FACILITY_FWP_ERROR_CODE = 0x22 << FacilityShift,
            FACILITY_FVE_ERROR_CODE = 0x21 << FacilityShift,
            FACILITY_FIREWIRE_ERROR_CODE = 0x12 << FacilityShift,
            FACILITY_FILTER_MANAGER = 0x1C << FacilityShift,
            FACILITY_DRIVER_FRAMEWORK = 0x20 << FacilityShift,
            FACILITY_DEBUGGER = 0x1 << FacilityShift,
            FACILITY_COMMONLOG = 0x1A << FacilityShift,
            FACILITY_CODCLASS_ERROR_CODE = 0x6 << FacilityShift,
            FACILITY_CLUSTER_ERROR_CODE = 0x13 << FacilityShift,
            FACILITY_NTCERT = 0x8 << FacilityShift,
            FACILITY_BTH_ATT = 0x42 << FacilityShift,
            FACILITY_BCD_ERROR_CODE = 0x39 << FacilityShift,
            FACILITY_AUDIO_KERNEL = 0x44 << FacilityShift,
            FACILITY_ACPI_ERROR_CODE = 0x14 << FacilityShift,
        }
    }
}
