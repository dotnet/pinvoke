// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Nullable wrapper for a <see cref="Guid" /> that can be used with <see cref="DllImportAttribute" /> in place of a
    /// Nullable&lt;Guid&gt;.
    /// Explicit cast operators exists to convert to and from Nullable&lt;Guid&gt; or <see cref="Guid" />.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1401:Fields must be private",
        Justification = "Used in DllImport Marshaling.")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class NullableGuid
    {
        public Guid Value;

        public NullableGuid()
        {
        }

        public NullableGuid(Guid value)
        {
            this.Value = value;
        }

        public static explicit operator NullableGuid(Guid value)
        {
            return new NullableGuid(value);
        }

        public static explicit operator NullableGuid(Guid? value)
        {
            return value.HasValue ? new NullableGuid(value.Value) : null;
        }

        public static explicit operator Guid(NullableGuid value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return value.Value;
        }

        public static explicit operator Guid? (NullableGuid value)
        {
            return value?.Value;
        }
    }
}