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
            public WtsSafeMemoryGuard()
                :base(IntPtr.Zero, false)
            {
            }

            public WtsSafeMemoryGuard(IntPtr invalidHandleValue, bool ownsHandle) 
                : base(invalidHandleValue, ownsHandle)
            {
            }

            public override bool IsInvalid
            {
                get
                {
                    return this.handle == IntPtr.Zero;
                }
            }

            public IEnumerator<TGuardType> GetEnumerator()
            {
                return new WtsSafeMemoryGuardIterator<TGuardType>(this.handle);
            }

            protected override bool ReleaseHandle()
            {
                WTSFreeMemory(this.handle);
                return true;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new WtsSafeMemoryGuardIterator<TGuardType>(this.handle);
            }
        }
    }
}
