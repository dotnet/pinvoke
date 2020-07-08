// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#pragma warning disable SA1202 // Elements must be ordered by access
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1303 // Const field names must begin with upper-case letter

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using Validation;

    /// <content>
    /// Contains the <see cref="DISPLAYCONFIG_VIDEO_SIGNAL_INFO"/> nested type.
    /// </content>
    public partial class User32
    {
        public struct DISPLAYCONFIG_ADDITIONAL_SIGNAL_INFO
        {
            private const int vSyncFreqDividerBitMask = 0x3f;

            public ushort videoStandard;

            private ushort split;

            public int vSyncFreqDivider
            {
                get
                {
                    return this.split & vSyncFreqDividerBitMask;
                }

                set
                {
                    Requires.Range(value <= vSyncFreqDividerBitMask, nameof(value));
                    this.split = (ushort)((this.split & ~vSyncFreqDividerBitMask) | value);
                }
            }
        }
    }
}
