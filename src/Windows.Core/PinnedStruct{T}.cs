// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Allocate a structure on the heap and pin it in place, allowing a controlled release (Via
    /// <see cref="PinnedStruct{T}.Dispose" />).
    /// </summary>
    /// <typeparam name="T">Type of the structure that will be pinned.</typeparam>
    public class PinnedStruct<T> : IDisposable
        where T : struct
    {
        private readonly IntPtr intPtr;

        private bool disposed;
        private GCHandle? gcHandle;

        public PinnedStruct(T? value)
        {
            if (value.HasValue)
            {
                object box = value.Value;
                this.gcHandle = GCHandle.Alloc(box, GCHandleType.Pinned);
                this.intPtr = this.gcHandle.Value.AddrOfPinnedObject();
            }

            this.disposed = false;
        }

        ~PinnedStruct()
        {
            this.Free();
        }

        /// <summary>
        /// Get a pointer to the value on the heap if this instance hold a value or <see cref="IntPtr.Zero" /> otherwise.
        /// </summary>
        public IntPtr IntPtr
        {
            get
            {
                this.ThrowIfDisposed();
                return this.intPtr;
            }
        }

        /// <summary>
        /// Get if this instance hold a value.
        /// </summary>
        public bool HasValue
        {
            get
            {
                this.ThrowIfDisposed();
                return this.gcHandle.HasValue;
            }
        }

        /// <summary>
        /// Get a copy of the value currently pinned by this instance if it exists.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// If this instance doesn't hold a value (<see cref="HasValue" /> =
        /// <see langword="false" />)
        /// </exception>
        public T Value
        {
            get
            {
                this.ThrowIfDisposed();

                if (!this.gcHandle.HasValue)
                {
                    throw new InvalidOperationException("The PinnedStruct was created without a value");
                }

                return (T)this.gcHandle.Value.Target;
            }
        }

        /// <summary>
        /// Un-pin the object held by this instance.
        /// </summary>
        public void Dispose()
        {
            this.Free();

            this.disposed = true;
            GC.SuppressFinalize(this);
        }

        private void Free()
        {
            if (this.gcHandle.HasValue && !this.disposed)
            {
                this.gcHandle.Value.Free();
            }
        }

        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(nameof(PinnedStruct<T>));
            }
        }
    }
}