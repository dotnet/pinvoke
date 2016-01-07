// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using PInvoke;
using Xunit;

public class PInvokeExtensionsTests
{
    [Fact]
    public void ToHResult_FromNTStatus()
    {
        Assert.Equal(0xD000022A, NTStatus.STATUS_DUPLICATE_OBJECTID.ToHResult());
    }

    [Fact]
    public void ToHResult_FromWin32ErrorCode()
    {
        Assert.Equal(0x80071392, Win32ErrorCode.ERROR_OBJECT_ALREADY_EXISTS.ToHResult());
    }

    [Fact]
    public void ThrowOnError_NTStatus()
    {
        NTStatus.STATUS_SUCCESS.ThrowOnError();
        Assert.Throws<COMException>(() => NTStatus.RPC_NT_CALL_FAILED.ThrowOnError());
    }
}
