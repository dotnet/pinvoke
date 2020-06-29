// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <content>
    /// Contains the <see cref="DeviceSetupClass"/> nested type.
    /// </content>
    public partial class SetupApi
    {
        /// <summary>
        /// Defines following classes and GUIDs are defined by the operating system.
        /// </summary>
        /// <seealso href="https://docs.microsoft.com/en-us/windows-hardware/drivers/install/system-defined-device-setup-classes-available-to-vendors"/>
        public static class DeviceSetupClass
        {
            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes battery devices and UPS devices.
            /// </summary>
            public static Guid Battery { get; } = new Guid("{72631e54-78a4-11d0-bcf7-00aa00b7b32a}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes all biometric-based personal identification devices.
            /// </summary>
            public static Guid Biometric { get; } = new Guid("{53D29EF7-377C-4D14-864B-EB3A85769359}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes all Bluetooth devices.
            /// </summary>
            public static Guid Bluetooth { get; } = new Guid("{e0cbf06c-cd8b-4647-bb8a-263b43f0f974}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes universal camera drivers.
            /// </summary>
            public static Guid Camera { get; } = new Guid("{ca3e7ab9-b4c3-4ae6-8251-579ef933890f}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes CD-ROM drives, including SCSI CD-ROM drives.
            /// By default, the system's CD-ROM class installer also installs a system-supplied CD audio driver and CD-ROM changer driver as Plug and Play filters.
            /// </summary>
            public static Guid CDROM { get; } = new Guid("{4d36e965-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes hard disk drives. See also the HDC and SCSIAdapter classes.
            /// </summary>
            public static Guid DiskDrive { get; } = new Guid("{4d36e967-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes video adapters. Drivers for this class include display drivers and video miniport drivers.
            /// </summary>
            public static Guid Display { get; } = new Guid("{4d36e968-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class whichincludes all devices requiring customizations. For more details, see Using an Extension INF File.
            /// </summary>
            public static Guid Inf { get; } = new Guid("{e2f84ce7-8efa-411c-aa69-97454ca4cb57}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes floppy disk drive controllers.
            /// </summary>
            public static Guid Fdc { get; } = new Guid("{4d36e969-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes floppy disk drives.
            /// </summary>
            public static Guid FloppyDisk { get; } = new Guid("{4d36e980-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes hard disk controllers, including ATA/ATAPI controllers but not SCSI and RAID disk controllers.
            /// </summary>
            public static Guid Hdc { get; } = new Guid("{4d36e96a-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes interactive input devices that are operated by the system-supplied Human Interface Devices (HID) class driver.
            /// This includes USB devices that comply with the USB HID Standard and non-USB devices that use a HID minidriver.
            /// For more information, see HIDClass Device Setup Class. (See also the Keyboard or Mouse classes later in this list.)
            /// </summary>
            public static Guid HidClass { get; } = new Guid("{745a17a0-74d3-11d0-b6fe-00a0c90f57da}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes devices that control the operation of multifunction IEEE 1284.4 peripheral devices.
            /// </summary>
            public static Guid Dot4 { get; } = new Guid("{48721b56-6795-11d2-b1a8-0080c72e74a2}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes Dot4 print functions. A Dot4 print function is a function on a Dot4 device and has a single child device, which is a member of the Printer device setup class.
            /// </summary>
            public static Guid Dot4Print { get; } = new Guid("{49ce6ac8-6f86-11d2-b1e5-0080c72e74a2}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes IEEE 1394 devices that support the IEC-61883 protocol device class.
            /// The 61883 component includes the 61883.sys protocol driver that transmits various audio and video data streams over the 1394 bus.
            /// These currently include standard/high/low quality DV, MPEG2, DSS, and Audio.These data streams are defined by the IEC-61883 specifications.
            /// </summary>
            public static Guid Iec61883 { get; } = new Guid("{7ebefbc0-3200-11d2-b4c2-00a0C9697d07}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes IEEE 1394 devices that support the AVC protocol device class.
            /// </summary>
            public static Guid Avc { get; } = new Guid("{c06ff265-ae09-48f0-812c-16753d7cba83}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes IEEE 1394 devices that support the SBP2 protocol device class.
            /// </summary>
            public static Guid Sbp2 { get; } = new Guid("{d48179be-ec20-11d1-b6b8-00c04fa372a7}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes 1394 host controllers connected on a PCI bus, but not 1394 peripherals. Drivers for this class are system-supplied.
            /// </summary>
            public static Guid Ieee1394 { get; } = new Guid("{6bdd1fc1-810f-11d0-bec7-08002be2092f}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes still-image capture devices, digital cameras, and scanners.
            /// </summary>
            public static Guid Image { get; } = new Guid("{6bdd1fc6-810f-11d0-bec7-08002be2092f}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes infrared devices. Drivers for this class include Serial-IR and Fast-IR NDIS miniports, but see also the Network Adapter class for other NDIS network adapter miniports.
            /// </summary>
            public static Guid Infrared { get; } = new Guid("{6bdd1fc5-810f-11d0-bec7-08002be2092f}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes all keyboards. That is, it must also be specified in the (secondary) INF for an enumerated child HID keyboard device.
            /// </summary>
            public static Guid Keyboard { get; } = new Guid("{4d36e96b-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes SCSI media changer devices.
            /// </summary>
            public static Guid MediumChanger { get; } = new Guid("{ce5939ae-ebde-11d0-b181-0000f8753ec4}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes memory devices, such as flash memory cards.
            /// </summary>
            public static Guid Mtd { get; } = new Guid("{4d36e970-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes modem devices or a software modem.
            /// These devices split the functionality between the modem device and the device driver. For more information about modem INF files and Microsoft Windows Driver Model (WDM) modem devices, see Overview of Modem INF Files and Adding WDM Modem Support.
            /// </summary>
            public static Guid Modem { get; } = new Guid("{4d36e96d-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes display monitors.
            /// An INF for a device of this class installs no device driver(s), but instead specifies the features of a particular monitor to be stored in the registry for use by drivers of video adapters.
            /// Monitors are enumerated as the child devices of display adapters.
            /// </summary>
            public static Guid Monitor { get; } = new Guid("{4d36e96e-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes all mouse devices and other kinds of pointing devices, such as trackballs. That is, this class must also be specified in the (secondary) INF for an enumerated child HID mouse device.
            /// </summary>
            public static Guid Mouse { get; } = new Guid("{4d36e96f-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes combo cards, such as a PCMCIA modem and netcard adapter.
            /// The driver for such a Plug and Play multifunction device is installed under this class and enumerates the modem and netcard separately as its child devices.
            /// </summary>
            public static Guid Multifunction { get; } = new Guid("{4d36e971-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes Audio and DVD multimedia devices, joystick ports, and full-motion video capture devices.
            /// </summary>
            public static Guid Media { get; } = new Guid("{4d36e96c-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes intelligent multiport serial cards, but not peripheral devices that connect to its ports.
            /// It does not include unintelligent (16550-type) multiport serial controllers or single-port serial controllers (see the Ports class).
            /// </summary>
            public static Guid MultiportSerial { get; } = new Guid("{50906cb8-ba12-11d1-bf5d-0000f805f530}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which consists of network adapter drivers.
            /// These drivers must either call NdisMRegisterMiniportDriver or NetAdapterCreate. Drivers that do not use NDIS or NetAdapter should use a different setup class.
            /// </summary>
            public static Guid Net { get; } = new Guid("{4d36e972-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes network and/or print providers.
            /// <see cref="NetClient"/> components are deprecated in Windows 8.1, Windows Server 2012 R2, and later.
            /// </summary>
            public static Guid NetClient { get; } = new Guid("{4d36e973-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes network services, such as redirectors and servers.
            /// </summary>
            public static Guid NetService { get; } = new Guid("{4d36e974-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes NDIS protocols CoNDIS stand-alone call managers, and CoNDIS clients, in addition to higher level drivers in transport stacks.
            /// </summary>
            public static Guid NetTrans { get; } = new Guid("{4d36e975-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes devices that accelerate secure socket layer (SSL) cryptographic processing.
            /// </summary>
            public static Guid SecurityAccelerator { get; } = new Guid("{268c95a1-edfe-11d3-95c3-0010dc4050a5}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes PCMCIA and CardBus host controllers, but not PCMCIA or CardBus peripherals. Drivers for this class are system-supplied.
            /// </summary>
            public static Guid Pcmcia { get; } = new Guid("{4d36e977-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes serial and parallel port devices. See also the <see cref="MultiportSerial"/> class.
            /// </summary>
            public static Guid Ports { get; } = new Guid("{4d36e978-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes printers.
            /// </summary>
            public static Guid Printer { get; } = new Guid("{4d36e979-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes SCSI/1394-enumerated printers. Drivers for this class provide printer communication for a specific bus.
            /// </summary>
            public static Guid PnpPrinters { get; } = new Guid("{4658ee7e-f050-11d1-b6bd-00c04fa372a7}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes processor types.
            /// </summary>
            public static Guid Processor { get; } = new Guid("{50127dc3-0f36-415e-a6cc-4cb3be910b65}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes SCSI HBAs (Host Bus Adapters) and disk-array controllers.
            /// </summary>
            public static Guid SCSIAdapter { get; } = new Guid("{4d36e97b-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes sensor and location devices, such as GPS devices.
            /// </summary>
            public static Guid Sensor { get; } = new Guid(" {5175d334-c371-4806-b3ba-71fd53c9258d}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes smart card readers.
            /// </summary>
            public static Guid SmartCardReader { get; } = new Guid("{50dd5230-ba8a-11d1-bf5d-0000f805f530}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes virtual child device to encapsulate software components. For more details, see Adding Software Components with an INF file.
            /// </summary>
            public static Guid SoftwareComponent { get; } = new Guid("{5c4c3332-344d-483c-8739-259e934c9cc8}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes storage volumes as defined by the system-supplied logical volume manager and class drivers that create device objects to represent storage volumes, such as the system disk class driver.
            /// </summary>
            public static Guid Volume { get; } = new Guid("{71a27cdd-812a-11d0-bec7-08002be2092f}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes HALs, system buses, system bridges, the system ACPI driver, and the system volume manager driver.
            /// </summary>
            public static Guid System { get; } = new Guid("{4d36e97d-e325-11ce-bfc1-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes tape drives, including all tape miniclass drivers.
            /// </summary>
            public static Guid TapeDrive { get; } = new Guid("{6d807884-7d21-11cf-801c-08002be10318}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes all USB devices that do not belong to another class. This class is not used for USB host controllers and hubs.
            /// </summary>
            public static Guid UsbDevice { get; } = new Guid("{88BAE032-5A81-49f0-BC3D-A4FF138216D6}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes Windows CE ActiveSync devices.
            /// The WCEUSBS setup class supports communication between a personal computer and a device that is compatible with the Windows CE ActiveSync driver (generally, PocketPC devices) over USB.
            /// </summary>
            public static Guid WCEUSBS { get; } = new Guid("{25dbce51-6c8f-4a72-8a6d-b54c2b4fc835}");

            /// <summary>
            /// Gets the <see cref="Guid"/> for the device setup class which includes Windows Portable Devices (WPD) devices.
            /// </summary>
            public static Guid Wpd { get; } = new Guid("{eec5ad98-8080-425f-922a-dabf3de3f69a}");

            /// <summary>
            ///  Gets the <see cref="Guid"/> for the device setup class which includes all devices that are compatible with Windows SideShow.
            /// </summary>
            public static Guid SideShow { get; } = new Guid("{997b5d8d-c442-4f2e-baf3-9c8e671e9e21}");
        }
    }
}
