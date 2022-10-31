// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using PInvoke;
using Xunit;
using static PInvoke.User32;

public partial class User32Facts
{
    [Fact]
    public void EnumDisplaySettings_Test()
    {
        // Arrange
        var mode = DEVMODE.Create();

        // Act
        bool result = EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref mode);

        // Assert
        Assert.True(result);
        Assert.True(mode.dmPelsWidth > 0);
        Assert.True(mode.dmPelsHeight > 0);
    }

    [Fact]
    public void EnumDisplaySettingsEx_Test()
    {
        // Arrange
        var mode = DEVMODE.Create();

        // Act
        bool result = EnumDisplaySettingsEx(null, ENUM_CURRENT_SETTINGS, ref mode, EnumDisplaySettingsExFlags.EDS_RAWMODE);

        // Assert
        Assert.True(result);
        Assert.True(mode.dmPelsWidth > 0);
        Assert.True(mode.dmPelsHeight > 0);
    }
}
