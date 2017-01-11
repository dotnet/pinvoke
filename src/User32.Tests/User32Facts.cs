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
        Assert.Equal(0u, i.Inputs.hi.uMsg);
        Assert.Equal(0, (int)i.Inputs.ki.wScan);
        Assert.Equal(0, i.Inputs.mi.dx);

        // Assert that these three fields (hi, ki, mi) share memory space.
        i.Inputs.hi.uMsg = 1;
        Assert.Equal(1, (int)i.Inputs.ki.wVk);
        Assert.Equal(1, i.Inputs.mi.dx);
    }

    /// <summary>
    /// Validates that the union fields are all exactly 4 bytes (or 8 bytes on x64)
    /// after the start of the struct.
    /// </summary>
    /// <devremarks>
    /// From http://www.pinvoke.net/default.aspx/Structures/INPUT.html:
    /// The last 3 fields are a union, which is why they are all at the same memory offset.
    /// On 64-Bit systems, the offset of the <see cref="mi"/>, <see cref="ki"/> and <see cref="hi"/> fields is 8,
    /// because the nested struct uses the alignment of its biggest member, which is 8
    /// (due to the 64-bit pointer in <see cref="KEYBDINPUT.dwExtraInfo"/>).
    /// By separating the union into its own structure, rather than placing the
    /// <see cref="mi"/>, <see cref="ki"/> and <see cref="hi"/> fields directly in the INPUT structure,
    /// we assure that the .NET structure will have the correct alignment on both 32 and 64 bit.
    /// </devremarks>
    [Fact]
    public unsafe void INPUT_UnionMemoryAlignment()
    {
        INPUT input;
        Assert.Equal(IntPtr.Size, (long)&input.Inputs.hi - (long)&input);
        Assert.Equal(IntPtr.Size, (long)&input.Inputs.mi - (long)&input);
        Assert.Equal(IntPtr.Size, (long)&input.Inputs.ki - (long)&input);
    }
}
