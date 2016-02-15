// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class MSCorEE
    {
        private static readonly Guid CLSID_CLRMetaHost = new Guid("{9280188d-0e8e-4867-b30c-7fa83884e8de}");
        private static readonly IClrMetaHost ClrMetaHost = CreateClrMetaHost();

        public static IEnumerable<string> GetProcessRuntimes(SafeHandle handle)
        {
            var buffer = new StringBuilder(1024);

            HResult result;
            if (ClrMetaHost != null)
            {
                IEnumUnknown ppEnumerator;
                result = ClrMetaHost.EnumerateLoadedRuntimes(handle.DangerousGetHandle(), out ppEnumerator);
                if (result.Succeeded)
                {
                    return ppEnumerator.OfType<IClrRuntimeInfo>().Select(rti =>
                    {
                        var bufferLength = (uint)buffer.Capacity;
                        rti.GetVersionString(buffer, ref bufferLength);
                        return buffer.ToString();
                    }).ToList();
                }
            }
            else
            {
                var bufferLength = (uint)buffer.Capacity;
                result = GetVersionFromProcess(handle.DangerousGetHandle(), buffer, bufferLength, out bufferLength);
                if (result.Succeeded && result != HResult.Code.E_INVALIDARG)
                {
                    return new[] { buffer.ToString() };
                }
            }

            return Enumerable.Empty<string>();
        }

        public static string GetFileRuntime(string filename)
        {
            if (filename == null)
            {
                throw new ArgumentNullException(nameof(filename));
            }

            var buffer = new StringBuilder(1024);
            var bufferLength = (uint)buffer.Capacity;
            var result = ClrMetaHost != null ? ClrMetaHost.GetVersionFromFile(filename, buffer, out bufferLength) : GetFileVersion(filename, buffer, bufferLength, out bufferLength);
            return result.Succeeded ? buffer.ToString() : null;
        }

        private static IClrMetaHost CreateClrMetaHost()
        {
            object pClrMetaHost;
            HResult result = CLRCreateInstance(CLSID_CLRMetaHost, typeof(IClrMetaHost).GUID, out pClrMetaHost);
            if (result.Failed)
            {
                throw new Win32Exception();
            }

            return (IClrMetaHost)pClrMetaHost;
        }
    }
}
