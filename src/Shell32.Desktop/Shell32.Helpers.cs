// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class Shell32
    {
        [Obsolete("As of Windows Vista, this function is merely a wrapper for GetKnownFolderPath.")]
        public static string GetFolderPath(CSIDL csidl)
        {
            IntPtr pszPath;
#pragma warning disable CS0618 // Type or member is obsolete
            if (SHGetFolderPath(IntPtr.Zero, csidl, IntPtr.Zero, SHGetFolderPathFlags.SHGFP_TYPE_CURRENT, out pszPath) != HResult.Code.S_OK)
#pragma warning restore CS0618 // Type or member is obsolete
            {
                throw new Win32Exception();
            }

            string path = Marshal.PtrToStringUni(pszPath);
            Marshal.FreeCoTaskMem(pszPath);
            return path;
        }

        public static string GetKnownFolderPath(Guid rfid)
        {
            IntPtr pszPath;
            if (SHGetKnownFolderPath(rfid, 0, IntPtr.Zero, out pszPath) != HResult.Code.S_OK)
            {
                throw new Win32Exception();
            }

            string path = Marshal.PtrToStringUni(pszPath);
            Marshal.FreeCoTaskMem(pszPath);
            return path;
        }

        [Obsolete("As of Windows Vista, this function is merely a wrapper for GetKnownFolderID")]
        public static unsafe string GetFolderLocation(CSIDL csidl)
        {
            IntPtr pidl;
#pragma warning disable CS0618 // Type or member is obsolete
            if (SHGetFolderLocation(IntPtr.Zero, csidl, IntPtr.Zero, 0, out pidl) != HResult.Code.S_OK)
#pragma warning restore CS0618 // Type or member is obsolete
            {
                throw new Win32Exception();
            }

            const int bufferSize = 260;
            char* szPath = stackalloc char[bufferSize]; // max path length

            if (!SHGetPathFromIDList(pidl, szPath))
            {
                throw new Win32Exception();
            }

            Marshal.FreeCoTaskMem(pidl);
            return new string(szPath, 0, bufferSize);
        }

        public static unsafe string GetKnownFolderID(Guid rfid)
        {
            IntPtr pidl;
             if (SHGetKnownFolderIDList(rfid, 0, IntPtr.Zero, out pidl) != HResult.Code.S_OK)
            {
                throw new Win32Exception();
            }

            const int bufferSize = 260;
            char* szPath = stackalloc char[bufferSize]; // max path length

            if (!SHGetPathFromIDList(pidl, szPath))
            {
                throw new Win32Exception();
            }

            Marshal.FreeCoTaskMem(pidl);
            return new string(szPath, 0, bufferSize);
        }
    }
}
