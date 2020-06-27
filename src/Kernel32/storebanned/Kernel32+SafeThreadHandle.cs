// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#pragma warning disable SA1625 // Element documentation must not be copied and pasted

namespace PInvoke
{
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;

    /// <summary>
    /// Contains definition for <see cref="SafeThreadHandle"/>
    /// </summary>
    public partial class Kernel32
    {
        /// <summary>
        /// A <see cref="SafeHandle"/> for thread handles.
        /// </summary>
        public class SafeThreadHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            public SafeThreadHandle()
                : base(ownsHandle: true)
            {
            }

            protected override bool ReleaseHandle()
            {
                return Kernel32.CloseHandle(this.handle);
            }
        }
    }
}
