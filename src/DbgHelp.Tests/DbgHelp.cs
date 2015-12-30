// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using PInvoke;
using Xunit;
using static PInvoke.DbgHelp;

public class DbgHelp
{
    [Fact]
    public void IntPtrGeneration()
    {
        LOADED_IMAGE image = default(LOADED_IMAGE);
        image.FileHeader_IntPtr = IntPtr.Zero;
    }
}
