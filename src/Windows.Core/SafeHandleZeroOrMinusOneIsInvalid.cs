// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if NETFRAMEWORK || NETSTANDARD2_0_ORLATER

// We must type forward so that folks who compiled against our netstandard1.x library
// can still run when linking against a more recent library at runtime.
using System.Runtime.CompilerServices;
using Microsoft.Win32.SafeHandles;

[assembly: TypeForwardedTo(typeof(SafeHandleZeroOrMinusOneIsInvalid))]

#else

namespace Microsoft.Win32.SafeHandles
{
    using System;
    using System.Runtime.InteropServices;

    public abstract class SafeHandleZeroOrMinusOneIsInvalid : SafeHandle
    {
        protected SafeHandleZeroOrMinusOneIsInvalid(bool ownsHandle)
            : base(IntPtr.Zero, ownsHandle)
        {
        }

        public override bool IsInvalid => this.handle == IntPtr.Zero || this.handle == new IntPtr(-1);
    }
}
#endif
