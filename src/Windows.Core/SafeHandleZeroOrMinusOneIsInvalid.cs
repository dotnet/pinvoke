// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if NETSTANDARD1_1 || PROFILE92 || PROFILE111

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

#else

// We must type forward so that folks who compiled against our net20 library
// can still run when linking against a net40 library at runtime.
using System.Runtime.CompilerServices;
using Microsoft.Win32.SafeHandles;

[assembly: TypeForwardedTo(typeof(SafeHandleZeroOrMinusOneIsInvalid))]

#endif
