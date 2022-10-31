// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
        Win32ErrorCode errorCode = RegOpenKeyEx(HKEY_CURRENT_USER, "Software", RegOpenKeyOptions.None, KEY_READ, out SafeRegistryHandle handle);
        Assert.Equal(Win32ErrorCode.ERROR_SUCCESS, errorCode);
        Assert.NotNull(handle);
        Assert.False(handle.IsInvalid);
        handle.Dispose();
    }

    [Fact]
    public void CanNotifyRegistryChange()
    {
        Assert.Equal(
            Win32ErrorCode.ERROR_SUCCESS,
            RegOpenKeyEx(HKEY_CURRENT_USER, "Software", RegOpenKeyOptions.None, KEY_READ, out SafeRegistryHandle handle));
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

    [Fact]
    public unsafe void ChangeServiceConfig2_ErrorsProperly()
    {
        Assert.False(ChangeServiceConfig2(SafeServiceHandle.Null, ServiceInfoLevel.SERVICE_CONFIG_DESCRIPTION, null));

        string rebootMessage = "Rebooting now.";
        fixed (char* pRebootMessage = rebootMessage.ToCharArrayWithNullTerminator())
        {
            var actions = new SC_ACTION[]
            {
                new SC_ACTION { Type = SC_ACTION_TYPE.SC_ACTION_REBOOT, Delay = 2000 },
                new SC_ACTION { Type = SC_ACTION_TYPE.SC_ACTION_REBOOT, Delay = 2000 },
            };
            fixed (SC_ACTION* pActions = &actions[0])
            {
                var failureActions = new SERVICE_FAILURE_ACTIONS
                {
                    lpRebootMsg = pRebootMessage,
                    cActions = 2,
                    lpsaActions = pActions,
                };

                Assert.False(ChangeServiceConfig2(SafeServiceHandle.Null, ServiceInfoLevel.SERVICE_CONFIG_FAILURE_ACTIONS_FLAG, &failureActions));
            }
        }
    }
}
