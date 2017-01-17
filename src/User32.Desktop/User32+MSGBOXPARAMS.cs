// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="MSGBOXPARAMS"/> nested type.
    /// </content>
    public partial class User32
    {
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct MSGBOXPARAMS
        {
            public int cbSize;
            public IntPtr hwndOwner;
            public IntPtr hInstance;
            public char* lpszText;
            public char* lpszCaption;
            public uint dwStyle;
            public IntPtr lpszIcon;
            public IntPtr dwContextHelpId;

            [MarshalAs(UnmanagedType.FunctionPtr)]
            public MSGBOXCALLBACK lpfnMsgBoxCallback;

            public uint dwLanguageId;

            public static MSGBOXPARAMS Create()
            {
                var nw = default(MSGBOXPARAMS);
                nw.cbSize = Marshal.SizeOf(typeof(MSGBOXPARAMS));
                return nw;
            }
        }
    }
}