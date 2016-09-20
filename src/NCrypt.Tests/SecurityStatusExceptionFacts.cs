// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PInvoke;
using Xunit;
using static PInvoke.NCrypt;

public class SecurityStatusExceptionFacts
{
    [Fact]
    public void SecurityStatusException_NativeErrorCode()
    {
        SECURITY_STATUS error = SECURITY_STATUS.NTE_BAD_DATA;
        var ex = new SecurityStatusException(error);
        Assert.Equal(error, ex.NativeErrorCode);
    }

    [Fact]
    [UseCulture("en-US")]
    public void SecurityStatusException_Error_Message()
    {
        SECURITY_STATUS error = SECURITY_STATUS.NTE_BAD_DATA;
        var ex = new SecurityStatusException(error);
#if DESKTOP
        Assert.Equal("Bad Data (SECURITY_STATUS error: NTE_BAD_DATA (0x80090005))", ex.Message);
#else
        Assert.Equal("SECURITY_STATUS error: NTE_BAD_DATA (0x80090005)", ex.Message);
#endif
    }

    [Fact]
    [UseCulture("en-US")]
    public void SecurityStatusException_Success_Message()
    {
        SECURITY_STATUS error = SECURITY_STATUS.ERROR_SUCCESS;
        var ex = new SecurityStatusException(error);
#if DESKTOP
        Assert.Equal("The operation completed successfully (SECURITY_STATUS success: ERROR_SUCCESS (0x00000000))", ex.Message);
#else
        Assert.Equal("SECURITY_STATUS success: ERROR_SUCCESS (0x00000000)", ex.Message);
#endif
    }

    [Fact]
    public void SecurityStatusException_MessageNotFound()
    {
        SECURITY_STATUS error = (SECURITY_STATUS)0xC1111111;
        var ex = new SecurityStatusException(error);
        Assert.Equal("SECURITY_STATUS error: 0xC1111111", ex.Message);
    }

    [Fact]
    public void SecurityStatusException_CodeAndMessage()
    {
        SECURITY_STATUS error = SECURITY_STATUS.NTE_BAD_DATA;
        var ex = new SecurityStatusException(error, "msg");
        Assert.Equal(error, ex.NativeErrorCode);
        Assert.Equal("msg", ex.Message);
    }
}
