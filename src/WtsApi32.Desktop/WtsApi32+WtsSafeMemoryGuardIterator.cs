// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <content>
    /// Exported functions from the WtsApi32.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    public static partial class WtsApi32
    {
        /// <summary>
        /// Iterator for iterating through memory returned by WtsApi32
        /// </summary>
        /// <typeparam name="TIteratorType">Element type</typeparam>
        internal struct WtsSafeMemoryGuardIterator<TIteratorType> : IEnumerator<TIteratorType>
        {
            private readonly IntPtr start;
            private readonly int underlyingTypeSize;
            private int index;

            public WtsSafeMemoryGuardIterator(IntPtr start)
            {
                this.start = start;
                this.index = -1;
                this.underlyingTypeSize = Marshal.SizeOf(typeof(TIteratorType));
            }

            public TIteratorType Current
            {
                get
                {
                    return (TIteratorType)Marshal.PtrToStructure(this.start + (this.index * this.underlyingTypeSize), typeof(TIteratorType));
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Marshal.PtrToStructure(this.start + (this.index * this.underlyingTypeSize), typeof(TIteratorType));
                }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                ++this.index;
                return true;
            }

            public void Reset()
            {
                this.index = -1;
            }
        }
    }
}
