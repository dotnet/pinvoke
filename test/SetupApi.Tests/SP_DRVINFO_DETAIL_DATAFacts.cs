// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using Xunit;
using static PInvoke.SetupApi;

public class SP_DRVINFO_DETAIL_DATAFacts
{
    [Fact]
    public void Layout_Test()
    {
        // These values listed below have been obtained by determining the size of the struct and the offset of its
        // fields using a C program which calls sizeof() and offsetof().
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(0, Marshal.OffsetOf<SP_DRVINFO_DETAIL_DATA>(nameof(SP_DRVINFO_DETAIL_DATA.cbSize)).ToInt32());
            Assert.Equal(4, Marshal.OffsetOf<SP_DRVINFO_DETAIL_DATA>(nameof(SP_DRVINFO_DETAIL_DATA.InfDate)).ToInt32());
            Assert.Equal(0xc, Marshal.OffsetOf<SP_DRVINFO_DETAIL_DATA>(nameof(SP_DRVINFO_DETAIL_DATA.CompatIDsOffset)).ToInt32());
            Assert.Equal(0x10, Marshal.OffsetOf<SP_DRVINFO_DETAIL_DATA>(nameof(SP_DRVINFO_DETAIL_DATA.CompatIDsLength)).ToInt32());
            Assert.Equal(0x18, Marshal.OffsetOf<SP_DRVINFO_DETAIL_DATA>(nameof(SP_DRVINFO_DETAIL_DATA.Reserved)).ToInt32());
            Assert.Equal(0x20, Marshal.OffsetOf<SP_DRVINFO_DETAIL_DATA>(nameof(SP_DRVINFO_DETAIL_DATA.SectionName)).ToInt32());
            Assert.Equal(0x220, Marshal.OffsetOf<SP_DRVINFO_DETAIL_DATA>(nameof(SP_DRVINFO_DETAIL_DATA.InfFileName)).ToInt32());
            Assert.Equal(0x428, Marshal.OffsetOf<SP_DRVINFO_DETAIL_DATA>(nameof(SP_DRVINFO_DETAIL_DATA.DrvDescription)).ToInt32());
            Assert.Equal(0x628, Marshal.OffsetOf<SP_DRVINFO_DETAIL_DATA>(nameof(SP_DRVINFO_DETAIL_DATA.HardwareID)).ToInt32());

            Assert.Equal(0x630, SP_DRVINFO_DETAIL_DATA.Create().cbSize);
        }
        else
        {
            Assert.Equal(0, Marshal.OffsetOf<SP_DRVINFO_DETAIL_DATA>(nameof(SP_DRVINFO_DETAIL_DATA.cbSize)).ToInt32());
            Assert.Equal(4, Marshal.OffsetOf<SP_DRVINFO_DETAIL_DATA>(nameof(SP_DRVINFO_DETAIL_DATA.InfDate)).ToInt32());
            Assert.Equal(0xc, Marshal.OffsetOf<SP_DRVINFO_DETAIL_DATA>(nameof(SP_DRVINFO_DETAIL_DATA.CompatIDsOffset)).ToInt32());
            Assert.Equal(0x10, Marshal.OffsetOf<SP_DRVINFO_DETAIL_DATA>(nameof(SP_DRVINFO_DETAIL_DATA.CompatIDsLength)).ToInt32());
            Assert.Equal(0x14, Marshal.OffsetOf<SP_DRVINFO_DETAIL_DATA>(nameof(SP_DRVINFO_DETAIL_DATA.Reserved)).ToInt32());
            Assert.Equal(0x18, Marshal.OffsetOf<SP_DRVINFO_DETAIL_DATA>(nameof(SP_DRVINFO_DETAIL_DATA.SectionName)).ToInt32());
            Assert.Equal(0x218, Marshal.OffsetOf<SP_DRVINFO_DETAIL_DATA>(nameof(SP_DRVINFO_DETAIL_DATA.InfFileName)).ToInt32());
            Assert.Equal(0x420, Marshal.OffsetOf<SP_DRVINFO_DETAIL_DATA>(nameof(SP_DRVINFO_DETAIL_DATA.DrvDescription)).ToInt32());
            Assert.Equal(0x620, Marshal.OffsetOf<SP_DRVINFO_DETAIL_DATA>(nameof(SP_DRVINFO_DETAIL_DATA.HardwareID)).ToInt32());

            Assert.Equal(0x622, SP_DRVINFO_DETAIL_DATA.Create().cbSize);
        }
    }
}
