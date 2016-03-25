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
    [DebuggerDisplay("{Value}")]
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
        /// The mask of the bits that describe the <see cref="FacilityStatus"/>.
        /// </summary>
        private const int FacilityStatusMask = 0xffff;

        /// <summary>
        /// The number of bits that <see cref="FacilityStatus"/> values are shifted
        /// in order to fit within <see cref="FacilityStatusMask"/>.
        /// </summary>
        private const int FacilityStatusShift = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="HResult"/> struct.
        /// </summary>
        /// <param name="value">The value of the HRESULT.</param>
        public HResult(Code value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HResult"/> struct.
        /// </summary>
        /// <param name="value">The value of the HRESULT.</param>
        public HResult(int value)
            : this((Code)value)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HResult"/> struct.
        /// </summary>
        /// <param name="value">The value of the HRESULT.</param>
        public HResult(uint value)
            : this((Code)value)
        {
        }

        /// <summary>
        /// Gets the full HRESULT value, as a <see cref="Code"/> enum.
        /// </summary>
        public Code Value { get; }

        /// <summary>
        /// Gets the HRESULT as a 32-bit signed integer.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int AsInt32 => (int)this.Value;

        /// <summary>
        /// Gets the HRESULT as a 32-bit unsigned integer.
        /// </summary>
        public uint AsUInt32 => (uint)this.Value;

        /// <summary>
        /// Gets a value indicating whether this HRESULT represents a successful operation.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool Succeeded => this.Severity == SeverityCode.Success;

        /// <summary>
        /// Gets a value indicating whether this HRESULT represents a failured operation.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool Failed => this.Severity == SeverityCode.Fail;

        /// <summary>
        /// Gets the facility code of the HRESULT.
        /// </summary>
        public FacilityCode Facility => (FacilityCode)(this.AsUInt32 & FacilityMask);

        /// <summary>
        /// Gets the severity of the HRESULT.
        /// </summary>
        public SeverityCode Severity => (SeverityCode)(this.AsUInt32 & SeverityMask);

        /// <summary>
        /// Gets the facility's status code bits from the HRESULT.
        /// </summary>
        public uint FacilityStatus => this.AsUInt32 & FacilityStatusMask;

        /// <summary>
        /// Converts an <see cref="int"/> into an <see cref="HResult"/>.
        /// </summary>
        /// <param name="hr">The value of the HRESULT.</param>
        public static implicit operator HResult(int hr) => new HResult(hr);

        /// <summary>
        /// Converts an <see cref="HResult"/> into an <see cref="int"/>.
        /// </summary>
        /// <param name="hr">The value of the HRESULT.</param>
        public static implicit operator int(HResult hr) => hr.AsInt32;

        /// <summary>
        /// Converts an <see cref="uint"/> into an <see cref="HResult"/>.
        /// </summary>
        /// <param name="hr">The value of the HRESULT.</param>
        public static implicit operator HResult(uint hr) => new HResult(hr);

        /// <summary>
        /// Converts an <see cref="HResult"/> into an <see cref="uint"/>.
        /// </summary>
        /// <param name="hr">The value of the HRESULT.</param>
        public static explicit operator uint(HResult hr) => hr.AsUInt32;

        /// <summary>
        /// Converts a <see cref="Code"/> enum to its structural <see cref="HResult"/> representation.
        /// </summary>
        /// <param name="hr">The value to convert.</param>
        public static implicit operator HResult(Code hr) => new HResult(hr);

        /// <summary>
        /// Converts an <see cref="HResult"/> to its <see cref="Code"/> enum representation.
        /// </summary>
        /// <param name="hr">The value to convert.</param>
        public static implicit operator Code(HResult hr) => hr.Value;

        /// <summary>
        /// Checks equality between this HResult and a <see cref="uint"/> value.
        /// </summary>
        /// <param name="hr">An <see cref="HResult"/></param>
        /// <param name="value">Some <see cref="uint"/> value</param>
        /// <returns><c>true</c> if they equal; <c>false</c> otherwise.</returns>
        /// <remarks>
        /// This operator overload is useful because HResult-uint conversion must be explicit,
        /// and without this overload, it makes comparing HResults to 0x8xxxxxxx values require casts.
        /// </remarks>
        public static bool operator ==(HResult hr, uint value) => hr.AsUInt32 == value;

        /// <summary>
        /// Checks inequality between this HResult and a <see cref="uint"/> value.
        /// </summary>
        /// <param name="hr">An <see cref="HResult"/></param>
        /// <param name="value">Some <see cref="uint"/> value</param>
        /// <returns><c>true</c> if they unequal; <c>false</c> otherwise.</returns>
        /// <remarks>
        /// This operator overload is useful because HResult-uint conversion must be explicit,
        /// and without this overload, it makes comparing HResults to 0x8xxxxxxx values require casts.
        /// </remarks>
        public static bool operator !=(HResult hr, uint value) => hr.AsUInt32 != value;

        /// <summary>
        /// Throws an exception if this HRESULT <see cref="Failed"/>, based on the failure value.
        /// </summary>
        public void ThrowOnFailure()
        {
            Marshal.ThrowExceptionForHR(this.AsInt32);
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
            Marshal.ThrowExceptionForHR(this.AsInt32, errorInfo);
        }

        /// <summary>
        /// Gets an exception that represents this <see cref="HResult" />
        /// if it represents a failure.
        /// </summary>
        /// <returns>
        /// The exception, if applicable; otherwise null.
        /// </returns>
        public Exception GetException() => Marshal.GetExceptionForHR(this);

        /// <summary>
        /// Gets an exception that represents this <see cref="HResult" />
        /// if it represents a failure.
        /// </summary>
        /// <param name="errorInfo">
        /// A pointer to additional error information that may be used to populate the Exception.
        /// </param>
        /// <returns>
        /// The exception, if applicable; otherwise null.
        /// </returns>
        public Exception GetException(IntPtr errorInfo) => Marshal.GetExceptionForHR(this, errorInfo);

        /// <inheritdoc />
        public override int GetHashCode() => this.AsInt32;

        /// <inheritdoc />
        public bool Equals(HResult other) => this.Value == other.Value;

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is HResult && this.Equals((HResult)obj);

        /// <inheritdoc />
        public int CompareTo(object obj) => ((IComparable)this.Value).CompareTo(obj);

        /// <inheritdoc />
        public int CompareTo(HResult other) => this.Value.CompareTo(other.Value);

        /// <inheritdoc />
        public override string ToString() => this.Value.ToString();

        /// <inheritdoc />
        public string ToString(string format, IFormatProvider formatProvider) => this.AsUInt32.ToString(format, formatProvider);
    }
}
