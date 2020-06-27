// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The maximum number of bytes to which a pointer can point.
    /// Use for a count that must span the full range of a pointer.
    /// </summary>
    /// <remarks>
    /// This struct is intended for P/Invoke marshaling and must exactly match
    /// the size of <see cref="IntPtr"/>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE_T
    {
        private IntPtr size;

        /// <summary>
        /// Initializes a new instance of the <see cref="SIZE_T"/> struct.
        ///
        /// Provides special handling for <paramref name="size"/> value 0
        /// by optimizing it to use <see cref="IntPtr.Zero"/>
        /// </summary>
        /// <param name="size">Win32 SIZE_T value represented by this instance</param>
        public SIZE_T(ulong size)
        {
            if (size == 0)
            {
                this.size = IntPtr.Zero;
            }
            else
            {
                this.size = new IntPtr((long)size);
            }
        }

        /// <summary>
        /// Gets special constant for (SIZE_T)0
        /// </summary>
        /// <remarks>
        /// Intentionally not backed by a field to limit struct-size bloat; also
        /// see remarks for <see cref="SIZE_T"/>.
        /// </remarks>
        public static SIZE_T Zero => new SIZE_T(0);

        /// <summary>
        /// Casts to a ulong
        /// </summary>
        /// <param name="size">Value to be converted to ulong</param>
        public static explicit operator ulong(SIZE_T size)
        {
            return (ulong)size.size.ToInt64();
        }
    }
}
