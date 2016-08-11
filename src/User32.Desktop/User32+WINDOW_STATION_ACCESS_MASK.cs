// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics;

    /// <content>
    /// Contains the <see cref="WINDOW_STATION_ACCESS_MASK"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// The <see cref="Kernel32.ACCESS_MASK"/> type is a bitmask that specifies a set of access rights in the access mask of an access control entry.
        /// /// This is a set of Specific Rights bitmask that defines access rights and security for desktop objects
        /// </summary>
        /// <remarks>
        /// <see cref="Kernel32.ACCESS_MASK"/> is quite well described here: http://blogs.msdn.com/b/openspecification/archive/2010/04/01/about-the-access-mask-structure.aspx
        /// Window Station security and access rights are quite well described here: https://msdn.microsoft.com/en-us/library/windows/desktop/ms687391(v=vs.85).aspx
        /// </remarks>
        public struct WINDOW_STATION_ACCESS_MASK : IComparable, IFormattable, IComparable<WINDOW_STATION_ACCESS_MASK>, IEquatable<WINDOW_STATION_ACCESS_MASK>, IComparable<Kernel32.ACCESS_MASK>, IEquatable<Kernel32.ACCESS_MASK>
        {
            /// <summary>
            /// Bits 28-31
            /// </summary>
            private const uint GenericRightsMask = 0xf0000000;

            /// <summary>
            /// Bits 24-27
            /// </summary>
            private const uint SpecialRightsMask = 0x0f000000;

            /// <summary>
            /// Bits 16-23
            /// </summary>
            private const uint StandardRightsMask = 0x00ff0000;

            /// <summary>
            /// Bits 0-15
            /// </summary>
            private const uint SpecificRightsMask = 0x0000ffff;

            /// <summary>
            /// Initializes a new instance of the <see cref="WINDOW_STATION_ACCESS_MASK"/> struct.
            /// </summary>
            /// <param name="value">The value for the <see cref="WINDOW_STATION_ACCESS_MASK"/>.</param>
            public WINDOW_STATION_ACCESS_MASK(uint value)
            {
                this.Value = value;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="WINDOW_STATION_ACCESS_MASK"/> struct.
            /// </summary>
            /// <param name="value">The reference <see cref="Kernel32.ACCESS_MASK"/> for the <see cref="WINDOW_STATION_ACCESS_MASK"/>.</param>
            public WINDOW_STATION_ACCESS_MASK(Kernel32.ACCESS_MASK value)
            {
                this.Value = value;
            }

            /// <summary>
            /// Generic access rights for the interactive window station object, which is the window station assigned to the logon session of the interactive user.
            /// </summary>
            [Flags]
            public enum InteractiveWindowStationGenericRight : uint
            {
                GENERIC_READ = Kernel32.ACCESS_MASK.StandardRight.STANDARD_RIGHTS_READ |
                    SpecificRight.WINSTA_ENUMDESKTOPS |
                    SpecificRight.WINSTA_ENUMERATE |
                    SpecificRight.WINSTA_READATTRIBUTES |
                    SpecificRight.WINSTA_READSCREEN,

                GENERIC_WRITE = Kernel32.ACCESS_MASK.StandardRight.STANDARD_RIGHTS_WRITE |
                    SpecificRight.WINSTA_ACCESSCLIPBOARD |
                    SpecificRight.WINSTA_CREATEDESKTOP |
                    SpecificRight.WINSTA_WRITEATTRIBUTES,

                GENERIC_EXECUTE = Kernel32.ACCESS_MASK.StandardRight.STANDARD_RIGHTS_EXECUTE |
                    SpecificRight.WINSTA_ACCESSGLOBALATOMS |
                    SpecificRight.WINSTA_EXITWINDOWS,

                GENERIC_ALL = Kernel32.ACCESS_MASK.StandardRight.STANDARD_RIGHTS_REQUIRED |
                    SpecificRight.WINSTA_ACCESSCLIPBOARD |
                    SpecificRight.WINSTA_ACCESSGLOBALATOMS |
                    SpecificRight.WINSTA_CREATEDESKTOP |
                    SpecificRight.WINSTA_ENUMDESKTOPS |
                    SpecificRight.WINSTA_ENUMERATE |
                    SpecificRight.WINSTA_EXITWINDOWS |
                    SpecificRight.WINSTA_READATTRIBUTES |
                    SpecificRight.WINSTA_READSCREEN |
                    SpecificRight.WINSTA_WRITEATTRIBUTES
            }

            /// <summary>
            /// Generic access rights for a noninteractive window station object.
            /// The system assigns noninteractive window stations to all logon sessions other than that of the interactive user.
            /// </summary>
            [Flags]
            public enum NonInteractiveWindowStationGenericRight : uint
            {
                GENERIC_READ = Kernel32.ACCESS_MASK.StandardRight.STANDARD_RIGHTS_READ |
                    SpecificRight.WINSTA_ENUMDESKTOPS |
                    SpecificRight.WINSTA_ENUMERATE |
                    SpecificRight.WINSTA_READATTRIBUTES,

                GENERIC_WRITE = Kernel32.ACCESS_MASK.StandardRight.STANDARD_RIGHTS_WRITE |
                    SpecificRight.WINSTA_ACCESSCLIPBOARD |
                    SpecificRight.WINSTA_CREATEDESKTOP,

                GENERIC_EXECUTE = Kernel32.ACCESS_MASK.StandardRight.STANDARD_RIGHTS_EXECUTE |
                    SpecificRight.WINSTA_ACCESSGLOBALATOMS |
                    SpecificRight.WINSTA_EXITWINDOWS,

                GENERIC_ALL = Kernel32.ACCESS_MASK.StandardRight.STANDARD_RIGHTS_REQUIRED |
                    SpecificRight.WINSTA_ACCESSCLIPBOARD |
                    SpecificRight.WINSTA_ACCESSGLOBALATOMS |
                    SpecificRight.WINSTA_CREATEDESKTOP |
                    SpecificRight.WINSTA_ENUMDESKTOPS |
                    SpecificRight.WINSTA_ENUMERATE |
                    SpecificRight.WINSTA_EXITWINDOWS |
                    SpecificRight.WINSTA_READATTRIBUTES |
                    SpecificRight.WINSTA_READSCREEN
            }

            /// <summary>
            /// Contains the access mask specific to the Window Station associated with the mask.
            /// </summary>
            [Flags]
            public enum SpecificRight : uint
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
                WINSTA_WRITEATTRIBUTES = 0x00000010
            }

            /// <summary>
            /// Gets the WINDOW_STATION_ACCESS_MASK as a 32-bit unsigned integer.
            /// </summary>
            public uint Value { get; }

            /// <summary>
            /// Gets the WINDOW_STATION_ACCESS_MASK as a 32-bit signed integer.
            /// </summary>
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public int AsInt32 => (int)this.Value;

            /// <summary>
            /// Gets the basic generic rights of this value, the ones that Windows can set and read for any object
            /// </summary>
            public Kernel32.ACCESS_MASK.GenericRight BasicGenericRights => (Kernel32.ACCESS_MASK.GenericRight)(this.Value & GenericRightsMask);

            /// <summary>
            /// Gets the generic rights of this value for interactive window stations.
            /// </summary>
            public InteractiveWindowStationGenericRight InteractiveWindowStationGenericRights => (InteractiveWindowStationGenericRight)(this.Value & GenericRightsMask);

            /// <summary>
            /// Gets the generic rights of this value for noninteractive window stations.
            /// </summary>
            public NonInteractiveWindowStationGenericRight NonInteractiveWindowStationGenericRights => (NonInteractiveWindowStationGenericRight)(this.Value & GenericRightsMask);

            /// <summary>
            /// Gets the special rights of this value.
            /// </summary>
            public Kernel32.ACCESS_MASK.SpecialRight SpecialRights => (Kernel32.ACCESS_MASK.SpecialRight)(this.Value & SpecialRightsMask);

            /// <summary>
            /// Gets the standard rights of this value.
            /// </summary>
            public Kernel32.ACCESS_MASK.StandardRight StandardRights => (Kernel32.ACCESS_MASK.StandardRight)(this.Value & StandardRightsMask);

            /// <summary>
            /// Gets the specific rights of this value.
            /// </summary>
            public SpecificRight SpecificRights => (SpecificRight)(this.Value & SpecificRightsMask);

            /// <summary>
            /// Converts an <see cref="int"/> into an <see cref="WINDOW_STATION_ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value of the ACCESS_MASK.</param>
            public static implicit operator WINDOW_STATION_ACCESS_MASK(int value) => new WINDOW_STATION_ACCESS_MASK((uint)value);

            /// <summary>
            /// Converts an <see cref="WINDOW_STATION_ACCESS_MASK"/> into an <see cref="int"/>.
            /// </summary>
            /// <param name="value">The value of the ACCESS_MASK.</param>
            public static explicit operator int(WINDOW_STATION_ACCESS_MASK value) => value.AsInt32;

            /// <summary>
            /// Converts an <see cref="uint"/> into an <see cref="WINDOW_STATION_ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value of the ACCESS_MASK.</param>
            public static implicit operator WINDOW_STATION_ACCESS_MASK(uint value) => new WINDOW_STATION_ACCESS_MASK(value);

            /// <summary>
            /// Converts an <see cref="WINDOW_STATION_ACCESS_MASK"/> into an <see cref="uint"/>.
            /// </summary>
            /// <param name="value">The value of the ACCESS_MASK.</param>
            public static implicit operator uint(WINDOW_STATION_ACCESS_MASK value) => value.Value;

            /// <summary>
            /// Converts an <see cref="Kernel32.ACCESS_MASK"/> into an <see cref="WINDOW_STATION_ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value of the ACCESS_MASK.</param>
            public static implicit operator WINDOW_STATION_ACCESS_MASK(Kernel32.ACCESS_MASK value) => new WINDOW_STATION_ACCESS_MASK(value);

            /// <summary>
            /// Converts an <see cref="WINDOW_STATION_ACCESS_MASK"/> into an <see cref="Kernel32.ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value of the ACCESS_MASK.</param>
            public static implicit operator Kernel32.ACCESS_MASK(WINDOW_STATION_ACCESS_MASK value) => value.Value;

            /// <summary>
            /// Converts a <see cref="Kernel32.ACCESS_MASK.StandardRight"/> to an <see cref="WINDOW_STATION_ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value for the <see cref="WINDOW_STATION_ACCESS_MASK"/></param>
            public static implicit operator WINDOW_STATION_ACCESS_MASK(Kernel32.ACCESS_MASK.StandardRight value) => new WINDOW_STATION_ACCESS_MASK((uint)value);

            /// <summary>
            /// Converts a <see cref="Kernel32.ACCESS_MASK.GenericRight"/> to an <see cref="WINDOW_STATION_ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value for the <see cref="WINDOW_STATION_ACCESS_MASK"/></param>
            public static implicit operator WINDOW_STATION_ACCESS_MASK(Kernel32.ACCESS_MASK.GenericRight value) => new WINDOW_STATION_ACCESS_MASK((uint)value);

            /// <summary>
            /// Converts a <see cref="SpecificRight"/> to an <see cref="WINDOW_STATION_ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value for the <see cref="WINDOW_STATION_ACCESS_MASK"/></param>
            public static implicit operator WINDOW_STATION_ACCESS_MASK(SpecificRight value) => new WINDOW_STATION_ACCESS_MASK((uint)value);

            /// <inheritdoc />
            public override int GetHashCode() => this.AsInt32;

            /// <inheritdoc />
            public bool Equals(WINDOW_STATION_ACCESS_MASK other) => this.Value == other.Value;

            /// <inheritdoc />
            public bool Equals(Kernel32.ACCESS_MASK other) => this.Value == other.Value;

            /// <inheritdoc />
            public override bool Equals(object obj) => (obj is Kernel32.ACCESS_MASK && this.Equals((Kernel32.ACCESS_MASK)obj)) ||
                                                        (obj is WINDOW_STATION_ACCESS_MASK && this.Equals((WINDOW_STATION_ACCESS_MASK)obj));

            /// <inheritdoc />
            public int CompareTo(WINDOW_STATION_ACCESS_MASK other) => this.Value.CompareTo(other.Value);

            /// <inheritdoc />
            public int CompareTo(Kernel32.ACCESS_MASK other) => this.Value.CompareTo(other.Value);

            /// <inheritdoc />
            public int CompareTo(object obj) => ((IComparable)this.Value).CompareTo(obj);

            /// <inheritdoc />
            public override string ToString() => this.Value.ToString();

            /// <inheritdoc />
            public string ToString(string format, IFormatProvider formatProvider) => this.Value.ToString(format, formatProvider);
        }
    }
}
