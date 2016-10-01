using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PInvoke
{
    public static partial class WtsApi32
    {
        public partial class WtsSafeMemoryGuard<TGuardType> : SafeHandle, IEnumerable<TGuardType>
        {
            internal struct WtsSafeMemoryGuardIterator<TIteratorType> : IEnumerator<TIteratorType>
            {
                private readonly IntPtr start;
                private int index;
                private readonly int underlyingTypeSize;

                public WtsSafeMemoryGuardIterator(IntPtr start)
                {
                    this.start = start;
                    this.index = 0;
                    this.underlyingTypeSize = Marshal.SizeOf(typeof(TIteratorType));
                }

                public TIteratorType Current
                {
                    get
                    {
                        return (TIteratorType)Marshal.PtrToStructure(this.start + index * underlyingTypeSize, typeof(TIteratorType));
                    }
                }

                object IEnumerator.Current
                {
                    get
                    {
                        return Marshal.PtrToStructure(this.start + index * underlyingTypeSize, typeof(TIteratorType));
                    }
                }

                public void Dispose()
                {
                }

                public bool MoveNext()
                {
                    ++index;
                    return true;
                }

                public void Reset()
                {
                    index = 0;
                }
            }
        }
    }
}
