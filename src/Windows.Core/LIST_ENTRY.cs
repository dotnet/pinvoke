// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes a link in a doubly-linked list.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [OfferIntPtrPropertyAccessors]
    public unsafe partial struct LIST_ENTRY
    {
        public LIST_ENTRY* Flink;
        public LIST_ENTRY* Blink;
    }
}
