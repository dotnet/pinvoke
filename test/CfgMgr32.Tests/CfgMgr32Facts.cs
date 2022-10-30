// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using PInvoke;
using Xunit;
using static PInvoke.CfgMgr32;

public class CfgMgr32Facts
{
    /// <summary>
    /// Tests the <see cref="CM_NOTIFY_FILTER"/> struct, by making sure the native size has the expected value.
    /// </summary>
    [Fact]
    public void CM_NOTIFY_FILTER_Test()
    {
        Assert.Equal(0x1a0, CM_NOTIFY_FILTER.Create().cbSize);
    }

    [Fact]
    public unsafe void RegisterUnregisterNoNotificationTest()
    {
        var callback = new CM_NOTIFY_CALLBACK(this.ProcessNotification);

        Assert.Equal(CONFIGRET.CR_SUCCESS, CM_Register_Notification(
            CM_NOTIFY_FILTER.Create(),
            null,
            callback,
            out SafeNotificationHandle context));

        context.Dispose();
        GC.KeepAlive(callback);
    }

    // These unit tests register for notifcations, but don't process any notifications.
    // You can test this locally by having each unit test block indefinitively before
    // context.Dispose(). Then, trigger a device event (e.g. by unplugging a USB device),
    // and observe the notification in the callback.
    [Fact]
    public unsafe void RegisterUnregisterClassGuidTest()
    {
        var callback = new CM_NOTIFY_CALLBACK(this.ProcessNotification);

        // Register for USB events
        Assert.Equal(CONFIGRET.CR_SUCCESS, CM_Register_Notification(
            CM_NOTIFY_FILTER.Create(new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED")),
            null,
            callback,
            out SafeNotificationHandle context));

        context.Dispose();
        GC.KeepAlive(callback);
    }

    [Fact]
    public unsafe void RegisterUnregisterInstanceIdTest()
    {
        var callback = new CM_NOTIFY_CALLBACK(this.ProcessNotification);
        var filter = CM_NOTIFY_FILTER.Create(@"ROOT\BASICDISPLAY\0000");

        Assert.Equal(CONFIGRET.CR_SUCCESS, CM_Register_Notification(
            &filter,
            null,
            callback,
            out SafeNotificationHandle context));

        context.Dispose();
        GC.KeepAlive(callback);
    }

    [Fact]
    public unsafe void RegisterUnregisterAllInterfaceClassesTest()
    {
        var callback = new CM_NOTIFY_CALLBACK(this.ProcessNotification);

        Assert.Equal(CONFIGRET.CR_SUCCESS, CM_Register_Notification(
            CM_NOTIFY_FILTER.AllInterfaces,
            null,
            callback,
            out SafeNotificationHandle context));

        context.Dispose();
        GC.KeepAlive(callback);
    }

    [Fact]
    public unsafe void RegisterUnregisterAllDevicesTest()
    {
        var callback = new CM_NOTIFY_CALLBACK(this.ProcessNotification);

        Assert.Equal(CONFIGRET.CR_SUCCESS, CM_Register_Notification(
            CM_NOTIFY_FILTER.AllDevices,
            null,
            callback,
            out SafeNotificationHandle context));

        context.Dispose();
        GC.KeepAlive(callback);
    }

    [Fact]
    public unsafe void RegisterErrorTest()
    {
        var callback = new CM_NOTIFY_CALLBACK(this.ProcessNotification);
        var filter = CM_NOTIFY_FILTER.Create(@"__INVALID__");

        Assert.Equal(CONFIGRET.CR_FAILURE, CM_Register_Notification(
            &filter,
            null,
            callback,
            out SafeNotificationHandle context));

        Assert.True(context.IsInvalid);
    }

    private unsafe Win32ErrorCode ProcessNotification(
            IntPtr notify,
            void* context,
            CM_NOTIFY_ACTION action,
            CM_NOTIFY_EVENT_DATA* eventData,
            int eventDataSize)
    {
        switch (eventData->FilterType)
        {
            case CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE:
                if (action == CM_NOTIFY_ACTION.CM_NOTIFY_ACTION_DEVICECUSTOMEVENT)
                {
                    Debug.WriteLine($"Received a custom event with Guid {eventData->EventGuid}.");
                }

                break;

            case CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE:
                string instanceId = new string(eventData->InstanceId);
                Debug.WriteLine($"Received a notification for device instance {instanceId}: {action}");
                break;

            case CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE:
                string symbolicLink = new string(eventData->SymbolicLink);
                Debug.WriteLine($"Received a notification for device interface with Class Guid {eventData->ClassGuid} at {symbolicLink}: {action}");
                break;
        }

        return Win32ErrorCode.ERROR_SUCCESS;
    }
}
