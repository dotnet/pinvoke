// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct LIST_ENTRY
    {
        public LIST_ENTRY* Flink;
        public LIST_ENTRY* Blink;
    }
}
