// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <content>
    /// Contains the <see cref="STARTUPINFO"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Specifies the window station, desktop, standard handles, and appearance of the main window for a process at creation time.
        /// </summary>
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct STARTUPINFO
        {
            /// <summary>
            /// The size of this data structure.
            /// </summary>
            public int cb;

            /// <summary>
            /// Reserved; must be NULL.
            /// </summary>
            public char* lpReserved;

            /// <summary>
            /// The name of the desktop, or the name of both the desktop and window station for this process. A backslash in the string indicates that the string includes both the desktop and window station names. For more information, see Thread Connection to a Desktop.
            /// </summary>
            public char* lpDesktop;

            /// <summary>
            /// For console processes, this is the title displayed in the title bar if a new console window is created. If NULL, the name of the executable file is used as the window title instead. This parameter must be NULL for GUI or console processes that do not create a new console window.
            /// </summary>
            public char* lpTitle;

            /// <summary>
            /// If <see cref="dwFlags"/> specifies STARTF_USEPOSITION, this member is the x offset of the upper left corner of a window if a new window is created, in pixels. Otherwise, this member is ignored.
            /// The offset is from the upper left corner of the screen. For GUI processes, the specified position is used the first time the new process calls CreateWindow to create an overlapped window if the x parameter of CreateWindow is CW_USEDEFAULT.
            /// </summary>
            public int dwX;

            /// <summary>
            /// If <see cref="dwFlags"/> specifies STARTF_USEPOSITION, this member is the y offset of the upper left corner of a window if a new window is created, in pixels. Otherwise, this member is ignored.
            /// The offset is from the upper left corner of the screen. For GUI processes, the specified position is used the first time the new process calls CreateWindow to create an overlapped window if the y parameter of CreateWindow is CW_USEDEFAULT.
            /// </summary>
            public int dwY;

            /// <summary>
            /// If <see cref="dwFlags"/> specifies STARTF_USESIZE, this member is the width of the window if a new window is created, in pixels. Otherwise, this member is ignored.
            /// For GUI processes, this is used only the first time the new process calls CreateWindow to create an overlapped window if the nWidth parameter of CreateWindow is CW_USEDEFAULT.
            /// </summary>
            public int dwXSize;

            /// <summary>
            /// If <see cref="dwFlags"/> specifies STARTF_USESIZE, this member is the height of the window if a new window is created, in pixels. Otherwise, this member is ignored.
            /// For GUI processes, this is used only the first time the new process calls CreateWindow to create an overlapped window if the nHeight parameter of CreateWindow is CW_USEDEFAULT.
            /// </summary>
            public int dwYSize;

            /// <summary>
            /// If <see cref="dwFlags"/> specifies STARTF_USECOUNTCHARS, if a new console window is created in a console process, this member specifies the screen buffer width, in character columns. Otherwise, this member is ignored.
            /// </summary>
            public int dwXCountChars;

            /// <summary>
            /// If <see cref="dwFlags"/> specifies STARTF_USECOUNTCHARS, if a new console window is created in a console process, this member specifies the screen buffer height, in character rows. Otherwise, this member is ignored.
            /// </summary>
            public int dwYCountChars;

            /// <summary>
            /// If <see cref="dwFlags"/> specifies STARTF_USEFILLATTRIBUTE, this member is the initial text and background colors if a new console window is created in a console application. Otherwise, this member is ignored.
            /// This value can be any combination of the following values: FOREGROUND_BLUE, FOREGROUND_GREEN, FOREGROUND_RED, FOREGROUND_INTENSITY, BACKGROUND_BLUE, BACKGROUND_GREEN, BACKGROUND_RED, and BACKGROUND_INTENSITY. For example, the following combination of values produces red text on a white background:
            /// FOREGROUND_RED| BACKGROUND_RED| BACKGROUND_GREEN| BACKGROUND_BLUE
            /// </summary>
            public uint dwFillAttribute;

            /// <summary>
            /// A bitfield that determines whether certain STARTUPINFO members are used when the process creates a window.
            /// </summary>
            public StartupInfoFlags dwFlags;

            /// <summary>
            /// If <see cref="dwFlags"/> specifies <see cref="StartupInfoFlags.STARTF_USESHOWWINDOW"/>, this member can be any of the values that can be specified in the nCmdShow parameter for the ShowWindow function, except for SW_SHOWDEFAULT. Otherwise, this member is ignored.
            /// For GUI processes, the first time ShowWindow is called, its nCmdShow parameter is ignored wShowWindow specifies the default value. In subsequent calls to ShowWindow, the wShowWindow member is used if the nCmdShow parameter of ShowWindow is set to SW_SHOWDEFAULT.
            /// </summary>
            public ushort wShowWindow;

            /// <summary>
            /// Reserved for use by the C Run-time; must be zero.
            /// </summary>
            public ushort cbReserved2;

            /// <summary>
            /// Reserved for use by the C Run-time; must be NULL.
            /// </summary>
            public IntPtr lpReserved2;

            /// <summary>
            /// If <see cref="dwFlags"/> specifies <see cref="StartupInfoFlags.STARTF_USESTDHANDLES"/>, this member is the standard input handle for the process. If <see cref="StartupInfoFlags.STARTF_USESTDHANDLES"/> is not specified, the default for standard input is the keyboard buffer.
            /// If <see cref="dwFlags"/> specifies <see cref="StartupInfoFlags.STARTF_USEHOTKEY"/>, this member specifies a hotkey value that is sent as the wParam parameter of a WM_SETHOTKEY message to the first eligible top-level window created by the application that owns the process. If the window is created with the WS_POPUP window style, it is not eligible unless the WS_EX_APPWINDOW extended window style is also set. For more information, see CreateWindowEx.
            /// Otherwise, this member is ignored.
            /// </summary>
            public IntPtr hStdInput;

            /// <summary>
            /// If <see cref="dwFlags"/> specifies <see cref="StartupInfoFlags.STARTF_USESTDHANDLES"/>, this member is the standard output handle for the process. Otherwise, this member is ignored and the default for standard output is the console window's buffer.
            /// If a process is launched from the taskbar or jump list, the system sets <see cref="hStdOutput"/> to a handle to the monitor that contains the taskbar or jump list used to launch the process. For more information, see Remarks.
            /// Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008, Windows XP, and Windows Server 2003:  This behavior was introduced in Windows 8 and Windows Server 2012.
            /// </summary>
            public IntPtr hStdOutput;

            /// <summary>
            /// If <see cref="dwFlags"/> specifies <see cref="StartupInfoFlags.STARTF_USESTDHANDLES"/>, this member is the standard error handle for the process. Otherwise, this member is ignored and the default for standard error is the console window's buffer.
            /// </summary>
            public IntPtr hStdError;

            /// <summary>
            /// Gets the value of <see cref="lpDesktop" /> as a string.
            /// </summary>
            public string Desktop => this.lpDesktop != null ? new string(this.lpDesktop) : null;

            /// <summary>
            /// Gets the value of <see cref="lpDesktop" /> as a string.
            /// </summary>
            public string Title => this.lpTitle != null ? new string(this.lpTitle) : null;

            /// <summary>
            /// Initializes a new instance of the <see cref="STARTUPINFO"/> struct.
            /// </summary>
            /// <returns>An initialized instance of the struct.</returns>
            public static STARTUPINFO Create()
            {
                return new STARTUPINFO
                {
#if NETSTANDARD1_3_ORLATER
                    cb = Marshal.SizeOf<STARTUPINFO>(),
#else
                    cb = Marshal.SizeOf(typeof(STARTUPINFO)),
#endif
                };
            }
        }
    }
}
