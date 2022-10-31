// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using PInvoke;
using Xunit;
using static PInvoke.Crypt32;

public class Crypt32Facts
{
    [Fact]
    public unsafe void PFXImportCertStoreTest()
    {
        byte[] protectedPfxContent = ReadEmbeddedResource("protectedPair.pfx");
        fixed (byte* pbData = protectedPfxContent)
        {
            var data = new CRYPT_DATA_BLOB
            {
                cbData = protectedPfxContent.Length,
                pbData = pbData,
            };
            using (SafeCertStoreHandle handle = PFXImportCertStore(ref data, "123456", PFXImportCertStoreFlags.None))
            {
                if (handle.IsInvalid)
                {
                    throw new Win32Exception();
                }

                Assert.False(handle.IsInvalid);
            }
        }
    }

    private static byte[] ReadEmbeddedResource(string fileName)
    {
        using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName))
        {
            if (stream == null)
            {
                throw new ArgumentException("No resource by that name found.", nameof(fileName));
            }

            var ms = new MemoryStream((int)stream.Length);
            stream.CopyTo(ms);
            return ms.ToArray();
        }
    }
}
