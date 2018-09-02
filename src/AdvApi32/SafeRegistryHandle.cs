// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if NET20 || NETSTANDARD1_1 || PROFILE92 || PROFILE111

namespace Microsoft.Win32.SafeHandles
{
    using System;
    using PInvoke;
    using static PInvoke.AdvApi32;

    // This must have no more than the public API that is exposed by net40
    // because on that platform we type forward to it.
    public sealed class SafeRegistryHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public SafeRegistryHandle(IntPtr preexistingHandle, bool ownsHandle)
            : base(ownsHandle)
        {
            this.SetHandle(preexistingHandle);
        }

        internal SafeRegistryHandle()
            : base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            return RegCloseKey(this.handle) == Win32ErrorCode.ERROR_SUCCESS;
        }
    }
}

#else

// We must type forward so that folks who compiled against our net20 library
// can still run when linking against a net40 library at runtime.
using System.Runtime.CompilerServices;
using Microsoft.Win32.SafeHandles;

[assembly: TypeForwardedTo(typeof(SafeRegistryHandle))]

#endif
