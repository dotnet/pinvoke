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
        /// Guard for Session info retreived from <see cref="WTSEnumerateSessions(IntPtr, int, int, ref WtsSafeSessionInfoGuard, ref int)"/>
        /// </summary>
        public partial class WtsSafeSessionInfoGuard : WtsSafeMemoryGuard, IEnumerable<WTS_SESSION_INFO>
        {
            public WtsSafeSessionInfoGuard()
                : base()
            {
            }

            public WtsSafeSessionInfoGuard(IntPtr invalidHandleValue, bool ownsHandle)
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

            public IEnumerator<WTS_SESSION_INFO> GetEnumerator()
            {
                return new WtsSafeMemoryGuardIterator<WTS_SESSION_INFO>(this.handle);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new WtsSafeMemoryGuardIterator<WTS_SESSION_INFO>(this.handle);
            }
        }
    }
}
