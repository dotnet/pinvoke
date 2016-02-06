// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

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
        [DllImport(nameof(UxTheme), CharSet = CharSet.Unicode)]
        private static extern HResult CloseThemeData(IntPtr hTheme);
    }
}
