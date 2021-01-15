// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics;

    /// <content>
    /// Contains the <see cref="ACCESS_MASK"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// The ACCESS_MASK type is a bitmask that specifies a set of access rights in the access mask of an access control entry.
        /// </summary>
        /// <remarks>
        /// Quite well described here: http://blogs.msdn.com/b/openspecification/archive/2010/04/01/about-the-access-mask-structure.aspx.
        /// </remarks>
        public partial struct ACCESS_MASK : IComparable, IComparable<ACCESS_MASK>, IEquatable<ACCESS_MASK>, IFormattable
        {
            /// <summary>
            /// Bits 28-31.
            /// </summary>
            private const uint GenericRightsMask = 0xf0000000;

            /// <summary>
            /// Bits 24-27.
            /// </summary>
            private const uint SpecialRightsMask = 0x0f000000;

            /// <summary>
            /// Bits 16-23.
            /// </summary>
            private const uint StandardRightsMask = 0x00ff0000;

            /// <summary>
            /// Bits 0-15.
            /// </summary>
            private const uint SpecificRightsMask = 0x0000ffff;

            /// <summary>
            /// Initializes a new instance of the <see cref="ACCESS_MASK"/> struct.
            /// </summary>
            /// <param name="value">The value for the <see cref="ACCESS_MASK"/>.</param>
            public ACCESS_MASK(uint value)
            {
                this.Value = value;
            }

            /// <summary>
            /// The type of access to a file mapping object, which determines the page protection of the pages. This parameter can be one of the following values, or a bitwise OR combination of multiple values where appropriate.
            /// </summary>
            [Flags]
            public enum FileMapRight : uint
            {
                /// <summary>
                /// A read/write view of the file is mapped. The file mapping object must have been created with PAGE_READWRITE or PAGE_EXECUTE_READWRITE protection.
                /// When used with MapViewOfFile, (FILE_MAP_WRITE | FILE_MAP_READ) and FILE_MAP_ALL_ACCESS are equivalent to FILE_MAP_WRITE.
                /// </summary>
                FILE_MAP_WRITE = SectionRight.SECTION_MAP_WRITE,

                /// <summary>
                /// A read-only view of the file is mapped. An attempt to write to the file view results in an access violation.
                /// The file mapping object must have been created with PAGE_READONLY, PAGE_READWRITE, PAGE_EXECUTE_READ, or PAGE_EXECUTE_READWRITE protection.
                /// </summary>
                FILE_MAP_READ = SectionRight.SECTION_MAP_READ,

                /// <summary>
                /// A read/write view of the file is mapped. The file mapping object must have been created with PAGE_READWRITE or PAGE_EXECUTE_READWRITE protection.
                /// When used with the MapViewOfFile function, FILE_MAP_ALL_ACCESS is equivalent to FILE_MAP_WRITE.
                /// </summary>
                FILE_MAP_ALL_ACCESS = SectionRight.SECTION_ALL_ACCESS,

                /// <summary>
                /// An executable view of the file is mapped (mapped memory can be run as code). The file mapping object must have been created with PAGE_EXECUTE_READ, PAGE_EXECUTE_WRITECOPY, or PAGE_EXECUTE_READWRITE protection.
                /// Windows Server 2003 and Windows XP:  This value is available starting with Windows XP with SP2 and Windows Server 2003 with SP1.
                /// </summary>
                FILE_MAP_EXECUTE = SectionRight.SECTION_MAP_EXECUTE_EXPLICIT, // not included in FILE_MAP_ALL_ACCESS

                /// <summary>
                /// A copy-on-write view of the file is mapped. The file mapping object must have been created with PAGE_READONLY, PAGE_READ_EXECUTE, PAGE_WRITECOPY, PAGE_EXECUTE_WRITECOPY, PAGE_READWRITE, or PAGE_EXECUTE_READWRITE protection.
                /// When a process writes to a copy-on-write page, the system copies the original page to a new page that is private to the process. The new page is backed by the paging file. The protection of the new page changes from copy-on-write to read/write.
                /// When copy-on-write access is specified, the system and process commit charge taken is for the entire view because the calling process can potentially write to every page in the view, making all pages private. The contents of the new page are never written back to the original file and are lost when the view is unmapped.
                /// </summary>
                FILE_MAP_COPY = 0x00000001,

                FILE_MAP_RESERVE = 0x80000000,

                /// <summary>
                /// Sets all the locations in the mapped file as invalid targets for Control Flow Guard (CFG). This flag is similar to PAGE_TARGETS_INVALID. Use this flag in combination with the execute access right FILE_MAP_EXECUTE. Any indirect call to locations in those pages will fail CFG checks, and the process will be terminated. The default behavior for executable pages allocated is to be marked valid call targets for CFG.
                /// </summary>
                FILE_MAP_TARGETS_INVALID = 0x40000000,

                /// <summary>
                /// Starting with Windows 10, version 1703, this flag specifies that the view should be mapped using large page support. The size of the view must be a multiple of the size of a large page reported by the GetLargePageMinimum function, and the file-mapping object must have been created using the SEC_LARGE_PAGES option. If you provide a non-null value for lpBaseAddress, then the value must be a multiple of GetLargePageMinimum.
                /// Note: On OS versions before Windows 10, version 1703, the FILE_MAP_LARGE_PAGES flag has no effect. On these releases, the view is automatically mapped using large pages if the section was created with the SEC_LARGE_PAGES flag set.
                /// </summary>
                FILE_MAP_LARGE_PAGES = 0x20000000,
            }

            [Flags]
            public enum GenericRight : uint
            {
                GENERIC_ALL = 0x10000000,
                GENERIC_EXECUTE = 0x20000000,
                GENERIC_WRITE = 0x40000000,
                GENERIC_READ = 0x80000000,
            }

            /// <summary>
            /// Specifies an ACCESS_MASK value that determines the requested access to the object. In addition to the access rights that are defined for all types of objects (see ACCESS_MASK), the caller can specify any of the following access rights, which are specific to section objects.
            /// </summary>
            [Flags]
            public enum SectionRight : uint
            {
                /// <summary>
                /// Query the section object for information about the section. Drivers should set this flag.
                /// </summary>
                SECTION_QUERY = 0x0001,

                /// <summary>
                /// Write views of the section.
                /// </summary>
                SECTION_MAP_WRITE = 0x0002,

                /// <summary>
                /// Read views of the section.
                /// </summary>
                SECTION_MAP_READ = 0x0004,

                /// <summary>
                /// Execute views of the section.
                /// </summary>
                SECTION_MAP_EXECUTE = 0x0008,

                /// <summary>
                /// Dynamically extend the size of the section.
                /// </summary>
                SECTION_EXTEND_SIZE = 0x0010,

                SECTION_MAP_EXECUTE_EXPLICIT = 0x0020, // not included in SECTION_ALL_ACCESS

                /// <summary>
                /// All of the previous flags combined with STANDARD_RIGHTS_REQUIRED.
                /// </summary>
                SECTION_ALL_ACCESS = StandardRight.STANDARD_RIGHTS_REQUIRED | SECTION_QUERY | SECTION_MAP_WRITE | SECTION_MAP_READ | SECTION_MAP_EXECUTE | SECTION_EXTEND_SIZE,
            }

            [Flags]
            public enum SpecialRight : uint
            {
                /// <summary>
                /// It is used to indicate access to a system access control list (SACL). This type of access requires the calling process to have the SE_SECURITY_NAME (Manage auditing and security log) privilege. If this flag is set in the access mask of an audit access ACE (successful or unsuccessful access), the SACL access will be audited.
                /// </summary>
                ACCESS_SYSTEM_SECURITY = 0x01000000,

                /// <summary>
                /// Maximum allowed.
                /// </summary>
                MAXIMUM_ALLOWED = 0x02000000,
            }

            /// <summary>
            /// Contains the object's standard access rights.
            /// </summary>
            [Flags]
            public enum StandardRight : uint
            {
                /// <summary>
                /// Delete access.
                /// </summary>
                DELETE = 0x00010000,

                /// <summary>
                /// Read access to the owner, group, and discretionary access control list (DACL) of the security descriptor.
                /// </summary>
                READ_CONTROL = 0x00020000,

                /// <summary>
                /// Write access to the DACL.
                /// </summary>
                WRITE_DAC = 0x00040000,

                /// <summary>
                /// Write access to owner.
                /// </summary>
                WRITE_OWNER = 0x00080000,

                /// <summary>
                /// Synchronize access.
                /// </summary>
                SYNCHRONIZE = 0x00100000,

                STANDARD_RIGHTS_REQUIRED = 0x000F0000,

                /// <summary>
                /// See also <see cref="READ_CONTROL"/>
                /// </summary>
                STANDARD_RIGHTS_READ = READ_CONTROL,

                /// <summary>
                /// See also <see cref="READ_CONTROL"/>
                /// </summary>
                STANDARD_RIGHTS_WRITE = READ_CONTROL,

                /// <summary>
                /// See also <see cref="READ_CONTROL"/>
                /// </summary>
                STANDARD_RIGHTS_EXECUTE = READ_CONTROL,

                STANDARD_RIGHTS_ALL = 0x001F0000,
            }

            /// <summary>
            /// Contains the access mask specific to the object type associated with the mask.
            /// </summary>
            [Flags]
            public enum SpecificRight : uint
            {
                /// <summary>
                /// The bit mask that covers specific rights.
                /// </summary>
                SPECIFIC_RIGHTS_ALL = 0x0000FFFF,
            }

            /// <summary>
            /// The following are the generic access rights for a desktop object contained in the interactive window station of the user's logon session.
            /// </summary>
            [Flags]
            public enum DesktopGenericRight : uint
            {
                GENERIC_READ = StandardRight.STANDARD_RIGHTS_READ |
                    DesktopSpecificRight.DESKTOP_ENUMERATE |
                    DesktopSpecificRight.DESKTOP_READOBJECTS,

                GENERIC_WRITE = StandardRight.STANDARD_RIGHTS_WRITE |
                    DesktopSpecificRight.DESKTOP_CREATEMENU |
                    DesktopSpecificRight.DESKTOP_CREATEWINDOW |
                    DesktopSpecificRight.DESKTOP_HOOKCONTROL |
                    DesktopSpecificRight.DESKTOP_JOURNALPLAYBACK |
                    DesktopSpecificRight.DESKTOP_JOURNALRECORD |
                    DesktopSpecificRight.DESKTOP_WRITEOBJECTS,

                GENERIC_EXECUTE = StandardRight.STANDARD_RIGHTS_EXECUTE |
                    DesktopSpecificRight.DESKTOP_SWITCHDESKTOP,

                GENERIC_ALL = StandardRight.STANDARD_RIGHTS_REQUIRED |
                    DesktopSpecificRight.DESKTOP_CREATEMENU |
                    DesktopSpecificRight.DESKTOP_CREATEWINDOW |
                    DesktopSpecificRight.DESKTOP_ENUMERATE |
                    DesktopSpecificRight.DESKTOP_HOOKCONTROL |
                    DesktopSpecificRight.DESKTOP_JOURNALPLAYBACK |
                    DesktopSpecificRight.DESKTOP_JOURNALRECORD |
                    DesktopSpecificRight.DESKTOP_READOBJECTS |
                    DesktopSpecificRight.DESKTOP_SWITCHDESKTOP |
                    DesktopSpecificRight.DESKTOP_WRITEOBJECTS,
            }

            /// <summary>
            /// Contains the access mask specific to the Desktop associated with the mask.
            /// </summary>
            [Flags]
            public enum DesktopSpecificRight : uint
            {
                /// <summary>
                /// The bit mask that covers all possible access rights for the desktop.
                /// </summary>
                DESKTOP_ALL_ACCESS = 0x000001FF,

                /// <summary>
                /// Required to create a menu on the desktop.
                /// </summary>
                DESKTOP_CREATEMENU = 0x00000004,

                /// <summary>
                /// Required for the desktop to be enumerated.
                /// </summary>
                DESKTOP_ENUMERATE = 0x00000040,

                /// <summary>
                /// Required to establish any of the window hooks.
                /// </summary>
                DESKTOP_HOOKCONTROL = 0x00000008,

                /// <summary>
                /// Required to perform journal playback on a desktop.
                /// </summary>
                DESKTOP_JOURNALPLAYBACK = 0x00000020,

                /// <summary>
                /// Required to perform journal recording on a desktop.
                /// </summary>
                DESKTOP_JOURNALRECORD = 0x00000010,

                /// <summary>
                /// Required to read objects on the desktop.
                /// </summary>
                DESKTOP_READOBJECTS = 0x00000001,

                /// <summary>
                /// Required to create a window on the desktop.
                /// </summary>
                DESKTOP_CREATEWINDOW = 0x00000002,

                /// <summary>
                /// Required to activate the desktop using the SwitchDesktop function.
                /// </summary>
                DESKTOP_SWITCHDESKTOP = 0x00000100,

                /// <summary>
                /// Required to write objects on the desktop.
                /// </summary>
                DESKTOP_WRITEOBJECTS = 0x00000080,
            }

            /// <summary>
            /// Generic access rights for the interactive window station object, which is the window station assigned to the logon session of the interactive user.
            /// </summary>
            [Flags]
            public enum InteractiveWindowStationGenericRight : uint
            {
                GENERIC_READ = StandardRight.STANDARD_RIGHTS_READ |
                    WindowStationSpecificRight.WINSTA_ENUMDESKTOPS |
                    WindowStationSpecificRight.WINSTA_ENUMERATE |
                    WindowStationSpecificRight.WINSTA_READATTRIBUTES |
                    WindowStationSpecificRight.WINSTA_READSCREEN,

                GENERIC_WRITE = StandardRight.STANDARD_RIGHTS_WRITE |
                    WindowStationSpecificRight.WINSTA_ACCESSCLIPBOARD |
                    WindowStationSpecificRight.WINSTA_CREATEDESKTOP |
                    WindowStationSpecificRight.WINSTA_WRITEATTRIBUTES,

                GENERIC_EXECUTE = StandardRight.STANDARD_RIGHTS_EXECUTE |
                    WindowStationSpecificRight.WINSTA_ACCESSGLOBALATOMS |
                    WindowStationSpecificRight.WINSTA_EXITWINDOWS,

                GENERIC_ALL = StandardRight.STANDARD_RIGHTS_REQUIRED |
                    WindowStationSpecificRight.WINSTA_ACCESSCLIPBOARD |
                    WindowStationSpecificRight.WINSTA_ACCESSGLOBALATOMS |
                    WindowStationSpecificRight.WINSTA_CREATEDESKTOP |
                    WindowStationSpecificRight.WINSTA_ENUMDESKTOPS |
                    WindowStationSpecificRight.WINSTA_ENUMERATE |
                    WindowStationSpecificRight.WINSTA_EXITWINDOWS |
                    WindowStationSpecificRight.WINSTA_READATTRIBUTES |
                    WindowStationSpecificRight.WINSTA_READSCREEN |
                    WindowStationSpecificRight.WINSTA_WRITEATTRIBUTES,
            }

            /// <summary>
            /// Generic access rights for a noninteractive window station object.
            /// The system assigns noninteractive window stations to all logon sessions other than that of the interactive user.
            /// </summary>
            [Flags]
            public enum NonInteractiveWindowStationGenericRight : uint
            {
                GENERIC_READ = StandardRight.STANDARD_RIGHTS_READ |
                    WindowStationSpecificRight.WINSTA_ENUMDESKTOPS |
                    WindowStationSpecificRight.WINSTA_ENUMERATE |
                    WindowStationSpecificRight.WINSTA_READATTRIBUTES,

                GENERIC_WRITE = StandardRight.STANDARD_RIGHTS_WRITE |
                    WindowStationSpecificRight.WINSTA_ACCESSCLIPBOARD |
                    WindowStationSpecificRight.WINSTA_CREATEDESKTOP,

                GENERIC_EXECUTE = StandardRight.STANDARD_RIGHTS_EXECUTE |
                    WindowStationSpecificRight.WINSTA_ACCESSGLOBALATOMS |
                    WindowStationSpecificRight.WINSTA_EXITWINDOWS,

                GENERIC_ALL = StandardRight.STANDARD_RIGHTS_REQUIRED |
                    WindowStationSpecificRight.WINSTA_ACCESSCLIPBOARD |
                    WindowStationSpecificRight.WINSTA_ACCESSGLOBALATOMS |
                    WindowStationSpecificRight.WINSTA_CREATEDESKTOP |
                    WindowStationSpecificRight.WINSTA_ENUMDESKTOPS |
                    WindowStationSpecificRight.WINSTA_ENUMERATE |
                    WindowStationSpecificRight.WINSTA_EXITWINDOWS |
                    WindowStationSpecificRight.WINSTA_READATTRIBUTES |
                    WindowStationSpecificRight.WINSTA_READSCREEN,
            }

            /// <summary>
            /// Contains the access mask specific to the Window Station associated with the mask.
            /// </summary>
            [Flags]
            public enum WindowStationSpecificRight : uint
            {
                /// <summary>
                /// The bit mask that covers all possible access rights for the window station.
                /// </summary>
                WINSTA_ALL_ACCESS = 0x0000037F,

                /// <summary>
                /// Required to use the clipboard.
                /// </summary>
                WINSTA_ACCESSCLIPBOARD = 0x00000004,

                /// <summary>
                /// Required to manipulate global atoms.
                /// </summary>
                WINSTA_ACCESSGLOBALATOMS = 0x00000020,

                /// <summary>
                /// Required to create new desktop objects on the window station.
                /// </summary>
                WINSTA_CREATEDESKTOP = 0x00000008,

                /// <summary>
                /// Required to enumerate existing desktop objects.
                /// </summary>
                WINSTA_ENUMDESKTOPS = 0x00000001,

                /// <summary>
                /// Required for the window station to be enumerated.
                /// </summary>
                WINSTA_ENUMERATE = 0x00000100,

                /// <summary>
                /// Required to successfully call the ExitWindows or ExitWindowsEx function
                /// Window stations can be shared by users and this access type can prevent other users of a window station from logging off the window station owner.
                /// </summary>
                WINSTA_EXITWINDOWS = 0x00000040,

                /// <summary>
                /// Required to read the attributes of a window station object. This attribute includes color settings and other global window station properties.
                /// </summary>
                WINSTA_READATTRIBUTES = 0x00000002,

                /// <summary>
                /// Required to access screen contents.
                /// </summary>
                WINSTA_READSCREEN = 0x00000200,

                /// <summary>
                /// Required to modify the attributes of a window station object. The attributes include color settings and other global window station properties.
                /// </summary>
                WINSTA_WRITEATTRIBUTES = 0x00000010,
            }

            /// <summary>
            /// Gets the ACCESS_MASK as a 32-bit unsigned integer.
            /// </summary>
            public uint Value { get; }

            /// <summary>
            /// Gets the ACCESS_MASK as a 32-bit signed integer.
            /// </summary>
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public int AsInt32 => (int)this.Value;

            /// <summary>
            /// Gets the generic rights of this value.
            /// </summary>
            public GenericRight GenericRights => (GenericRight)(this.Value & GenericRightsMask);

            /// <summary>
            /// Gets the special rights of this value.
            /// </summary>
            public SpecialRight SpecialRights => (SpecialRight)(this.Value & SpecialRightsMask);

            /// <summary>
            /// Gets the standard rights of this value.
            /// </summary>
            public StandardRight StandardRights => (StandardRight)(this.Value & StandardRightsMask);

            /// <summary>
            /// Gets the specific rights of this value.
            /// </summary>
            public SpecificRight SpecificRights => (SpecificRight)(this.Value & SpecificRightsMask);

            /// <summary>
            /// Gets the specific rights of this value for desktops.
            /// </summary>
            public DesktopSpecificRight DesktopSpecificRights => (DesktopSpecificRight)this.SpecificRights;

            /// <summary>
            /// Gets the generic rights of this value for interactive window stations.
            /// </summary>
            public InteractiveWindowStationGenericRight InteractiveWindowStationGenericRights => (InteractiveWindowStationGenericRight)this.GenericRights;

            /// <summary>
            /// Gets the generic rights of this value for noninteractive window stations.
            /// </summary>
            public NonInteractiveWindowStationGenericRight NonInteractiveWindowStationGenericRights => (NonInteractiveWindowStationGenericRight)this.GenericRights;

            /// <summary>
            /// Gets the specific rights of this value for window stations.
            /// </summary>
            public WindowStationSpecificRight WindowStationSpecificRights => (WindowStationSpecificRight)this.SpecificRights;

            /// <summary>
            /// Converts an <see cref="int"/> into an <see cref="ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value of the ACCESS_MASK.</param>
            public static implicit operator ACCESS_MASK(int value) => new ACCESS_MASK((uint)value);

            /// <summary>
            /// Converts an <see cref="ACCESS_MASK"/> into an <see cref="int"/>.
            /// </summary>
            /// <param name="value">The value of the ACCESS_MASK.</param>
            public static explicit operator int(ACCESS_MASK value) => value.AsInt32;

            /// <summary>
            /// Converts an <see cref="uint"/> into an <see cref="ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value of the ACCESS_MASK.</param>
            public static implicit operator ACCESS_MASK(uint value) => new ACCESS_MASK(value);

            /// <summary>
            /// Converts an <see cref="ACCESS_MASK"/> into an <see cref="uint"/>.
            /// </summary>
            /// <param name="value">The value of the ACCESS_MASK.</param>
            public static implicit operator uint(ACCESS_MASK value) => value.Value;

            /// <summary>
            /// Converts a <see cref="StandardRight"/> to an <see cref="ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value for the <see cref="ACCESS_MASK"/>.</param>
            public static implicit operator ACCESS_MASK(StandardRight value) => new ACCESS_MASK((uint)value);

            /// <summary>
            /// Converts a <see cref="GenericRight"/> to an <see cref="ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value for the <see cref="ACCESS_MASK"/>.</param>
            public static implicit operator ACCESS_MASK(GenericRight value) => new ACCESS_MASK((uint)value);

            /// <summary>
            /// Converts a <see cref="SpecificRight"/> to an <see cref="ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value for the <see cref="ACCESS_MASK"/>.</param>
            public static implicit operator ACCESS_MASK(SpecificRight value) => new ACCESS_MASK((uint)value);

            /// <inheritdoc />
            public override int GetHashCode() => this.AsInt32;

            /// <inheritdoc />
            public bool Equals(ACCESS_MASK other) => this.Value == other.Value;

            /// <inheritdoc />
            public override bool Equals(object obj) => obj is ACCESS_MASK && this.Equals((ACCESS_MASK)obj);

            /// <inheritdoc />
            public int CompareTo(object obj) => ((IComparable)this.Value).CompareTo(obj);

            /// <inheritdoc />
            public int CompareTo(ACCESS_MASK other) => this.Value.CompareTo(other.Value);

            /// <inheritdoc />
            public override string ToString() => this.Value.ToString();

            /// <inheritdoc />
            public string ToString(string format, IFormatProvider formatProvider) => this.Value.ToString(format, formatProvider);
        }
    }
}
