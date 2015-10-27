// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Allocate a structure on the heap and pin it in place, allowing a controlled release (Via Dispose).
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
            else
            {
                this.gcHandle = null;
                this.intPtr = IntPtr.Zero;
            }

            this.disposed = false;
        }

        public IntPtr IntPtr
        {
            get
            {
                this.ThrowIfDisposed();
                return this.intPtr;
            }
        }

        public bool HasValue
        {
            get
            {
                this.ThrowIfDisposed();
                return this.gcHandle.HasValue;
            }
        }

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

        public void Dispose()
        {
            if (this.gcHandle.HasValue && !this.disposed)
            {
                this.gcHandle.Value.Free();
            }

            this.disposed = true;
        }

        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException("PinnedStruct");
            }
        }
    }
}