// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using PInvoke;
using Xunit;
using static PInvoke.Kernel32;

public class Kernel32
{
    [Fact]
    public void FindFiles()
    {
        WIN32_FIND_DATA data;
        using (var handle = FindFirstFile("foodoesnotexist", out data))
        {
            Assert.True(handle.IsInvalid);
        }
    }
}
