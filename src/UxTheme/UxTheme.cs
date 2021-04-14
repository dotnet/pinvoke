// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
#if NETFRAMEWORK || NETSTANDARD2_0_ORLATER
    using System.Runtime.ConstrainedExecution;
#endif
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Exported functions from the UxTheme.dll Windows library
    /// that are available to Desktop and Store apps.
    /// </summary>
    [OfferFriendlyOverloads]
    public static partial class UxTheme
    {
        /// <summary>
        /// Opens the theme data for a window and its associated class.
        /// </summary>
        /// <param name="hwnd">Handle of the window for which theme data is required.</param>
        /// <param name="pszClassList">
        /// A string that contains a semicolon-separated list of classes.
        /// The pszClassList parameter contains a list, not just a single name, to provide the class an opportunity to get the best match between the class and the current visual style. For example, a button might pass L"OkButton;Button" if its ID is ID_OK. If the current visual style has an entry for OkButton, that is used; otherwise no visual style is applied.
        /// Class names for the Aero theme are defined in AeroStyle.xml.
        /// </param>
        /// <returns>
        /// OpenThemeData tries to match each class, one at a time, to a class data section in the active theme. If a match is found, an associated HTHEME handle is returned. If no match is found NULL is returned.
        /// </returns>
        [DllImport(nameof(UxTheme), CharSet = CharSet.Unicode)]
        public static extern SafeThemeHandle OpenThemeData(
            IntPtr hwnd,
            string pszClassList);

        /// <summary>
        /// A variant of OpenThemeData that opens a theme handle associated with a specific DPI.
        /// </summary>
        /// <param name="hwnd">The handle of the window for which theme data is required.</param>
        /// <param name="pszClassIdList">A pointer to a string that contains a semicolon-separated list of classes.</param>
        /// <param name="dpi">The specified DPI value with which to associate the theme handle. The function will return an error if this value is outside of those that correspond to the set of connected monitors.</param>
        /// <returns>See OpenThemeData.</returns>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// uxtheme!OpenThemeData will create theme handles associated with the DPI of a window when used with Per Monitor v2 windows. OpenThemeDataForDpi
        /// allows you to open a theme handle for a specific DPI when you do not have a window at that DPI.
        /// The behavior of the returned theme handle will be undermined if the requested DPI value does not correspond to a currently connected display.The theming system only loads theme assets
        /// for the set of DPI values corresponding to the currently connected displays.
        /// The theme handle will become invalid anytime the system reloads the theme data.Applications are required to monitor <see cref="User32.WindowMessage.WM_THEMECHANGED"/> and close and reopen all
        /// theme handles in response.This behavior is the same regardless of whether the handles were opened via OpenThemeData or OpenThemeDataForDpi.
        /// </item>
        /// <item>The <see cref="SafeThemeHandle"/> returned by this method is not the same one as those used within the UxTheme library,  but it can be passed to
        /// UxTheme API's seamlessly</item>
        /// </list>
        /// </remarks>
        [DllImport(nameof(UxTheme), CharSet = CharSet.Unicode)]
        public static extern SafeThemeHandle OpenThemeDataForDpi(
            IntPtr hwnd,
            [MarshalAs(UnmanagedType.LPWStr)] string pszClassIdList,
            int dpi);

        /// <summary>
        /// Retrieves the value of a <see cref="MARGINS"/> property.
        /// </summary>
        /// <param name="hTheme">Handle to a window's specified theme data. Use <see cref="OpenThemeData"/> to create an HTHEME.</param>
        /// <param name="hdc">HDC to select fonts into. This parameter may be set to <see cref="User32.SafeDCHandle.Null"/>.</param>
        /// <param name="iPartId">Value of type int that specifies the part that contains the MARGINS property. See Parts and States.</param>
        /// <param name="iStateId">Value of type int that specifies the state of the part. See Parts and States.</param>
        /// <param name="iPropId">Value of type int that specifies the property to retrieve. For a list of possible values, see Property Identifiers.</param>
        /// <param name="prc">Pointer to a <see cref="RECT"/> structure that contains the rectangle that specifies the area to be drawn into. This parameter may be set to NULL.</param>
        /// <param name="pMargins">Pointer to a <see cref="MARGINS"/> structure that receives the retrieved value.</param>
        /// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [DllImport(nameof(UxTheme))]
        public static extern unsafe HResult GetThemeMargins(
            SafeThemeHandle hTheme,
            User32.SafeDCHandle hdc,
            int iPartId,
            int iStateId,
            int iPropId,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] RECT* prc,
            out MARGINS pMargins);

        /// <summary>
        /// Closes the theme data handle.
        /// </summary>
        /// <param name="hTheme">Handle to a window's specified theme data. Use <see cref="OpenThemeData"/> to create an HTHEME.</param>
        /// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
#if NETFRAMEWORK || NETSTANDARD2_0_ORLATER
        [SuppressUnmanagedCodeSecurity]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
        [DllImport(nameof(UxTheme), CharSet = CharSet.Unicode)]
        private static extern HResult CloseThemeData(IntPtr hTheme);
    }
}
