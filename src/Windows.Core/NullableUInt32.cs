// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Nullable wrapper for a <see cref="uint" /> that can be used with <see cref="DllImportAttribute" /> in place of a
    /// Nullable&lt;UInt32&gt;.
    /// Explicit cast operators exists to convert to and from Nullable&lt;UInt32&gt; or <see cref="uint" />.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1401:Fields must be private",
        Justification = "Used in DllImport Marshaling.")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class NullableUInt32
    {
        public uint Value;

        public NullableUInt32()
        {
        }

        public NullableUInt32(uint value)
        {
            this.Value = value;
        }

        public static explicit operator NullableUInt32(uint value)
        {
            return new NullableUInt32(value);
        }

        public static explicit operator NullableUInt32(uint? value)
        {
            return value.HasValue ? new NullableUInt32(value.Value) : null;
        }

        public static explicit operator uint (NullableUInt32 value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return value.Value;
        }

        public static explicit operator uint? (NullableUInt32 value)
        {
            return value?.Value;
        }
    }
}