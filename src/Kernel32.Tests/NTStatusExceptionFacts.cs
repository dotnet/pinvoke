// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.IO;
using PInvoke;
using Xunit;
using static PInvoke.Kernel32;

public partial class NTStatusExceptionFacts
{
    [Fact]
    [UseCulture("en-US")]
    public void NTStatusException_NativeErrorCode()
    {
        NTSTATUS error = NTSTATUS.Code.EPT_NT_INVALID_ENTRY;
        var ex = new NTStatusException(error);
        Assert.Equal(error, ex.NativeErrorCode);
    }

    [Fact]
    [UseCulture("en-US")]
    public void NTStatusException_Error_Message()
    {
        NTSTATUS error = NTSTATUS.Code.EPT_NT_INVALID_ENTRY;
        var ex = new NTStatusException(error);
#if DESKTOP
        Assert.Equal("The entry is invalid (NT_STATUS error: EPT_NT_INVALID_ENTRY (0xC0020034))", ex.Message);
#else
        Assert.Equal("NT_STATUS error: EPT_NT_INVALID_ENTRY (0xC0020034)", ex.Message);
#endif
    }

    [Fact]
    [UseCulture("en-US")]
    public void NTStatusException_Warning_Message()
    {
        NTSTATUS error = NTSTATUS.Code.STATUS_BUFFER_OVERFLOW;
        var ex = new NTStatusException(error);
#if DESKTOP
        Assert.Equal("{Buffer Overflow}\r\nThe data was too large to fit into the specified buffer (NT_STATUS warning: STATUS_BUFFER_OVERFLOW (0x80000005))", ex.Message);
#else
        Assert.Equal("NT_STATUS warning: STATUS_BUFFER_OVERFLOW (0x80000005)", ex.Message);
#endif
    }

    [Fact]
    [UseCulture("en-US")]
    public void NTStatusException_Informational_Message()
    {
        NTSTATUS error = NTSTATUS.Code.STATUS_WAKE_SYSTEM;
        var ex = new NTStatusException(error);
#if DESKTOP
        Assert.Equal("The system has awoken (NT_STATUS information: STATUS_WAKE_SYSTEM (0x40000294))", ex.Message);
#else
        Assert.Equal("NT_STATUS information: STATUS_WAKE_SYSTEM (0x40000294)", ex.Message);
#endif
    }

    [Fact]
    [UseCulture("en-US")]
    public void NTStatusException_Success_Message()
    {
        NTSTATUS error = NTSTATUS.Code.STATUS_PENDING;
        var ex = new NTStatusException(error);
#if DESKTOP
        Assert.Equal("The operation that was requested is pending completion (NT_STATUS success: STATUS_PENDING (0x00000103))", ex.Message);
#else
        Assert.Equal("NT_STATUS success: STATUS_PENDING (0x00000103)", ex.Message);
#endif
    }

    [Fact]
    public void NTStatusException_MessageNotFound()
    {
        NTSTATUS error = 0xC1111111;
        var ex = new NTStatusException(error);
        Assert.Equal("NT_STATUS error: 0xC1111111", ex.Message);
    }

    [Fact]
    public void NTStatusException_CodeAndMessage()
    {
        NTSTATUS error = NTSTATUS.Code.EPT_NT_INVALID_ENTRY;
        var ex = new NTStatusException(error, "msg");
        Assert.Equal(error, ex.NativeErrorCode);
        Assert.Equal("msg", ex.Message);
    }
}
