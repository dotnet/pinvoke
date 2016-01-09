﻿// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using PInvoke;
using Xunit;

public partial class Kernel32ExtensionsTests
{
    [Fact]
    public void ThrowOnError_Win32ErrorCode()
    {
        Win32ErrorCode success = Win32ErrorCode.ERROR_SUCCESS;
        success.ThrowOnError();
        Win32ErrorCode failure = Win32ErrorCode.ERROR_FAIL_NOACTION_REBOOT;
        Assert.Throws<Win32Exception>(() => failure.ThrowOnError());

        try
        {
            failure.ThrowOnError();
            Assert.False(true, "Expected exception not thrown.");
        }
        catch (Win32Exception ex)
        {
            Assert.Equal("No action was taken as a system reboot is required", ex.Message);
        }
    }

    [Fact]
    public void ThrowOnError_NTStatus()
    {
        NTStatus success = NTStatus.STATUS_SUCCESS;
        success.ThrowOnError();
        NTStatus failure = NTStatus.RPC_NT_CALL_FAILED;
        Assert.Throws<NTStatusException>(() => failure.ThrowOnError());

        try
        {
            failure.ThrowOnError();
            Assert.False(true, "Expected exception not thrown.");
        }
        catch (NTStatusException ex)
        {
#if DESKTOP
            Assert.Equal("The remote procedure call failed", ex.Message);
#else
            Assert.Equal("Unknown NT_STATUS error (0xc002001b)", ex.Message);
#endif
        }
    }
}