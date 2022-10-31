// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using PInvoke;
using Xunit;

public class PInvokeExtensionsFacts
{
    [Fact]
    public void ToHResult_FromNTStatus()
    {
        NTSTATUS duplicate = NTSTATUS.Code.STATUS_DUPLICATE_OBJECTID;
        Assert.Equal(0xD000022A, duplicate.ToHResult());
    }

    [Fact]
    public void ToHResult_FromWin32ErrorCode()
    {
        Assert.Equal(0x80071392, Win32ErrorCode.ERROR_OBJECT_ALREADY_EXISTS.ToHResult());
    }
}
