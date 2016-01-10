// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes an HRESULT error or success condition.
    /// </summary>
    /// <remarks>
    ///  HRESULTs are 32 bit values layed out as follows:
    ///
    ///   3 3 2 2 2 2 2 2 2 2 2 2 1 1 1 1 1 1 1 1 1 1
    ///   1 0 9 8 7 6 5 4 3 2 1 0 9 8 7 6 5 4 3 2 1 0 9 8 7 6 5 4 3 2 1 0
    ///  +-+-+-+-+-+---------------------+-------------------------------+
    ///  |S|R|C|N|r|    Facility         |               Code            |
    ///  +-+-+-+-+-+---------------------+-------------------------------+
    ///
    ///  where
    ///
    ///      S - Severity - indicates success/fail
    ///
    ///          0 - Success
    ///          1 - Fail (COERROR)
    ///
    ///      R - reserved portion of the facility code, corresponds to NT's
    ///              second severity bit.
    ///
    ///      C - reserved portion of the facility code, corresponds to NT's
    ///              C field.
    ///
    ///      N - reserved portion of the facility code. Used to indicate a
    ///              mapped NT status value.
    ///
    ///      r - reserved portion of the facility code. Reserved for internal
    ///              use. Used to indicate HRESULT values that are not status
    ///              values, but are instead message ids for display strings.
    ///
    ///      Facility - is the facility code
    ///
    ///      Code - is the facility's status code
    ///
    /// </remarks>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct HResult : IComparable, IComparable<HResult>, IEquatable<HResult>, IFormattable
    {
        /// <summary>
        /// The mask of the bits that describe the <see cref="Severity"/>.
        /// </summary>
        private const uint SeverityMask = 0x80000000;

        /// <summary>
        /// The number of bits that <see cref="Severity"/> values are shifted
        /// in order to fit within <see cref="SeverityMask"/>.
        /// </summary>
        private const int SeverityShift = 31;

        /// <summary>
        /// The mask of the bits that describe the <see cref="Facility"/>.
        /// </summary>
        private const int FacilityMask = 0x7ff0000;

        /// <summary>
        /// The number of bits that <see cref="Facility"/> values are shifted
        /// in order to fit within <see cref="FacilityMask"/>.
        /// </summary>
        private const int FacilityShift = 16;

        /// <summary>
        /// The mask of the bits that describe the facility's status <see cref="FacilityCode"/>.
        /// </summary>
        private const int FacilityCodeMask = 0xffff;

        /// <summary>
        /// The number of bits that <see cref="FacilityCode"/> values are shifted
        /// in order to fit within <see cref="FacilityCodeMask"/>.
        /// </summary>
        private const int FacilityCodeShift = 0;

        /// <summary>
        /// The value of the HRESULT.
        /// </summary>
        private readonly int value;

        /// <summary>
        /// Initializes a new instance of the <see cref="HResult"/> struct.
        /// </summary>
        /// <param name="value">The value of the HRESULT.</param>
        public HResult(int value)
        {
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HResult"/> struct.
        /// </summary>
        /// <param name="value">The value of the HRESULT.</param>
        public HResult(uint value)
            : this((int)value)
        {
        }

        /// <summary>
        /// Gets the HRESULT as a 32-bit signed integer.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int AsInt32 => this.value;

        /// <summary>
        /// Gets the HRESULT as a 32-bit unsigned integer.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public uint AsUInt32 => (uint)this.value;

        /// <summary>
        /// Gets a value indicating whether this HRESULT represents a successful operation.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool Succeeded => this.value >= 0;

        /// <summary>
        /// Gets a value indicating whether this HRESULT represents a failured operation.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool Failed => this.value < 0;

        /// <summary>
        /// Gets the facility code of the HRESULT.
        /// </summary>
        public FacilityCodes Facility => (FacilityCodes)(this.value & FacilityMask);

        /// <summary>
        /// Gets the severity of the HRESULT.
        /// </summary>
        public SeverityCodes Severity => (SeverityCodes)(this.value & SeverityMask);

        /// <summary>
        /// Gets the facility's status code bits from the HRESULT.
        /// </summary>
        public int FacilityCode => this.value & FacilityCodeMask;

        /// <summary>
        /// Gets the string to display in a data tip when debugging.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => this.ToString();

        /// <summary>
        /// Converts an <see cref="int"/> into an <see cref="HResult"/>.
        /// </summary>
        /// <param name="hr">The value of the HRESULT.</param>
        public static implicit operator HResult(int hr) => new HResult(hr);

        /// <summary>
        /// Converts an <see cref="HResult"/> into an <see cref="int"/>.
        /// </summary>
        /// <param name="hr">The value of the HRESULT.</param>
        public static implicit operator int(HResult hr) => hr.value;

        /// <summary>
        /// Converts an <see cref="uint"/> into an <see cref="HResult"/>.
        /// </summary>
        /// <param name="hr">The value of the HRESULT.</param>
        public static implicit operator HResult(uint hr) => new HResult((int)hr);

        /// <summary>
        /// Converts an <see cref="HResult"/> into an <see cref="uint"/>.
        /// </summary>
        /// <param name="hr">The value of the HRESULT.</param>
        public static explicit operator uint(HResult hr) => (uint)hr.value;

        /// <summary>
        /// Throws an exception if this HRESULT <see cref="Failed"/>, based on the failure value.
        /// </summary>
        public void ThrowOnFailure()
        {
            Marshal.ThrowExceptionForHR(this.value);
        }

        /// <summary>
        /// Throws an exception if this HRESULT <see cref="Failed"/>, based on the failure value and the specified IErrorInfo interface.
        /// </summary>
        /// <param name="errorInfo">
        /// A pointer to the IErrorInfo interface that provides more information about the
        /// error. You can specify IntPtr(0) to use the current IErrorInfo interface, or
        /// IntPtr(-1) to ignore the current IErrorInfo interface and construct the exception
        /// just from the error code.
        /// </param>
        public void ThrowOnFailure(IntPtr errorInfo)
        {
            Marshal.ThrowExceptionForHR(this.value, errorInfo);
        }

        /// <inheritdoc />
        public override int GetHashCode() => this.value;

        /// <inheritdoc />
        public bool Equals(HResult other) => this.value == other.value;

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is HResult && this.Equals((HResult)obj);

        /// <inheritdoc />
        public int CompareTo(object obj) => ((IComparable)this.value).CompareTo(obj);

        /// <inheritdoc />
        public int CompareTo(HResult other) => this.value.CompareTo(other.value);

        /// <inheritdoc />
        public override string ToString() => $"0x{this.value:x8}";

        /// <inheritdoc />
        public string ToString(string format, IFormatProvider formatProvider) => this.value.ToString(format, formatProvider);
    }
}
