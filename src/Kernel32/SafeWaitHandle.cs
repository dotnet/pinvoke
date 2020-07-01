// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if NETPORTABLE || WINDOWS8 || WINDOWS_UWP

namespace Microsoft.Win32.SafeHandles
{
    using System;

    public sealed class SafeWaitHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public SafeWaitHandle(IntPtr existingHandle, bool ownsHandle)
            : base(ownsHandle)
        {
            this.SetHandle(existingHandle);
        }

        protected override bool ReleaseHandle()
        {
            return PInvoke.Kernel32.CloseHandle(this.handle);
        }
    }
}

#else

// We must type forward so that folks who compiled against our net20 library
// can still run when linking against a net40 library at runtime.
using System.Runtime.CompilerServices;
using Microsoft.Win32.SafeHandles;

[assembly: TypeForwardedTo(typeof(SafeWaitHandle))]

#endif
