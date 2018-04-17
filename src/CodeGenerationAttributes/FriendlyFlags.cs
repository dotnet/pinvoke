// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    [Flags]
    public enum FriendlyFlags
    {
        Array = 0x1,

        In = 0x2,

        Out = 0x4,

        Optional = 0x8,

        Bidirectional = In | Out,
    }
}
