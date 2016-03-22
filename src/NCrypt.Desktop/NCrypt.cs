// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Exported functions from the NCrypt.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    public static partial class NCrypt
    {
        /// <summary>
        /// Determines if the specified handle is a CNG key handle.
        /// </summary>
        /// <param name="hKey">The handle of the key to test.</param>
        /// <returns>Returns a nonzero value if the handle is a key handle or zero otherwise.</returns>
        [DllImport(nameof(NCrypt))]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool NCryptIsKeyHandle(IntPtr hKey);
    }
}
