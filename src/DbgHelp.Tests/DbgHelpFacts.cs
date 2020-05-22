// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using PInvoke;
using Xunit;
using static PInvoke.DbgHelp;

public class DbgHelpFacts
{
    [Fact]
    public void IntPtrGeneration()
    {
        LOADED_IMAGE image = default(LOADED_IMAGE);
        image.FileHeader_IntPtr = IntPtr.Zero;
    }
}
