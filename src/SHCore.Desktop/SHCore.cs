// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Exported functions from the SHCore.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    public static partial class SHCore
    {
        /// <summary>
        /// Queries the dots per inch (dpi) of a display.
        /// The values of <paramref name="dpiX"/> and <paramref name="dpiY"/> are identical.
        /// You only need to record one of the values to determine the DPI and respond appropriately.
        /// </summary>
        /// <param name="hmonitor">Handle of the monitor being queried</param>
        /// <param name="dpiType">The type of DPI being queried. Possible values are from the <see cref="MONITOR_DPI_TYPE"/> enumeration</param>
        /// <param name="dpiX">The value of the DPI along the X axis. This value always refers to the horizontal edge, even when the screen is rotated</param>
        /// <param name="dpiY">The value of the DPI along the Y axis. This value always refers to the vertical edge, even when the screen is rotated</param>
        /// <returns>
        /// This function returns one of the following values:
        /// <list>
        /// <item><see cref="HResult.Code.S_OK"/>: The function successfully returns the X and Y DPI values for the specified monitor</item>
        /// <item><see cref="HResult.Code.E_INVALIDARG"/>: The handle, DPI type, or pointers passed in are not valid</item>
        /// </list>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When <see cref="MONITOR_DPI_TYPE"/> is <see cref="MONITOR_DPI_TYPE.MDT_ANGULAR_DPI"/> or <see cref="MONITOR_DPI_TYPE.MDT_RAW_DPI"/>,
        /// the returned DPI value does not include any changes that the user made to the DPI by using the desktop scaling override slider control in Control Panel.
        /// </para>
        /// <para>
        /// When you call <see cref="GetDpiForMonitor"/>, you will receive different DPI values depending on the DPI awareness of the calling application.
        /// DPI awareness is an application-level property usually defined in the application manifest.
        /// The following table indicates how the results will differ based on the <see cref="PROCESS_DPI_AWARENESS"/> value of your application.
        /// </para>
        /// <list>
        /// <item><see cref="PROCESS_DPI_AWARENESS.PROCESS_DPI_UNAWARE"/>: 96 because the app is unaware of any other scale factors</item>
        /// <item><see cref="PROCESS_DPI_AWARENESS.PROCESS_SYSTEM_DPI_AWARE"/>:A value set to the system DPI because the app assumes all applications use the system DPI</item>
        /// <item><see cref="PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE"/>: The actual DPI value set by the user for that display</item>
        /// </list>
        /// </remarks>
        [DllImport(nameof(SHCore), SetLastError = true)]
        public static extern HResult GetDpiForMonitor(IntPtr hmonitor, MONITOR_DPI_TYPE dpiType, out int dpiX, out int dpiY);

        /// <summary>
        /// Retrieves the dots per inch (dpi) awareness of the specified process
        /// </summary>
        /// <param name="hprocess">Handle of the process that is being queried. If this parameter is NULL, the current process is queried</param>
        /// <param name="value">The DPI awareness of the specified process. Possible values are from the <see cref="PROCESS_DPI_AWARENESS"/> enumeration</param>
        /// <returns>
        /// This function returns one of the following values:
        /// <list>
        /// <item><see cref="HResult.Code.S_OK"/>: The function successfully retrieved the DPI awareness of the specified process</item>
        /// <item><see cref="HResult.Code.E_INVALIDARG"/>: The handle or pointer passed in is not valid</item>
        /// <item><see cref="HResult.Code.E_ACCESSDENIED"/>: The application does not have sufficient privileges</item>
        /// </list>
        /// </returns>
        [DllImport(nameof(SHCore), SetLastError = true)]
        public static extern HResult GetProcessDpiAwareness(IntPtr hprocess, out PROCESS_DPI_AWARENESS value);

        /// <summary>
        /// Sets the current process to a specified dots per inch (dpi) awareness level. The DPI awareness levels are from the <see cref="PROCESS_DPI_AWARENESS"/> enumeration
        /// </summary>
        /// <param name="value">The DPI awareness value to set. Possible values are from the <see cref="PROCESS_DPI_AWARENESS"/> enumeration</param>
        /// <returns>
        /// This function returns one of the following values:
        /// <list>
        /// <item><see cref="HResult.Code.S_OK"/>: The DPI awareness for the app was set successfully</item>
        /// <item><see cref="HResult.Code.E_INVALIDARG"/>: The value passed in is not valid</item>
        /// <item><see cref="HResult.Code.E_ACCESSDENIED"/>: The DPI awareness is already set, either by calling this API previously or through the application (.exe) manifest</item>
        /// </list>
        /// </returns>
        /// <remarks>
        /// <para>
        /// It is strongly recommended to not use <see cref="SetProcessDpiAwareness"/> to set the DPI awareness for your application.
        /// Instead, you should declare the DPI awareness for your application in the application manifest.
        /// See <see cref="PROCESS_DPI_AWARENESS"/> for more information about the DPI awareness values and how to set them in the manifest.
        /// </para>
        /// <para>
        /// You must call this API before you call any APIs that depend on the dpi awareness.
        /// This is part of the reason why it is recommended to use the application manifest rather than the <see cref="SetProcessDpiAwareness"/> API.
        /// Once API awareness is set for an app, any future calls to this API will fail.
        /// This is true regardless of whether you set the DPI awareness in the manifest or by using this API.
        /// If the DPI awareness level is not set, the default value is <see cref="PROCESS_DPI_AWARENESS.PROCESS_DPI_UNAWARE"/>.
        /// </para>
        /// </remarks>
        [DllImport(nameof(SHCore), SetLastError = true)]
        public static extern HResult SetProcessDpiAwareness(PROCESS_DPI_AWARENESS value);

        /// <summary>
        /// Retrieves the dots per inch (dpi) occupied by a <see cref="SHELL_UI_COMPONENT"/> based on the current scale factor and <see cref="PROCESS_DPI_AWARENESS"/>.
        /// </summary>
        /// <param name="component">The type of shell component</param>
        /// <returns>The DPI required for an icon of this type</returns>
        [DllImport(nameof(SHCore), SetLastError = true)]
        public static extern int GetDpiForShellUiComponent(SHELL_UI_COMPONENT component);
    }
}
