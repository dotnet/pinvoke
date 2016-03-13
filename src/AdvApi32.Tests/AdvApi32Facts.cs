// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.Threading;
using Microsoft.Win32.SafeHandles;
using PInvoke;
using Xunit;
using static PInvoke.AdvApi32;

public class AdvApi32Facts
{
    [Fact]
    public void LsaNtStatusToWinError_UsesTable()
    {
        Assert.Equal(Win32ErrorCode.ERROR_NOACCESS, LsaNtStatusToWinError(NTSTATUS.Code.STATUS_ACCESS_VIOLATION));
    }

    [Fact]
    public void CanOpenRegistryKey()
    {
        SafeRegistryHandle handle;
        var errorCode = RegOpenKeyEx(HKEY_CURRENT_USER, "Software", RegOpenKeyOptions.None, KEY_READ, out handle);
        Assert.Equal(Win32ErrorCode.ERROR_SUCCESS, errorCode);
        Assert.NotNull(handle);
        Assert.False(handle.IsInvalid);
        handle.Dispose();
    }

    [Fact]
    public void CanNotifyRegistryChange()
    {
        SafeRegistryHandle handle;
        Assert.Equal(
            Win32ErrorCode.ERROR_SUCCESS,
            RegOpenKeyEx(HKEY_CURRENT_USER, "Software", RegOpenKeyOptions.None, KEY_READ, out handle));
        using (handle)
        {
            using (var evt = new ManualResetEvent(false))
            {
                Assert.Equal(
                    Win32ErrorCode.ERROR_SUCCESS,
                    RegNotifyChangeKeyValue(handle, false, RegNotifyFilter.REG_NOTIFY_CHANGE_NAME, evt.SafeWaitHandle, true));
            }
        }
    }
}
