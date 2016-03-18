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

    [Fact]
    public void IsProductElevated_BadArgs()
    {
        Guid productCode = Guid.Empty;
        bool elevated;
        Win32ErrorCode result = MsiIsProductElevated(productCode, out elevated);
        Assert.Equal(Win32ErrorCode.ERROR_UNKNOWN_PRODUCT, result);
    }

    [Fact]
    public unsafe void EnumProductsEx()
    {
        Guid installedProductCode;
        string sid;
        MSIINSTALLCONTEXT installedContext;
        Win32ErrorCode result = MsiEnumProductsEx(
            null,
            null,
            MSIINSTALLCONTEXT.MSIINSTALLCONTEXT_ALL,
            0,
            out installedProductCode,
            out installedContext,
            out sid);
        Assert.Equal(Win32ErrorCode.ERROR_SUCCESS, result);
    }
}
