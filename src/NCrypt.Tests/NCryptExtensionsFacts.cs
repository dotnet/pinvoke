// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using PInvoke;
using Xunit;
using static PInvoke.NCrypt;

public class NCryptExtensionsFacts
{
    [Fact]
    [UseCulture("en-US")]
    public void GetMessage_SecurityStatus()
    {
        SECURITY_STATUS status = SECURITY_STATUS.NTE_BAD_DATA;
        Assert.Equal("Bad Data", status.GetMessage());
    }

    [Fact]
    public void ThrowOnError_OnSuccess()
    {
        SECURITY_STATUS.ERROR_SUCCESS.ThrowOnError();
    }

    [Fact]
    [UseCulture("en-US")]
    public void ThrowOnError_Failure()
    {
        SECURITY_STATUS status = SECURITY_STATUS.NTE_BAD_DATA;
        try
        {
            status.ThrowOnError();
            Assert.False(true, "Expected exception not thrown.");
        }
        catch (SecurityStatusException ex)
        {
            Assert.Equal("Bad Data (SECURITY_STATUS error: NTE_BAD_DATA (0x80090005))", ex.Message);
        }
    }
}
