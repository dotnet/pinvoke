// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics;

    /// <content>
    /// Contains the <see cref="DESKTOP_ACCESS_MASK"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// The <see cref="Kernel32.ACCESS_MASK"/> type is a bitmask that specifies a set of access rights in the access mask of an access control entry.
        /// /// This is a set of Specific Rights bitmask that defines access rights and security for desktop objects
        /// </summary>
        /// <remarks>
        /// <see cref="Kernel32.ACCESS_MASK"/> is quite well described here: http://blogs.msdn.com/b/openspecification/archive/2010/04/01/about-the-access-mask-structure.aspx
        /// Desktop security and access rights are quite well described here: https://msdn.microsoft.com/en-us/library/windows/desktop/ms687391(v=vs.85).aspx
        /// </remarks>
        public struct DESKTOP_ACCESS_MASK : IComparable, IFormattable, IComparable<DESKTOP_ACCESS_MASK>, IEquatable<DESKTOP_ACCESS_MASK>, IComparable<Kernel32.ACCESS_MASK>, IEquatable<Kernel32.ACCESS_MASK>
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
            /// Initializes a new instance of the <see cref="DESKTOP_ACCESS_MASK"/> struct.
            /// </summary>
            /// <param name="value">The value for the <see cref="DESKTOP_ACCESS_MASK"/>.</param>
            public DESKTOP_ACCESS_MASK(uint value)
            {
                this.Value = value;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="DESKTOP_ACCESS_MASK"/> struct.
            /// </summary>
            /// <param name="value">The reference <see cref="Kernel32.ACCESS_MASK"/> for the <see cref="DESKTOP_ACCESS_MASK"/>.</param>
            public DESKTOP_ACCESS_MASK(Kernel32.ACCESS_MASK value)
            {
                this.Value = value;
            }

            /// <summary>
            /// The following are the generic access rights for a desktop object contained in the interactive window station of the user's logon session
            /// </summary>
            [Flags]
            public enum GenericRight : uint
            {
                GENERIC_READ = Kernel32.ACCESS_MASK.StandardRight.STANDARD_RIGHTS_READ |
                    SpecificRight.DESKTOP_ENUMERATE |
                    SpecificRight.DESKTOP_READOBJECTS,
                GENERIC_WRITE = Kernel32.ACCESS_MASK.StandardRight.STANDARD_RIGHTS_WRITE |
                    SpecificRight.DESKTOP_CREATEMENU |
                    SpecificRight.DESKTOP_CREATEWINDOW |
                    SpecificRight.DESKTOP_HOOKCONTROL |
                    SpecificRight.DESKTOP_JOURNALPLAYBACK |
                    SpecificRight.DESKTOP_JOURNALRECORD |
                    SpecificRight.DESKTOP_WRITEOBJECTS,
                GENERIC_EXECUTE = Kernel32.ACCESS_MASK.StandardRight.STANDARD_RIGHTS_EXECUTE |
                    SpecificRight.DESKTOP_SWITCHDESKTOP,
                GENERIC_ALL = Kernel32.ACCESS_MASK.StandardRight.STANDARD_RIGHTS_REQUIRED |
                    SpecificRight.DESKTOP_CREATEMENU |
                    SpecificRight.DESKTOP_CREATEWINDOW |
                    SpecificRight.DESKTOP_ENUMERATE |
                    SpecificRight.DESKTOP_HOOKCONTROL |
                    SpecificRight.DESKTOP_JOURNALPLAYBACK |
                    SpecificRight.DESKTOP_JOURNALRECORD |
                    SpecificRight.DESKTOP_READOBJECTS |
                    SpecificRight.DESKTOP_SWITCHDESKTOP |
                    SpecificRight.DESKTOP_WRITEOBJECTS
            }

            /// <summary>
            /// Contains the access mask specific to the Desktop associated with the mask.
            /// </summary>
            [Flags]
            public enum SpecificRight : uint
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
                /// Required to activate the desktop using the <see cref="SwitchDesktop"/> function.
                /// </summary>
                DESKTOP_SWITCHDESKTOP = 0x00000100,

                /// <summary>
                /// Required to write objects on the desktop.
                /// </summary>
                DESKTOP_WRITEOBJECTS = 0x00000080
            }

            /// <summary>
            /// Gets the DESKTOP_ACCESS_MASK as a 32-bit unsigned integer.
            /// </summary>
            public uint Value { get; }

            /// <summary>
            /// Gets the DESKTOP_ACCESS_MASK as a 32-bit signed integer.
            /// </summary>
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public int AsInt32 => (int)this.Value;

            /// <summary>
            /// Gets the basic generic rights of this value, the ones that Windows can set and read for any object
            /// </summary>
            public Kernel32.ACCESS_MASK.GenericRight BasicGenericRights => (Kernel32.ACCESS_MASK.GenericRight)(this.Value & GenericRightsMask);

            /// <summary>
            /// Gets the generic rights of this value for interactive desktops.
            /// </summary>
            public GenericRight InteractiveWindowStationGenericRights => (GenericRight)(this.Value & GenericRightsMask);

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
            /// Converts an <see cref="int"/> into an <see cref="DESKTOP_ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value of the ACCESS_MASK.</param>
            public static implicit operator DESKTOP_ACCESS_MASK(int value) => new DESKTOP_ACCESS_MASK((uint)value);

            /// <summary>
            /// Converts an <see cref="DESKTOP_ACCESS_MASK"/> into an <see cref="int"/>.
            /// </summary>
            /// <param name="value">The value of the ACCESS_MASK.</param>
            public static explicit operator int(DESKTOP_ACCESS_MASK value) => value.AsInt32;

            /// <summary>
            /// Converts an <see cref="uint"/> into an <see cref="DESKTOP_ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value of the ACCESS_MASK.</param>
            public static implicit operator DESKTOP_ACCESS_MASK(uint value) => new DESKTOP_ACCESS_MASK(value);

            /// <summary>
            /// Converts an <see cref="DESKTOP_ACCESS_MASK"/> into an <see cref="uint"/>.
            /// </summary>
            /// <param name="value">The value of the ACCESS_MASK.</param>
            public static implicit operator uint(DESKTOP_ACCESS_MASK value) => value.Value;

            /// <summary>
            /// Converts an <see cref="Kernel32.ACCESS_MASK"/> into an <see cref="DESKTOP_ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value of the ACCESS_MASK.</param>
            public static implicit operator DESKTOP_ACCESS_MASK(Kernel32.ACCESS_MASK value) => new DESKTOP_ACCESS_MASK(value);

            /// <summary>
            /// Converts an <see cref="DESKTOP_ACCESS_MASK"/> into an <see cref="Kernel32.ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value of the ACCESS_MASK.</param>
            public static implicit operator Kernel32.ACCESS_MASK(DESKTOP_ACCESS_MASK value) => value.Value;

            /// <summary>
            /// Converts a <see cref="Kernel32.ACCESS_MASK.StandardRight"/> to an <see cref="DESKTOP_ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value for the <see cref="DESKTOP_ACCESS_MASK"/></param>
            public static implicit operator DESKTOP_ACCESS_MASK(Kernel32.ACCESS_MASK.StandardRight value) => new DESKTOP_ACCESS_MASK((uint)value);

            /// <summary>
            /// Converts a <see cref="Kernel32.ACCESS_MASK.GenericRight"/> to an <see cref="WINDOW_STATION_ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value for the <see cref="WINDOW_STATION_ACCESS_MASK"/></param>
            public static implicit operator DESKTOP_ACCESS_MASK(Kernel32.ACCESS_MASK.GenericRight value) => new DESKTOP_ACCESS_MASK((uint)value);

            /// <summary>
            /// Converts a <see cref="SpecificRight"/> to an <see cref="WINDOW_STATION_ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value for the <see cref="WINDOW_STATION_ACCESS_MASK"/></param>
            public static implicit operator DESKTOP_ACCESS_MASK(SpecificRight value) => new DESKTOP_ACCESS_MASK((uint)value);

            /// <inheritdoc />
            public override int GetHashCode() => this.AsInt32;

            /// <inheritdoc />
            public bool Equals(DESKTOP_ACCESS_MASK other) => this.Value == other.Value;

            /// <inheritdoc />
            public bool Equals(Kernel32.ACCESS_MASK other) => this.Value == other.Value;

            /// <inheritdoc />
            public override bool Equals(object obj) => (obj is Kernel32.ACCESS_MASK && this.Equals((Kernel32.ACCESS_MASK)obj)) ||
                                                        (obj is DESKTOP_ACCESS_MASK && this.Equals((DESKTOP_ACCESS_MASK)obj));

            /// <inheritdoc />
            public int CompareTo(DESKTOP_ACCESS_MASK other) => this.Value.CompareTo(other.Value);

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
