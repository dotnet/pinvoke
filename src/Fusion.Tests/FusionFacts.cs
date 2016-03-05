// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using PInvoke;
using Xunit;
using static PInvoke.Fusion;

public class FusionFacts
{
    [Fact]
    public unsafe void CreateAssemblyCache_QueryAssemblyInfo()
    {
        IAssemblyCache cache;
        CreateAssemblyCache(out cache, 0).ThrowOnFailure();
        Assert.NotNull(cache);
        ASSEMBLY_INFO info = ASSEMBLY_INFO.Create();
        var assemblyPath = new char[500];
        fixed (char* pAssemblyPath = assemblyPath)
        {
            info.pszCurrentAssemblyPathBuf = pAssemblyPath;
            info.cchBuf = assemblyPath.Length;

            // fusion.dll's implementation of this interface expects simple name 'mscorlib'
            // sxs.dll's implementation seems to not like anything.
            HResult hr = cache.QueryAssemblyInfo(QueryAssemblyInfoFlags.QUERYASMINFO_FLAG_GETSIZE, "mscorlib", &info);
            Assert.Equal<HResult>(HResult.Code.S_OK, hr);
            Assert.NotEqual(0, info.uliAssemblySizeInKB);

            hr = cache.QueryAssemblyInfo(QueryAssemblyInfoFlags.QUERYASMINFO_FLAG_GETSIZE, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", &info);
            Assert.Equal<HResult>(0x80070002, hr); // File not found
        }
    }
}
