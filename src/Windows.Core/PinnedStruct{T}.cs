// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Allocate a structure on the heap and pin it in place, allowing a controlled release (Via
    /// <see cref="PinnedStruct{T}.Dispose()" />).
    /// </summary>
    /// <typeparam name="T">Type of the structure that will be pinned.</typeparam>
    public class PinnedStruct<T> : IDisposable
        where T : struct
    {
        /// <summary>
        /// The fixed pointer to the struct, or <see cref="IntPtr.Zero"/> if no struct was provided.
        /// </summary>
        private readonly IntPtr intPtr;

        /// <summary>
        /// A value indicating whether this instance has already been disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The handle that is pinning <see cref="Value"/> in memory.
        /// </summary>
        private GCHandle? gcHandle;

        /// <summary>
        /// Initializes a new instance of the <see cref="PinnedStruct{T}"/> class.
        /// </summary>
        /// <param name="value">The optional struct to pass to native code.</param>
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

        /// <summary>
        /// Finalizes an instance of the <see cref="PinnedStruct{T}"/> class.
        /// </summary>
        ~PinnedStruct()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets a pointer to the value on the heap if this instance holds a value
        /// or <see cref="IntPtr.Zero" /> otherwise.
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
        /// Get a value indicating whether this instance was initialized with a value.
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
            this.Dispose(true);
        }

        /// <summary>
        /// Disposes of managed and native resources owned by this instance.
        /// </summary>
        /// <param name="disposing"><c>true</c> if this object is being disposed of; <c>false</c> if the object is being finalized.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.gcHandle.HasValue && !this.disposed)
            {
                this.gcHandle.Value.Free();
            }

            if (disposing)
            {
                this.disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Throws an <see cref="ObjectDisposedException"/> if this instance has already been disposed.
        /// </summary>
        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(nameof(PinnedStruct<T>));
            }
        }
    }
}