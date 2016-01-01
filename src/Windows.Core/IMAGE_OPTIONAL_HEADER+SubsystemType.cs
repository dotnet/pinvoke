// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="SubsystemType"/> nested type.
    /// </content>
    public partial struct IMAGE_OPTIONAL_HEADER
    {
        /// <summary>
        /// Describes expected values for the <see cref="Subsystem"/> field.
        /// </summary>
        public enum SubsystemType : ushort
        {
            /// <summary>
            /// Unknown subsystem.
            /// </summary>
            IMAGE_SUBSYSTEM_UNKNOWN = 0,

            /// <summary>
            /// No subsystem required (device drivers and native system processes).
            /// </summary>
            IMAGE_SUBSYSTEM_NATIVE = 1,

            /// <summary>
            /// Windows graphical user interface (GUI) subsystem.
            /// </summary>
            IMAGE_SUBSYSTEM_WINDOWS_GUI = 2,

            /// <summary>
            /// Windows character-mode user interface (CUI) subsystem.
            /// </summary>
            IMAGE_SUBSYSTEM_WINDOWS_CUI = 3,

            /// <summary>
            /// OS/2 CUI subsystem.
            /// </summary>
            IMAGE_SUBSYSTEM_OS2_CUI = 5,

            /// <summary>
            /// POSIX CUI subsystem.
            /// </summary>
            IMAGE_SUBSYSTEM_POSIX_CUI = 7,

            /// <summary>
            /// Windows CE system.
            /// </summary>
            IMAGE_SUBSYSTEM_WINDOWS_CE_GUI = 9,

            /// <summary>
            /// Extensible Firmware Interface (EFI) application.
            /// </summary>
            IMAGE_SUBSYSTEM_EFI_APPLICATION = 10,

            /// <summary>
            /// EFI driver with boot services.
            /// </summary>
            IMAGE_SUBSYSTEM_EFI_BOOT_SERVICE_DRIVER = 11,

            /// <summary>
            /// EFI driver with run-time services.
            /// </summary>
            IMAGE_SUBSYSTEM_EFI_RUNTIME_DRIVER = 12,

            /// <summary>
            /// EFI ROM image.
            /// </summary>
            IMAGE_SUBSYSTEM_EFI_ROM = 13,

            /// <summary>
            /// Xbox system.
            /// </summary>
            IMAGE_SUBSYSTEM_XBOX = 14,

            /// <summary>
            /// Boot application.
            /// </summary>
            IMAGE_SUBSYSTEM_WINDOWS_BOOT_APPLICATION = 16,
        }
    }
}