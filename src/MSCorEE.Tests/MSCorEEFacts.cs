﻿// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using CLRMetaHost;
using PInvoke;
using Xunit;
using static PInvoke.MSCorEE;

public class MSCorEEFacts
{
    private static readonly ICLRMetaHost ClrMetaHost = CreateClrMetaHost();

    public static IEnumerable<string> GetProcessRuntimes(ICLRMetaHost host, SafeHandle handle)
    {
        var buffer = new StringBuilder(1024);

        if (host != null)
        {
            IEnumUnknown ppEnumerator = host.EnumerateLoadedRuntimes(handle.DangerousGetHandle());
            return ppEnumerator.Cast<ICLRRuntimeInfo>().Select(rti =>
            {
                var bufferLength = (uint)buffer.Capacity;
                rti.GetVersionString(buffer, ref bufferLength);
                return buffer.ToString(0, (int)bufferLength - 1);
            }).ToList();
        }
        else
        {
            uint bufferLength = (uint)buffer.Capacity;
            HResult result = GetVersionFromProcess(handle.DangerousGetHandle(), buffer, bufferLength, out bufferLength);
            if (result.Succeeded && result != HResult.Code.E_INVALIDARG)
            {
                return new[] { buffer.ToString(0, (int)bufferLength - 1) };
            }
        }

        return Enumerable.Empty<string>();
    }

    public static string GetFileRuntime(ICLRMetaHost host, string filename)
    {
        if (filename == null)
        {
            throw new ArgumentNullException(nameof(filename));
        }

        var buffer = new StringBuilder(1024);
        uint valueLength = (uint)buffer.Capacity;
        if (host != null)
        {
            host.GetVersionFromFile(filename, buffer, ref valueLength);
        }
        else
        {
            GetFileVersion(filename, buffer, valueLength, out valueLength);
        }

        return buffer.ToString(0, (int)valueLength - 1);
    }

    [Fact]
    public void StrongNameGetPublicKey_ReadSnkFile()
    {
        byte[] publicKey = StrongNameGetPublicKey(GetKeyFileBytes("keypair.snk"));
        Assert.NotNull(publicKey);
        string actual = BitConverter.ToString(publicKey).Replace("-", string.Empty).ToLowerInvariant();
        string expected = "002400000480000094000000060200000024000052534131000400000100010067cea773679e0ecc114b7e1d442466a90bf77c755811a0d3962a546ed716525b6508abf9f78df132ffd3fb75fe604b3961e39c52d5dfc0e6c1fb233cb4fb56b1a9e3141513b23bea2cd156cb2ef7744e59ba6b663d1f5b2f9449550352248068e85b61c68681a6103cad91b3bf7a4b50d2fabf97e1d97ac34db65b25b58cd0dc";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void StrongNameTokenFromPublicKey_ReadSnkFile()
    {
        byte[] publicKeyToken = StrongNameTokenFromPublicKey(GetKeyFileBytes("public.snk"));
        Assert.NotNull(publicKeyToken);
        string actual = BitConverter.ToString(publicKeyToken).Replace("-", string.Empty).ToLowerInvariant();
        string expected = "ca2d1515679318f5";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShouldGetRuntimesFromCurrentProcess()
    {
        Process process = Process.GetCurrentProcess();
        IEnumerable<string> result = GetProcessRuntimes(ClrMetaHost, process.SafeHandle);
        Assert.Contains("v4.0.30319", result);
    }

    [Fact]
    public void ShouldGetRuntimeFromFile()
    {
        Process process = Process.GetCurrentProcess();
        string result = GetFileRuntime(ClrMetaHost, process.MainModule.FileName);
        Assert.Equal("v4.0.30319", result);
    }

    private static byte[] GetKeyFileBytes(string keyFileName)
    {
        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Keys." + keyFileName))
        {
            Assert.NotNull(stream);
            var ms = new MemoryStream((int)stream.Length);
            stream.CopyTo(ms);
            return ms.ToArray();
        }
    }
}
