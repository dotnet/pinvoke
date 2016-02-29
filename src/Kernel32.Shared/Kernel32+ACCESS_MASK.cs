// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

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
        /// Quite well described here: http://blogs.msdn.com/b/openspecification/archive/2010/04/01/about-the-access-mask-structure.aspx
        /// </remarks>
        public partial struct ACCESS_MASK : IComparable, IComparable<ACCESS_MASK>, IEquatable<ACCESS_MASK>, IFormattable
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
            /// Initializes a new instance of the <see cref="ACCESS_MASK"/> struct.
            /// </summary>
            /// <param name="value">The value for the <see cref="ACCESS_MASK"/>.</param>
            public ACCESS_MASK(uint value)
            {
                this.Value = value;
            }

            [Flags]
            public enum GenericRight : uint
            {
                GENERIC_ALL = 0x10000000,
                GENERIC_EXECUTE = 0x20000000,
                GENERIC_WRITE = 0x40000000,
                GENERIC_READ = 0x80000000,
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
            /// <param name="value">The value for the <see cref="ACCESS_MASK"/></param>
            public static implicit operator ACCESS_MASK(StandardRight value) => new ACCESS_MASK((uint)value);

            /// <summary>
            /// Converts a <see cref="GenericRight"/> to an <see cref="ACCESS_MASK"/>.
            /// </summary>
            /// <param name="value">The value for the <see cref="ACCESS_MASK"/></param>
            public static implicit operator ACCESS_MASK(GenericRight value) => new ACCESS_MASK((uint)value);

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
