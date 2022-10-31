// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using PInvoke;
using Xunit;

public class SP_DEVINFO_DATAFacts
{
    [Fact]
    public void Size_Test()
    {
        var value = SetupApi.SP_DEVINFO_DATA.Create();

        if (Environment.Is64BitProcess)
        {
            Assert.Equal(0x20, value.Size);
        }
        else
        {
            Assert.Equal(0x1c, value.Size);
        }
    }
}
