// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if WINDOWS8 || WINDOWS_UWP

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

#endif
