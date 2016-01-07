// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

#pragma warning disable SA1124 // DoNotUseRegions

    /// <summary>
    /// Describes an HRESULT error or success condition.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay}")]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct HResult : IComparable, IComparable<HResult>, IEquatable<HResult>, IFormattable
    {
        #region Common HRESULT constants

        /// <summary>
        /// Operation successful, and returned a false result.
        /// </summary>
        public static readonly HResult S_FALSE = 1;

        /// <summary>
        /// Operation successful
        /// </summary>
        public static readonly HResult S_OK = 0;

        /// <summary>
        /// Unspecified failure
        /// </summary>
        public static readonly HResult E_FAIL = 0x80004005;

        /// <summary>
        /// Operation aborted
        /// </summary>
        public static readonly HResult E_ABORT = 0x80004004;

        /// <summary>
        /// General access denied error
        /// </summary>
        public static readonly HResult E_ACCESSDENIED = 0x80070005;

        /// <summary>
        /// Handle that is not valid
        /// </summary>
        public static readonly HResult E_HANDLE = 0x80070006;

        /// <summary>
        /// One or more arguments are not valid
        /// </summary>
        public static readonly HResult E_INVALIDARG = 0x80070057;

        /// <summary>
        /// No such interface supported
        /// </summary>
        public static readonly HResult E_NOINTERFACE = 0x80004002;

        /// <summary>
        /// Not implemented
        /// </summary>
        public static readonly HResult E_NOTIMPL = 0x80004001;

        /// <summary>
        /// Failed to allocate necessary memory
        /// </summary>
        public static readonly HResult E_OUTOFMEMORY = 0x8007000E;

        /// <summary>
        /// Pointer that is not valid
        /// </summary>
        public static readonly HResult E_POINTER = 0x80004003;

        /// <summary>
        /// Unexpected failure
        /// </summary>
        public static readonly HResult E_UNEXPECTED = 0x8000FFFF;

        #endregion

        /// <summary>
        /// The mask of the bits that describe the <see cref="Facility"/>.
        /// </summary>
        private const int FacilityMask = 0x7ff0000;

        /// <summary>
        /// The mask of the bits that describe the facility's status <see cref="Code"/>.
        /// </summary>
        private const int CodeMask = 0xffff;

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
        public int AsInt32 => this.value;

        /// <summary>
        /// Gets the HRESULT as a 32-bit unsigned integer.
        /// </summary>
        public uint AsUInt32 => (uint)this.value;

        /// <summary>
        /// Gets a value indicating whether this HRESULT represents a successful operation.
        /// </summary>
        public bool Succeeded => this.value >= 0;

        /// <summary>
        /// Gets a value indicating whether this HRESULT represents a failured operation.
        /// </summary>
        public bool Failed => this.value < 0;

        /// <summary>
        /// Gets the facility code bits from the HRESULT.
        /// </summary>
        public int Facility => this.value & FacilityMask;

        /// <summary>
        /// Gets the facility's status code bits from the HRESULT.
        /// </summary>
        public int Code => this.value & CodeMask;

        /// <summary>
        /// Gets the string to display in a data tip when debugging.
        /// </summary>
        private string DebuggerDisplay => this.ToString();

        /// <summary>
        /// Converts an <see cref="int"/> into an <see cref="HResult"/>.
        /// </summary>
        /// <param name="hr">The value of the HRESULT.</param>
        public static implicit operator HResult(int hr)
        {
            return new HResult(hr);
        }

        /// <summary>
        /// Converts an <see cref="HResult"/> into an <see cref="int"/>.
        /// </summary>
        /// <param name="hr">The value of the HRESULT.</param>
        public static implicit operator int(HResult hr)
        {
            return hr.value;
        }

        /// <summary>
        /// Converts an <see cref="uint"/> into an <see cref="HResult"/>.
        /// </summary>
        /// <param name="hr">The value of the HRESULT.</param>
        public static implicit operator HResult(uint hr)
        {
            return new HResult((int)hr);
        }

        /// <summary>
        /// Converts an <see cref="HResult"/> into an <see cref="uint"/>.
        /// </summary>
        /// <param name="hr">The value of the HRESULT.</param>
        public static explicit operator uint(HResult hr)
        {
            return (uint)hr.value;
        }

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
        public bool Equals(HResult other)
        {
            return this.value == other.value;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is HResult && this.Equals((HResult)obj);
        }

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
