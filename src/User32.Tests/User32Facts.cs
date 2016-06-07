// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using PInvoke;
using Xunit;
using static PInvoke.User32;

public partial class User32Facts
{
    [Fact]
    public void MessageBeep_Asterisk()
    {
        Assert.True(MessageBeep(MessageBeepType.MB_ICONASTERISK));
    }

    [Fact]
    public void INPUT_Union()
    {
        INPUT i = default(INPUT);
        i.type = InputType.INPUT_HARDWARE;

        // Assert that the first field (type) has its own memory space.
        Assert.Equal(0u, i.hi.uMsg);
        Assert.Equal(0, (int)i.ki.wScan);
        Assert.Equal(0, i.mi.dx);

        // Assert that these three fields (hi, ki, mi) share memory space.
        i.hi.uMsg = 1;
        Assert.Equal(1, (int)i.ki.wVk);
        Assert.Equal(1, i.mi.dx);
    }
}
