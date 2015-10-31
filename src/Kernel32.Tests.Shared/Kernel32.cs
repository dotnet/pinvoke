// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.IO;
using PInvoke;
using Xunit;
using static PInvoke.Kernel32;

public partial class Kernel32
{
    [Fact]
    public void Win32Exception_NativeErrorCode()
    {
        int error = unchecked((int)NTStatus.RPC_NT_CALL_FAILED);
        var ex = new Win32Exception(error);
        Assert.Equal(error, ex.NativeErrorCode);
    }

    [Fact]
    public void Win32Exception_Message()
    {
        int error = unchecked((int)NTStatus.RPC_NT_CALL_FAILED);
        var ex = new Win32Exception(error);
        Assert.Equal("Unknown error (0xc002001b)", ex.Message);
    }

    [Fact]
    public void Win32Exception_CodeAndMessage()
    {
        int error = unchecked((int)NTStatus.RPC_NT_CALL_FAILED);
        var ex = new Win32Exception(error, "msg");
        Assert.Equal(error, ex.NativeErrorCode);
        Assert.Equal("msg", ex.Message);
    }
}
