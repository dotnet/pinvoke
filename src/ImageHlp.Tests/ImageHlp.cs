// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using PInvoke;
using Xunit;
using static PInvoke.DbgHelp;
using static PInvoke.ImageHlp;

public class ImageHlp
{
    [Fact(Skip = "Fails on appveyor")]
    public void MapAndLoadTest()
    {
        LOADED_IMAGE imageData;
        Assert.True(MapAndLoad("kernel32.dll", null, out imageData, true, true));
        try
        {
            Assert.True(imageData.fReadOnly);
            Assert.Contains("kernel32", imageData.ModuleName, StringComparison.OrdinalIgnoreCase);
        }
        finally
        {
            Assert.True(UnMapAndLoad(ref imageData));
        }
    }
}
