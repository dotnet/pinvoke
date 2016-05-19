// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SHITEMID"/> nested type.
    /// </content>
    public partial class Shell32
    {
        /// <summary>
        /// Defines an item identifier.
        /// </summary>
        /// <remarks>Used by <see cref="ITEMIDLIST"/></remarks>
        [StructLayout(LayoutKind.Sequential)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct SHITEMID
        {
            /// <summary>
            /// The size of identifier, in bytes, including <see cref="cb"/> itself.
            /// </summary>
            public ushort cb;

            /// <summary>
            /// A variable-length item identifier.
            /// </summary>
            public fixed byte abID[1];

            /// <summary>
            /// Gets or sets the byte at a given index within the <see cref="abID"/> buffer.
            /// </summary>
            /// <param name="index">The index, which must be less than <see cref="cb"/>.</param>
            /// <returns>The byte at the given index.</returns>
            public unsafe byte this[int index]
            {
                get
                {
                    if (index >= this.cb)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    fixed (byte* pabID = this.abID)
                    {
                        return *(pabID + index);
                    }
                }

                set
                {
                    if (index >= this.cb)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    fixed (byte* pabID = this.abID)
                    {
                        *(pabID + index) = value;
                    }
                }
            }

            /// <summary>
            /// Allocates and initializes an <see cref="SHITEMID"/> structure.
            /// Free the struct when done using the <see cref="Free(SHITEMID*)"/> method.
            /// </summary>
            /// <param name="size">The number of bytes to allocate for the buffer.</param>
            /// <returns>A pointer to the allocated structure, with its <see cref="cb"/> member initialized.</returns>
            public static unsafe SHITEMID* Create(ushort size)
            {
                ushort totalSize = checked((ushort)(sizeof(ushort) + size));
                var result = (SHITEMID*)Marshal.AllocHGlobal(totalSize);
                result->cb = totalSize;
                return result;
            }

            /// <summary>
            /// Allocates and initializes an <see cref="SHITEMID"/> structure.
            /// Free the struct when done using the <see cref="Free(SHITEMID*)"/> method.
            /// </summary>
            /// <param name="content">The data to initialize the struct with..</param>
            /// <returns>A pointer to the allocated structure, with its <see cref="cb"/> and <see cref="abID"/> members initialized.</returns>
            public static unsafe SHITEMID* Create(byte[] content)
            {
                ushort totalSize = checked((ushort)(sizeof(ushort) + content.Length));
                var result = (SHITEMID*)Marshal.AllocHGlobal(totalSize);
                result->cb = totalSize;
                Marshal.Copy(content, 0, new IntPtr(&result->abID[0]), content.Length);
                return result;
            }

            /// <summary>
            /// Frees memory allocated by <see cref="Create(ushort)"/>.
            /// Use <see cref="ILFree(void*)"/> when this struct was obtained from native code.
            /// </summary>
            /// <param name="value">The pointer to the struct to be freed.</param>
            public static unsafe void Free(SHITEMID* value)
            {
                Marshal.FreeHGlobal(new IntPtr(value));
            }

            /// <summary>
            /// Copies the buffer held by this structure to a managed byte array.
            /// </summary>
            /// <returns>The managed byte array.</returns>
            public byte[] GetCopy()
            {
                var length = this.cb - sizeof(ushort);
                var result = new byte[length];
                fixed (byte* pabID = this.abID)
                {
                    Marshal.Copy((IntPtr)pabID, result, 0, length);
                }

                return result;
            }
        }
    }
}