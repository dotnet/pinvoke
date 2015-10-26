// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using Microsoft.Win32.SafeHandles;

    public static partial class Hid
    {
        public class SafePreparsedDataHandle : SafeHandleMinusOneIsInvalid
        {
            public SafePreparsedDataHandle() : base(true)
            {

            }

            public SafePreparsedDataHandle(IntPtr preexistingHandle, bool ownsHandle) : base(ownsHandle)
            {
                handle = preexistingHandle;
            }

            protected override bool ReleaseHandle() => HidD_FreePreparsedData(this);
        }
    }
}