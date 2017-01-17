// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Exported functions from the DwmApi.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    [OfferFriendlyOverloads]
    public static partial class DwmApi
    {
        /// <summary>
        /// Enables the blur effect on a specified window.
        /// </summary>
        /// <param name="hWnd">The handle to the window on which the blur behind data is applied.</param>
        /// <param name="pBlurBehind">A pointer to a <see cref="DWM_BLURBEHIND"/> structure that provides blur behind data.</param>
        /// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [DllImport(nameof(DwmApi))]
        public static extern unsafe HResult DwmEnableBlurBehindWindow(
            IntPtr hWnd,
            [Friendly(FriendlyFlags.In)] DWM_BLURBEHIND* pBlurBehind);

        /// <summary>
        /// Enables or disables Desktop Window Manager (DWM) composition.
        /// </summary>
        /// <param name="uCompositionAction">The flag to enable or disable composition.</param>
        /// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        /// <remarks>
        /// As of Windows 8, calling this function with <see cref="DwmEnableCompositionFlags.DWM_EC_DISABLECOMPOSITION"/> has no effect.
        /// However, the function will still return a success code.
        /// </remarks>
        [DllImport(nameof(DwmApi))]
        public static extern unsafe HResult DwmEnableComposition(
            DwmEnableCompositionFlags uCompositionAction);

#pragma warning disable SA1625 // Element documentation must not be copied and pasted
        /// <summary>
        /// Default window procedure for Desktop Window Manager (DWM) hit testing within the non-client area.
        /// </summary>
        /// <param name="hwnd">A handle to the window procedure that received the message.</param>
        /// <param name="msg">The message.</param>
        /// <param name="wParam">Specifies additional message information. The content of this parameter depends on the value of the <paramref name="msg"/> parameter.</param>
        /// <param name="lParam">Specifies additional message information. The content of this parameter depends on the value of the <paramref name="msg"/> parameter.</param>
        /// <param name="plResult">A pointer to an LRESULT value that, when this method returns successfully,receives the result of the hit test.</param>
        /// <returns>TRUE if DwmDefWindowProc handled the message; otherwise, FALSE.</returns>
        [DllImport(nameof(DwmApi))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DwmDefWindowProc(
            IntPtr hwnd,
            uint msg,
            IntPtr wParam,
            IntPtr lParam,
            out IntPtr plResult);
#pragma warning restore SA1625 // Element documentation must not be copied and pasted

        /// <summary>
        /// Issues a flush call that blocks the caller until the next present, when all of the Microsoft DirectX surface updates that are currently outstanding have been made. This compensates for very complex scenes or calling processes with very low priority.
        /// </summary>
        /// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        /// <remarks>
        /// DwmFlush waits for any queued DirectX changes that were queued by the calling application to be drawn to the screen before returning. It does not flush the entire session rendering batch.
        /// </remarks>
        [DllImport(nameof(DwmApi))]
        public static extern HResult DwmFlush();

        /// <summary>
        /// Retrieves the current color used for Desktop Window Manager (DWM) glass composition. This value is based on the current color scheme and can be modified by the user. Applications can listen for color changes by handling the WM_DWMCOLORIZATIONCOLORCHANGED notification.
        /// </summary>
        /// <param name="pcrColorization">A pointer to a value that, when this function returns successfully, receives the current color used for glass composition. The color format of the value is 0xAARRGGBB.</param>
        /// <param name="pfOpaqueBlend">A pointer to a value that, when this function returns successfully, indicates whether the color is an opaque blend. TRUE if the color is an opaque blend; otherwise, FALSE.</param>
        /// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [DllImport(nameof(DwmApi))]
        public static extern HResult DwmGetColorizationColor(
            out uint pcrColorization,
            [MarshalAs(UnmanagedType.Bool)] out bool pfOpaqueBlend);

        /// <summary>
        /// Retrieves the current value of a specified attribute applied to a window.
        /// </summary>
        /// <param name="hwnd">The handle to the window from which the attribute data is retrieved.</param>
        /// <param name="dwAttribute">The attribute to retrieve, specified as a <see cref="DWMWINDOWATTRIBUTE"/> value.</param>
        /// <param name="pvAttribute">A pointer to a value that, when this function returns successfully, receives the current value of the attribute. The type of the retrieved value depends on the value of the <paramref name="dwAttribute"/> parameter.</param>
        /// <param name="cbAttribute">The size of the <see cref="DWMWINDOWATTRIBUTE"/> value being retrieved. The size is dependent on the type of the <paramref name="pvAttribute"/> parameter.</param>
        /// <returns>If this function succeeds, it returns <see cref="HResult.Code.S_OK"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        [DllImport(nameof(DwmApi))]
        public static unsafe extern HResult DwmGetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE dwAttribute, out void* pvAttribute, int cbAttribute);
    }
}
