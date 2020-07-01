// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;
using PInvoke;
using Xunit;

public class CfgMgr32Facts
{

    /// <summary>
    /// Tests the <see cref="CfgMgr32.CM_NOTIFY_FILTER"/> struct, by making sure the native size has the expected value.
    /// </summary>
    [Fact]
    public void CM_NOTIFY_FILTER_Test()
    {
        Assert.Equal(0x1a0, Marshal.SizeOf<CfgMgr32.CM_NOTIFY_FILTER>());
    }
}
