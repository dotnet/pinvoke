// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SafeThemeHandle.UxTheme"/> nested type
    /// </content>
    public partial class User32
    {
        /// <content>
        /// Contains the <see cref="UxTheme"/> private nested type that contains
        /// UxTheme.dll P/Invoke definitions for use within <see cref="SafeThemeHandle"/>
        /// </content>
        public partial class SafeThemeHandle
        {
            private static class UxTheme
            {
                /// <summary>
                /// Closes the theme data handle.
                /// </summary>
                /// <param name="hTheme">Handle to a window's specified theme data. Use OpenThemeData or OpenThemeDataForDpi to create an HTHEME.</param>
                /// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
                [DllImport(nameof(UxTheme))]
                public static extern HResult CloseThemeData(IntPtr hTheme);
            }
        }
    }
}
