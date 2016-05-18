// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="MOUSEINPUT"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Contains information about a simulated mouse event.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public MOUSEEVENTF dwFlags;
            public int time;
            public void* dwExtraInfo;
        }
    }
}