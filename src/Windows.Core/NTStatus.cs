// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Win32 return error codes.
    /// </summary>
    /// <remarks>
    /// This values come from https://msdn.microsoft.com/en-us/library/cc704588.aspx
    ///  Values are 32 bit values laid out as follows:
    ///   3 3 2 2 2 2 2 2 2 2 2 2 1 1 1 1 1 1 1 1 1 1
    ///   1 0 9 8 7 6 5 4 3 2 1 0 9 8 7 6 5 4 3 2 1 0 9 8 7 6 5 4 3 2 1 0
    ///  +---+-+-+-----------------------+-------------------------------+
    ///  |Sev|C|R|     Facility          |               Code            |
    ///  +---+-+-+-----------------------+-------------------------------+
    ///  where
    ///      Sev - is the severity code
    ///          00 - Success
    ///          01 - Informational
    ///          10 - Warning
    ///          11 - Error
    ///      C - is the Customer code flag
    ///      R - is a reserved bit
    ///      Facility - is the facility code
    ///      Code - is the facility's status code
    ///
    /// FacilityCodes 0x5 - 0xF have been allocated by various drivers.
    /// The success status codes 0 - 63 are reserved for wait completion status.
    /// </remarks>
    [DebuggerDisplay("{Value}")]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct NTStatus : IComparable, IComparable<NTStatus>, IEquatable<NTStatus>, IFormattable
    {
        /// <summary>
        /// The mask of the bits that describe the <see cref="Severity"/>.
        /// </summary>
        private const uint SeverityMask = 0xc0000000;

        /// <summary>
        /// The number of bits that <see cref="Severity"/> values are shifted
        /// in order to fit within <see cref="SeverityMask"/>.
        /// </summary>
        private const int SeverityShift = 30;

        /// <summary>
        /// The mask of the bits that describe the <see cref="CustomerCode"/>.
        /// </summary>
        private const uint CustomerCodeMask = 0x20000000;

        /// <summary>
        /// The number of bits that <see cref="CustomerCode"/> values are shifted
        /// in order to fit within <see cref="CustomerCodeMask"/>.
        /// </summary>
        private const int CustomerCodeShift = 29;

        /// <summary>
        /// The mask of the bits that describe the <see cref="Facility"/>.
        /// </summary>
        private const uint FacilityMask = 0xfff0000;

        /// <summary>
        /// The number of bits that <see cref="Facility"/> values are shifted
        /// in order to fit within <see cref="FacilityMask"/>.
        /// </summary>
        private const int FacilityShift = 16;

        /// <summary>
        /// The mask of the bits that describe the facility's status <see cref="FacilityStatus"/>.
        /// </summary>
        private const uint FacilityStatusMask = 0xffff;

        /// <summary>
        /// The number of bits that <see cref="FacilityStatus"/> values are shifted
        /// in order to fit within <see cref="FacilityStatusMask"/>.
        /// </summary>
        private const int FacilityStatusShift = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="NTStatus"/> struct.
        /// </summary>
        /// <param name="status">The value of the NTStatus.</param>
        public NTStatus(uint status)
            : this((Code)status)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NTStatus"/> struct.
        /// </summary>
        /// <param name="status">The value of the NTStatus.</param>
        public NTStatus(int status)
            : this((Code)status)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NTStatus"/> struct.
        /// </summary>
        /// <param name="status">The value of the NTStatus.</param>
        public NTStatus(Code status)
        {
            this.Value = status;
        }

        /// <summary>
        /// Gets the full NT_STATUS value, as a <see cref="Code"/> enum.
        /// </summary>
        public Code Value { get; }

        /// <summary>
        /// Gets the NT_STATUS as a 32-bit signed integer.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int AsInt32 => (int)this.Value;

        /// <summary>
        /// Gets the NT_STATUS as a 32-bit unsigned integer.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public uint AsUInt32 => (uint)this.Value;

        /// <summary>
        /// Gets the severity code of this value.
        /// </summary>
        public SeverityCode Severity => (SeverityCode)(this.AsUInt32 & SeverityMask);

        /// <summary>
        /// Gets the customer code portion of this value.
        /// </summary>
        public uint CustomerCode => this.AsUInt32 & CustomerCodeMask;

        /// <summary>
        /// Gets the facility code of this value.
        /// </summary>
        public FacilityCode Facility => (FacilityCode)(this.AsUInt32 & FacilityMask);

        /// <summary>
        /// Gets the facility's status code bits from the NT_STATUS.
        /// </summary>
        public uint FacilityStatus => this.AsUInt32 & FacilityStatusMask;

        /// <summary>
        /// Converts an <see cref="int"/> into an <see cref="NTStatus"/>.
        /// </summary>
        /// <param name="status">The value of the NT_STATUS.</param>
        public static implicit operator NTStatus(int status) => new NTStatus(status);

        /// <summary>
        /// Converts an <see cref="NTStatus"/> into an <see cref="int"/>.
        /// </summary>
        /// <param name="status">The value of the NT_STATUS.</param>
        public static explicit operator int(NTStatus status) => status.AsInt32;

        /// <summary>
        /// Converts an <see cref="uint"/> into an <see cref="NTStatus"/>.
        /// </summary>
        /// <param name="status">The value of the NT_STATUS.</param>
        public static implicit operator NTStatus(uint status) => new NTStatus(status);

        /// <summary>
        /// Converts an <see cref="NTStatus"/> into an <see cref="uint"/>.
        /// </summary>
        /// <param name="status">The value of the NT_STATUS.</param>
        public static implicit operator uint(NTStatus status) => status.AsUInt32;

        /// <summary>
        /// Converts a <see cref="Code"/> enum to its structural <see cref="NTStatus"/> representation.
        /// </summary>
        /// <param name="status">The value to convert.</param>
        public static implicit operator NTStatus(Code status) => new NTStatus(status);

        /// <summary>
        /// Converts an <see cref="NTStatus"/> to its <see cref="Code"/> enum representation.
        /// </summary>
        /// <param name="status">The value to convert.</param>
        public static implicit operator Code(NTStatus status) => status.Value;

        /// <inheritdoc />
        public override int GetHashCode() => (int)this.Value;

        /// <inheritdoc />
        public bool Equals(NTStatus other) => this.Value == other.Value;

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is NTStatus && this.Equals((NTStatus)obj);

        /// <inheritdoc />
        public int CompareTo(object obj) => ((IComparable)this.Value).CompareTo(obj);

        /// <inheritdoc />
        public int CompareTo(NTStatus other) => this.Value.CompareTo(other.Value);

        /// <inheritdoc />
        public override string ToString() => this.Value.ToString();

        /// <inheritdoc />
        public string ToString(string format, IFormatProvider formatProvider) => this.AsUInt32.ToString(format, formatProvider);
    }
}
