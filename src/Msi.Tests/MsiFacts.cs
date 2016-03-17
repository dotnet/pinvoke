// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using PInvoke;
using Xunit;
using static PInvoke.Msi;

public class MsiFacts
{
    [Fact]
    public void InstallProduct_BadArgs()
    {
        Win32ErrorCode result = MsiInstallProduct(null, null);
        Assert.Equal(Win32ErrorCode.ERROR_INVALID_PARAMETER, result);
    }
}
