// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SP_DEVINFO_DATA" /> nested type.
    /// </content>
    public partial class SetupApi
    {
        /// <summary>
        /// An <seealso cref="SP_DEVINSTALL_PARAMS"/> structure contains device installation parameters associated with a particular device
        /// information element or associated globally with a device information set.
        /// </summary>
        /// <seealso href="https://msdn.microsoft.com/en-us/library/windows/hardware/ff552346(v=vs.85).aspx"/>
        public unsafe struct SP_DEVINSTALL_PARAMS
        {
            /// <summary>
            /// The size, in bytes, of the <seealso cref="SP_DEVINSTALL_PARAMS"/> structure.
            /// </summary>
            public int cbSize;

            /// <summary>
            /// Flags that control installation and user interface operations. Some flags can be set before sending the device installation request
            /// while other flags are set automatically during the processing of some requests. Flags can be a combination of the following values.
            /// </summary>
            public DevInstallFlags Flags;

            /// <summary>
            /// Additional flags that provide control over installation and user interface operations. Some flags can be set before calling the device
            /// installer functions while other flags are set automatically during the processing of some functions.
            /// </summary>
            public DevInstallFlagsEx FlagsEx;

            /// <summary>
            /// Window handle that will own the user interface dialogs related to this device.
            /// </summary>
            public IntPtr hwndParent;

            /// <summary>
            /// Callback used to handle events during file copying. An installer can use a callback, for example,
            /// to perform special processing when committing a file queue.
            /// </summary>
            public IntPtr InstallMsgHandler;

            /// <summary>
            /// Private data that is used by the <see cref="InstallMsgHandler"/> callback.
            /// </summary>
            public IntPtr InstallMsgHandlerContext;

            /// <summary>
            /// <para>
            /// A handle to a caller-supplied file queue where file operations should be queued but not committed.
            /// </para>
            /// <para>
            /// If you associate a file queue with a device information set (<see cref="SetupApi.SetupDiSetDeviceInstallParams(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, SP_DEVINSTALL_PARAMS*)"/>),
            /// you must disassociate the queue from the device information set before you delete the device information set. If you fail to
            /// disassociate the file queue, Windows cannot decrement its reference count on the device information set and cannot free the memory.
            /// </para>
            /// <para>
            /// This queue is only used if the <see cref="DevInstallFlags.DI_NOVCP"/> flag is set, indicating that file operations should be enqueued but not committed.
            /// </para>
            /// </summary>
            public IntPtr FileQueue;

            /// <summary>
            /// A pointer for class-installer data. Co-installers must not use this field.
            /// </summary>
            public IntPtr ClassInstallReserved;

            /// <summary>
            /// Reserved. For internal use only.
            /// </summary>
            public int Reserved;

            /// <summary>
            /// This path is used by the <see cref="SetupApi.SetupDiBuildDriverInfoList(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DriverType)"/> function.
            /// </summary>
            public fixed char DriverPath[260];

            /// <summary>
            /// Gets the driver path.
            /// </summary>
            public string DriverPathString
            {
                get
                {
                    fixed (char* driverPath = this.DriverPath)
                    {
                        return new string(driverPath);
                    }
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SP_DEVINSTALL_PARAMS" /> struct
            /// with <see cref="cbSize" /> set to the correct value.
            /// </summary>
            /// <returns>An instance of <see cref="SP_DEVINSTALL_PARAMS"/>.</returns>
            public static SP_DEVINSTALL_PARAMS Create() => new SP_DEVINSTALL_PARAMS { cbSize = sizeof(SP_DEVINSTALL_PARAMS) };
        }
    }
}
