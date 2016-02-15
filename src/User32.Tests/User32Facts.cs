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
}
