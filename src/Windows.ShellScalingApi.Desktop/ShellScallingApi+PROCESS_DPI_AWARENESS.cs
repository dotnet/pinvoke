// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// <para>
    /// Identifies dots per inch (dpi) awareness values. DPI awareness indicates how much scaling work an application performs for DPI versus how much is done by the system.
    /// </para>
    /// <para>
    /// Tip: If your app is <see cref="PROCESS_DPI_UNAWARE"/>, there is no need to set any value in the application manifest.
    /// <see cref="PROCESS_DPI_UNAWARE"/> is the default value for apps unless another value is specified. Also, in previous versions of Windows,
    /// there was no setting for <see cref="PROCESS_PER_MONITOR_DPI_AWARE"/>. Apps were either DPI unaware or DPI aware.
    /// Legacy applications that were classified as DPI aware before Windows 8.1 are considered to have a PROCESS_DPI_AWARENESS setting of <see cref="PROCESS_SYSTEM_DPI_AWARE"/>
    /// in current versions of Windows.
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Users have the ability to set the DPI scale factor on their displays independent of each other.
    /// Some legacy applications are not able to adjust their scaling for multiple DPI settings.
    /// In order for users to use these applications without content appearing too large or small on displays, Windows can apply DPI virtualization to an application,
    /// causing it to be automatically be scaled by the system to match the DPI of the current display.
    /// The PROCESS_DPI_AWARENESS value indicates what level of scaling your application handles on its own and how much is provided by Windows.
    /// Keep in mind that applications scaled by the system may appear blurry and will read virtualized data about the monitor to maintain compatibility
    /// </para>
    /// The DPI awareness for an application should be set through the application manifest so that it is determined before any actions are taken
    /// which depend on the DPI of the system. Alternatively, you can set the DPI awareness using SetProcessDpiAwareness, but if you do so,
    /// you need to make sure to set it before taking any actions dependent on the system DPI. Once you set the DPI awareness for a process, it cannot be changed.
    /// <para>
    /// </para>
    /// <see cref="PROCESS_DPI_UNAWARE"/> and <see cref="PROCESS_SYSTEM_DPI_AWARE"/> apps do not need to respond to the Window Message WM_DPICHANGED
    /// and are not expected to handle changes in DPI. The system will automatically scale these types of apps up or down as necessary when the DPI changes.
    /// <see cref="PROCESS_PER_MONITOR_DPI_AWARE"/> apps are responsible for recognizing and responding to changes in DPI, signaled by WM_DPICHANGED.
    /// These will not be scaled by the system. If an app of this type does not resize the window and its content,
    /// it will appear to grow or shrink by the relative DPI changes as the window is moved from one display
    /// to the another with a different DPI setting.
    /// <para>
    /// In previous versions of Windows, there was no setting for PROCESS_PER_MONITOR_DPI_AWARE. Apps were either DPI unaware or DPI aware.
    /// Legacy applications that were classified as DPI aware before Windows 8.1 are considered to have a PROCESS_DPI_AWARENESS setting of PROCESS_SYSTEM_DPI_AWARE in current versions of Windows.
    /// </para>
    /// <para>
    /// Unlike the other awareness values, PROCESS_PER_MONITOR_DPI_AWARE should adapt to the display that it is on.
    /// This means that it is always rendered natively and is never scaled by the system.
    /// The responsibility is on the app to adjust the scale factor when receiving the WM_DPICHANGED message.
    /// Part of this message includes a suggested rect for the window.
    /// This suggestion is the current window scaled from the old DPI value to the new DPI value.
    /// </para>
    /// <para>
    /// Because of DPI virtualization, if one application queries another with a different awareness level for DPI-dependent information,
    /// the system will automatically scale values to match the awareness level of the caller.
    /// One example of this is if you call GetWindowRect and pass in a window created by another application. Using the situation described above,
    /// assume that a PROCESS_DPI_UNAWARE app created a 500 by 500 window on display C.
    /// If you query for the window rect from a different application, the size of the rect will vary based upon the DPI awareness of your app:
    /// </para>
    /// <list>
    /// <item>PROCESS_DPI_UNAWARE: You will get a 500 by 500 rect because the system will assume a DPI of 96 and automatically scale the actual rect down by a factor of 3.</item>
    /// <item>PROCESS_SYSTEM_DPI_AWARE: You will get a 1000 by 1000 rect because the system will assume a DPI of 192 and automatically scale the actual rect down by a factor of 3/2.</item>
    /// <item>PROCESS_PER_MONITOR_DPI_AWARE: You will get a 1500 by 1500 rect because the system will use the actual DPI of the display and not do any scaling behind the scenes.</item>
    /// </list>
    /// </remarks>
    public enum PROCESS_DPI_AWARENESS
    {
        /// <summary>
        /// DPI unaware. This app does not scale for DPI changes and is always assumed to have a scale factor of 100% (96 DPI).
        /// It will be automatically scaled by the system on any other DPI setting
        /// </summary>
        PROCESS_DPI_UNAWARE = 0,

        /// <summary>
        /// System DPI aware. This app does not scale for DPI changes. It will query for the DPI once and use that value for the lifetime of the app.
        /// If the DPI changes, the app will not adjust to the new DPI value.
        /// It will be automatically scaled up or down by the system when the DPI changes from the system value
        /// </summary>
        /// <remarks>
        /// This snippet demonstrates how to set a value of <see cref="PROCESS_SYSTEM_DPI_AWARE"/> in your application manifest:
        /// <code><dpiAware>true</dpiAware></code>
        /// </remarks>
        PROCESS_SYSTEM_DPI_AWARE = 1,

        /// <summary>
        /// Per monitor DPI aware. This app checks for the DPI when it is created and adjusts the scale factor whenever the DPI changes.
        /// These applications are not automatically scaled by the system
        /// </summary>
        /// <remarks>
        /// This snippet demonstrates how to set a value of <see cref="PROCESS_PER_MONITOR_DPI_AWARE"/> in your application manifest:
        /// <code><dpiAware>true/PM</dpiAware></code>
        /// </remarks>
        PROCESS_PER_MONITOR_DPI_AWARE = 2
    }
}