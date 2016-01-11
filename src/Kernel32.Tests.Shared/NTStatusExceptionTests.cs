// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.IO;
using PInvoke;
using Xunit;
using static PInvoke.Kernel32;

public partial class NTStatusExceptionTests
{
    [Fact]
    public void NTStatusException_StatusCode()
    {
        NTStatus error = NTStatus.Code.EPT_NT_INVALID_ENTRY;
        var ex = new NTStatusException(error);
        Assert.Equal(error, ex.StatusCode);
    }

    [Fact]
    public void NTStatusException_Message()
    {
        NTStatus error = NTStatus.Code.EPT_NT_INVALID_ENTRY;
        var ex = new NTStatusException(error);
#if DESKTOP
        Assert.Equal("The entry is invalid (NT_STATUS error: EPT_NT_INVALID_ENTRY)", ex.Message);
#else
        Assert.Equal("NT_STATUS error: EPT_NT_INVALID_ENTRY", ex.Message);
#endif
    }

    [Fact]
    public void NTStatusException_MessageNotFound()
    {
        NTStatus error = 0x11111111;
        var ex = new NTStatusException(error);
        Assert.Equal("NT_STATUS error: 0x11111111", ex.Message);
    }

    [Fact]
    public void NTStatusException_CodeAndMessage()
    {
        NTStatus error = NTStatus.Code.EPT_NT_INVALID_ENTRY;
        var ex = new NTStatusException(error, "msg");
        Assert.Equal(error, ex.StatusCode);
        Assert.Equal("msg", ex.Message);
    }
}
