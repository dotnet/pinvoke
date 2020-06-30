// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using PInvoke;
using Xunit;

public class SP_DRVINFO_DATAFacts
{
    [Fact]
    public void Size_Test()
    {
        var value = SetupApi.SP_DRVINFO_DATA.Create();

        if (Environment.Is64BitProcess)
        {
            Assert.Equal(0x620, value.cbSize);
        }
        else
        {
            Assert.Equal(0x61c, value.cbSize);
        }
    }
}
