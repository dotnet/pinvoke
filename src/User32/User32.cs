// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#pragma warning disable SA1625 // Element documentation must not be copied and pasted

namespace PInvoke
{
    using System;
#if NETFRAMEWORK || NETSTANDARD2_0_ORLATER
    using System.Runtime.ConstrainedExecution;
#endif
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Text;
    using System.Threading;
    using static PInvoke.Kernel32;

#pragma warning disable SA1300 // Elements must begin with an uppercase letter

    /// <summary>
    /// Exported functions from the User32.dll Windows library.
    /// </summary>
    [OfferFriendlyOverloads]
    public static partial class User32
    {
        /// <summary>
        /// The multiplicative constant 120 for calculating mouse wheel movement.
        /// </summary>
        /// <remarks>
        /// See https://msdn.microsoft.com/en-us/library/windows/desktop/ms646254(v=vs.85).aspx.
        /// </remarks>
        public const int WHEEL_DELTA = 120;

        /// <summary>
        /// Size of a device name string.
        /// </summary>
        public const int CCHDEVICENAME = 32;

        /// <summary>
        /// Default parameters for <see cref="CreateWindowEx(WindowStylesEx, string, string, WindowStyles, int, int, int, int, IntPtr, IntPtr, IntPtr, IntPtr)"/>.
        /// </summary>
        public const int CW_USEDEFAULT = unchecked((int)0x80000000);

        /// <summary>
        /// Size of a font name or a font family name.
        /// </summary>
        public const int LF_FACESIZE = 32;

        public const uint STATUS_WAIT_0 = 0;

        public const uint WAIT_OBJECT_0 = STATUS_WAIT_0 + 0;

        public const uint STATUS_ABANDONED_WAIT_0 = 0x80;

        public const uint WAIT_ABANDONED_0 = STATUS_ABANDONED_WAIT_0 + 0;

        public const uint STATUS_USER_APC = 0x000000C0;

        public const uint WAIT_IO_COMPLETION = STATUS_USER_APC;

        public const uint WAIT_TIMEOUT = 258;

        public const uint WAIT_FAILED = 0xFFFFFFFF;

        public const uint ENUM_CURRENT_SETTINGS = unchecked((uint)-1);

        public const uint ENUM_REGISTRY_SETTINGS = unchecked((uint)-2);

        /// <summary>
        ///     A bitmap that is drawn by the window that owns the menu. The application must process the WM_MEASUREITEM and
        ///     WM_DRAWITEM messages.
        /// </summary>
        public static readonly IntPtr HBMMENU_CALLBACK = new IntPtr(-1);

        /// <summary>Close button for the menu bar.</summary>
        public static readonly IntPtr HBMMENU_MBAR_CLOSE = new IntPtr(5);

        /// <summary>Disabled close button for the menu bar.</summary>
        public static readonly IntPtr HBMMENU_MBAR_CLOSE_D = new IntPtr(6);

        /// <summary>Minimize button for the menu bar.</summary>
        public static readonly IntPtr HBMMENU_MBAR_MINIMIZE = new IntPtr(3);

        /// <summary>Disabled minimize button for the menu bar.</summary>
        public static readonly IntPtr HBMMENU_MBAR_MINIMIZE_D = new IntPtr(7);

        /// <summary>Restore button for the menu bar.</summary>
        public static readonly IntPtr HBMMENU_MBAR_RESTORE = new IntPtr(2);

        /// <summary>Close button for the submenu.</summary>
        public static readonly IntPtr HBMMENU_POPUP_CLOSE = new IntPtr(8);

        /// <summary>Maximize button for the submenu.</summary>
        public static readonly IntPtr HBMMENU_POPUP_MAXIMIZE = new IntPtr(10);

        /// <summary>Minimize button for the submenu.</summary>
        public static readonly IntPtr HBMMENU_POPUP_MINIMIZE = new IntPtr(11);

        /// <summary>Restore button for the submenu.</summary>
        public static readonly IntPtr HBMMENU_POPUP_RESTORE = new IntPtr(9);

        /// <summary>Windows icon or the icon of the window specified in <see cref="MENUITEMINFO.dwItemData" />.</summary>
        public static readonly IntPtr HBMMENU_SYSTEM = new IntPtr(1);

        /// <summary>
        /// Gets the predefined DPI_AWARENESS_CONTEXT handle for DPI unaware mode. These windows do not scale
        /// for DPI changes and are always assumed to have a scale factor of 100% (96 DPI). They will be automatically scaled by
        /// the system on any other DPI setting.
        /// </summary>
        /// <remarks>DPI_AWARENESS_CONTEXT values should never be compared directly. Instead, use AreDpiAwarenessContextsEqual function.</remarks>
        public static readonly IntPtr DPI_AWARENESS_CONTEXT_UNAWARE = new IntPtr(-1);

        /// <summary>
        /// Gets the predefined DPI_AWARENESS_CONTEXT handle for System aware mode. These windows do not scale for DPI changes.
        /// They will query for the DPI once and use that value for the lifetime of the process. If the DPI changes,
        /// the process will not adjust to the new DPI value. It will be automatically scaled up or down by the system
        /// when the DPI changes from the system value.
        /// </summary>
        /// <remarks>DPI_AWARENESS_CONTEXT values should never be compared directly. Instead, use AreDpiAwarenessContextsEqual function.</remarks>
        public static readonly IntPtr DPI_AWARENESS_CONTEXT_SYSTEM_AWARE = new IntPtr(-2);

        /// <summary>
        /// Gets the predefined DPI_AWARENESS_CONTEXT handle for the Per Monitor mode. These windows check for the DPI when
        /// they are created and adjust the scale factor whenever the DPI changes. These processes are not automatically
        /// scaled by the system.
        /// </summary>
        /// <remarks>DPI_AWARENESS_CONTEXT values should never be compared directly. Instead, use AreDpiAwarenessContextsEqual function.</remarks>
        public static readonly IntPtr DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE = new IntPtr(-3);

        /// <summary>
        /// Gets the predefined DPI_AWARENESS_CONTEXT handle for Per Monitor v2 mode.
        /// Per Monitor v2 is an advancement over the original Per Monitor DPI awareness mode, which enables applications to access
        /// new DPI-related scaling behaviors on a per top-level window basis. Per Monitor v2 was made available in the
        /// Creators Update of Windows 10, and is not available on earlier versions of the operating system. The additional behaviors
        /// introduced are as follows:
        /// <list type="bullet">
        /// <item>Child window DPI change notifications - In Per Monitor v2 contexts, the entire window tree is notified of any DPI changes that occur.</item>
        /// <item>Scaling of non-client area - All windows will automatically have their non-client area drawn in a DPI sensitive fashion. Calls to EnableNonClientDpiScaling are unnecessary.</item>
        /// <item>Scaling of Win32 menus - All NTUSER menus created in Per Monitor v2 contexts will be scaling in a per-monitor fashion.</item>
        /// <item>Dialog Scaling - Win32 dialogs created in Per Monitor v2 contexts will automatically respond to DPI changes.</item>
        /// <item>Improved scaling of comctl32 controls - Various comctl32 controls have improved DPI scaling behavior in Per Monitor v2 contexts.</item>
        /// <item>Improved theming behavior - UxTheme handles opened in the context of a Per Monitor v2 window will operate in terms of the DPI associated with that window.</item>
        /// </list>
        /// </summary>
        /// <remarks>DPI_AWARENESS_CONTEXT values should never be compared directly. Instead, use AreDpiAwarenessContextsEqual function.</remarks>
        public static readonly IntPtr DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = new IntPtr(-4);

        /// <summary>
        /// DPI unaware with improved quality of GDI-based content. This mode behaves similarly to <see cref="DPI_AWARENESS_CONTEXT_UNAWARE" />,
        /// but also enables the system to automatically improve the rendering quality of text and other GDI-based primitives when
        /// the window is displayed on a high-DPI monitor.
        /// </summary>
        /// <remarks>
        /// <see cref="DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED" /> was introduced in the October 2018 update
        /// of Windows 10 (also known as version 1809).
        /// For more details, see <see href="https://blogs.windows.com/buildingapps/2017/05/19/improving-high-dpi-experience-gdi-based-desktop-apps/#Uwv9gY1SvpbgQ4dK.97">Improving the high-DPI experience in GDI-based Desktop apps</see>.
        /// </remarks>
        public static readonly IntPtr DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED = new IntPtr(-5);

        /// <summary>
        /// A special windows handle used to indicate to <see cref="SendMessage(IntPtr, WindowMessage, IntPtr, IntPtr)" />
        /// that the message is sent to all top-level windows in the system, including disabled or invisible unowned windows,
        /// overlapped windows, and pop-up windows.
        /// </summary>
        public static readonly IntPtr HWND_BROADCAST = (IntPtr)0xffff;

        /// <summary>
        /// An application-defined or library-defined callback function used with the <see cref="SetWindowsHookEx(WindowsHookType, IntPtr, IntPtr, int)"/> function.
        /// This is a generic function to Hook callbacks. For specific callback functions see this <see href="https://msdn.microsoft.com/en-us/library/windows/desktop/ms632589(v=vs.85).aspx" >API documentation on MSDN</see>.
        /// </summary>
        /// <param name="nCode">An action code for the callback. Can be used to indicate if the hook procedure must process the message or not.</param>
        /// <param name="wParam">First message parameter.</param>
        /// <param name="lParam">Second message parameter.</param>
        /// <returns>
        /// An LRESULT. Usually if nCode is less than zero, the hook procedure must return the value returned by CallNextHookEx.
        /// If nCode is greater than or equal to zero, it is highly recommended that you call CallNextHookEx and return the value it returns;
        /// otherwise, other applications that have installed hooks will not receive hook notifications and may behave incorrectly as a result.
        /// If the hook procedure does not call CallNextHookEx, the return value should be zero.
        /// </returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int WindowsHookDelegate(int nCode, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// An application-defined callback (or hook) function that the system calls in response to events generated by an accessible object.
        /// The hook function processes the event notifications as required. Clients install the hook function and request specific types
        /// of event notifications by calling <see cref="SetWinEventHook(WindowsEventHookType, WindowsEventHookType, IntPtr, IntPtr, int, int, WindowsEventHookFlags)"/>.
        /// </summary>
        /// <param name="hWinEventHook">Handle to an event hook function. This value is returned by <see cref="SetWinEventHook(WindowsEventHookType, WindowsEventHookType, IntPtr, IntPtr, int, int, WindowsEventHookFlags)"/> when the hook function
        /// is installed and is specific to each instance of the hook function.</param>
        /// <param name="event">Specifies the event that occurred. This value is one of the <see cref="WindowsEventHookType"/> constants.</param>
        /// <param name="hwnd">Handle to the window that generates the event, or NULL if no window is associated with the event.
        /// For example, the mouse pointer is not associated with a window.</param>
        /// <param name="idObject">Identifies the object associated with the event. This is one of the object identifiers or a custom object ID.
        /// <see href="https://msdn.microsoft.com/en-us/library/windows/desktop/dd373606(v=vs.85).aspx"/>.</param>
        /// <param name="idChild">Identifies whether the event was triggered by an object or a child element of the object.
        /// If this value is CHILDID_SELF, the event was triggered by the object; otherwise, this value is the child ID of the element that triggered the event.</param>
        /// <param name="dwEventThread">Identifies the thread that generated the event, or the thread that owns the current window.</param>
        /// <param name="dwmsEventTime">Specifies the time, in milliseconds, that the event was generated.</param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void WinEventProc(
            IntPtr hWinEventHook,
            WindowsEventHookType @event,
            IntPtr hwnd,
            int idObject,
            int idChild,
            int dwEventThread,
            uint dwmsEventTime);

        /// <summary>
        /// An application-defined callback function used with the <see cref="EnumWindowStations(WINSTAENUMPROC, IntPtr)"/> function.
        /// </summary>
        /// <param name="lpszWindowStation">The name of the window station.</param>
        /// <param name="lParam">An application-defined value specified in the <see cref="EnumWindowStations(WINSTAENUMPROC, IntPtr)"/> function.</param>
        /// <returns>To continue enumeration, the callback function must return TRUE (non-zero value). To stop enumeration, it must return FALSE (0).</returns>
        /// <remarks>
        /// An application must register this callback function by passing its address to <see cref="EnumWindowStations(WINSTAENUMPROC, IntPtr)"/>.
        /// The callback function can call SetLastError to set an error code for the caller to retrieve by calling GetLastError.
        /// </remarks>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public delegate int WINSTAENUMPROC(string lpszWindowStation, IntPtr lParam);

        /// <summary>
        /// An application-defined callback function used with the <see cref="EnumDesktops(SafeWindowStationHandle, DESKTOPENUMPROC, IntPtr)"/> function.
        /// </summary>
        /// <param name="lpwstrDesktopName">The name of the desktop.</param>
        /// <param name="lParam">An application-defined value specified in the <see cref="EnumDesktops(SafeWindowStationHandle, DESKTOPENUMPROC, IntPtr)"/> function.</param>
        /// <returns>To continue enumeration, the callback function must return TRUE (non-zero value). To stop enumeration, it must return FALSE (0).</returns>
        /// <remarks>
        /// An application must register this callback function by passing its address to <see cref="EnumDesktops(SafeWindowStationHandle, DESKTOPENUMPROC, IntPtr)"/>.
        /// The callback function can call SetLastError to set an error code for the caller to retrieve by calling GetLastError.
        /// </remarks>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public delegate int DESKTOPENUMPROC(string lpwstrDesktopName, IntPtr lParam);

        /// <summary> An application-defined callback function used with the <see cref="EnumWindows"/> or <see cref="EnumDesktopWindows(SafeDesktopHandle, WNDENUMPROC, IntPtr)"/> function.</summary>
        /// <param name="hwnd">A handle to a top-level window.</param>
        /// <param name="lParam">The application-defined value given in <see cref="EnumWindows"/> or <see cref="EnumDesktopWindows(SafeDesktopHandle, WNDENUMPROC, IntPtr)"/>.</param>
        /// <returns>To continue enumeration, the callback function must return TRUE; to stop enumeration, it must return FALSE.</returns>
        /// <remarks>
        /// An application must register this callback function by passing its address to <see cref="EnumWindows"/> or <see cref="EnumDesktopWindows(SafeDesktopHandle, WNDENUMPROC, IntPtr)"/>.
        /// The callback function can call SetLastError to set an error code for the caller to retrieve by calling GetLastError.
        /// </remarks>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public delegate bool WNDENUMPROC(IntPtr hwnd, IntPtr lParam);

        /// <summary>
        ///     Application-defined callback function used with the CreateDialog and DialogBox families of functions. It processes
        ///     messages sent to a modal or modeless dialog box.
        /// </summary>
        /// <param name="hwndDlg">A handle to the dialog box.</param>
        /// <param name="uMsg">The message.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>
        ///     Typically, the dialog box procedure should return TRUE if it processed the message, and FALSE if it did not. If the
        ///     dialog box procedure returns FALSE, the dialog manager performs the default dialog operation in response to the
        ///     message.
        ///     <para>
        ///         If the dialog box procedure processes a message that requires a specific return value, the dialog box
        ///         procedure should set the desired return value by calling <see cref="SetWindowLong" /> with
        ///         <see cref="WindowLongIndexFlags.DWLP_MSGRESULT" /> immediately before returning TRUE. Note that you must call
        ///         SetWindowLong immediately before returning TRUE; doing so earlier may result in the
        ///         <see cref="WindowLongIndexFlags.DWLP_MSGRESULT" /> value being overwritten by a nested dialog box message.
        ///     </para>
        /// </returns>
        public delegate IntPtr DialogProc(IntPtr hwndDlg, WindowMessage uMsg, IntPtr wParam, IntPtr lParam);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void MSGBOXCALLBACK(HELPINFO lpHelpInfo);

        public unsafe delegate bool MONITORENUMPROC(IntPtr hMonitor, IntPtr hdcMonitor, RECT* lprcMonitor, void* dwData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public unsafe delegate IntPtr WndProc(IntPtr hWnd, WindowMessage msg, void* wParam, void* lParam);

        /// <summary>
        /// Plays a waveform sound. The waveform sound for each sound type is identified by an entry in the registry.
        /// </summary>
        /// <param name="uType">The sound to be played. The sounds are set by the user through the Sound control panel application, and then stored in the registry.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MessageBeep(MessageBeepType uType);

        [DllImport(nameof(User32))]
        public static extern MessageBoxResult MessageBox(IntPtr hWnd, string text, string caption, MessageBoxOptions options);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern int MessageBoxIndirect(ref MSGBOXPARAMS lpMsgBoxParams);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern int SetWindowLong(IntPtr hWnd, WindowLongIndexFlags nIndex, SetWindowLongFlags dwNewLong);

        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int GetWindowLong(IntPtr hWnd, WindowLongIndexFlags nIndex);

        /// <summary>
        /// Retrieves the name of the class to which the specified window belongs.
        /// </summary>
        /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="lpClassName">The class name string.</param>
        /// <param name="nMaxCount">
        /// The length of the <paramref name="lpClassName"/> buffer, in characters. The buffer must be large enough to include the terminating null character; otherwise, the class name string is truncated to <paramref name="nMaxCount"/>-1 characters.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of characters copied to the buffer, not including the terminating null character.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern unsafe int GetClassName(
            IntPtr hWnd,
            [Friendly(FriendlyFlags.Array | FriendlyFlags.Out, ArrayLengthParameter = 2)] char* lpClassName,
            int nMaxCount);

        /// <summary>
        /// Retrieves the identifier of the thread that created the specified window and, optionally, the identifier of the process that created the window.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="lpdwProcessId">A pointer to a variable that receives the process identifier. If this parameter is not NULL, GetWindowThreadProcessId copies the identifier of the process to the variable; otherwise, it does not.</param>
        /// <returns>The return value is the identifier of the thread that created the window.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        /// <summary>
        /// Attaches or detaches the input processing mechanism of one thread to that of another thread.
        /// </summary>
        /// <param name="idAttach">The identifier of the thread to be attached to another thread. The thread to be attached cannot be a system thread.</param>
        /// <param name="idAttachTo">The identifier of the thread to which idAttach will be attached. This thread cannot be a system thread. A thread cannot attach to itself. Therefore, idAttachTo cannot equal idAttach.</param>
        /// <param name="fAttach">If this parameter is TRUE, the two threads are attached. If the parameter is FALSE, the threads are detached.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError. Windows Server2003 and WindowsXP: There is no extended error information; do not call GetLastError. This behavior changed as of WindowsVista.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern bool AttachThreadInput(int idAttach, int idAttachTo, [MarshalAs(UnmanagedType.Bool)] bool fAttach);

        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        /// <summary>
        /// Retrieves the coordinates of a window's client area. The client coordinates specify the upper-left and lower-right corners of the client area. Because client coordinates are relative to the upper-left corner of a window's client area, the coordinates of the upper-left corner are (0,0).
        /// </summary>
        /// <param name="hWnd">A handle to the window whose client coordinates are to be retrieved.</param>
        /// <param name="lpRect">A pointer to a RECT structure that receives the client coordinates. The left and top members are zero. The right and bottom members contain the width and height of the window.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern bool GetCursorPos(out POINT lpPoint);

        /// <summary>
        /// Retrieves a handle to the foreground window (the window with which the user is currently
        /// working). The system assigns a slightly higher priority to the thread that creates the
        /// foreground window than it does to other threads.
        /// <para>
        /// See https://msdn.microsoft.com/en-us/library/windows/desktop/ms633505%28v=vs.85%29.aspx
        /// for more information.
        /// </para>
        /// </summary>
        /// <returns>
        /// C++ ( Type: Type: HWND ) <br/> The return value is a handle to the foreground window. The
        /// foreground window can be NULL in certain circumstances, such as when a window is losing activation.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window. These
        /// windows are ordered according to their appearance on the screen. The topmost window
        /// receives the highest rank and is the first window in the Z order.
        /// <para>
        /// See https://msdn.microsoft.com/en-us/library/windows/desktop/ms633545%28v=vs.85%29.aspx
        /// for more information.
        /// </para>
        /// </summary>
        /// <param name="hWnd">C++ ( hWnd Type: HWND ) <br/> A handle to the window.</param>
        /// <param name="hWndInsertAfter">
        /// C++ ( hWndInsertAfter Type: HWND ) <br/> A handle to the window to
        /// precede the positioned window in the Z order. This parameter must be a window handle or
        /// one of the following values.
        /// <list type="table">
        /// <itemheader>
        /// <term>HWND placement</term>
        /// <description>Window to precede placement</description>
        /// </itemheader>
        /// <item>
        /// <term>HWND_BOTTOM ((HWND)1)</term>
        /// <description>
        /// Places the window at the bottom of the Z order. If the hWnd parameter identifies a
        /// topmost window, the window loses its topmost status and is placed at the bottom of all
        /// other windows.
        /// </description>
        /// </item>
        /// <item>
        /// <term>HWND_NOTOPMOST ((HWND)-2)</term>
        /// <description>
        /// Places the window above all non-topmost windows (that is, behind all topmost windows).
        /// This flag has no effect if the window is already a non-topmost window.
        /// </description>
        /// </item>
        /// <item>
        /// <term>HWND_TOP ((HWND)0)</term>
        /// <description>Places the window at the top of the Z order.</description>
        /// </item>
        /// <item>
        /// <term>HWND_TOPMOST ((HWND)-1)</term>
        /// <description>
        /// Places the window above all non-topmost windows. The window maintains its topmost
        /// position even when it is deactivated.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// For more information about how this parameter is used, see the following Remarks section.
        /// </para>
        /// </param>
        /// <param name="X">
        /// C++ ( X Type: int ) <br/> The new position of the left side of the window, in
        /// client coordinates.
        /// </param>
        /// <param name="Y">
        /// C++ ( Y Type: int ) <br/> The new position of the top of the window, in client coordinates.
        /// </param>
        /// <param name="cx">C++ ( cx Type: int ) <br/> The new width of the window, in pixels.</param>
        /// <param name="cy">
        /// C++ ( cy Type: int ) <br/> The new height of the window, in pixels.
        /// </param>
        /// <param name="uFlags">
        /// C++ ( uFlags Type: UINT ) <br/> The window sizing and positioning flags. This
        /// parameter can be a combination of the following values.
        /// <list type="table">
        /// <itemheader>
        /// <term>HWND sizing and positioning flags</term>
        /// <description>Where to place and size window. Can be a combination of any</description>
        /// </itemheader>
        /// <item>
        /// <term>SWP_ASYNCWINDOWPOS (0x4000)</term>
        /// <description>
        /// If the calling thread and the thread that owns the window are attached to different input
        /// queues, the system posts the request to the thread that owns the window. This prevents
        /// the calling thread from blocking its execution while other threads process the request.
        /// </description>
        /// </item>
        /// <item>
        /// <term>SWP_DEFERERASE (0x2000)</term>
        /// <description>Prevents generation of the WM_SYNCPAINT message.</description>
        /// </item>
        /// <item>
        /// <term>SWP_DRAWFRAME (0x0020)</term>
        /// <description>
        /// Draws a frame (defined in the window's class description) around the window.
        /// </description>
        /// </item>
        /// <item>
        /// <term>SWP_FRAMECHANGED (0x0020)</term>
        /// <description>
        /// Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE
        /// message to the window, even if the window's size is not being changed. If this flag is
        /// not specified, WM_NCCALCSIZE is sent only when the window's size is being changed
        /// </description>
        /// </item>
        /// <item>
        /// <term>SWP_HIDEWINDOW (0x0080)</term>
        /// <description>Hides the window.</description>
        /// </item>
        /// <item>
        /// <term>SWP_NOACTIVATE (0x0010)</term>
        /// <description>
        /// Does not activate the window. If this flag is not set, the window is activated and moved
        /// to the top of either the topmost or non-topmost group (depending on the setting of the
        /// hWndInsertAfter parameter).
        /// </description>
        /// </item>
        /// <item>
        /// <term>SWP_NOCOPYBITS (0x0100)</term>
        /// <description>
        /// Discards the entire contents of the client area. If this flag is not specified, the valid
        /// contents of the client area are saved and copied back into the client area after the
        /// window is sized or repositioned.
        /// </description>
        /// </item>
        /// <item>
        /// <term>SWP_NOMOVE (0x0002)</term>
        /// <description>Retains the current position (ignores X and Y parameters).</description>
        /// </item>
        /// <item>
        /// <term>SWP_NOOWNERZORDER (0x0200)</term>
        /// <description>Does not change the owner window's position in the Z order.</description>
        /// </item>
        /// <item>
        /// <term>SWP_NOREDRAW (0x0008)</term>
        /// <description>
        /// Does not redraw changes. If this flag is set, no repainting of any kind occurs. This
        /// applies to the client area, the nonclient area (including the title bar and scroll bars),
        /// and any part of the parent window uncovered as a result of the window being moved. When
        /// this flag is set, the application must explicitly invalidate or redraw any parts of the
        /// window and parent window that need redrawing.
        /// </description>
        /// </item>
        /// <item>
        /// <term>SWP_NOREPOSITION (0x0200)</term>
        /// <description>Same as the SWP_NOOWNERZORDER flag.</description>
        /// </item>
        /// <item>
        /// <term>SWP_NOSENDCHANGING (0x0400)</term>
        /// <description>Prevents the window from receiving the WM_WINDOWPOSCHANGING message.</description>
        /// </item>
        /// <item>
        /// <term>SWP_NOSIZE (0x0001)</term>
        /// <description>Retains the current size (ignores the cx and cy parameters).</description>
        /// </item>
        /// <item>
        /// <term>SWP_NOZORDER (0x0004)</term>
        /// <description>Retains the current Z order (ignores the hWndInsertAfter parameter).</description>
        /// </item>
        /// <item>
        /// <term>SWP_SHOWWINDOW (0x0040)</term>
        /// <description>Displays the window.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>
        /// <c>true</c> or nonzero if the function succeeds, <c>false</c> or zero otherwise or if
        /// function fails.
        /// </returns>
        /// <remarks>
        /// <para>
        /// As part of the Vista re-architecture, all services were moved off the interactive desktop
        /// into Session 0. hwnd and window manager operations are only effective inside a session
        /// and cross-session attempts to manipulate the hwnd will fail. For more information, see
        /// The Windows Vista Developer Story: Application Compatibility Cookbook.
        /// </para>
        /// <para>
        /// If you have changed certain window data using SetWindowLong, you must call SetWindowPos
        /// for the changes to take effect. Use the following combination for uFlags: SWP_NOMOVE |
        /// SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED.
        /// </para>
        /// <para>
        /// A window can be made a topmost window either by setting the hWndInsertAfter parameter to
        /// HWND_TOPMOST and ensuring that the SWP_NOZORDER flag is not set, or by setting a window's
        /// position in the Z order so that it is above any existing topmost windows. When a
        /// non-topmost window is made topmost, its owned windows are also made topmost. Its owners,
        /// however, are not changed.
        /// </para>
        /// <para>
        /// If neither the SWP_NOACTIVATE nor SWP_NOZORDER flag is specified (that is, when the
        /// application requests that a window be simultaneously activated and its position in the Z
        /// order changed), the value specified in hWndInsertAfter is used only in the following circumstances.
        /// </para>
        /// <list type="bullet">
        /// <item>Neither the HWND_TOPMOST nor HWND_NOTOPMOST flag is specified in hWndInsertAfter.</item>
        /// <item>The window identified by hWnd is not the active window.</item>
        /// </list>
        /// <para>
        /// An application cannot activate an inactive window without also bringing it to the top of
        /// the Z order. Applications can change an activated window's position in the Z order
        /// without restrictions, or it can activate a window and then move it to the top of the
        /// topmost or non-topmost windows.
        /// </para>
        /// <para>
        /// If a topmost window is repositioned to the bottom (HWND_BOTTOM) of the Z order or after
        /// any non-topmost window, it is no longer topmost. When a topmost window is made
        /// non-topmost, its owners and its owned windows are also made non-topmost windows.
        /// </para>
        /// <para>
        /// A non-topmost window can own a topmost window, but the reverse cannot occur. Any window
        /// (for example, a dialog box) owned by a topmost window is itself made a topmost window, to
        /// ensure that all owned windows stay above their owner.
        /// </para>
        /// <para>
        /// If an application is not in the foreground, and should be in the foreground, it must call
        /// the SetForegroundWindow function.
        /// </para>
        /// <para>
        /// To use SetWindowPos to bring a window to the top, the process that owns the window must
        /// have SetForegroundWindow permission.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(
            IntPtr hWnd,
            IntPtr hWndInsertAfter,
            int X,
            int Y,
            int cx,
            int cy,
            SetWindowPosFlags uFlags);

        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MoveWindow(
            IntPtr hWnd,
            int X,
            int Y,
            int nWidth,
            int nHeight,
            [MarshalAs(UnmanagedType.Bool)] bool bRepaint);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        /// <summary>
        /// The ReleaseDC function releases a device context (DC), freeing it for use by other applications. The effect of the ReleaseDC function depends on the type of DC. It frees only common and window DCs. It has no effect on class or private DCs.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose DC is to be released.</param>
        /// <param name="hDC">A handle to the DC to be released.</param>
        /// <returns>
        /// The return value indicates whether the DC was released. If the DC was released, the return value is 1.
        /// If the DC was not released, the return value is zero.
        /// </returns>
#if NETFRAMEWORK || NETSTANDARD2_0_ORLATER
        [SuppressUnmanagedCodeSecurity]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
        [DllImport(nameof(User32), SetLastError = false)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        /// <summary>
        /// Retrieves a handle to the top-level window whose class name and window name match the specified strings. This function does not search child windows. This function does not perform a case-sensitive search. To search child windows, beginning with a specified child window, use the FindWindowEx function.
        /// </summary>
        /// <param name="lpClassName">The window class name. If lpClassName is NULL, it finds any window whose title matches the lpWindowName parameter.</param>
        /// <param name="lpWindowName">The window name (the window's title). If this parameter is NULL, all window names match.</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has the specified
        ///  class name and window name. If the function fails, the return value is NULL.</returns>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindowEx(
            IntPtr parentHandle,
            IntPtr childAfter,
            string className,
            string windowTitle);

        /// <summary>
        /// Shows a Window.
        /// </summary>
        /// <remarks>
        /// <para>To perform certain special effects when showing or hiding a window, use AnimateWindow.</para>
        /// <para>
        /// The first time an application calls ShowWindow, it should use the WinMain function's
        /// nCmdShow parameter as its nCmdShow parameter. Subsequent calls to ShowWindow must use one
        /// of the values in the given list, instead of the one specified by the WinMain function's
        /// nCmdShow parameter.
        /// </para>
        /// <para>
        /// As noted in the discussion of the nCmdShow parameter, the nCmdShow value is ignored in
        /// the first call to ShowWindow if the program that launched the application specifies
        /// startup information in the structure. In this case, ShowWindow uses the information
        /// specified in the STARTUPINFO structure to show the window. On subsequent calls, the
        /// application must call ShowWindow with nCmdShow set to SW_SHOWDEFAULT to use the startup
        /// information provided by the program that launched the application. This behavior is
        /// designed for the following situations:
        /// </para>
        /// <list type="">
        /// <item>
        /// Applications create their main window by calling CreateWindow with the WS_VISIBLE flag set.
        /// </item>
        /// <item>
        /// Applications create their main window by calling CreateWindow with the WS_VISIBLE flag
        /// cleared, and later call ShowWindow with the SW_SHOW flag set to make it visible.
        /// </item>
        /// </list>
        /// </remarks>
        /// <param name="hWnd">Handle to the window.</param>
        /// <param name="nCmdShow">
        /// Specifies how the window is to be shown. This parameter is ignored the first time an
        /// application calls ShowWindow, if the program that launched the application provides a
        /// STARTUPINFO structure. Otherwise, the first time ShowWindow is called, the value should
        /// be the value obtained by the WinMain function in its nCmdShow parameter. In subsequent
        /// calls, this parameter can be one of the WindowShowStyle members.
        /// </param>
        /// <returns>
        /// If the window was previously visible, the return value is nonzero. If the window was
        /// previously hidden, the return value is zero.
        /// </returns>
        [DllImport(nameof(User32))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, WindowShowStyle nCmdShow);

        /// <summary>
        /// Retrieves a handle to the desktop window. The desktop window covers the entire screen. The desktop window is the area on top of which other windows are painted.
        /// </summary>
        /// <returns>The return value is a handle to the desktop window.</returns>
        [DllImport(nameof(User32))]
        public static extern IntPtr GetDesktopWindow();

        /// <summary>
        /// Retrieves a handle to the Shell's desktop window.
        /// </summary>
        /// <returns>The return value is the handle of the Shell's desktop window. If no Shell process is present, the return value is NULL.</returns>
        [DllImport(nameof(User32))]
        public static extern IntPtr GetShellWindow();

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
        /// To send a message and return immediately, use the SendMessageCallback or SendNotifyMessage function. To post a message to a thread's message queue and return immediately, use the PostMessage or PostThreadMessage function.
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.
        /// Message sending is subject to UIPI. The thread of a process can send messages only to message queues of threads in processes of lesser or equal integrity level.
        /// </param>
        /// <param name="wMsg">
        /// The message to be sent.
        /// For lists of the system-provided messages, see <see cref="WindowMessage"/>.
        /// </param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern unsafe IntPtr SendMessage(IntPtr hWnd, WindowMessage wMsg, void* wParam, void* lParam);

        /// <summary>
        /// Places (posts) a message in the message queue associated with the thread that created the specified window and returns without waiting for the thread to process the message.
        /// To post a message in the message queue associated with a thread, use the PostThreadMessage function.
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose window procedure is to receive the message.
        /// </param>
        /// <param name="wMsg">
        /// The message to be posted.
        /// For lists of the system-provided messages, see <see cref="WindowMessage"/>.
        /// </param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError. GetLastError returns ERROR_NOT_ENOUGH_QUOTA when the limit is hit.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool PostMessage(IntPtr hWnd, WindowMessage wMsg, void* wParam, void* lParam);

        /// <summary>
        /// Sends the specified message to one or more windows.
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose window procedure will receive the message.
        /// If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows.
        /// The function does not return until each window has timed out.
        /// Therefore, the total wait time can be up to the value of uTimeout multiplied by the number of top-level windows.
        /// </param>
        /// <param name="msg">
        /// The message to be sent.
        /// For lists of the system-provided messages, see <see cref="WindowMessage"/>.
        /// </param>
        /// <param name="wParam">Any additional message-specific information.</param>
        /// <param name="lParam">Any additional message-specific information.</param>
        /// <param name="flags">The behavior of this function. This parameter can be one or more of the following values: <see cref="SendMessageTimeoutFlags"/>.</param>
        /// <param name="timeout">The duration of the time-out period, in milliseconds.
        /// If the message is a broadcast message, each window can use the full time-out period.
        /// For example, if you specify a five second time-out period and there are three top-level windows that fail to process the message, you could have up to a 15 second delay.
        /// </param>
        /// <param name="pdwResult">The result of the message processing. The value of this parameter depends on the message that is specified.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// SendMessageTimeout does not provide information about individual windows timing out if HWND_BROADCAST is used.
        /// If the function fails or times out, the return value is 0.
        /// To get extended error information, call GetLastError.
        /// If GetLastError returns ERROR_TIMEOUT, then the function timed out.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr SendMessageTimeout(IntPtr hWnd, WindowMessage msg, IntPtr wParam, IntPtr lParam, SendMessageTimeoutFlags flags, int timeout, out IntPtr pdwResult);

        /// <summary>
        ///     Brings the thread that created the specified window into the foreground and activates the window. Keyboard
        ///     input is directed to the window, and various visual cues are changed for the user. The system assigns a slightly
        ///     higher priority to the thread that created the foreground window than it does to other threads.
        /// </summary>
        /// <param name="hWnd">A handle to the window that should be activated and brought to the foreground.</param>
        /// <returns>
        ///     If the window was brought to the foreground, the return value is true.
        ///     <para>If the window was not brought to the foreground, the return value is false.</para>
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>Retrieves the handle to the ancestor of the specified window.</summary>
        /// <param name="hWnd">
        ///     A handle to the window whose ancestor is to be retrieved. If this parameter is the desktop window,
        ///     the function returns <see cref="IntPtr.Zero" />.
        /// </param>
        /// <param name="gaFlags">The ancestor to be retrieved.</param>
        /// <returns>The handle to the ancestor window.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr GetAncestor(IntPtr hWnd, GetAncestorFlags gaFlags);

        /// <summary>
        ///     Installs an application-defined hook procedure into a hook chain. You would install a hook procedure to
        ///     monitor the system for certain types of events. These events are associated either with a specific thread or with
        ///     all threads in the same desktop as the calling thread.
        /// </summary>
        /// <param name="idHook">The type of hook procedure to be installed.</param>
        /// <param name="lpfn">
        ///     A pointer to the hook procedure. If the <paramref name="dwThreadId" /> parameter is zero or
        ///     specifies the identifier of a thread created by a different process, the <paramref name="lpfn" /> parameter must
        ///     point to a hook procedure in a DLL. Otherwise, <paramref name="lpfn" /> can point to a hook procedure in the code
        ///     associated with the current process.
        /// </param>
        /// <param name="hMod">
        ///     A handle to the DLL containing the hook procedure pointed to by the <paramref name="lpfn" />
        ///     parameter. The <paramref name="hMod" /> parameter must be set to <see cref="IntPtr.Zero" /> if the
        ///     <paramref name="dwThreadId" /> parameter specifies a thread created by the current process and if the hook
        ///     procedure is within the code associated with the current process.
        /// </param>
        /// <param name="dwThreadId">
        ///     The identifier of the thread with which the hook procedure is to be associated. For desktop
        ///     apps, if this parameter is zero, the hook procedure is associated with all existing threads running in the same
        ///     desktop as the calling thread. For Windows Store apps, see the Remarks section.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is the handle to the hook procedure.
        ///     <para>
        ///         If the function fails, the return value is an invalid handle. To get extended error information,
        ///         call GetLastError.
        ///     </para>
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern SafeHookHandle SetWindowsHookEx(
            WindowsHookType idHook,
            WindowsHookDelegate lpfn,
            IntPtr hMod,
            int dwThreadId);

        /// <summary>
        ///     Installs an application-defined hook procedure into a hook chain. You would install a hook procedure to
        ///     monitor the system for certain types of events. These events are associated either with a specific thread or with
        ///     all threads in the same desktop as the calling thread.
        /// </summary>
        /// <param name="idHook">The type of hook procedure to be installed.</param>
        /// <param name="lpfn">
        ///     A pointer to the hook procedure. If the <paramref name="dwThreadId" /> parameter is zero or
        ///     specifies the identifier of a thread created by a different process, the <paramref name="lpfn" /> parameter must
        ///     point to a hook procedure in a DLL. Otherwise, <paramref name="lpfn" /> can point to a hook procedure in the code
        ///     associated with the current process.
        /// </param>
        /// <param name="hMod">
        ///     A handle to the DLL containing the hook procedure pointed to by the <paramref name="lpfn" />
        ///     parameter. The <paramref name="hMod" /> parameter must be set to <see cref="IntPtr.Zero" /> if the
        ///     <paramref name="dwThreadId" /> parameter specifies a thread created by the current process and if the hook
        ///     procedure is within the code associated with the current process.
        /// </param>
        /// <param name="dwThreadId">
        ///     The identifier of the thread with which the hook procedure is to be associated. For desktop
        ///     apps, if this parameter is zero, the hook procedure is associated with all existing threads running in the same
        ///     desktop as the calling thread. For Windows Store apps, see the Remarks section.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is the handle to the hook procedure.
        ///     <para>
        ///         If the function fails, the return value is an invalid handle. To get extended error information,
        ///         call GetLastError.
        ///     </para>
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern SafeHookHandle SetWindowsHookEx(
            WindowsHookType idHook,
            IntPtr lpfn,
            IntPtr hMod,
            int dwThreadId);

        /// <summary>
        /// Sets an event hook function for a range of events.
        /// </summary>
        /// <param name="eventMin">Specifies the event constant for the lowest event value in the range of events that are handled by
        /// the hook function. This parameter can be set to EVENT_MIN to indicate the lowest possible event value.</param>
        /// <param name="eventMax">Specifies the event constant for the highest event value in the range of events that are handled by
        /// the hook function. This parameter can be set to EVENT_MAX to indicate the highest possible event value.</param>
        /// <param name="hmodWinEventProc">Handle to the DLL that contains the hook function at lpfnWinEventProc, if the WINEVENT_INCONTEXT
        /// flag is specified in the dwFlags parameter. If the hook function is not located in a DLL, or if the WINEVENT_OUTOFCONTEXT flag
        /// is specified, this parameter is NULL.</param>
        /// <param name="lpfnWinEventProc">Pointer to the event hook function. For more information about this function, see WinEventProc.</param>
        /// <param name="idProcess">Specifies the ID of the process from which the hook function receives events. Specify zero (0) to
        /// receive events from all processes on the current desktop.</param>
        /// <param name="idThread">Specifies the ID of the thread from which the hook function receives events. If this parameter is zero,
        /// the hook function is associated with all existing threads on the current desktop.</param>
        /// <param name="dwflags">Flag values that specify the location of the hook function and of the events to be skipped.</param>
        /// <returns>If successful, returns an <see cref="SafeEventHookHandle"/> value that identifies this event hook instance.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern SafeEventHookHandle SetWinEventHook(
            WindowsEventHookType eventMin,
            WindowsEventHookType eventMax,
            IntPtr hmodWinEventProc,
            IntPtr lpfnWinEventProc,
            int idProcess,
            int idThread,
            WindowsEventHookFlags dwflags);

        /// <summary>
        /// Sets an event hook function for a range of events.
        /// </summary>
        /// <param name="eventMin">Specifies the event constant for the lowest event value in the range of events that are handled by
        /// the hook function. This parameter can be set to EVENT_MIN to indicate the lowest possible event value.</param>
        /// <param name="eventMax">Specifies the event constant for the highest event value in the range of events that are handled by
        /// the hook function. This parameter can be set to EVENT_MAX to indicate the highest possible event value.</param>
        /// <param name="hmodWinEventProc">Handle to the DLL that contains the hook function at lpfnWinEventProc, if the WINEVENT_INCONTEXT
        /// flag is specified in the dwFlags parameter. If the hook function is not located in a DLL, or if the WINEVENT_OUTOFCONTEXT flag
        /// is specified, this parameter is NULL.</param>
        /// <param name="lpfnWinEventProc">Pointer to the event hook function. For more information about this function, see WinEventProc.</param>
        /// <param name="idProcess">Specifies the ID of the process from which the hook function receives events. Specify zero (0) to
        /// receive events from all processes on the current desktop.</param>
        /// <param name="idThread">Specifies the ID of the thread from which the hook function receives events. If this parameter is zero,
        /// the hook function is associated with all existing threads on the current desktop.</param>
        /// <param name="dwflags">Flag values that specify the location of the hook function and of the events to be skipped.</param>
        /// <returns>If successful, returns an <see cref="SafeEventHookHandle"/> value that identifies this event hook instance.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern SafeEventHookHandle SetWinEventHook(
            WindowsEventHookType eventMin,
            WindowsEventHookType eventMax,
            IntPtr hmodWinEventProc,
            WinEventProc lpfnWinEventProc,
            int idProcess,
            int idThread,
            WindowsEventHookFlags dwflags);

        /// <summary>
        ///     Passes the hook information to the next hook procedure in the current hook chain. A hook procedure can call
        ///     this function either before or after processing the hook information.
        /// </summary>
        /// <param name="hhk">This parameter is ignored.</param>
        /// <param name="nCode">
        ///     The hook code passed to the current hook procedure. The next hook procedure uses this code to
        ///     determine how to process the hook information.
        /// </param>
        /// <param name="wParam">
        ///     The wParam value passed to the current hook procedure. The meaning of this parameter depends on
        ///     the type of hook associated with the current hook chain.
        /// </param>
        /// <param name="lParam">
        ///     The lParam value passed to the current hook procedure. The meaning of this parameter depends on
        ///     the type of hook associated with the current hook chain.
        /// </param>
        /// <returns>
        ///     This value is returned by the next hook procedure in the chain. The current hook procedure must also return
        ///     this value. The meaning of the return value depends on the hook type. For more information, see the descriptions of
        ///     the individual hook procedures.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern int CallNextHookEx(
            IntPtr hhk,
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        /// <summary>
        ///     Sets the mouse capture to the specified window belonging to the current thread.SetCapture captures mouse input
        ///     either when the mouse is over the capturing window, or when the mouse button was pressed while the mouse was over
        ///     the capturing window and the button is still down. Only one window at a time can capture the mouse.
        ///     <para>
        ///         If the mouse cursor is over a window created by another thread, the system will direct mouse input to the
        ///         specified window only if a mouse button is down.
        ///     </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window in the current thread that is to capture the mouse.</param>
        /// <returns>
        ///     The return value is a handle to the window that had previously captured the mouse. If there is no such window,
        ///     the return value is <see cref="IntPtr.Zero" />.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr SetCapture(IntPtr hWnd);

        /// <summary>
        ///     Releases the mouse capture from a window in the current thread and restores normal mouse input processing. A
        ///     window that has captured the mouse receives all mouse input, regardless of the position of the cursor, except when
        ///     a mouse button is clicked while the cursor hot spot is in the window of another thread.
        /// </summary>
        /// <returns>
        ///     If the function succeeds, the return value is true.
        ///     <para>If the function fails, the return value is false. To get extended error information, call GetLastError.</para>
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReleaseCapture();

        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, PrintWindowFlags nFlags);

        /// <summary>Flashes the specified window. It does not change the active state of the window.</summary>
        /// <param name="pwfi">A pointer to a <see cref="FLASHWINFO" /> structure.</param>
        /// <returns>
        ///     The return value specifies the window's state before the call to the FlashWindowEx function. If the window
        ///     caption was drawn as active before the call, the return value is nonzero. Otherwise, the return value is zero.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        /// <summary>
        ///     Enables the application to access the window menu (also known as the system menu or the control menu) for
        ///     copying and modifying.
        /// </summary>
        /// <param name="hWnd">A handle to the window that will own a copy of the window menu.</param>
        /// <param name="bRevert">
        ///     The action to be taken. If this parameter is FALSE, GetSystemMenu returns a handle to the copy of
        ///     the window menu currently in use. The copy is initially identical to the window menu, but it can be modified. If
        ///     this parameter is TRUE, GetSystemMenu resets the window menu back to the default state. The previous window menu,
        ///     if any, is destroyed.
        /// </param>
        /// <returns>
        ///     If the bRevert parameter is FALSE, the return value is a handle to a copy of the window menu. If the bRevert
        ///     parameter is TRUE, the return value is NULL.
        /// </returns>
        [DllImport(nameof(User32))]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)] bool bRevert);

        /// <summary>
        /// Loads the specified cursor resource from the executable (.EXE) file associated with an application instance.
        /// </summary>
        /// <param name="hInstance">A handle to an instance of the module whose executable file contains the cursor to be loaded.</param>
        /// <param name="lpCursorName">
        /// The name of the cursor resource to be loaded. Alternatively, this parameter can consist of the resource identifier in the low-order word and zero in the high-order word.
        /// The <see cref="Kernel32.MAKEINTRESOURCE(int)"/> macro can also be used to create this value. To use one of the predefined cursors, the application must set the hInstance parameter to NULL and the lpCursorName parameter to one the values defined by <see cref="Cursors" />.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the newly loaded cursor.
        /// If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError" />.
        /// </returns>
        /// <remarks>
        /// Note: This function has been superseded by the LoadImage function.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern unsafe SafeCursorHandle LoadCursor(
            IntPtr hInstance,
            [Friendly(FriendlyFlags.Array | FriendlyFlags.In)] char* lpCursorName);

        /// <summary>
        /// Retrieves a handle to the current cursor.
        /// To get information on the global cursor, even if it is not owned by the current thread, use <see cref="GetCursorInfo(CURSORINFO*)" />.
        /// </summary>
        /// <returns>The return value is the handle to the current cursor. If there is no cursor, the return value is null.</returns>
        [DllImport(nameof(User32))]
        public static extern SafeCursorHandle GetCursor();

        /// <summary>
        /// Creates a cursor having the specified size, bit patterns, and hot spot.
        /// </summary>
        /// <param name="hInst">A handle to the current instance of the application creating the cursor.</param>
        /// <param name="xHotspot">The horizontal position of the cursor's hot spot.</param>
        /// <param name="yHotSpot">The vertical position of the cursor's hot spot.</param>
        /// <param name="nWidth">The width of the cursor, in pixels.</param>
        /// <param name="nHeight">The height of the cursor, in pixels.</param>
        /// <param name="pvANDPlane">An array of bytes that contains the bit values for the AND mask of the cursor, as in a device-dependent monochrome bitmap.</param>
        /// <param name="pvXORPlane">An array of bytes that contains the bit values for the XOR mask of the cursor, as in a device-dependent monochrome bitmap.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the cursor.
        /// If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>The <paramref name="nWidth"/> and <paramref name="nHeight"/> parameters must specify a width and height that are supported by the current display driver, because the system cannot create cursors of other sizes. To determine the width and height supported by the display driver, use the GetSystemMetrics function, specifying the SM_CXCURSOR or SM_CYCURSOR value.</para>
        /// <para>Before closing, an application must call the <see cref="DestroyCursor"/> function to free any system resources associated with the cursor.</para>
        /// <para>This API does not participate in DPI virtualization. The output returned is in terms of physical coordinates, and is not affected by the DPI of the calling thread. Note that the cursor created may still be scaled to match the DPI of any given window it is drawn into.</para>
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern unsafe SafeCursorHandle CreateCursor(
            IntPtr hInst,
            int xHotspot,
            int yHotSpot,
            int nWidth,
            int nHeight,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Array)] byte* pvANDPlane,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Array)] byte* pvXORPlane);

        /// <summary>
        /// Sets the cursor shape.
        /// </summary>
        /// <param name="hCursor">
        /// A handle to the cursor. The cursor must have been created by the <see cref="CreateCursor(IntPtr, int, int, int, int, byte*, byte*)" /> function or loaded by the <see cref="LoadCursor(IntPtr, char*)" /> or <see cref="LoadImage(IntPtr, char*, ImageType, int, int, LoadImageFlags)" /> function. If this parameter is NULL, the cursor is removed from the screen.
        /// </param>
        /// <returns>
        /// The return value is the handle to the previous cursor, if there was one.
        /// If there was no previous cursor, the return value is NULL.
        /// </returns>
        /// <remarks>
        /// <para>The cursor is set only if the new cursor is different from the previous cursor; otherwise, the function returns immediately.</para>
        /// <para>The cursor is a shared resource. A window should set the cursor shape only when the cursor is in its client area or when the window is capturing mouse input. In systems without a mouse, the window should restore the previous cursor before the cursor leaves the client area or before it relinquishes control to another window.</para>
        /// <para>If your application must set the cursor while it is in a window, make sure the class cursor for the specified window's class is set to NULL. If the class cursor is not NULL, the system restores the class cursor each time the mouse is moved.</para>
        /// <para>The cursor is not shown on the screen if the internal cursor display count is less than zero. This occurs if the application uses the <see cref="ShowCursor" /> function to hide the cursor more times than to show the cursor.</para>
        /// </remarks>
        [DllImport(nameof(User32))]
        public static extern SafeCursorHandle SetCursor(SafeCursorHandle hCursor);

        /// <summary>
        /// Retrieves information about the global cursor.
        /// </summary>
        /// <param name="pci">A pointer to a <see cref="CURSORINFO" /> structure that receives the information. Note that you must set the <see cref="CURSORINFO.cbSize" /> member to sizeof(CURSORINFO) before calling this function.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError" />.
        /// </returns>
        [DllImport(nameof(User32))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool GetCursorInfo(
            [Friendly(FriendlyFlags.Bidirectional)] CURSORINFO* pci);

        /// <summary>
        /// Displays or hides the cursor.
        /// </summary>
        /// <param name="bShow">
        /// If bShow is TRUE, the display count is incremented by one. If bShow is FALSE, the display count is decremented by one.
        /// </param>
        /// <returns>The return value specifies the new display counter.</returns>
        /// <remarks>
        /// Windows 8: Call <see cref="GetCursorInfo(CURSORINFO*)"/> to determine the cursor visibility.
        /// This function sets an internal display counter that determines whether the cursor should be displayed. The cursor is displayed only if the display count is greater than or equal to 0. If a mouse is installed, the initial display count is 0. If no mouse is installed, the display count is -1.
        /// </remarks>
        [DllImport(nameof(User32))]
        public static extern int ShowCursor([MarshalAs(UnmanagedType.Bool)] bool bShow);

        /// <summary>
        /// Loads an icon, cursor, animated cursor, or bitmap.
        /// </summary>
        /// <param name="hInst">
        /// A handle to the module of either a DLL or executable (.exe) that contains the image to be loaded. For more information, see <see cref="GetModuleHandle"/>. Note that as of 32-bit Windows, an instance handle (HINSTANCE), such as the application instance handle exposed by system function call of WinMain, and a module handle (HMODULE) are the same thing.
        /// To load an OEM image, set this parameter to NULL.
        /// To load a stand-alone resource (icon, cursor, or bitmap file)—for example, c:\myimage.bmp—set this parameter to NULL.
        /// </param>
        /// <param name="name">
        /// The image to be loaded. If the hinst parameter is non-NULL and the fuLoad parameter omits LR_LOADFROMFILE, lpszName specifies the image resource in the hinst module. If the image resource is to be loaded by name from the module, the lpszName parameter is a pointer to a null-terminated string that contains the name of the image resource. If the image resource is to be loaded by ordinal from the module, use the MAKEINTRESOURCE macro to convert the image ordinal into a form that can be passed to the LoadImage function.
        /// For more information, see the <see href="https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-loadimagew">Microsoft documentation</see>.
        /// </param>
        /// <param name="type">The type of image to be loaded.</param>
        /// <param name="cx">The width, in pixels, of the icon or cursor. If this parameter is zero and the fuLoad parameter is LR_DEFAULTSIZE, the function uses the SM_CXICON or SM_CXCURSOR system metric value to set the width. If this parameter is zero and LR_DEFAULTSIZE is not used, the function uses the actual resource width.</param>
        /// <param name="cy">The height, in pixels, of the icon or cursor. If this parameter is zero and the fuLoad parameter is LR_DEFAULTSIZE, the function uses the SM_CYICON or SM_CYCURSOR system metric value to set the height. If this parameter is zero and LR_DEFAULTSIZE is not used, the function uses the actual resource height.</param>
        /// <param name="fuLoad">This parameter can be one or more of the values defined by the enum.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle of the newly loaded image.
        /// If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern unsafe IntPtr LoadImage(
            IntPtr hInst,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Array)] char* name,
            ImageType type,
            int cx,
            int cy,
            LoadImageFlags fuLoad);

        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr LoadIcon(IntPtr hInstance, string lpIconName);

        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIconName);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr RealChildWindowFromPoint(IntPtr hwndParent, POINT ptParentClientCoords);

        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowDisplayAffinity(IntPtr hWnd, int dwAffinity);

        /// <summary>
        /// Retrieves a string that specifies the window type.
        /// </summary>
        /// <param name="hwnd">A handle to the window whose type will be retrieved.</param>
        /// <param name="pszType">A pointer to a string that receives the window type.</param>
        /// <param name="cchType">The length, in characters, of the buffer pointed to by the <paramref name="pszType"/> parameter.</param>
        /// <returns>
        /// If the function succeeds, the return value is the number of characters copied to the specified buffer.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern unsafe uint RealGetWindowClass(
            IntPtr hwnd,
            [Friendly(FriendlyFlags.Array | FriendlyFlags.Out, ArrayLengthParameter = 2)] char* pszType,
            uint cchType);

        /// <summary>
        ///     Appends a new item to the end of the specified menu bar, drop-down menu, submenu, or shortcut menu. You can
        ///     use this function to specify the content, appearance, and behavior of the menu item.
        /// </summary>
        /// <param name="hMenu">A handle to the menu bar, drop-down menu, submenu, or shortcut menu to be changed.</param>
        /// <param name="uFlags">Controls the appearance and behavior of the new menu item.</param>
        /// <param name="uIdNewItem">
        ///     The identifier of the new menu item or, if the uFlags parameter is set to
        ///     <see cref="MenuItemFlags.MF_POPUP" />, a handle to the drop-down menu or submenu.
        /// </param>
        /// <param name="lpNewItem">
        ///     The content of the new menu item. The interpretation of lpNewItem depends on whether the uFlags parameter includes
        ///     the following values.
        ///     <para><see cref="MenuItemFlags.MF_BITMAP" />: Contains a bitmap handle.</para>
        ///     <para>
        ///         <see cref="MenuItemFlags.MF_OWNERDRAW" />: Contains an application-supplied value that can be used to
        ///         maintain additional data related to the menu item. The value is in the itemData member of the structure pointed
        ///         to by the lParam parameter of the WM_MEASUREITEM or WM_DRAWITEM message sent when the menu is created or its
        ///         appearance is updated.
        ///     </para>
        ///     <para><see cref="MenuItemFlags.MF_STRING" />: Contains a pointer to a null-terminated string.</para>
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is true.
        ///     <para>If the function fails, the return value is false. To get extended error information, call GetLastError.</para>
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AppendMenu(
            IntPtr hMenu,
            MenuItemFlags uFlags,
            IntPtr uIdNewItem,
            string lpNewItem);

        /// <summary>Changes information about a menu item.</summary>
        /// <param name="hMenu">A handle to the menu that contains the menu item.</param>
        /// <param name="uItem">
        ///     The identifier or position of the menu item to change. The meaning of this parameter depends on the
        ///     value of <paramref name="fByPosition" />.
        /// </param>
        /// <param name="fByPosition">
        ///     The meaning of uItem. If this parameter is FALSE, uItem is a menu item identifier. Otherwise,
        ///     it is a menu item position.
        /// </param>
        /// <param name="lpmii">
        ///     A <see cref="MENUITEMINFO" /> structure that contains information about the menu item and specifies
        ///     which menu item attributes to change.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is true.
        ///     <para>If the function fails, the return value is false. To get extended error information, call GetLastError.</para>
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool SetMenuItemInfo(
            IntPtr hMenu,
            uint uItem,
            [MarshalAs(UnmanagedType.Bool)] bool fByPosition,
            [Friendly(FriendlyFlags.In)] MENUITEMINFO* lpmii);

        /// <summary>
        /// Retrieves a handle to the menu assigned to the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose menu handle is to be retrieved.</param>
        /// <returns>The return value is a handle to the menu. If the specified window has no menu, the return value is <see cref="IntPtr.Zero"/>. If the window is a child window, the return value is undefined.</returns>
        /// <remarks>
        /// <see cref="GetMenu"/> does not work on floating menu bars. Floating menu bars are custom controls that mimic standard menus; they are not menus. To get the handle on a floating menu bar, use the Active Accessibility APIs.
        /// </remarks>
        [DllImport(nameof(User32))]
        public static extern IntPtr GetMenu(IntPtr hWnd);

        /// <summary>
        /// Retrieves information about the specified menu bar.
        /// </summary>
        /// <param name="hwnd">A handle to the window (menu bar) whose information is to be retrieved.</param>
        /// <param name="idObject">The menu object.</param>
        /// <param name="idItem">The item for which to retrieve information. If this parameter is zero, the function retrieves information about the menu itself. If this parameter is 1, the function retrieves information about the first item on the menu, and so on.</param>
        /// <param name="pmbi">A pointer to a <see cref="MENUBARINFO"/> structure that receives the information. Note that you must set the <see cref="MENUBARINFO.cbSize"/> member to sizeof(MENUBARINFO) before calling this function.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool GetMenuBarInfo(
            IntPtr hwnd,
            MenuObject idObject,
            int idItem,
            MENUBARINFO* pmbi);

        /// <summary>
        /// Retrieves the dimensions of the default check-mark bitmap.
        /// The system displays this bitmap next to selected menu items.
        /// Before calling the SetMenuItemBitmaps function to replace the default check-mark bitmap for a menu item,
        /// an application must determine the correct bitmap size by calling <see cref="GetMenuCheckMarkDimensions"/>.
        /// </summary>
        /// <returns>
        /// The return value specifies the height and width, in pixels, of the default check-mark bitmap. The high-order word contains the height; the low-order word contains the width.
        /// </returns>
        [DllImport(nameof(User32))]
        [Obsolete("The GetMenuCheckMarkDimensions function is included only for compatibility with 16-bit versions of Windows. Applications should use the GetSystemMetrics function with the CXMENUCHECK and CYMENUCHECK values to retrieve the bitmap dimensions.")]
        public static extern int GetMenuCheckMarkDimensions();

        /// <summary>
        /// Determines the default menu item on the specified menu.
        /// </summary>
        /// <param name="hMenu">A handle to the menu for which to retrieve the default menu item.</param>
        /// <param name="fByPos">Indicates whether to retrieve the menu item's identifier or its position. If this parameter is 0, the identifier is returned. Otherwise, the position is returned.</param>
        /// <param name="gmdiFlags">Indicates how the function should search for menu items.</param>
        /// <returns>If the function succeeds, the return value is the identifier or position of the menu item. If the function fails, the return value is -1. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern uint GetMenuDefaultItem(
            IntPtr hMenu,
            uint fByPos,
            GetMenuDefaultItemFlags gmdiFlags);

        /// <summary>
        /// Retrieves information about a specified menu.
        /// </summary>
        /// <param name="hMenu">A handle on a menu.</param>
        /// <param name="lpMenuInfo">A pointer to a <see cref="MENUINFO"/> structure containing information for the menu. Note that you must set the <see cref="MENUINFO.cbSize"/> member to sizeof(MENUINFO) before calling this function.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern unsafe bool GetMenuInfo(
            IntPtr hMenu,
            MENUINFO* lpMenuInfo);

        /// <summary>
        /// Determines the number of items in the specified menu.
        /// </summary>
        /// <param name="hMenu">A handle to the menu to be examined.</param>
        /// <returns>If the function succeeds, the return value specifies the number of items in the menu.
        /// If the function fails, the return value is -1. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern int GetMenuItemCount(IntPtr hMenu);

        /// <summary>
        /// Retrieves the menu item identifier of a menu item located at the specified position in a menu.
        /// </summary>
        /// <param name="hMenu">A handle to the menu that contains the item whose identifier is to be retrieved.</param>
        /// <param name="nPos">The zero-based relative position of the menu item whose identifier is to be retrieved.</param>
        /// <returns>The return value is the identifier of the specified menu item. If the menu item identifier is NULL or if the specified item opens a submenu, the return value is -1.</returns>
        [DllImport(nameof(User32), EntryPoint = "GetMenuItemID")]
        public static extern uint GetMenuItemId(IntPtr hMenu, int nPos);

#pragma warning disable SA1629 // Documentation text should end with a period
        /// <summary>Retrieves information about a menu item.</summary>
        /// <param name="hMenu">A handle to the menu that contains the menu item.</param>
        /// <param name="uItem">
        ///     The identifier or position of the menu item to get information about. The meaning of this parameter
        ///     depends on the value of <paramref name="fByPosition" />.
        /// </param>
        /// <param name="fByPosition">
        ///     The meaning of <paramref name="uItem" />. If this parameter is FALSE,
        ///     <paramref name="uItem" /> is a menu item identifier. Otherwise, it is a menu item position.
        /// </param>
        /// <param name="lpmii">
        ///     A <see cref="MENUITEMINFO" /> structure that specifies the information to retrieve and receives
        ///     information about the menu item. Note that you must set the cbSize member to <code>sizeof(MENUITEMINFO)</code>
        ///     before calling this function (Either manually or by using <see cref="MENUITEMINFO.Create" />).
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is true.
        ///     <para>If the function fails, the return value is false. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.</para>
        /// </returns>
#pragma warning restore SA1629 // Documentation text should end with a period
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool GetMenuItemInfo(
            IntPtr hMenu,
            uint uItem,
            [MarshalAs(UnmanagedType.Bool)] bool fByPosition,
            [Friendly(FriendlyFlags.Bidirectional)] MENUITEMINFO* lpmii);

        /// <summary>
        /// Retrieves the bounding rectangle for the specified menu item.
        /// </summary>
        /// <param name="hWnd">A handle to the window containing the menu. If this value is NULL and the <paramref name="hMenu"/> parameter represents a popup menu, the function will find the menu window.</param>
        /// <param name="hMenu">A handle to a menu.</param>
        /// <param name="uItem">The zero-based position of the menu item.</param>
        /// <param name="lprcItem">A pointer to a <see cref="RECT"/> structure that receives the bounding rectangle of the specified menu item expressed in screen coordinates.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, use the <see cref="Marshal.GetLastWin32Error"/> function.
        /// </returns>
        /// <remarks>
        /// In order for the returned rectangle to be meaningful, the menu must be popped up if a popup menu or attached to a window if a menu bar. Menu item positions are not determined until the menu is displayed.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool GetMenuItemRect(
            IntPtr hWnd,
            IntPtr hMenu,
            uint uItem,
            RECT* lprcItem);

        /// <summary>
        /// Retrieves the menu flags associated with the specified menu item. If the menu item opens a submenu, this function also returns the number of items in the submenu.
        /// </summary>
        /// <param name="hMenu">A handle to the menu that contains the menu item whose flags are to be retrieved.</param>
        /// <param name="uId">The menu item for which the menu flags are to be retrieved, as determined by the <paramref name="uFlags" /> parameter.</param>
        /// <param name="uFlags">Indicates how the uId parameter is interpreted.</param>
        /// <returns>
        /// If the specified item does not exist, the return value is -1.
        /// If the menu item opens a submenu, the low-order byte of the return value contains the menu flags associated with the item, and the high-order byte contains the number of items in the submenu opened by the item.
        /// Otherwise, the return value is a mask (Bitwise OR) of the menu flags.
        /// Menu flags associated with the menu item are a subset of those defined in <see cref="MenuItemFlags"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetMenuState"/> function has been superseded by the <see cref="GetMenuItemInfo(IntPtr, uint, bool, MENUITEMINFO*)"/>.
        /// You can still use <see cref="GetMenuState"/>, however, if you do not need any of the extended features of <see cref="GetMenuItemInfo(IntPtr, uint, bool, MENUITEMINFO*)"/>.
        /// </remarks>
        [DllImport(nameof(User32))]
        public static extern uint GetMenuState(
            IntPtr hMenu,
            uint uId,
            GetMenuStateFlags uFlags);

        /// <summary>
        /// Copies the text string of the specified menu item into the specified buffer.
        /// </summary>
        /// <param name="hMenu">A handle to the menu.</param>
        /// <param name="uIDItem">The menu item to be changed, as determined by the <paramref name="flags"/> parameter.</param>
        /// <param name="lpString">The buffer that receives the null-terminated string. If the string is as long or longer than <paramref name="lpString" />, the string is truncated and the terminating null character is added. If <paramref name="lpString" /> is NULL, the function returns the length of the menu string.</param>
        /// <param name="cchMax">The maximum length, in characters, of the string to be copied. If the string is longer than the maximum specified in the <paramref name="cchMax" /> parameter, the extra characters are truncated. If <paramref name="cchMax" /> is 0, the function returns the length of the menu string.</param>
        /// <param name="flags">Indicates how the <paramref name="uIDItem"/> parameter is interpreted.</param>
        /// <returns>
        /// If the function succeeds, the return value specifies the number of characters copied to the buffer, not including the terminating null character.
        /// If the function fails, the return value is zero.
        /// If the specified item is not of type <see cref="MenuMembersMask.MIIM_STRING"/> or <see cref="MenuItemType.MFT_STRING"/>, then the return value is zero.
        /// </returns>
        [DllImport(nameof(User32))]
        [Obsolete("The GetMenuString function has been superseded. Use the GetMenuItemInfo function to retrieve the menu item text.")]
        public static extern unsafe int GetMenuString(
            IntPtr hMenu,
            uint uIDItem,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Array | FriendlyFlags.Optional, ArrayLengthParameter = 3)] char* lpString,
            int cchMax,
            GetMenuStateFlags flags);

        /// <summary>
        /// Retrieves a handle to the drop-down menu or submenu activated by the specified menu item.
        /// </summary>
        /// <param name="hMenu">A handle to the menu.</param>
        /// <param name="nPos">The zero-based relative position in the specified menu of an item that activates a drop-down menu or submenu.</param>
        /// <returns>If the function succeeds, the return value is a handle to the drop-down menu or submenu activated by the menu item. If the menu item does not activate a drop-down menu or submenu, the return value is NULL.</returns>
        [DllImport(nameof(User32))]
        public static extern IntPtr GetSubMenu(
            IntPtr hMenu,
            int nPos);

        /// <summary>
        /// Retrieves the Help context identifier associated with the specified menu.
        /// </summary>
        /// <param name="hMenu">A handle to the menu for which the Help context identifier is to be retrieved.</param>
        /// <returns>Returns the Help context identifier if the menu has one, or zero otherwise.</returns>
        [DllImport(nameof(User32))]
        public static extern uint GetMenuContextHelpId(IntPtr hMenu);

        /// <summary>
        /// Associates a Help context identifier with a menu.
        /// </summary>
        /// <param name="hMenu">A handle to the menu with which to associate the Help context identifier.</param>
        /// <param name="helpId">The help context identifier.</param>
        /// <returns>Returns nonzero if successful, or zero otherwise. To retrieve extended error information, call <see cref="Marshal.GetLastWin32Error"/>.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern uint SetMenuContextHelpId(IntPtr hMenu, uint helpId);

        /// <summary>
        ///     Translates (maps) a virtual-key code into a scan code or character value, or translates a scan code into a
        ///     virtual-key code.
        ///     <para>
        ///         To specify a handle to the keyboard layout to use for translating the specified code, use the MapVirtualKeyEx
        ///         function.
        ///     </para>
        /// </summary>
        /// <param name="uCode">
        ///     The virtual key code or scan code for a key. How this value is interpreted depends on the value of
        ///     the uMapType parameter.
        /// </param>
        /// <param name="uMapType">
        ///     The translation to be performed. The value of this parameter depends on the value of the uCode
        ///     parameter.
        /// </param>
        /// <returns>
        ///     The return value is either a scan code, a virtual-key code, or a character value, depending on the value of
        ///     <paramref name="uCode" /> and <paramref name="uMapType" />. If there is no translation, the return value is zero.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int MapVirtualKey(int uCode, MapVirtualKeyTranslation uMapType);

        /// <summary>Retrieves the window handle to the active window attached to the calling thread's message queue.</summary>
        /// <returns>
        ///     The return value is the handle to the active window attached to the calling thread's message queue. Otherwise,
        ///     the return value is <see cref="IntPtr.Zero" />.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr GetActiveWindow();

        /// <summary>
        /// Determines whether the specified window handle identifies an existing window.
        /// </summary>
        /// <param name="hWnd">A handle to the window to be tested.</param>
        /// <returns>If the window handle identifies an existing window, the return value is true, otherwise it is false.</returns>
        /// <remarks>
        /// A thread should not use IsWindow for a window that it did not create because the window could be destroyed after this function was called.
        /// Further, because window handles are recycled the handle could even point to a different window.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindow(IntPtr hWnd);

        /// <summary>
        /// Determines whether the calling thread is already a GUI thread. It can also optionally convert the thread to a GUI thread.
        /// </summary>
        /// <param name="bConvert">If TRUE and the thread is not a GUI thread, convert the thread to a GUI thread.</param>
        /// <returns>The function returns a nonzero value (different from <see cref="HResult.Code.S_OK"/> but not specified on MSDN documentation) in the following situations:
        /// <list>
        /// <item>If the calling thread is already a GUI thread.</item>
        /// <item>If <paramref name="bConvert"/> is TRUE and the function successfully converts the thread to a GUI thread.</item>
        /// </list>
        /// Otherwise, the function returns <see cref="HResult.Code.S_OK"/>.
        /// If <paramref name="bConvert"/> is TRUE and the function cannot successfully convert the thread to a GUI thread,
        /// IsGUIThread returns <see cref="Win32ErrorCode.ERROR_NOT_ENOUGH_MEMORY"/>.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern HResult IsGUIThread([MarshalAs(UnmanagedType.Bool)] bool bConvert);

        /// <summary>
        /// Determines whether a window is a child window or descendant window of a specified parent window.
        /// A child window is the direct descendant of a specified parent window if that parent window is in the chain of parent windows;
        /// the chain of parent windows leads from the original overlapped or pop-up window to the child window.
        /// </summary>
        /// <param name="hWndParent">A handle to the parent window.</param>
        /// <param name="hWnd">A handle to the window to be tested.</param>
        /// <returns>If the window is a child or descendant window of the specified parent window, the return value is true, otherwise it is false.</returns>
        [DllImport(nameof(User32))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsChild(IntPtr hWndParent, IntPtr hWnd);

        /// <summary>
        /// Determines whether the system considers that a specified application is not responding.
        /// An application is considered to be not responding if it is not waiting for input, is not in startup processing,
        /// and has not called <see cref="PeekMessage(MSG*, IntPtr, WindowMessage, WindowMessage, PeekMessageRemoveFlags)"/> within the internal timeout period of 5 seconds.
        /// </summary>
        /// <param name="hWnd">A handle to the window to be tested.</param>
        /// <returns>
        /// If the window handle identifies an existing window, the return value is true, otherwise it is false.
        /// Ghost windows always return true.
        /// </returns>
        /// <remarks>
        /// The Windows timeout criteria of 5 seconds is subject to change.
        /// This function was not included in the SDK headers and libraries until Windows XP Service Pack 1 (SP1) and Windows Server 2003.
        /// If you do not have a header file and import library for this function, you can call the function using <see cref="Kernel32.LoadLibrary"/> and <see cref="GetProcAddress"/>.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsHungAppWindow(IntPtr hWnd);

        /// <summary>
        /// Determines whether the specified window is minimized (iconic).
        /// </summary>
        /// <param name="hWnd">A handle to the window to be tested.</param>
        /// <returns>If the window is iconic, the return value is true, otherwise it is false.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsIconic(IntPtr hWnd);

        /// <summary>
        /// Determines whether the specified window is a native Unicode window.
        /// </summary>
        /// <param name="hWnd">A handle to the window to be tested.</param>
        /// <returns>If the window is a native Unicode window, the return value is true, otherwise it is false (the window is a native ANSI window).</returns>
        /// <remarks>
        /// <para>
        /// The character set of a window is determined by the use of the <see cref="RegisterClass"/> function.
        /// If the window class was registered with the ANSI version of <see cref="RegisterClass"/> (RegisterClassA), the character set of the window is ANSI.
        /// If the window class was registered with the Unicode version of <see cref="RegisterClass"/> (RegisterClassW), the character set of the window is Unicode.
        /// </para>
        /// <para>
        /// The system does automatic two-way translation (Unicode to ANSI) for window messages. For example,
        /// if an ANSI window message is sent to a window that uses the Unicode character set,
        /// the system translates that message into a Unicode message before calling the window procedure.
        /// The system calls IsWindowUnicode to determine whether to translate the message or not.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowUnicode(IntPtr hWnd);

        /// <summary>
        /// Determines the visibility state of the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to the window to be tested.</param>
        /// <returns>
        /// If the specified window, its parent window, its parent's parent window, and so forth, have the WS_VISIBLE style, the return value is true, otherwise it is false.
        /// Because the return value specifies whether the window has the WS_VISIBLE style, it may be nonzero even if the window is totally obscured by other windows.
        /// </returns>
        /// <remarks>
        /// The visibility state of a window is indicated by the WS_VISIBLE style bit.
        /// When WS_VISIBLE is set, the window is displayed and subsequent drawing into it is displayed as long as the window has the WS_VISIBLE style.
        /// Any drawing to a window with the WS_VISIBLE style will not be displayed if the window is obscured by other windows or is clipped by its parent window.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        /// <summary>
        /// Determines whether a window is maximized.
        /// </summary>
        /// <param name="hWnd">A handle to the window to be tested.</param>
        /// <returns>If the window is zoomed, the return value is true, otherwise it is false.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsZoomed(IntPtr hWnd);

        /// <summary>
        /// Searches through icon or cursor data for the icon or cursor that best fits the current display device.
        /// To specify a desired height or width, use the LookupIconIdFromDirectoryEx function.
        /// </summary>
        /// <param name="presbits">
        /// The icon or cursor directory data. Because this function does not validate the resource data, it causes a general protection (GP) fault or returns an undefined value if <paramref name="presbits"/> is not pointing to valid resource data.
        /// </param>
        /// <param name="fIcon">
        /// Indicates whether an icon or a cursor is sought. If this parameter is TRUE, the function is searching for an icon; if the parameter is FALSE, the function is searching for a cursor.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is an integer resource identifier for the icon or cursor that best fits the current display device.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern unsafe int LookupIconIdFromDirectory(
            [Friendly(FriendlyFlags.Array | FriendlyFlags.In)] byte* presbits,
            [MarshalAs(UnmanagedType.Bool)] bool fIcon);

        /// <summary>
        /// Searches through icon or cursor data for the icon or cursor that best fits the current display device.
        /// To specify a desired height or width, use the LookupIconIdFromDirectoryEx function.
        /// </summary>
        /// <param name="presbits">
        /// The icon or cursor directory data. Because this function does not validate the resource data, it causes a general protection (GP) fault or returns an undefined value if <paramref name="presbits"/> is not pointing to valid resource data.
        /// </param>
        /// <param name="fIcon">
        /// Indicates whether an icon or a cursor is sought. If this parameter is TRUE, the function is searching for an icon; if the parameter is FALSE, the function is searching for a cursor.
        /// </param>
        /// <param name="cxDesired">The desired width, in pixels, of the icon. If this parameter is zero, the function uses the SM_CXICON or SM_CXCURSOR system metric value.</param>
        /// <param name="cyDesired">The desired height, in pixels, of the icon. If this parameter is zero, the function uses the SM_CYICON or SM_CYCURSOR system metric value.</param>
        /// <param name="Flags">A combination of the following values.</param>
        /// <returns>
        /// If the function succeeds, the return value is an integer resource identifier for the icon or cursor that best fits the current display device.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern unsafe int LookupIconIdFromDirectoryEx(
            [Friendly(FriendlyFlags.Array | FriendlyFlags.In)] byte* presbits,
            [MarshalAs(UnmanagedType.Bool)] bool fIcon,
            int cxDesired,
            int cyDesired,
            LookupIconIdFromDirectoryExFlags Flags);

        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int RegisterWindowMessage(string lpString);

        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowDisplayAffinity(IntPtr hWnd, out int dwAffinity);

        /// <summary>
        /// Enumerates display monitors (including invisible pseudo-monitors associated with the mirroring drivers)
        /// that intersect a region formed by the intersection of a specified clipping rectangle and the visible region of a device context.
        /// EnumDisplayMonitors calls an application-defined <see cref="MONITORENUMPROC"/> callback function once for each monitor that is enumerated. Note that <see cref="GetSystemMetrics(SystemMetric)"/> counts only the display monitors.
        /// </summary>
        /// <param name="hdc">
        /// A handle to a display device context that defines the visible region of interest.
        /// If this parameter is NULL, the hdcMonitor parameter passed to the callback function will be NULL,
        /// and the visible region of interest is the virtual screen that encompasses all the displays on the desktop.
        /// </param>
        /// <param name="lprcClip">
        /// A pointer to a RECT structure that specifies a clipping rectangle.
        /// The region of interest is the intersection of the clipping rectangle with the visible region specified by hdc.
        /// If hdc is non-NULL, the coordinates of the clipping rectangle are relative to the origin of the hdc.If hdc is NULL, the coordinates are virtual-screen coordinates.
        /// This parameter can be NULL if you don't want to clip the region specified by hdc.
        /// </param>
        /// <param name="lpfnEnum">A pointer to a <see cref="MONITORENUMPROC"/> application-defined callback function.</param>
        /// <param name="dwData">Application-defined data that EnumDisplayMonitors passes directly to the MonitorEnumProc function.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// See: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumdisplaymonitors#remarks.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool EnumDisplayMonitors(IntPtr hdc, RECT* lprcClip, MONITORENUMPROC lpfnEnum, void* dwData);

        /// <summary>
        /// Lets you obtain information about the display devices in the current session.
        /// </summary>
        /// <param name="lpDevice">A pointer to the device name. If <c>NULL</c>, function returns information for the display adapter(s) on the machine, based on <paramref name="iDevNum"/>.</param>
        /// <param name="iDevNum">
        /// An index value that specifies the display device of interest.
        /// The operating system identifies each display device in the current session with an index value.
        /// The index values are consecutive integers, starting at 0. If the current session has three display devices, for example, they are specified by the index values 0, 1, and 2.
        /// </param>
        /// <param name="lpDisplayDevice">
        /// A pointer to a <see cref="DISPLAY_DEVICE"/> structure that receives information about the display device specified by <paramref name="iDevNum"/>.
        /// Before calling <see cref="EnumDisplayDevices(char*, uint, DISPLAY_DEVICE*, EnumDisplayDevicesFlags)"/>, you must initialize the member <see cref="DISPLAY_DEVICE.cb"/> to the size, in bytes, of <see cref="DISPLAY_DEVICE"/>.
        /// </param>
        /// <param name="dwFlags">
        /// Set this flag to <see cref="EnumDisplayDevicesFlags.EDD_GET_DEVICE_INTERFACE_NAME"/> to retrieve the device interface name for <c>GUID_DEVINTERFACE_MONITOR</c>, which is registered by the operating system on a per monitor basis.
        /// The value is placed in the <see cref="DISPLAY_DEVICE.DeviceID"/> structure returned in <paramref name="lpDisplayDevice"/>.
        /// The resulting device interface name can be used with SetupAPI functions and serves as a link between GDI monitor devices and SetupAPI monitor devices.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// The function fails if <paramref name="iDevNum"/> is greater than the largest device index.
        /// </returns>
        /// <remarks>
        /// See https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumdisplaydevicesa#remarks.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool EnumDisplayDevices(
            [Friendly(FriendlyFlags.Array | FriendlyFlags.In)] char* lpDevice,
            uint iDevNum,
            [Friendly(FriendlyFlags.Bidirectional)] DISPLAY_DEVICE* lpDisplayDevice,
            EnumDisplayDevicesFlags dwFlags);

        /// <summary>
        /// Retrieves information about one of the graphics modes for a display device. To retrieve information for all the graphics modes of a display device, make a series of calls to this function.
        /// </summary>
        /// <param name="lpszDeviceName">
        /// A pointer to a null-terminated string that specifies the display device about whose graphics mode the function will obtain information.
        /// This parameter is either <c>NULL</c> or a <see cref="DISPLAY_DEVICE.DeviceName"/> returned from <see cref="EnumDisplayDevices(char*, uint, DISPLAY_DEVICE*, EnumDisplayDevicesFlags)"/>.
        /// A <c>NULL</c> value specifies the current display device on the computer on which the calling thread is running.
        /// </param>
        /// <param name="iModeNum">
        /// <para>The type of information to be retrieved. This value can be a graphics mode index or one of the following values.</para>
        /// <para><see cref="ENUM_CURRENT_SETTINGS"/>: Retrieve the current settings for the display device.</para>
        /// <para><see cref="ENUM_REGISTRY_SETTINGS"/>: Retrieve the settings for the display device that are currently stored in the registry.</para>
        /// <para>
        /// Graphics mode indexes start at zero. To obtain information for all of a display device's graphics modes, make a series of calls to <see cref="EnumDisplaySettings(char*, uint, DEVMODE*)"/>, as follows: Set <paramref name="iModeNum"/> to zero for the first call,
        /// and increment <paramref name="iModeNum"/> by one for each subsequent call.
        /// </para>
        /// <para>
        /// Continue calling the function until the return value is zero.<br/>
        /// When you call <see cref="EnumDisplaySettings(char*, uint, DEVMODE*)"/> with <paramref name="iModeNum"/> set to zero, the operating system initializes and caches information about the display device.<br/>
        /// When you call <see cref="EnumDisplaySettings(char*, uint, DEVMODE*)"/> with <paramref name="iModeNum"/> set to a nonzero value,
        /// the function returns the information that was cached the last time the function was called with iModeNum set to zero.
        /// </para>
        /// </param>
        /// <param name="lpDevMode">
        /// A pointer to a <see cref="DEVMODE"/> structure into which the function stores information about the specified graphics mode.
        /// </param>
        /// <remarks>
        /// The function fails if <paramref name="iModeNum"/> is greater than the index of the display device's last graphics mode.
        /// As noted in the description of the <paramref name="iModeNum"/> parameter, you can use this behavior to enumerate all of a display device's graphics modes.
        /// </remarks>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
        [DllImport(nameof(User32))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool EnumDisplaySettings(
            [Friendly(FriendlyFlags.Array | FriendlyFlags.In)] char* lpszDeviceName,
            uint iModeNum,
            [Friendly(FriendlyFlags.Bidirectional)] DEVMODE* lpDevMode);

        /// <summary>
        /// Retrieves information about one of the graphics modes for a display device. To retrieve information for all the graphics modes of a display device, make a series of calls to this function.
        /// </summary>
        /// <param name="lpszDeviceName">
        /// A pointer to a null-terminated string that specifies the display device about whose graphics mode the function will obtain information.
        /// This parameter is either <c>NULL</c> or a <see cref="DISPLAY_DEVICE.DeviceName"/> returned from <see cref="EnumDisplayDevices(char*, uint, DISPLAY_DEVICE*, EnumDisplayDevicesFlags)"/>.
        /// A <c>NULL</c> value specifies the current display device on the computer on which the calling thread is running.
        /// </param>
        /// <param name="iModeNum">
        /// <para>The type of information to be retrieved. This value can be a graphics mode index or one of the following values.</para>
        /// <para><see cref="ENUM_CURRENT_SETTINGS"/>: Retrieve the current settings for the display device.</para>
        /// <para><see cref="ENUM_REGISTRY_SETTINGS"/>: Retrieve the settings for the display device that are currently stored in the registry.</para>
        /// <para>
        /// Graphics mode indexes start at zero. To obtain information for all of a display device's graphics modes, make a series of calls to <see cref="EnumDisplaySettingsEx(char*, uint, DEVMODE*, EnumDisplaySettingsExFlags)"/>, as follows: Set <paramref name="iModeNum"/> to zero for the first call,
        /// and increment <paramref name="iModeNum"/> by one for each subsequent call.
        /// </para>
        /// <para>
        /// Continue calling the function until the return value is zero.<br/>
        /// When you call <see cref="EnumDisplaySettingsEx(char*, uint, DEVMODE*, EnumDisplaySettingsExFlags)"/> with <paramref name="iModeNum"/> set to zero, the operating system initializes and caches information about the display device.<br/>
        /// When you call <see cref="EnumDisplaySettingsEx(char*, uint, DEVMODE*, EnumDisplaySettingsExFlags)"/> with <paramref name="iModeNum"/> set to a nonzero value,
        /// the function returns the information that was cached the last time the function was called with iModeNum set to zero.
        /// </para>
        /// </param>
        /// <param name="lpDevMode">
        /// A pointer to a <see cref="DEVMODE"/> structure into which the function stores information about the specified graphics mode.
        /// </param>
        /// <param name="dwFlags">
        /// See documentation on the fields of <see cref="EnumDisplaySettingsExFlags"/>.
        /// </param>
        /// <remarks>
        /// The function fails if <paramref name="iModeNum"/> is greater than the index of the display device's last graphics mode.
        /// As noted in the description of the <paramref name="iModeNum"/> parameter, you can use this behavior to enumerate all of a display device's graphics modes.
        /// </remarks>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
        [DllImport(nameof(User32))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool EnumDisplaySettingsEx(
            [Friendly(FriendlyFlags.Array | FriendlyFlags.In)] char* lpszDeviceName,
            uint iModeNum,
            [Friendly(FriendlyFlags.Bidirectional)] DEVMODE* lpDevMode,
            EnumDisplaySettingsExFlags dwFlags);

        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClassInfoEx(
            IntPtr hInstance,
            string lpClassName,
            ref WNDCLASSEX lpWndClass);

        /// <summary>
        /// Retrieves information about a display monitor.
        /// </summary>
        /// <param name="hMonitor">A handle to the display monitor of interest.</param>
        /// <param name="lpmi">
        /// A pointer to a <see cref="MONITORINFO"/> or <see cref="MONITORINFOEX"/> structure that receives information about the specified display monitor.
        /// You must set the cbSize member of the structure to <c>sizeof(MONITORINFO)</c> or <c>sizeof(MONITORINFOEX)</c> before calling the <see cref="GetMonitorInfo(IntPtr, MONITORINFO*)"/> function. Doing so lets the function determine the type of structure you are passing to it.
        /// The <see cref="MONITORINFOEX"/> structure is a superset of the <see cref="MONITORINFO"/> structure. It has one additional member: a string that contains a name for the display monitor. Most applications have no use for a display monitor name, and so can save some bytes by using a <see cref="MONITORINFO"/> structure.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>.
        /// If the function fails, the return value is <c>false</c>.
        /// </returns>
        [DllImport(nameof(User32))]
        public static extern unsafe bool GetMonitorInfo(
            IntPtr hMonitor,
            [Friendly(FriendlyFlags.Bidirectional)] MONITORINFO* lpmi);

        /// <inheritdoc cref="GetMonitorInfo(IntPtr, MONITORINFOEX*)"/>
        [Obsolete("Use " + nameof(GetMonitorInfo) + " instead.")]
        public static unsafe bool GetMonitorInfoEx(IntPtr hMonitor, [Friendly(FriendlyFlags.Bidirectional)] MONITORINFOEX* lpmi) => GetMonitorInfo(hMonitor, lpmi);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern int GetSystemMetrics(SystemMetric smIndex);

        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowInfo(IntPtr hwnd, ref WINDOWINFO pwi);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, ref RECT rect, [MarshalAs(UnmanagedType.U4)] int cPoints);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr MonitorFromPoint(POINT pt, MonitorOptions dwFlags);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr MonitorFromPoint(POINT point, int flags);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr MonitorFromRect(ref RECT lprc, MonitorOptions dwFlags);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr MonitorFromWindow(IntPtr hwnd, MonitorOptions dwFlags);

        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool SystemParametersInfo(
            SystemParametersInfoAction uiAction,
            uint uiParam,
            void* pvParam,
            SystemParametersInfoFlags fWinIni);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern unsafe int QueryDisplayConfig(
            uint Flags,
            ref int pNumPathArrayElements,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Array)] DISPLAYCONFIG_PATH_INFO* pPathInfoArray,
            ref int pNumModeInfoArrayElements,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Array)] DISPLAYCONFIG_MODE_INFO* pModeInfoArray,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional)] DISPLAYCONFIG_TOPOLOGY_ID pCurrentTopologyId);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern ushort RegisterClass(ref WNDCLASS lpWndClass);

        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.U2)]
        public static extern short RegisterClassEx(ref WNDCLASSEX lpwcx);

        /// <summary>
        /// Unregisters a window class, freeing the memory required for the class.
        /// </summary>
        /// <param name="lpClassName">
        /// A null-terminated string or a class atom. If lpClassName is a string, it specifies the window class name.
        /// This class name must have been registered by a previous call to the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// System classes, such as dialog box controls, cannot be unregistered.
        /// If this parameter is an atom, it must be a class atom created by a previous call to the <see cref="RegisterClass"/> or <see cref="RegisterClassEx"/> function.
        /// The atom must be in the low-order word of lpClassName; the high-order word must be zero.
        /// </param>
        /// <param name="hInstance">A handle to the instance of the module that created the class.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the class could not be found or if a window still exists that was created with the class, the return value is zero. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnregisterClass(
            string lpClassName,
            IntPtr hInstance);

        /// <summary>
        /// Retrieves the name of the format from the clipboard.
        /// </summary>
        /// <param name="format">The type of format to be retrieved. This parameter must not specify any of the predefined clipboard formats.</param>
        /// <param name="lpszFormatName">The format name string.</param>
        /// <param name="cchMaxCount">
        /// The length of the <paramref name="lpszFormatName"/> buffer, in characters. The buffer must be large enough to include the terminating null character; otherwise, the format name string is truncated to <paramref name="cchMaxCount"/>-1 characters.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of characters copied to the buffer.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern unsafe int GetClipboardFormatName(
            int format,
            [Friendly(FriendlyFlags.Array | FriendlyFlags.Out, ArrayLengthParameter = 2)] char* lpszFormatName,
            int cchMaxCount);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern unsafe void* GetClipboardData(int uFormat);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern unsafe void* SetClipboardData(int uFormat, void* hMem);

        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseClipboard();

        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EmptyClipboard();

        /// <summary>
        /// Synthesizes keystrokes, mouse motions, and button clicks.
        /// </summary>
        /// <param name="nInputs">The number of structures in the <paramref name="pInputs" /> array.</param>
        /// <param name="pInputs">An array of  structures. Each structure represents an event to be inserted into the keyboard or mouse input stream.</param>
        /// <param name="cbSize">The size, in bytes, of an <see cref="INPUT" /> structure. If cbSize is not the size of an <see cref="INPUT" /> structure, the function fails.</param>
        /// <returns>
        /// The function returns the number of events that it successfully inserted into the keyboard or mouse input stream.
        /// If the function returns zero, the input was already blocked by another thread. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// This function is subject to UIPI. Applications are permitted to inject input only into applications that are at an equal or lesser integrity level.
        /// This function fails when it is blocked by UIPI. Note that neither GetLastError nor the return value will indicate the failure was caused by UIPI blocking.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern unsafe uint SendInput(
            int nInputs,
            [Friendly(FriendlyFlags.Array | FriendlyFlags.In)] INPUT* pInputs,
            int cbSize);

        /// <summary>
        /// Waits until the specified process has finished processing its initial input and is waiting for user input with no input pending, or until the time-out interval has elapsed.
        /// </summary>
        /// <param name="hProcess">A handle to the process. If this process is a console application or does not have a message queue, WaitForInputIdle returns immediately.</param>
        /// <param name="dwMilliseconds">The time-out interval, in milliseconds. If dwMilliseconds is INFINITE, the function does not return until the process is idle.</param>
        /// <returns>0 if the wait was satisfied successfully., <see cref="WAIT_TIMEOUT" /> if the wait was terminated because the time-out interval elapsed, and <see cref="WAIT_FAILED"/> if an error occurred.</returns>
        /// <remarks>Raymond Chen has a series of articles that give a bit more depth to how this function was intended to be used.
        /// <a href="http://blogs.msdn.com/b/oldnewthing/archive/2010/03/25/9984720.aspx">Here</a> and <a href="http://blogs.msdn.com/b/oldnewthing/archive/2010/03/26/9985422.aspx">here</a>.
        /// The jist of it is that this function should have been really called WaitForProcessStartupComplete, as this is all it does.</remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern int WaitForInputIdle(IntPtr hProcess, int dwMilliseconds);

        /// <summary>
        /// Determines whether a key is up or down at the time the function is called, and whether the key was pressed after a previous call to GetAsyncKeyState.
        /// </summary>
        /// <param name="vKey">
        /// The virtual-key code from the <see cref="VirtualKey" /> enum.
        /// You can use left- and right-distinguishing constants to specify certain keys.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies whether the key was pressed since the last call to GetAsyncKeyState, and whether the key is currently up or down. If the most significant bit is set, the key is down, and if the least significant bit is set, the key was pressed after /// the previous call to GetAsyncKeyState. However, you should not rely on this last behavior; for more information, see the Remarks on MSDN.
        /// </returns>
        [DllImport(nameof(User32))]
        public static extern short GetAsyncKeyState(int vKey);

        /// <summary>
        /// Retrieves the status of the specified virtual key. The status specifies whether the key is up, down, or toggled (on, off—alternating each time the key is pressed).
        /// </summary>
        /// <param name="nVirtKey">
        /// A virtual key code from the <see cref="VirtualKey" /> enum. If the desired virtual key is a letter or digit (A through Z, a through z, or 0 through 9), nVirtKey must be set to the ASCII value of that character. For other keys, it must be a virtual-key code.
        /// If a non-English keyboard layout is used, virtual keys with values in the range ASCII A through Z and 0 through 9 are used to specify most of the character keys. For example, for the German keyboard layout,
        /// the virtual key of value ASCII O (0x4F) refers to the "o" key, whereas VK_OEM_1 refers to the "o with umlaut" key.
        /// </param>
        /// <returns>
        /// The return value specifies the status of the specified virtual key, as follows:
        /// If the high-order bit is 1, the key is down; otherwise, it is up.
        /// If the low-order bit is 1, the key is toggled. A key, such as the CAPS LOCK key, is toggled if it is turned on. The key is off and untoggled if the low-order bit is 0. A toggle key's indicator light (if any) on the keyboard will be on when the key is toggled,
        /// and off when the key is untoggled.
        /// </returns>
        [DllImport(nameof(User32))]
        public static extern short GetKeyState(int nVirtKey);

        /// <summary>
        /// <para>
        /// Converts a point in a window from logical coordinates into physical coordinates, regardless of the dots per inch (dpi) awareness of the caller.
        /// For more information about DPI awareness levels, see <see cref="PROCESS_DPI_AWARENESS"/>.
        /// </para>
        /// <para>
        /// Tip: Since an application with a value of <see cref="PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE"/> uses the actual DPI of the monitor,
        /// physical and logical coordinates are the same for this app.
        /// </para>
        /// </summary>
        /// <param name="hwnd">A handle to the window whose transform is used for the conversion.</param>
        /// <param name="lpPoint">
        /// A pointer to a <see cref="POINT"/> structure that specifies the physical/screen coordinates to be converted.
        /// The new logical coordinates are copied into this structure if the function succeeds.
        /// </param>
        /// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
        /// <remarks>
        /// <para>
        /// In Windows 8, system–DPI aware applications translated between physical and logical space using
        /// <see cref="PhysicalToLogicalPoint"/> and <see cref="LogicalToPhysicalPoint"/>.
        /// In Windows 8.1, the additional virtualization of the system and inter-process communications means that for the majority of applications, you do not need these APIs.
        /// As a result, in Windows 8.1, these APIs no longer transform points.
        /// The system returns all points to an application in its own coordinate space.
        /// This behavior preserves functionality for the majority of applications,
        /// but there are some exceptions in which you must make changes to ensure that the application works as expected.
        /// </para>
        /// <para>
        /// For example, an application might need to walk the entire window tree of another process and ask the system for DPI-dependent information about the window.
        /// By default, the system will return the information based on the DPI awareness of the caller. This is ideal for most applications.
        /// However, the caller might need the information based on the DPI awareness of the application associated with the window.
        /// This might be necessary because the two applications send DPI-dependent information between each other directly.
        /// In this case, the application can use <see cref="LogicalToPhysicalPointForPerMonitorDPI"/> to get physical coordinates and
        /// then use PhysicalToLogicalPointForPerMonitorDPI to convert the physical coordinates
        /// into logical coordinates based on the DPI-awareness of the provided <paramref name="hwnd"/>.
        /// </para>
        /// <para>
        /// Consider two applications, one has value of  and the other has a value of <see cref="PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE"/>.
        /// The <see cref="PROCESS_DPI_AWARENESS.PROCESS_DPI_UNAWARE"/> app creates a window on a single monitor where the scale factor is 200% (192 DPI).
        /// If both apps call <see cref="GetWindowRect"/> on this window, they will receive different values.
        /// The <see cref="PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE"/> app will receive a rect based on 96 DPI coordinates,
        /// while the <see cref="PROCESS_DPI_AWARENESS.PROCESS_DPI_UNAWARE"/> app will receive coordinates matching the actual DPI of the monitor.
        /// If the <see cref="PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE"/> needs the <see cref="RECT"/> that the system returned
        /// to the <see cref="PROCESS_DPI_AWARENESS.PROCESS_DPI_UNAWARE"/> app, it could call <see cref="LogicalToPhysicalPointForPerMonitorDPI"/>
        /// for the corners of its <see cref="RECT"/> and pass in the handle to the <see cref="PROCESS_DPI_AWARENESS.PROCESS_DPI_UNAWARE"/> app's window.
        /// This will return points based on the other app's awareness that can be used to create a <see cref="RECT"/>.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PhysicalToLogicalPointForPerMonitorDPI(IntPtr hwnd, ref POINT lpPoint);

        /// <summary>
        /// Converts the physical coordinates of a point in a window to logical coordinates.
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window whose transform is used for the conversion. Top level windows are fully supported.
        /// In the case of child windows, only the area of overlap between the parent and the child window is converted.
        /// </param>
        /// <param name="lpPoint">
        /// A pointer to a <see cref="POINT"/> structure that specifies the physical/screen coordinates to be converted.
        /// The new logical coordinates are copied into this structure if the function succeeds.
        /// </param>
        /// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
        /// <remarks>
        /// <para>
        /// The function uses the window identified by the <paramref name="hwnd"/> parameter and the physical coordinates
        /// given in the <see cref="POINT"/> structure to compute the logical coordinates.
        /// The logical coordinates are the unscaled coordinates that appear to the application in a programmatic way.
        /// In other words, the logical coordinates are the coordinates the application recognizes, which can be different from the physical coordinates.
        /// The API then replaces the physical coordinates with the logical coordinates.
        /// The new coordinates are in the world coordinates whose origin is (0, 0) on the desktop.
        /// The coordinates passed to the API have to be on the <paramref name="hwnd"/>.
        /// </para>
        /// <para>
        /// On all platforms, PhysicalToLogicalPoint will fail on a window that has either 0 width or height;
        /// an application must first establish a non-0 width and height by calling, for example, <see cref="MoveWindow"/>.
        /// On some versions of Windows (including Windows 7), PhysicalToLogicalPointwill still fail if <see cref="MoveWindow"/> has been called
        /// after a call to <see cref="ShowWindow"/> with <see cref="WindowShowStyle.SW_HIDE"/> has hidden the window.
        /// </para>
        /// <para>
        /// In Windows 8, system–DPI aware applications translate between physical and logical space using PhysicalToLogicalPoint and <see cref="LogicalToPhysicalPoint"/>.
        /// In Windows 8.1, the additional virtualization of the system and inter-process communications means that for the majority of applications,
        /// you do not need these APIs. As a result, in Windows 8.1, PhysicalToLogicalPoint and <see cref="LogicalToPhysicalPoint"/> no longer transform points.
        /// The system returns all points to an application in its own coordinate space.
        /// This behavior preserves functionality for the majority of applications,
        /// but there are some exceptions in which you must make changes to ensure that the application works as expected.
        /// In those cases, use <see cref="PhysicalToLogicalPointForPerMonitorDPI"/> and <see cref="LogicalToPhysicalPointForPerMonitorDPI"/>.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PhysicalToLogicalPoint(IntPtr hwnd, ref POINT lpPoint);

        /// <summary>
        /// Converts a point in a window from logical coordinates into physical coordinates, regardless of the dots per inch (dpi) awareness of the caller.
        /// For more information about DPI awareness levels, see <see cref="PROCESS_DPI_AWARENESS"/>.
        /// <para>
        /// Tip: Since an application with a value of <see cref="PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE"/> uses the actual DPI of the monitor,
        /// physical and logical coordinates are the same for this app.
        /// </para>
        /// </summary>
        /// <param name="hwnd">A handle to the window whose transform is used for the conversion.</param>
        /// <param name="lpPoint">
        /// A pointer to a <see cref="POINT"/> structure that specifies the logical coordinates to be converted.
        /// The new physical coordinates are copied into this structure if the function succeeds.
        /// </param>
        /// <returns>Returns true if successful, or false otherwise.</returns>
        /// <remarks>
        /// <para>
        /// In Windows 8, system–DPI aware applications translated between physical and logical space using
        /// <see cref="PhysicalToLogicalPoint"/> and <see cref="LogicalToPhysicalPoint"/>.
        /// In Windows 8.1, the additional virtualization of the system and inter-process communications means that for the majority of applications, you do not need these APIs.
        /// As a result, in Windows 8.1, these APIs no longer transform points.
        /// The system returns all points to an application in its own coordinate space.
        /// This behavior preserves functionality for the majority of applications,
        /// but there are some exceptions in which you must make changes to ensure that the application works as expected.
        /// </para>
        /// <para>
        /// For example, an application might need to walk the entire window tree of another process and ask the system for DPI-dependent information about the window.
        /// By default, the system will return the information based on the DPI awareness of the caller. This is ideal for most applications.
        /// However, the caller might need the information based on the DPI awareness of the application associated with the window.
        /// This might be necessary because the two applications send DPI-dependent information between each other directly.
        /// In this case, the application can use LogicalToPhysicalPointForPerMonitorDPI to get physical coordinates and
        /// then use <see cref="PhysicalToLogicalPointForPerMonitorDPI"/> to convert the physical coordinates
        /// into logical coordinates based on the DPI-awareness of the provided <paramref name="hwnd"/>.
        /// </para>
        /// <para>
        /// Consider two applications, one has value of  and the other has a value of <see cref="PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE"/>.
        /// The <see cref="PROCESS_DPI_AWARENESS.PROCESS_DPI_UNAWARE"/> app creates a window on a single monitor where the scale factor is 200% (192 DPI).
        /// If both apps call <see cref="GetWindowRect"/> on this window, they will receive different values.
        /// The <see cref="PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE"/> app will receive a rect based on 96 DPI coordinates,
        /// while the <see cref="PROCESS_DPI_AWARENESS.PROCESS_DPI_UNAWARE"/> app will receive coordinates matching the actual DPI of the monitor.
        /// If the <see cref="PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE"/> needs the <see cref="RECT"/> that the system returned
        /// to the <see cref="PROCESS_DPI_AWARENESS.PROCESS_DPI_UNAWARE"/> app, it could call LogicalToPhysicalPointForPerMonitorDPI
        /// for the corners of its <see cref="RECT"/> and pass in the handle to the <see cref="PROCESS_DPI_AWARENESS.PROCESS_DPI_UNAWARE"/> app's window.
        /// This will return points based on the other app's awareness that can be used to create a <see cref="RECT"/>.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LogicalToPhysicalPointForPerMonitorDPI(IntPtr hwnd, ref POINT lpPoint);

        /// <summary>
        /// Converts the logical coordinates of a point in a window to physical coordinates.
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window whose transform is used for the conversion. Top level windows are fully supported.
        /// In the case of child windows, only the area of overlap between the parent and the child window is converted.
        /// </param>
        /// <param name="lpPoint">
        /// A pointer to a <see cref="POINT"/> structure that specifies the logical coordinates to be converted.
        /// The new physical coordinates are copied into this structure if the function succeeds.
        /// </param>
        /// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
        /// <remarks>
        /// <para>
        /// LogicalToPhysicalPoint is a transformation API that can be called by a process that declares itself as dpi aware.
        /// The function uses the window identified by the hWnd parameter and the logical coordinates given in the <see cref="POINT"/> structure to compute the physical coordinates.
        /// The LogicalToPhysicalPoint function replaces the logical coordinates in the <see cref="POINT"/> structure with the physical coordinates.
        /// The physical coordinates are relative to the upper-left corner of the screen.
        /// The coordinates have to be inside the client area of <paramref name="hwnd"/>.
        /// </para>
        /// <para>
        /// On all platforms, LogicalToPhysicalPoint will fail on a window that has either 0 width or height;
        /// an application must first establish a non-0 width and height by calling, for example, <see cref="MoveWindow"/>.
        /// On some versions of Windows (including Windows 7), LogicalToPhysicalPoint will still fail if <see cref="MoveWindow"/> has been called
        /// after a call to <see cref="ShowWindow"/> with <see cref="WindowShowStyle.SW_HIDE"/> has hidden the window.
        /// </para>
        /// <para>
        /// In Windows 8, system–DPI aware applications translate between physical and logical space using <see cref="PhysicalToLogicalPoint"/> and LogicalToPhysicalPoint.
        /// In Windows 8.1, the additional virtualization of the system and inter-process communications means that for the majority of applications,
        /// you do not need these APIs. As a result, in Windows 8.1, <see cref="PhysicalToLogicalPoint"/> and LogicalToPhysicalPoint no longer transform points.
        /// The system returns all points to an application in its own coordinate space.
        /// This behavior preserves functionality for the majority of applications,
        /// but there are some exceptions in which you must make changes to ensure that the application works as expected.
        /// In those cases, use <see cref="PhysicalToLogicalPointForPerMonitorDPI"/> and <see cref="LogicalToPhysicalPointForPerMonitorDPI"/>.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LogicalToPhysicalPoint(IntPtr hwnd, ref POINT lpPoint);

        /// <summary>
        /// Determines whether the current process is dots per inch (dpi) aware such that it adjusts the sizes of UI elements to compensate for the dpi setting.
        /// </summary>
        /// <returns>TRUE if the process is dpi aware; otherwise, FALSE.</returns>
        /// <remarks>
        /// IsProcessDPIAware is available for use in Windows Vista or superior the operating systems.
        /// It may be altered or unavailable in subsequent versions.
        /// For Windows 8.1 or superior operating systems, use GetProcessDPIAwareness/>.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsProcessDPIAware();

        /// <summary>
        /// Sets the current process as dots per inch (dpi) awareness.
        /// </summary>
        /// <returns>If the function succeeds, the return value is true. Otherwise, the return value is false.</returns>
        /// <remarks>
        /// <para>
        /// SetProcessDPIAware is available for use in Windows Vista or superior the operating systems.
        /// It may be altered or unavailable in subsequent versions.
        /// For Windows 8.1 or superior operating systems, use SetProcessDpiAwareness/>.
        /// </para>
        /// <para>
        /// SetProcessDPIAware is subject to a possible race condition if a DLL caches dpi settings during initialization.
        /// For this reason, it is recommended that dpi-aware be set through the application (.exe) manifest rather than by calling SetProcessDPIAware.
        /// DLLs should accept the dpi setting of the host process rather than call SetProcessDPIAware themselves.
        /// To be set properly, dpiAware should be specified as part of the application (.exe) manifest.
        /// IMPORTANT: dpiAware defined in an embedded DLL manifest has no affect.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern bool SetProcessDPIAware();

        /// <summary>
        /// The GetDC function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen. You can use the returned handle in subsequent GDI functions to draw in the DC. The device context is an opaque data structure, whose values are used internally by GDI.
        /// The GetDCEx function is an extension to GetDC, which gives an application more control over how and whether clipping occurs in the client area.
        /// Makes the specified desktop visible and activates it. This enables the desktop to receive input from the user.
        /// The calling process must have DESKTOP_SWITCHDESKTOP access to the desktop for the SwitchDesktop function to succeed.
        /// </summary>
        /// <param name="hDesktop">
        /// A handle to the desktop. This handle is returned by the <see cref="CreateDesktop(string, string, IntPtr, DesktopCreationFlags, ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/> and <see cref="OpenDesktop"/> functions.
        /// This desktop must be associated with the current window station for the process.</param>
        /// <returns>If the function succeeds, the return value is true, if it fails, the return value is false.</returns>
        /// <remarks>
        /// <para>
        /// SwitchDesktop only sets the last error for the following cases:
        /// <list>
        /// <item>When the desktop belongs to an invisible window station</item>
        /// <item>When hDesktop is an invalid handle, refers to a destroyed desktop, or belongs to a different session than that of the calling process</item>
        /// </list>
        /// </para>
        /// <para>
        /// The SwitchDesktop function fails if the desktop belongs to an invisible window station.
        /// SwitchDesktop also fails when called from a process that is associated with a secured desktop such as the WinLogon and ScreenSaver desktops.
        /// Processes that are associated with a secured desktop include custom UserInit processes. Such calls typically fail with an "access denied" error.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SwitchDesktop(SafeDesktopHandle hDesktop);

        /// <summary>
        /// Assigns the specified desktop to the calling thread. All subsequent operations on the desktop use the access rights granted to the desktop.
        /// </summary>
        /// <param name="hDesktop">
        /// A handle to the desktop to be assigned to the calling thread.
        /// This handle is returned by the <see cref="CreateDesktop(string, string, IntPtr, DesktopCreationFlags, ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/>, <see cref="GetThreadDesktop"/>, <see cref="OpenDesktop"/>, or <see cref="OpenInputDesktop"/> function.
        /// This desktop must be associated with the current window station for the process.
        /// </param>
        /// <returns>If the function succeeds, the return value is true, if it fails, the return value is false.</returns>
        /// <remarks>
        /// The function will fail if the calling thread has any windows or hooks on its current desktop (unless the <paramref name="hDesktop"/> parameter is a handle to the current desktop).
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetThreadDesktop(SafeDesktopHandle hDesktop);

        /// <summary>
        /// Opens the specified desktop object.
        /// </summary>
        /// <param name="lpszDesktop">The name of the desktop to be opened. Desktop names are case-insensitive. This desktop must belong to the current window station.</param>
        /// <param name="dwFlags">Access control flags.</param>
        /// <param name="fInherit">If this value is true, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.</param>
        /// <param name="dwDesiredAccess">The access to the desktop. For a list of access rights, see <see cref="ACCESS_MASK"/>.</param>
        /// <returns>If the function succeeds, the return value is a handle to the opened desktop, if the function fails, the return value is an invalid handle.</returns>
        /// <remarks>
        /// <para>
        /// When you are finished using the handle, call the <see cref="CloseDesktop"/> function to close it.
        /// </para>
        /// <para>
        /// The calling process must have an associated window station, either assigned by the system at process creation time or set by the <see cref="SetProcessWindowStation"/> function.
        /// </para>
        /// <para>
        /// If the <paramref name="dwDesiredAccess"/> parameter specifies the READ_CONTROL, WRITE_DAC, or WRITE_OWNER standard access rights, you must also request the DESKTOP_READOBJECTS and DESKTOP_WRITEOBJECTS access rights.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern SafeDesktopHandle OpenDesktop(
            string lpszDesktop,
            DesktopCreationFlags dwFlags,
            [MarshalAs(UnmanagedType.Bool)] bool fInherit,
            ACCESS_MASK dwDesiredAccess);

        /// <summary>
        /// Enumerates all top-level windows associated with the specified desktop. It passes the handle to each window, in turn, to an application-defined callback function.
        /// </summary>
        /// <param name="hDesktop">
        /// A handle to the desktop whose top-level windows are to be enumerated. This handle is returned by the <see cref="CreateDesktop(string, string, IntPtr, DesktopCreationFlags, ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/>, <see cref="GetThreadDesktop"/>, <see cref="OpenDesktop"/>, or <see cref="OpenInputDesktop"/> function,
        /// and must have the <see cref="ACCESS_MASK.DesktopSpecificRight.DESKTOP_READOBJECTS"/> access right.
        /// If this parameter is NULL, the current desktop is used.
        /// </param>
        /// <param name="lpfn">An application-defined <see cref="WNDENUMPROC"/> callback function.</param>
        /// <param name="lParam">An application-defined value to be passed to the callback function.</param>
        /// <returns>
        /// If the function is unable to perform the enumeration, the return value is zero. Call GetLastError to get extended error information.
        /// If the function succeeds, it returns the nonzero value returned by the callback function that was pointed to by <paramref name="lpfn"/>.
        /// If the callback function fails, the return value is zero. The callback function can call SetLastError to set an error code for the caller to retrieve by calling GetLastError.
        /// Windows Server 2003 and Windows XP/2000:  If there are no windows on the desktop, GetLastError returns ERROR_INVALID_HANDLE.
        /// </returns>
        /// <remarks>The EnumDesktopWindows function repeatedly invokes the <paramref name="lpfn"/> callback function until the last top-level window is enumerated or the callback function returns FALSE.</remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumDesktopWindows(SafeDesktopHandle hDesktop, WNDENUMPROC lpfn, IntPtr lParam);

        /// <summary>
        /// Enumerates all top-level windows on the screen by passing the handle to each window, in turn, to an application-defined callback function. EnumWindows continues until the last top-level window is enumerated or the callback function returns FALSE.
        /// </summary>
        /// <param name="lpEnumFunc">An application-defined <see cref="WNDENUMPROC"/> callback function.</param>
        /// <param name="lParam">An application-defined value to be passed to the callback function.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.To get extended error information, call GetLastError.
        /// If <see cref="WNDENUMPROC"/> returns zero, the return value is also zero. In this case, the callback function should call SetLastError to obtain a meaningful error code to be returned to the caller of EnumWindows.
        /// </returns>
        /// <remarks>
        /// The EnumWindows function does not enumerate child windows, with the exception of a few top-level windows owned by the system that have the WS_CHILD style.
        /// This function is more reliable than calling the GetWindow function in a loop. An application that calls GetWindow to perform this task risks being caught in an infinite loop or referencing a handle to a window that has been destroyed.
        /// Note that for Windows 8 and later, EnumWindows enumerates only top-level windows of desktop apps.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows(WNDENUMPROC lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// Enumerates all desktops associated with the specified window station of the calling process. The function passes the name of each desktop, in turn, to an application-defined callback function.
        /// </summary>
        /// <param name="hWinsta">A handle to the window station whose desktops are to be enumerated. This handle is returned by the <see cref="CreateWindowStation(string, WindowStationCreationFlags, ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/>, <see cref="GetProcessWindowStation"/>, or <see cref="OpenWindowStation"/> function, and must have the WINSTA_ENUMDESKTOPS access right.</param>
        /// <param name="lpEnumFunc">An application-defined <see cref="DESKTOPENUMPROC"/> callback function.</param>
        /// <param name="lParam">An application-defined value to be passed to the callback function.</param>
        /// <returns>
        /// If the function succeeds, it returns the nonzero value returned by the callback function that was pointed to by <paramref name="lpEnumFunc"/>.
        /// If the function is unable to perform the enumeration, the return value is zero. Call GetLastError to get extended error information.
        /// If the callback function fails, the return value is zero. The callback function can call SetLastError to set an error code for the caller to retrieve by calling GetLastError.
        /// </returns>
        /// <remarks>
        /// The EnumDesktops function enumerates only those desktops for which the calling process has the <see cref="ACCESS_MASK.DesktopSpecificRight.DESKTOP_ENUMERATE"/> access right.
        /// The EnumDesktops function repeatedly invokes the lpEnumFunc callback function until the last desktop is enumerated or the callback function returns zero.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern int EnumDesktops(SafeWindowStationHandle hWinsta, DESKTOPENUMPROC lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// Opens the desktop that receives user input.
        /// </summary>
        /// <param name="dwFlags">Access control flags.</param>
        /// <param name="fInherit">If this value is true, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.</param>
        /// <param name="dwDesiredAccess">The requested access to the desktop. For a list of values, see <see cref="ACCESS_MASK"/>.</param>
        /// <returns>If the function succeeds, the return value is a handle to the opened desktop, if the function fails, the return value is an invalid handle.</returns>
        /// <remarks>
        /// <para>
        /// When you are finished using the handle, call the <see cref="CloseDesktop"/> function to close it.
        /// </para>
        /// <para>
        /// The calling process must have an associated window station, either assigned by the system at process creation time or set by the <see cref="SetProcessWindowStation"/> function. The window station associated with the calling process must be capable of receiving input.
        /// If the calling process is running in a disconnected session, the function returns a handle to the desktop that becomes active when the user restores the connection.
        /// </para>
        /// <para>
        /// An application can use the <see cref="SwitchDesktop"/> function to change the input desktop.
        /// </para>
        /// <para>
        /// If the <paramref name="dwDesiredAccess"/> parameter specifies the READ_CONTROL, WRITE_DAC, or WRITE_OWNER standard access rights, you must also request the DESKTOP_READOBJECTS and DESKTOP_WRITEOBJECTS access rights.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern SafeDesktopHandle OpenInputDesktop(
            DesktopCreationFlags dwFlags,
            [MarshalAs(UnmanagedType.Bool)] bool fInherit,
            ACCESS_MASK dwDesiredAccess);

        /// <summary>
        /// Creates a new desktop with the specified heap, associates it with the current window station of the calling process, and assigns it to the calling thread.
        /// The calling process must have an associated window station, either assigned by the system at process creation time or set by the <see cref="SetProcessWindowStation"/> function.
        /// </summary>
        /// <param name="lpszDesktop">The name of the desktop to be created. Desktop names are case-insensitive and may not contain backslash characters (\).</param>
        /// <param name="lpszDevice">This parameter is reserved and must be <see cref="IntPtr.Zero"/>.</param>
        /// <param name="pDevmode">This parameter is reserved and must be <see cref="IntPtr.Zero"/>.</param>
        /// <param name="dwFlags">Access control flags.</param>
        /// <param name="dwDesiredAccess">
        /// The requested access to the desktop. For a list of values, see <see cref="ACCESS_MASK"/>.
        /// This parameter must include the <see cref="ACCESS_MASK.DesktopSpecificRight.DESKTOP_CREATEWINDOW"/> access right, because internally <see cref="CreateDesktop(string, string, IntPtr, DesktopCreationFlags, ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/> uses the handle to create a window.
        /// </param>
        /// <param name="lpsa">
        /// A pointer to a <see cref="Kernel32.SECURITY_ATTRIBUTES"/> structure that determines whether the returned handle can be inherited by child processes. If lpsa is NULL, the handle cannot be inherited.
        /// The <see cref="Kernel32.SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new desktop. If this parameter is NULL, the desktop inherits its security descriptor from the parent window station.
        /// </param>
        /// <param name="ulHeapSize">The size of the desktop heap, in kilobytes.</param>
        /// <param name="pvoid">This parameter is also reserved and must be <see cref="IntPtr.Zero"/>.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created desktop.
        /// If the specified desktop already exists, the function succeeds and returns a handle to the existing desktop.
        /// If the function fails, the return value is an invalid handle.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the dwDesiredAccess parameter specifies the READ_CONTROL, WRITE_DAC, or WRITE_OWNER standard access rights, you must also request the DESKTOP_READOBJECTS and DESKTOP_WRITEOBJECTS access rights.
        /// </para>
        /// <para>
        /// The number of desktops that can be created is limited by the size of the system desktop heap, which is 48 MB. Desktop objects use the heap to store resources. You can increase the number of desktops that can be created by reducing the default heap reserved for each desktop in the interactive window station. This value is specified in the SharedSection substring of the following registry value: HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\SubSystems\Windows.
        /// </para>
        /// <para>
        /// The default size of the desktop heap depends on factors such as hardware architecture. To retrieve the size of the desktop heap, call the <see cref="GetUserObjectInformation(IntPtr, ObjectInformationType, void*, uint, uint*)"/> function with UOI_HEAPSIZE.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe SafeDesktopHandle CreateDesktopEx(
           string lpszDesktop,
           IntPtr lpszDevice,
           IntPtr pDevmode,
           DesktopCreationFlags dwFlags,
           ACCESS_MASK dwDesiredAccess,
           [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] Kernel32.SECURITY_ATTRIBUTES* lpsa,
           uint ulHeapSize,
           IntPtr pvoid = default(IntPtr));

        /// <summary>
        /// Creates a new desktop, associates it with the current window station of the calling process, and assigns it to the calling thread. The calling process must have an associated window station, either assigned by the system at process creation time or set by the <see cref="SetProcessWindowStation"/> function.
        /// </summary>
        /// <param name="lpszDesktop">The name of the desktop to be created. Desktop names are case-insensitive and may not contain backslash characters (\).</param>
        /// <param name="lpszDevice">This parameter is reserved and must be <see cref="IntPtr.Zero"/>.</param>
        /// <param name="pDevmode">This parameter is reserved and must be <see cref="IntPtr.Zero"/>.</param>
        /// <param name="dwFlags">Access control flags.</param>
        /// <param name="dwDesiredAccess">
        /// The requested access to the desktop. For a list of values, see <see cref="ACCESS_MASK"/>.
        /// This parameter must include the <see cref="ACCESS_MASK.DesktopSpecificRight.DESKTOP_CREATEWINDOW"/> access right, because internally <see cref="CreateDesktop(string, string, IntPtr, DesktopCreationFlags, ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/> uses the handle to create a window.
        /// </param>
        /// <param name="lpsa">
        /// A pointer to a <see cref="Kernel32.SECURITY_ATTRIBUTES"/> structure that determines whether the returned handle can be inherited by child processes. If lpsa is NULL, the handle cannot be inherited.
        /// The <see cref="Kernel32.SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new desktop. If this parameter is NULL, the desktop inherits its security descriptor from the parent window station.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created desktop.
        /// If the specified desktop already exists, the function succeeds and returns a handle to the existing desktop.
        /// If the function fails, the return value is an invalid handle.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the dwDesiredAccess parameter specifies the READ_CONTROL, WRITE_DAC, or WRITE_OWNER standard access rights, you must also request the DESKTOP_READOBJECTS and DESKTOP_WRITEOBJECTS access rights.
        /// </para>
        /// <para>
        /// The number of desktops that can be created is limited by the size of the system desktop heap, which is 48 MB. Desktop objects use the heap to store resources. You can increase the number of desktops that can be created by reducing the default heap reserved for each desktop in the interactive window station. This value is specified in the SharedSection substring of the following registry value: HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\SubSystems\Windows.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe SafeDesktopHandle CreateDesktop(
            string lpszDesktop,
            string lpszDevice,
            IntPtr pDevmode,
            DesktopCreationFlags dwFlags,
            ACCESS_MASK dwDesiredAccess,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] Kernel32.SECURITY_ATTRIBUTES* lpsa);

        /// <summary>
        /// Retrieves a handle to the desktop assigned to the specified thread.
        /// </summary>
        /// <param name="dwThreadId">The thread identifier. The <see cref="Kernel32.GetCurrentThreadId"/> and CreateProcess functions return thread identifiers.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the desktop associated with the specified thread.
        /// You do not need to call the <see cref="CloseDesktop"/> function to close the returned handle.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The system associates a desktop with a thread when that thread is created. A thread can use the SetThreadDesktop function to change its desktop. The desktop associated with a thread must be on the window station associated with the thread's process.
        /// </para>
        /// <para>
        /// The calling process can use the returned handle in calls to the <see cref="GetUserObjectInformation(IntPtr, ObjectInformationType, void*, uint, uint*)"/>, GetUserObjectSecurity, SetUserObjectInformation, and SetUserObjectSecurity functions.
        /// </para>
        /// <para>
        /// A service application is created with an associated window station and desktop, so there is no need to call a USER or GDI function to connect the service to a window station and desktop.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern SafeDesktopHandle GetThreadDesktop(uint dwThreadId);

        /// <summary>
        /// Closes an open handle to a desktop object.
        /// </summary>
        /// <param name="hDesktop">
        /// A handle to the desktop to be closed. This can be a handle returned by the <see cref="CreateDesktop(string, string, IntPtr, DesktopCreationFlags, ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/>, <see cref="OpenDesktop"/>, or <see cref="OpenInputDesktop"/> functions.
        /// Do not specify the handle returned by the <see cref="GetThreadDesktop"/> function.
        /// </param>
        /// <returns>If the function succeeds, the return value is true, if it fails, the return value is false.</returns>
        /// <remarks>The CloseDesktop function will fail if any thread in the calling process is using the specified desktop handle or if the handle refers to the initial desktop of the calling process.</remarks>
#if NETFRAMEWORK || NETSTANDARD2_0_ORLATER
        [SuppressUnmanagedCodeSecurity]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseDesktop(IntPtr hDesktop);

        /// <summary>
        /// Retrieves information about the specified window station or desktop object.
        /// </summary>
        /// <param name="hObj">A handle to the window station or desktop object. This handle is returned by the <see cref="CreateWindowStation(string, WindowStationCreationFlags, ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/>, <see cref="OpenWindowStation"/>, <see cref="CreateDesktop(string, string, IntPtr, DesktopCreationFlags, ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/>, or <see cref="OpenDesktop"/> function.</param>
        /// <param name="nIndex">The information to be retrieved.</param>
        /// <param name="pvInfo">A pointer to a buffer to receive the object information.</param>
        /// <param name="nLength">The size of the buffer pointed to by the <paramref name="pvInfo"/> parameter, in bytes.</param>
        /// <param name="lpnLengthNeeded">
        /// A pointer to a variable receiving the number of bytes required to store the requested information.
        /// If this variable's value is greater than the value of the <paramref name="nLength"/> parameter when the function returns, the function returns false, and none of the information is copied to the <paramref name="pvInfo"/> buffer.
        /// If the value of the variable pointed to by lpnLengthNeeded is less than or equal to the value of <paramref name="nLength"/>, the entire information block is copied.</param>
        /// <returns>If the function succeeds, the return value is true, if it fails, the return value is false.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool GetUserObjectInformation(IntPtr hObj, ObjectInformationType nIndex, void* pvInfo, uint nLength, uint* lpnLengthNeeded);

        /// <summary>
        /// Assigns the specified window station to the calling process.
        /// This enables the process to access objects in the window station such as desktops, the clipboard, and global atoms. All subsequent operations on the window station use the access rights granted to <paramref name="hWinSta"/>.
        /// </summary>
        /// <param name="hWinSta">
        /// A handle to the window station. This can be a handle returned by the <see cref="CreateWindowStation(string, WindowStationCreationFlags, ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/>, <see cref="OpenWindowStation"/>, or <see cref="GetProcessWindowStation"/> function.
        /// This window station must be associated with the current session.
        /// </param>
        /// <returns>If the function succeeds, the return value is true, if it fails, the return value is false.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetProcessWindowStation(SafeWindowStationHandle hWinSta);

        /// <summary>
        /// Closes an open window station handle.
        /// </summary>
        /// <param name="hWinsta">
        /// A handle to the window station to be closed.
        /// This handle is returned by the <see cref="CreateWindowStation(string, WindowStationCreationFlags, ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/> or <see cref="OpenWindowStation"/> function.
        /// Do not specify the handle returned by the <see cref="GetProcessWindowStation"/> function.
        /// </param>
        /// <returns>If the function succeeds, the return value is true, if it fails, the return value is false.</returns>
        /// <remarks>
        /// <para>
        /// Windows Server 2003 and Windows XP/2000:  This function does not set the last error code on failure.
        /// </para>
        /// <para>
        /// The CloseWindowStation function will fail if the handle being closed is for the window station assigned to the calling process.
        /// </para>
        /// </remarks>
#if NETFRAMEWORK || NETSTANDARD2_0_ORLATER
        [SuppressUnmanagedCodeSecurity]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseWindowStation(IntPtr hWinsta);

        /// <summary>
        /// Creates a window station object, associates it with the calling process, and assigns it to the current session.
        /// </summary>
        /// <param name="lpwinsta">
        /// The name of the window station to be created. Window station names are case-insensitive and cannot contain backslash characters (\).
        /// Only members of the Administrators group are allowed to specify a name.
        /// If lpwinsta is NULL or an empty string, the system forms a window station name using the logon session identifier for the calling process.
        /// To get this name, call the <see cref="GetUserObjectInformation(IntPtr, ObjectInformationType, void*, uint, uint*)"/> function.</param>
        /// <param name="dwFlags">
        /// If this parameter is <see cref="WindowStationCreationFlags.CWF_CREATE_ONLY"/> and the window station already exists, the call fails.
        /// If this flag is not specified and the window station already exists, the function succeeds and returns a new handle to the existing window station.
        /// Windows XP/2000:  This parameter is reserved and must be zero.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The requested access to the window station. For a list of values, see <see cref="ACCESS_MASK"/>.
        /// In addition, you can specify any of the standard access rights, such as <see cref="ACCESS_MASK.StandardRight.READ_CONTROL"/> or <see cref="ACCESS_MASK.StandardRight.WRITE_DAC"/>, and a combination of the window station-specific access rights.
        /// </param>
        /// <param name="lpsa">
        /// A pointer to a <see cref="Kernel32.SECURITY_ATTRIBUTES"/> structure that determines whether the returned handle can be inherited by child processes. If lpsa is NULL, the handle cannot be inherited.
        /// The <see cref="Kernel32.SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new window station.
        /// If lpsa is NULL, the window station (and any desktops created within the window) gets a security descriptor that grants <see cref="ACCESS_MASK.GenericRight.GENERIC_ALL"/> access to all users.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created window station.
        /// If the specified window station already exists, the function succeeds and returns a handle to the existing window station.
        /// If the function fails, the return value is an invalid handle.
        /// </returns>
        /// <remarks>After you are done with the handle, you must call <see cref="CloseWindowStation"/> to free the handle.</remarks>
        [DllImport(nameof(User32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe SafeWindowStationHandle CreateWindowStation(
            string lpwinsta,
            WindowStationCreationFlags dwFlags,
            ACCESS_MASK dwDesiredAccess,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] Kernel32.SECURITY_ATTRIBUTES* lpsa);

        /// <summary>
        /// Retrieves a handle to the current window station for the calling process.
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the window station. If the function fails, the return value is an invalid handle.
        /// Do not close the handle returned by this function.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The system associates a window station with a process when the process is created. A process can use the <see cref="SetProcessWindowStation"/> function to change its window station.
        /// </para>
        /// <para>
        /// The calling process can use the returned handle in calls to the <see cref="GetUserObjectInformation(IntPtr, ObjectInformationType, void*, uint, uint*)"/>, GetUserObjectSecurity, SetUserObjectInformation, and SetUserObjectSecurity functions.
        /// </para>
        /// <para>
        /// A service application is created with an associated window station and desktop, so there is no need to call a USER or GDI function to connect the service to a window station and desktop.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern SafeWindowStationHandle GetProcessWindowStation();

        /// <summary>
        /// Enumerates all window stations in the current session. The function passes the name of each window station, in turn, to an application-defined callback function.
        /// </summary>
        /// <param name="lpEnumFunc">An application-defined <see cref="WINSTAENUMPROC"/> callback function.</param>
        /// <param name="lParam">An application-defined value to be passed to the callback function.</param>
        /// <returns>
        /// If the function is unable to perform the enumeration, the return value is zero. Call GetLastError to get extended error information.
        /// If the function succeeds, it returns the nonzero value returned by the callback function that was pointed to by <paramref name="lpEnumFunc"/>.
        /// If the callback function fails, the return value is zero. The callback function can call SetLastError to set an error code for the caller to retrieve by calling GetLastError.
        /// </returns>
        /// <remarks>
        /// The EnumWindowStations function enumerates only those window stations for which the calling process has the <see cref="ACCESS_MASK.WindowStationSpecificRight.WINSTA_ENUMERATE"/> access right.
        ///  EnumWindowStations repeatedly invokes the <paramref name="lpEnumFunc"/> callback function until the last window station is enumerated or the callback function returns FALSE.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindowStations(WINSTAENUMPROC lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// Opens the specified window station.
        /// </summary>
        /// <param name="lpszWinSta">The name of the window station to be opened. Window station names are case-insensitive. This window station must belong to the current session.</param>
        /// <param name="fInherit">If this value is TRUE, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.</param>
        /// <param name="dwDesiredAccess">The access to the window station. For a list of access rights.</param>
        /// <returns>If the function succeeds, the return value is the handle to the specified window station. If the function fails, the return value is NULL.</returns>
        /// <remarks>After you are done with the handle, you must call <see cref="CloseWindowStation"/> to free the handle.</remarks>
        [DllImport(nameof(User32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern SafeWindowStationHandle OpenWindowStation(
            string lpszWinSta,
            [MarshalAs(UnmanagedType.Bool)] bool fInherit,
            ACCESS_MASK dwDesiredAccess);

        /// <summary>
        ///     Creates a modeless dialog box from a dialog box template in memory. Before displaying the dialog box, the function
        ///     passes an application-defined value to the dialog box procedure as the lParam parameter of the
        ///     <see cref="WindowMessage.WM_INITDIALOG" /> message. An application can use this value to initialize dialog box
        ///     controls.
        /// </summary>
        /// <param name="hInstance">
        ///     A handle to the module which contains the dialog box template. If this parameter is
        ///     <see cref="Kernel32.SafeLibraryHandle.Null" />, then the current executable is used.
        /// </param>
        /// <param name="lpTemplate">
        ///     The template CreateDialogIndirectParam uses to create the dialog box. A dialog box template consists of a header
        ///     that describes the dialog box, followed by one or more additional blocks of data that describe each of the controls
        ///     in the dialog box. The template can use either the standard format or the extended format.
        ///     <para>
        ///         In a standard template, the header is a <see cref="DLGTEMPLATE" /> structure followed by additional
        ///         variable-length arrays. The data for each control consists of a <see cref="DLGITEMTEMPLATE" /> structure
        ///         followed by additional variable-length arrays.
        ///     </para>
        ///     <para>
        ///         In an extended dialog box template, the header uses the DLGTEMPLATEEX format and the control definitions use
        ///         the DLGITEMTEMPLATEEX format.
        ///     </para>
        ///     <para>
        ///         After CreateDialogIndirectParam returns, you can free the template, which is only used to get the dialog box
        ///         started.
        ///     </para>
        /// </param>
        /// <param name="hWndParent">A handle to the window that owns the dialog box.</param>
        /// <param name="lpDialogFunc">A pointer to the dialog box procedure.</param>
        /// <param name="lParamInit">
        ///     The value to pass to the dialog box in the lParam parameter of the
        ///     <see cref="WindowMessage.WM_INITDIALOG" /> message.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is the window handle to the dialog box.
        ///     <para>
        ///         If the function fails, the return value is <see cref="IntPtr.Zero" />. To get extended error information,
        ///         call <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern unsafe IntPtr CreateDialogIndirectParam(
            SafeLibraryHandle hInstance,
            DLGTEMPLATE* lpTemplate,
            IntPtr hWndParent,
            DialogProc lpDialogFunc,
            IntPtr lParamInit);

        /// <summary>
        ///     Retrieves a message from the calling thread's message queue. The function dispatches incoming sent messages until a
        ///     posted message is available for retrieval.
        ///     <para>
        ///         Unlike <see cref="GetMessage(MSG*, IntPtr, WindowMessage,WindowMessage)" />, the <see cref="PeekMessage(MSG*, IntPtr, WindowMessage,WindowMessage,PeekMessageRemoveFlags)" /> function does not wait for a message to be
        ///         posted before returning.
        ///     </para>
        /// </summary>
        /// <param name="lpMsg">A pointer to an <see cref="MSG" /> structure that receives message information.</param>
        /// <param name="hWnd">
        ///     A handle to the window whose messages are to be retrieved. The window must belong to the current thread.
        ///     <para>
        ///         If hWnd is <see cref="IntPtr.Zero" />, PeekMessage retrieves messages for any window that belongs to the
        ///         current thread, and any messages on the current thread's message queue whose hwnd value is NULL (see the MSG
        ///         structure). Therefore if hWnd is <see cref="IntPtr.Zero" />, both window messages and thread messages are
        ///         processed.
        ///     </para>
        ///     <para>
        ///         If hWnd is -1, PeekMessage retrieves only messages on the current thread's message queue whose hwnd value is
        ///         NULL, that is, thread messages as posted by <see cref="PostMessage(IntPtr, WindowMessage, void*, void*)" />
        ///         (when the hWnd parameter is <see cref="IntPtr.Zero" />) or <see cref="PostThreadMessage(int, WindowMessage, IntPtr, IntPtr)"/>.
        ///     </para>
        /// </param>
        /// <param name="wMsgFilterMin">
        ///     <para>
        ///         The value of the first message in the range of messages to be examined. Use
        ///         <see cref="WindowMessage.WM_KEYFIRST" /> to specify the first keyboard message or
        ///         <see cref="WindowMessage.WM_MOUSEFIRST" /> to specify the first mouse message.
        ///     </para>
        ///     <para>
        ///         If wMsgFilterMin and wMsgFilterMax are both <see cref="WindowMessage.WM_NULL" />, PeekMessage returns all
        ///         available messages (that is, no range filtering is performed).
        ///     </para>
        /// </param>
        /// <param name="wMsgFilterMax">
        ///     <para>
        ///         The value of the last message in the range of messages to be examined. Use
        ///         <see cref="WindowMessage.WM_KEYLAST" /> to specify the last keyboard message or
        ///         <see cref="WindowMessage.WM_MOUSELAST" /> to specify the last mouse message.
        ///     </para>
        ///     <para>
        ///         If wMsgFilterMin and wMsgFilterMax are both <see cref="WindowMessage.WM_NULL" />, PeekMessage returns all
        ///         available messages (that is, no range filtering is performed).
        ///     </para>
        /// </param>
        /// <returns>
        ///     If the function retrieves a message other than <see cref="WindowMessage.WM_QUIT" />, the return value is nonzero.
        ///     <para>If the function retrieves the <see cref="WindowMessage.WM_QUIT" /> message, the return value is zero.</para>
        ///     <para>
        ///         If there is an error, the return value is -1. For example, the function fails if <paramref name="hWnd" /> is
        ///         an invalid window handle or <paramref name="lpMsg" /> is an invalid pointer. To get extended error information,
        ///         call <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern unsafe int GetMessage(
            MSG* lpMsg,
            IntPtr hWnd,
            WindowMessage wMsgFilterMin,
            WindowMessage wMsgFilterMax);

        /// <summary>
        ///     Dispatches incoming sent messages, checks the thread message queue for a posted message, and retrieves the message
        ///     (if any exist).
        /// </summary>
        /// <param name="lpMsg">A pointer to an <see cref="MSG" /> structure that receives message information.</param>
        /// <param name="hWnd">
        ///     A handle to the window whose messages are to be retrieved. The window must belong to the current thread.
        ///     <para>
        ///         If hWnd is <see cref="IntPtr.Zero" />, PeekMessage retrieves messages for any window that belongs to the
        ///         current thread, and any messages on the current thread's message queue whose hwnd value is NULL (see the MSG
        ///         structure). Therefore if hWnd is <see cref="IntPtr.Zero" />, both window messages and thread messages are
        ///         processed.
        ///     </para>
        ///     <para>
        ///         If hWnd is -1, PeekMessage retrieves only messages on the current thread's message queue whose hwnd value is
        ///         NULL, that is, thread messages as posted by <see cref="PostMessage(IntPtr, WindowMessage, void*, void*)" /> (when the hWnd parameter is
        ///         <see cref="IntPtr.Zero" />) or <see cref="PostThreadMessage(int, WindowMessage, IntPtr, IntPtr)"/>.
        ///     </para>
        /// </param>
        /// <param name="wMsgFilterMin">
        ///     <para>
        ///         The value of the first message in the range of messages to be examined. Use
        ///         <see cref="WindowMessage.WM_KEYFIRST" /> to specify the first keyboard message or
        ///         <see cref="WindowMessage.WM_MOUSEFIRST" /> to specify the first mouse message.
        ///     </para>
        ///     <para>
        ///         If wMsgFilterMin and wMsgFilterMax are both <see cref="WindowMessage.WM_NULL" />, PeekMessage returns all
        ///         available messages (that is, no range filtering is performed).
        ///     </para>
        /// </param>
        /// <param name="wMsgFilterMax">
        ///     <para>
        ///         The value of the last message in the range of messages to be examined. Use
        ///         <see cref="WindowMessage.WM_KEYLAST" /> to specify the last keyboard message or
        ///         <see cref="WindowMessage.WM_MOUSELAST" /> to specify the last mouse message.
        ///     </para>
        ///     <para>
        ///         If wMsgFilterMin and wMsgFilterMax are both <see cref="WindowMessage.WM_NULL" />, PeekMessage returns all
        ///         available messages (that is, no range filtering is performed).
        ///     </para>
        /// </param>
        /// <param name="wRemoveMsg">Specifies how messages are to be handled.</param>
        /// <returns>
        ///     If a message is available, the return value is true.
        ///     <para>If no messages are available, the return value is false.</para>
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool PeekMessage(
            MSG* lpMsg,
            IntPtr hWnd,
            WindowMessage wMsgFilterMin,
            WindowMessage wMsgFilterMax,
            PeekMessageRemoveFlags wRemoveMsg);

        /// <summary>
        ///     Posts a message to the message queue of the specified thread. It returns without waiting for the thread to process
        ///     the message.
        /// </summary>
        /// <param name="idThread">
        ///     The identifier of the thread to which the message is to be posted.
        ///     <para>
        ///         The function fails if the specified thread does not have a message queue. The system creates a thread's
        ///         message queue when the thread makes its first call to one of the User or GDI functions.
        ///     </para>
        ///     <para>
        ///         Message posting is subject to UIPI. The thread of a process can post messages only to posted-message queues
        ///         of threads in processes of lesser or equal integrity level.
        ///     </para>
        ///     <para>
        ///         This thread must have the SE_TCB_NAME privilege to post a message to a thread that belongs to a process with
        ///         the same locally unique identifier (LUID) but is in a different desktop. Otherwise, the function fails and
        ///         returns <see cref="Win32ErrorCode.ERROR_INVALID_THREAD_ID" />.
        ///     </para>
        ///     <para>
        ///         This thread must either belong to the same desktop as the calling thread or to a process with the same LUID.
        ///         Otherwise, the function fails and returns <see cref="Win32ErrorCode.ERROR_INVALID_THREAD_ID" />.
        ///     </para>
        /// </param>
        /// <param name="Msg">The type of message to be posted.</param>
        /// <param name="wParam">First additional message-specific information.</param>
        /// <param name="lParam">Second additional message-specific information.</param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />. GetLastError returns
        ///         <see cref="Win32ErrorCode.ERROR_INVALID_THREAD_ID" /> if idThread is not a valid thread identifier, or if the
        ///         thread specified by idThread does not have a message queue. GetLastError returns
        ///         <see cref="Win32ErrorCode.ERROR_NOT_ENOUGH_QUOTA" /> when the message limit is hit.
        ///     </para>
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PostThreadMessage(
            int idThread,
            WindowMessage Msg,
            IntPtr wParam,
            IntPtr lParam);

        /// <summary>
        ///     Calls the default window procedure to provide default processing for any window messages that an application does
        ///     not process. This function ensures that every message is processed. DefWindowProc is called with the same
        ///     parameters received by the window procedure.
        /// </summary>
        /// <param name="hWnd">A handle to the window procedure that received the message.</param>
        /// <param name="Msg">The message.</param>
        /// <param name="wParam">First additional message information. The content of this parameter depends on the value of the <paramref name="Msg" /> parameter.</param>
        /// <param name="lParam">Second additional message information. The content of this parameter depends on the value of the <paramref name="Msg" /> parameter.</param>
        /// <returns>The return value is the result of the message processing and depends on the message.</returns>
        [DllImport(nameof(User32))]
        public static extern IntPtr DefWindowProc(
            IntPtr hWnd,
            WindowMessage Msg,
            IntPtr wParam,
            IntPtr lParam);

        /// <summary>
        ///     Retrieves the type of messages found in the calling thread's message queue.
        /// </summary>
        /// <param name="flags">The types of messages for which to check.</param>
        /// <returns>
        ///     The high-order word of the return value indicates the types of messages currently in the queue. The low-order word
        ///     indicates the types of messages that have been added to the queue and that are still in the queue since the last
        ///     call to the <see cref="GetQueueStatus" />, <see cref="GetMessage(MSG*, IntPtr, WindowMessage,WindowMessage)" />, or <see cref="PeekMessage(MSG*, IntPtr, WindowMessage,WindowMessage,PeekMessageRemoveFlags)" /> function.
        /// </returns>
        [DllImport(nameof(User32))]
        public static extern int GetQueueStatus(QueueStatusFlags flags);

        /// <summary>
        ///     Translates virtual-key messages into character messages. The character messages are posted to the calling thread's
        ///     message queue, to be read the next time the thread calls the <see cref="GetMessage(MSG*, IntPtr, WindowMessage,WindowMessage)" /> or
        ///     <see cref="PeekMessage(MSG*, IntPtr, WindowMessage,WindowMessage,PeekMessageRemoveFlags)" /> function.
        /// </summary>
        /// <param name="lpMsg">
        ///     A pointer to an <see cref="MSG" /> structure that contains message information retrieved from the
        ///     calling thread's message queue by using the <see cref="GetMessage(MSG*, IntPtr, WindowMessage,WindowMessage)" /> or <see cref="PeekMessage(MSG*, IntPtr, WindowMessage,WindowMessage,PeekMessageRemoveFlags)" /> function.
        /// </param>
        /// <returns>
        ///     If the message is translated (that is, a character message is posted to the thread's message queue), the return
        ///     value is nonzero.
        ///     <para>
        ///         If the message is <see cref="WindowMessage.WM_KEYDOWN" />, <see cref="WindowMessage.WM_KEYUP" />,
        ///         <see cref="WindowMessage.WM_SYSKEYDOWN" />, or
        ///         <see cref="WindowMessage.WM_SYSKEYUP" />, the return value is nonzero, regardless of the translation.
        ///     </para>
        ///     <para>
        ///         If the message is not translated (that is, a character message is not posted to the thread's message queue),
        ///         the return value is zero.
        ///     </para>
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool TranslateMessage(MSG* lpMsg);

        /// <summary>
        ///     Dispatches a message to a window procedure. It is typically used to dispatch a message retrieved by the
        ///     <see cref="GetMessage(MSG*, IntPtr, WindowMessage,WindowMessage)" /> function.
        /// </summary>
        /// <param name="lpMsg">A pointer to a structure that contains the message.</param>
        /// <returns>
        ///     The return value specifies the value returned by the window procedure. Although its meaning depends on the
        ///     message being dispatched, the return value generally is ignored.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern unsafe IntPtr DispatchMessage(MSG* lpMsg);

        /// <summary>
        ///     Indicates to the system that a thread has made a request to terminate (quit). It is typically used in response to a
        ///     <see cref="WindowMessage.WM_DESTROY" /> message.
        /// </summary>
        /// <param name="nExitCode">
        ///     The application exit code. This value is used as the wParam parameter of the
        ///     <see cref="WindowMessage.WM_QUIT" /> message.
        /// </param>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern void PostQuitMessage(int nExitCode);

        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TranslateMessage(ref MSG lpMsg);

        /// <summary>
        ///     Determines whether a message is intended for the specified dialog box and, if it is, processes the message.
        /// </summary>
        /// <param name="hDlg">A handle to the dialog box.</param>
        /// <param name="lpMsg">A pointer to an <see cref="MSG" /> structure that contains the message to be checked.</param>
        /// <returns>
        ///     If the message has been processed, the return value is nonzero.
        ///     <para>If the message has not been processed, the return value is zero.</para>
        /// </returns>
        [DllImport(nameof(User32))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool IsDialogMessage(IntPtr hDlg, MSG* lpMsg);

        /// <summary>
        ///     Loads a string resource from the executable file associated with a specified module, copies the string into
        ///     a buffer, and appends a terminating null character.
        /// </summary>
        /// <param name="hInstance">
        ///     A handle to an instance of the module whose executable file contains the string resource. To get the handle
        ///     to the application itself, call the <see cref="Kernel32.GetModuleHandle(string)"/> function with NULL.
        /// </param>
        /// <param name="uID">
        ///     The identifier of the string to be loaded.
        /// </param>
        /// <param name="lpBuffer">
        /// The buffer to receive the string (if <paramref name="cchBufferMax" /> is non-zero) or a read-only pointer to the string resource itself (if <paramref name="cchBufferMax" /> is zero). Must be of sufficient length to hold a pointer (8 bytes).
        /// </param>
        /// <param name="cchBufferMax">
        ///     The size of the buffer, in characters. The string is truncated and null-terminated if it is longer than the
        ///     number of characters specified. If this parameter is 0, then <paramref name="lpBuffer" /> receives a read-only pointer to the
        ///     resource itself.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is the number of characters copied into the buffer, not
        ///     including the terminating null character, or zero if the string resource does not exist. To get extended
        ///     error information, call <see cref="Kernel32.GetLastError"/>.
        /// </returns>
        [DllImport(nameof(User32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe int LoadString(
            IntPtr hInstance,
            uint uID,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Array, ArrayLengthParameter = 3)] char* lpBuffer,
            int cchBufferMax);

        /// <summary>
        /// Retrieves the length, in characters, of the specified window's title bar text (if the window has a title bar).
        /// If the specified window is a control, the function retrieves the length of the text within the control. However,
        /// GetWindowTextLength cannot retrieve the length of the text of an edit control in another application.
        /// </summary>
        /// <param name="hWnd">A handle to the window or control.</param>
        /// <returns>
        /// If the function succeeds, the return value is the length, in characters, of the text. Under certain
        /// conditions, this value may actually be greater than the length of the text. For more information, see the following
        /// Remarks section.
        /// <para>If the window has no text, the return value is zero. To get extended error information, call GetLastError.</para>
        /// </returns>
        [DllImport(nameof(User32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        /// <summary>
        /// Copies the text of the specified window's title bar (if it has one) into a buffer. If the specified window is
        /// a control, the text of the control is copied. However, GetWindowText cannot retrieve the text of a control in another
        /// application.
        /// </summary>
        /// <param name="hWnd">A handle to the window or control containing the text.</param>
        /// <param name="lpString">
        /// The buffer that will receive the text. If the string is as long or longer than the buffer, the
        /// string is truncated and terminated with a null character.
        /// </param>
        /// <param name="nMaxCount">
        /// The maximum number of characters to copy to the buffer, including the null character. If the
        /// text exceeds this limit, it is truncated.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length, in characters, of the copied string, not including
        /// the terminating null character. If the window has no title bar or text, if the title bar is empty, or if the window or
        /// control handle is invalid, the return value is zero. To get extended error information, call GetLastError.
        /// <para>This function cannot retrieve the text of an edit control in another application.</para>
        /// </returns>
        [DllImport(nameof(User32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe int GetWindowText(
            IntPtr hWnd,
            [Friendly(FriendlyFlags.Array | FriendlyFlags.Out, ArrayLengthParameter = 2)] char* lpString,
            int nMaxCount);

        /// <summary>
        /// Changes the text of the specified window's title bar (if it has one). If the specified window is a control, the text of the control is changed. However, SetWindowText cannot change the text of a control in another application.
        /// </summary>
        /// <param name="hWnd">A handle to the window or control whose text is to be changed.</param>
        /// <param name="lpString">The new title or control text.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(nameof(User32), CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool SetWindowText(
            IntPtr hWnd,
            string lpString);

        /// <summary>
        /// Examines the Z order of the child windows associated with the specified parent window and retrieves a handle to the child window at the top of the Z order.
        /// </summary>
        /// <param name="hWnd">A handle to the parent window whose child windows are to be examined. If this parameter is NULL, the function returns a handle to the window at the top of the Z order.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the child window at the top of the Z order. If the specified window has no child windows, the return value is NULL. To get extended error information, use the GetLastError function.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr GetTopWindow(IntPtr hWnd);

        /// <summary>
        /// Retrieves a handle to a window that has the specified relationship (Z-Order or owner) to the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to a window. The window handle retrieved is relative to this window, based on the value of the wCmd parameter.</param>
        /// <param name="wCmd">The relationship between the specified window and the window whose handle is to be retrieved.</param>
        /// <returns>If the function succeeds, the return value is a handle to the next (or previous) window. If there is no next (or previous) window, the return value is NULL. To get extended error information, call GetLastError.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr GetWindow(
            IntPtr hWnd,
            GetWindowCommands wCmd);

        /// <summary>
        /// Retrieves a handle to the next or previous window in the Z-Order. The next window is below the specified window; the previous window is above.
        /// If the specified window is a topmost window, the function searches for a topmost window. If the specified window is a top-level window, the function searches for a top-level window. If the specified window is a child window, the function searches for a child window.
        /// </summary>
        /// <param name="hWnd">A handle to a window. The window handle retrieved is relative to this window, based on the value of the wCmd parameter.</param>
        /// <param name="wCmd">Indicates whether the function returns a handle to the next window or the previous window.</param>
        /// <returns>If the function succeeds, the return value is a handle to the next (or previous) window. If there is no next (or previous) window, the return value is NULL. To get extended error information, call GetLastError.</returns>
        public static IntPtr GetNextWindow(IntPtr hWnd, GetNextWindowCommands wCmd) => GetWindow(hWnd, (GetWindowCommands)wCmd);

        /// <summary>
        /// Moves the cursor to the specified screen coordinates. If the new coordinates are not within the screen
        /// rectangle set by the most recent ClipCursor function call, the system automatically adjusts the coordinates so that the
        /// cursor stays within the rectangle.
        /// </summary>
        /// <param name="X">The new x-coordinate of the cursor, in screen coordinates.</param>
        /// <param name="Y">The new y-coordinate of the cursor, in screen coordinates.</param>
        /// <returns>Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int X, int Y);

        /// <summary>
        /// Retrieves the position of the mouse cursor, in screen coordinates.
        /// </summary>
        /// <param name="lpPoint">A pointer to a POINT structure that receives the screen coordinates of the cursor.</param>
        /// <returns>Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool GetCursorPos(POINT* lpPoint);

        /// <summary>
        /// Retrieves a handle to the window that contains the specified point.
        /// </summary>
        /// <param name="Point">The point to be checked.</param>
        /// <returns>The return value is a handle to the window that contains the point. If no window exists at the given point, the return value is <see cref="IntPtr.Zero"/>. If the point is over a static text control, the return value is a handle to the window under the static text control.</returns>
        [DllImport(nameof(User32))]
        public static extern IntPtr WindowFromPoint(POINT Point);

        /// <summary>Retrieves the show state and the restored, minimized, and maximized positions of the specified window.</summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="lpwndpl">
        /// A pointer to the WINDOWPLACEMENT structure that receives the show state and position information.
        /// Before calling GetWindowPlacement, set the length member to sizeof(WINDOWPLACEMENT). GetWindowPlacement fails if
        /// lpwndpl-> length is not set correctly.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool GetWindowPlacement(IntPtr hWnd, WINDOWPLACEMENT* lpwndpl);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr ChildWindowFromPoint(IntPtr hWndParent, POINT Point);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr ChildWindowFromPointEx(IntPtr hWndParent, POINT pt, ChildWindowFromPointExFlags uFlags);

        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT lpPoint);

        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UpdateWindow(IntPtr hWnd);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr WindowFromPhysicalPoint(POINT pt);

        /// <summary>
        /// Creates an overlapped, pop-up, or child window with an
        /// extended window style; otherwise, this function is identical to the CreateWindow function.
        /// </summary>
        /// <param name="dwExStyle">Specifies the extended window style of the window being created.</param>
        /// <param name="lpClassName">
        /// Pointer to a null-terminated string that specifies
        /// the window class name. The class name can be any name registered with RegisterClass or
        /// RegisterClassEx, provided that the module that registers the class is also the module
        /// that creates the window. The class name can also be any of the predefined system class names.
        /// </param>
        /// <param name="lpWindowName">
        /// Pointer to a null-terminated string that specifies the window name. If the window style
        /// specifies a title bar, the window title pointed to by lpWindowName is displayed in the
        /// title bar. When using CreateWindow to create controls, such as buttons, check boxes, and
        /// static controls, use lpWindowName to specify the text of the control. When creating a
        /// static control with the SS_ICON style, use lpWindowName to specify the icon name or
        /// identifier. To specify an identifier, use the syntax "#num".
        /// </param>
        /// <param name="dwStyle">
        /// Specifies the style of the window being created. This parameter can be a combination of
        /// window styles, plus the control styles indicated in the Remarks section.
        /// </param>
        /// <param name="x">
        /// Specifies the initial horizontal position of the window. For an overlapped or pop-up
        /// window, the x parameter is the initial x-coordinate of the window's upper-left corner, in
        /// screen coordinates. For a child window, x is the x-coordinate of the upper-left corner of
        /// the window relative to the upper-left corner of the parent window's client area. If x is
        /// set to CW_USEDEFAULT, the system selects the default position for the window's upper-left
        /// corner and ignores the y parameter. CW_USEDEFAULT is valid only for overlapped windows;
        /// if it is specified for a pop-up or child window, the x and y parameters are set to zero.
        /// </param>
        /// <param name="y">
        /// Specifies the initial vertical position of the window. For an overlapped or pop-up
        /// window, the y parameter is the initial y-coordinate of the window's upper-left corner, in
        /// screen coordinates. For a child window, y is the initial y-coordinate of the upper-left
        /// corner of the child window relative to the upper-left corner of the parent window's
        /// client area. For a list box y is the initial y-coordinate of the upper-left corner of the
        /// list box's client area relative to the upper-left corner of the parent window's client area.
        /// <para>
        /// If an overlapped window is created with the WS_VISIBLE style bit set and the x parameter
        /// is set to CW_USEDEFAULT, then the y parameter determines how the window is shown. If the
        /// y parameter is CW_USEDEFAULT, then the window manager calls ShowWindow with the SW_SHOW
        /// flag after the window has been created. If the y parameter is some other value, then the
        /// window manager calls ShowWindow with that value as the nCmdShow parameter.
        /// </para>
        /// </param>
        /// <param name="nWidth">
        /// Specifies the width, in device units, of the window. For overlapped windows, nWidth is
        /// the window's width, in screen coordinates, or CW_USEDEFAULT. If nWidth is CW_USEDEFAULT,
        /// the system selects a default width and height for the window; the default width extends
        /// from the initial x-coordinates to the right edge of the screen; the default height
        /// extends from the initial y-coordinate to the top of the icon area. CW_USEDEFAULT is valid
        /// only for overlapped windows; if CW_USEDEFAULT is specified for a pop-up or child window,
        /// the nWidth and nHeight parameter are set to zero.
        /// </param>
        /// <param name="nHeight">
        /// Specifies the height, in device units, of the window. For overlapped windows, nHeight is
        /// the window's height, in screen coordinates. If the nWidth parameter is set to
        /// CW_USEDEFAULT, the system ignores nHeight.
        /// </param>
        /// <param name="hWndParent">
        /// Handle to the parent or owner window of the window being created. To create a child
        /// window or an owned window, supply a valid window handle. This parameter is optional for
        /// pop-up windows.
        /// <para>
        /// Windows 2000/XP: To create a message-only window, supply HWND_MESSAGE or a handle to an
        /// existing message-only window.
        /// </para>
        /// </param>
        /// <param name="hMenu">
        /// Handle to a menu, or specifies a child-window identifier, depending on the window style.
        /// For an overlapped or pop-up window, hMenu identifies the menu to be used with the window;
        /// it can be NULL if the class menu is to be used. For a child window, hMenu specifies the
        /// child-window identifier, an integer value used by a dialog box control to notify its
        /// parent about events. The application determines the child-window identifier; it must be
        /// unique for all child windows with the same parent window.
        /// </param>
        /// <param name="hInstance">
        /// Handle to the instance of the module to be associated with the window.
        /// </param>
        /// <param name="lpParam">
        /// Pointer to a value to be passed to the window through the CREATESTRUCT structure
        /// (lpCreateParams member) pointed to by the lParam param of the WM_CREATE message. This
        /// message is sent to the created window by this function before it returns.
        /// <para>
        /// If an application calls CreateWindow to create a MDI client window, lpParam should point
        /// to a CLIENTCREATESTRUCT structure. If an MDI client window calls CreateWindow to create
        /// an MDI child window, lpParam should point to a MDICREATESTRUCT structure. lpParam may be
        /// NULL if no additional data is needed.
        /// </para>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the new window.
        /// <para>
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </para>
        /// <para>This function typically fails for one of the following reasons:</para>
        /// <list type="">
        /// <item>an invalid parameter value</item>
        /// <item>the system class was registered by a different module</item>
        /// <item>The WH_CBT hook is installed and returns a failure code</item>
        /// <item>
        /// if one of the controls in the dialog template is not registered, or its window window
        /// procedure fails WM_CREATE or WM_NCCREATE
        /// </item>
        /// </list>
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern unsafe IntPtr CreateWindowEx(
           WindowStylesEx dwExStyle,
           string lpClassName,
           string lpWindowName,
           WindowStyles dwStyle,
           int x,
           int y,
           int nWidth,
           int nHeight,
           IntPtr hWndParent,
           IntPtr hMenu,
           IntPtr hInstance,
           void* lpParam);

        /// <summary>
        /// Creates an overlapped, pop-up, or child window with an
        /// extended window style; otherwise, this function is identical to the CreateWindow function.
        /// </summary>
        /// <param name="dwExStyle">Specifies the extended window style of the window being created.</param>
        /// <param name="lpClassName">
        /// Pointer to a class atom created by a previous call to the
        /// RegisterClass or RegisterClassEx function. The atom must be in the low-order word of
        /// lpClassName; the high-order word must be zero.
        /// </param>
        /// <param name="lpWindowName">
        /// Pointer to a null-terminated string that specifies the window name. If the window style
        /// specifies a title bar, the window title pointed to by lpWindowName is displayed in the
        /// title bar. When using CreateWindow to create controls, such as buttons, check boxes, and
        /// static controls, use lpWindowName to specify the text of the control. When creating a
        /// static control with the SS_ICON style, use lpWindowName to specify the icon name or
        /// identifier. To specify an identifier, use the syntax "#num".
        /// </param>
        /// <param name="dwStyle">
        /// Specifies the style of the window being created. This parameter can be a combination of
        /// window styles, plus the control styles indicated in the Remarks section.
        /// </param>
        /// <param name="x">
        /// Specifies the initial horizontal position of the window. For an overlapped or pop-up
        /// window, the x parameter is the initial x-coordinate of the window's upper-left corner, in
        /// screen coordinates. For a child window, x is the x-coordinate of the upper-left corner of
        /// the window relative to the upper-left corner of the parent window's client area. If x is
        /// set to CW_USEDEFAULT, the system selects the default position for the window's upper-left
        /// corner and ignores the y parameter. CW_USEDEFAULT is valid only for overlapped windows;
        /// if it is specified for a pop-up or child window, the x and y parameters are set to zero.
        /// </param>
        /// <param name="y">
        /// Specifies the initial vertical position of the window. For an overlapped or pop-up
        /// window, the y parameter is the initial y-coordinate of the window's upper-left corner, in
        /// screen coordinates. For a child window, y is the initial y-coordinate of the upper-left
        /// corner of the child window relative to the upper-left corner of the parent window's
        /// client area. For a list box y is the initial y-coordinate of the upper-left corner of the
        /// list box's client area relative to the upper-left corner of the parent window's client area.
        /// <para>
        /// If an overlapped window is created with the WS_VISIBLE style bit set and the x parameter
        /// is set to CW_USEDEFAULT, then the y parameter determines how the window is shown. If the
        /// y parameter is CW_USEDEFAULT, then the window manager calls ShowWindow with the SW_SHOW
        /// flag after the window has been created. If the y parameter is some other value, then the
        /// window manager calls ShowWindow with that value as the nCmdShow parameter.
        /// </para>
        /// </param>
        /// <param name="nWidth">
        /// Specifies the width, in device units, of the window. For overlapped windows, nWidth is
        /// the window's width, in screen coordinates, or CW_USEDEFAULT. If nWidth is CW_USEDEFAULT,
        /// the system selects a default width and height for the window; the default width extends
        /// from the initial x-coordinates to the right edge of the screen; the default height
        /// extends from the initial y-coordinate to the top of the icon area. CW_USEDEFAULT is valid
        /// only for overlapped windows; if CW_USEDEFAULT is specified for a pop-up or child window,
        /// the nWidth and nHeight parameter are set to zero.
        /// </param>
        /// <param name="nHeight">
        /// Specifies the height, in device units, of the window. For overlapped windows, nHeight is
        /// the window's height, in screen coordinates. If the nWidth parameter is set to
        /// CW_USEDEFAULT, the system ignores nHeight.
        /// </param>
        /// <param name="hWndParent">
        /// Handle to the parent or owner window of the window being created. To create a child
        /// window or an owned window, supply a valid window handle. This parameter is optional for
        /// pop-up windows.
        /// <para>
        /// Windows 2000/XP: To create a message-only window, supply HWND_MESSAGE or a handle to an
        /// existing message-only window.
        /// </para>
        /// </param>
        /// <param name="hMenu">
        /// Handle to a menu, or specifies a child-window identifier, depending on the window style.
        /// For an overlapped or pop-up window, hMenu identifies the menu to be used with the window;
        /// it can be NULL if the class menu is to be used. For a child window, hMenu specifies the
        /// child-window identifier, an integer value used by a dialog box control to notify its
        /// parent about events. The application determines the child-window identifier; it must be
        /// unique for all child windows with the same parent window.
        /// </param>
        /// <param name="hInstance">
        /// Handle to the instance of the module to be associated with the window.
        /// </param>
        /// <param name="lpParam">
        /// Pointer to a value to be passed to the window through the CREATESTRUCT structure
        /// (lpCreateParams member) pointed to by the lParam param of the WM_CREATE message. This
        /// message is sent to the created window by this function before it returns.
        /// <para>
        /// If an application calls CreateWindow to create a MDI client window, lpParam should point
        /// to a CLIENTCREATESTRUCT structure. If an MDI client window calls CreateWindow to create
        /// an MDI child window, lpParam should point to a MDICREATESTRUCT structure. lpParam may be
        /// NULL if no additional data is needed.
        /// </para>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the new window.
        /// <para>
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </para>
        /// <para>This function typically fails for one of the following reasons:</para>
        /// <list type="">
        /// <item>an invalid parameter value</item>
        /// <item>the system class was registered by a different module</item>
        /// <item>The WH_CBT hook is installed and returns a failure code</item>
        /// <item>
        /// if one of the controls in the dialog template is not registered, or its window window
        /// procedure fails WM_CREATE or WM_NCCREATE
        /// </item>
        /// </list>
        /// </returns>
        public static unsafe IntPtr CreateWindowEx(
           WindowStylesEx dwExStyle,
           short lpClassName,
           string lpWindowName,
           WindowStyles dwStyle,
           int x,
           int y,
           int nWidth,
           int nHeight,
           IntPtr hWndParent,
           IntPtr hMenu,
           IntPtr hInstance,
           void* lpParam) => CreateWindowEx(dwExStyle, (IntPtr)lpClassName, lpWindowName, dwStyle, x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam);

        /// <summary>
        /// Destroys the specified window. The function sends WM_DESTROY and WM_NCDESTROY messages to the window to deactivate it and remove the keyboard focus from it. The function also destroys the window's menu, flushes the thread message queue, destroys timers, removes clipboard ownership, and breaks the clipboard viewer chain (if the window is at the top of the viewer chain).
        /// If the specified window is a parent or owner window, DestroyWindow automatically destroys the associated child or owned windows when it destroys the parent or owner window. The function first destroys child or owned windows, and then it destroys the parent or owner window.
        /// DestroyWindow also destroys modeless dialog boxes created by the CreateDialog function.
        /// </summary>
        /// <param name="hWnd">A handle to the window to be destroyed.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DestroyWindow(IntPtr hWnd);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr DispatchMessage(ref MSG lpmsg);

        /// <summary>
        /// The DrawText function draws formatted text in the specified rectangle.
        /// It formats the text according to the specified method (expanding tabs, justifying characters, breaking lines, and so forth).
        /// To specify additional formatting options, use the <see cref="DrawTextEx(SafeDCHandle, char*, int, RECT*, uint, DRAWTEXTPARAMS*)"/> function.
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <param name="lpchText">
        /// A pointer to the string that specifies the text to be drawn.
        /// If the <paramref name="cchText"/> parameter is -1, the string must be null-terminated.
        /// If <paramref name="format"/> includes <see cref="TextFormats.DT_MODIFYSTRING"/>, the function could add up to four additional characters to this string.
        /// The buffer containing the string should be large enough to accommodate these extra characters.
        /// </param>
        /// <param name="cchText">The length, in characters, of the string. If <paramref name="cchText"/> is -1, then the <paramref name="lpchText"/> parameter is assumed to be a pointer to a null-terminated string and DrawText computes the character count automatically.</param>
        /// <param name="lprc">A pointer to a RECT structure that contains the rectangle (in logical coordinates) in which the text is to be formatted.</param>
        /// <param name="format">The method of formatting the text.</param>
        /// <returns>
        /// If the function succeeds, the return value is the height of the text in logical units.
        /// If <see cref="TextFormats.DT_VCENTER"/> or <see cref="TextFormats.DT_BOTTOM"/> is specified, the return value is the offset from <see cref="RECT.top"/> (<paramref name="lprc"/>) to the bottom of the drawn text.
        /// If the function fails, the return value is zero.</returns>
        /// <remarks>
        /// <para>
        /// The DrawText function uses the device context's selected font, text color, and background color to draw the text.
        /// Unless the <see cref="TextFormats.DT_NOCLIP"/> format is used, DrawText clips the text so that it does not appear outside the specified rectangle.
        /// Note that text with significant overhang may be clipped, for example, an initial "W" in the text string or text that is in italics.
        /// All formatting is assumed to have multiple lines unless the <see cref="TextFormats.DT_SINGLELINE"/> format is specified.
        /// </para>
        /// <para>
        /// If the selected font is too large for the specified rectangle, the DrawText function does not attempt to substitute a smaller font.
        /// The text alignment mode for the device context must include the TA_LEFT, TA_TOP, and TA_NOUPDATECP flags.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern unsafe int DrawText(
            SafeDCHandle hdc,
            [Friendly(FriendlyFlags.Array | FriendlyFlags.Bidirectional, ArrayLengthParameter = 2)] char* lpchText,
            int cchText,
            [Friendly(FriendlyFlags.Bidirectional)] RECT* lprc,
            TextFormats format);

        /// <summary>
        /// The DrawTextEx function draws formatted text in the specified rectangle.
        /// </summary>
        /// <param name="hdc">A handle to the device context in which to draw.</param>
        /// <param name="lpchText">
        /// A pointer to the string that contains the text to draw. If the <paramref name="cchText"/> parameter is -1, the string must be null-terminated.
        /// If <paramref name="dwDTFormat"/> includes <see cref="TextFormats.DT_MODIFYSTRING"/>, the function could add up to four additional characters to this string.
        /// The buffer containing the string should be large enough to accommodate these extra characters.
        /// </param>
        /// <param name="cchText">
        /// The length of the string pointed to by <paramref name="lpchText"/>.
        /// If <paramref name="cchText"/> is -1, then the lpchText parameter is assumed to be a pointer to a null-terminated string and DrawTextEx computes the character count automatically.
        /// </param>
        /// <param name="lprc">A pointer to a <see cref="RECT"/> structure that contains the rectangle, in logical coordinates, in which the text is to be formatted.</param>
        /// <param name="dwDTFormat">The formatting options.</param>
        /// <param name="lpDTParams">A pointer to a <see cref="DRAWTEXTPARAMS"/> structure that specifies additional formatting options. This parameter can be NULL.</param>
        /// <returns>
        /// If the function succeeds, the return value is the text height in logical units.
        /// If <see cref="TextFormats.DT_VCENTER"/> or <see cref="TextFormats.DT_BOTTOM"/> is specified, the return value is the offset from  <see cref="RECT.top"/> (<paramref name="lprc"/>) to the bottom of the drawn text
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern unsafe int DrawTextEx(
            SafeDCHandle hdc,
            [Friendly(FriendlyFlags.Array | FriendlyFlags.Bidirectional, ArrayLengthParameter = 2)] char* lpchText,
            int cchText,
            [Friendly(FriendlyFlags.Bidirectional)] RECT* lprc,
            uint dwDTFormat,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] DRAWTEXTPARAMS* lpDTParams);

        /// <summary>
        /// The EndPaint function marks the end of painting in the specified window. This function is required for each call to the <see cref="BeginPaint(IntPtr, PAINTSTRUCT*)"/> function, but only after painting is complete.
        /// </summary>
        /// <param name="hWnd">Handle to the window that has been repainted.</param>
        /// <param name="lpPaint">Pointer to a <see cref="PAINTSTRUCT"/> structure that contains the painting information retrieved by <see cref="BeginPaint(IntPtr, PAINTSTRUCT*)"/>.</param>
        /// <returns>The return value is always nonzero.</returns>
        /// <remarks>
        /// If the caret was hidden by <see cref="BeginPaint(IntPtr, PAINTSTRUCT*)"/>, EndPaint restores the caret to the screen.
        /// EndPaint releases the display device context that <see cref="BeginPaint(IntPtr, PAINTSTRUCT*)"/> retrieved.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool EndPaint(
            IntPtr hWnd,
            [Friendly(FriendlyFlags.In)] PAINTSTRUCT* lpPaint);

        /// <summary>
        /// Sets the show state and the restored, minimized, and maximized positions of the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="lpwndpl">A pointer to a WINDOWPLACEMENT structure that specifies the new show state and window positions.
        /// Before calling SetWindowPlacement, set the <see cref="WINDOWPLACEMENT.length"/> member of the <see cref="WINDOWPLACEMENT"/> structure to sizeof(WINDOWPLACEMENT).
        /// SetWindowPlacement fails if the length member is not set correctly.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool SetWindowPlacement(
            IntPtr hWnd,
            [Friendly(FriendlyFlags.In)] WINDOWPLACEMENT* lpwndpl);

        /// <summary>
        ///     Synthesizes a keystroke. The system can use such a synthesized keystroke to generate a WM_KEYUP or WM_KEYDOWN message. The keyboard driver's interrupt handler calls the keybd_event function.
        /// </summary>
        /// <param name="bVk">
        ///     A virtual-key code from <see cref="VirtualKey" />. The code must be a value in the range 1 to 254.
        /// </param>
        /// <param name="bScan">
        ///     A hardware scan code for the key from <see cref="ScanCode" />.
        /// </param>
        /// <param name="dwFlags">
        ///     Controls various aspects of function operation. This parameter can be one or more of the following values.
        /// </param>
        /// <param name="dwExtraInfo">
        ///     An additional value associated with the key stroke.
        /// </param>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern unsafe void keybd_event(byte bVk, byte bScan, KEYEVENTF dwFlags, void* dwExtraInfo);

        /// <summary>
        /// Sets the last-error code for the calling thread.
        /// Currently, this function is identical to the SetLastError function. The second parameter is ignored.
        /// </summary>
        /// <param name="dwErrCode">The last-error code for the thread.</param>
        /// <param name="dwType">This parameter is ignored.</param>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern void SetLastErrorEx(uint dwErrCode, uint dwType);

        /// <summary>
        /// The <see cref="mouse_event(mouse_eventFlags, int, int, int, void*)"/> function synthesizes mouse motion and button clicks.
        /// </summary>
        /// <param name="dwFlags">Controls various aspects of mouse motion and button clicking.</param>
        /// <param name="dx">The mouse's absolute position along the x-axis or its amount of motion since the last mouse event was generated, depending on the setting of <see cref="mouse_eventFlags.MOUSEEVENTF_ABSOLUTE" />. Absolute data is specified as the mouse's actual x-coordinate; relative data is specified as the number of mickeys moved. A mickey is the amount that a mouse has to move for it to report that it has moved.</param>
        /// <param name="dy">The mouse's absolute position along the y-axis or its amount of motion since the last mouse event was generated, depending on the setting of <see cref="mouse_eventFlags.MOUSEEVENTF_ABSOLUTE" />. Absolute data is specified as the mouse's actual y-coordinate; relative data is specified as the number of mickeys moved.</param>
        /// <param name="dwData">
        /// If <paramref name="dwFlags"/> contains <see cref="mouse_eventFlags.MOUSEEVENTF_WHEEL"/>, then dwData specifies the amount of wheel movement. A positive value indicates that the wheel was rotated forward, away from the user; a negative value indicates that the wheel was rotated backward, toward the user. One wheel click is defined as WHEEL_DELTA, which is 120.
        /// If <paramref name="dwFlags"/> contains <see cref="mouse_eventFlags.MOUSEEVENTF_HWHEEL" />, then dwData specifies the amount of wheel movement. A positive value indicates that the wheel was tilted to the right; a negative value indicates that the wheel was tilted to the left.
        /// If <paramref name="dwFlags"/> contains <see cref="mouse_eventFlags.MOUSEEVENTF_XDOWN" /> or <see cref="mouse_eventFlags.MOUSEEVENTF_XUP" />, then <paramref name="dwData"/> specifies which X buttons were pressed or released. This value may be any combination of the following flags.
        /// If <paramref name="dwFlags"/> is not <see cref="mouse_eventFlags.MOUSEEVENTF_WHEEL" />, <see cref="mouse_eventFlags.MOUSEEVENTF_XDOWN" />, or <see cref="mouse_eventFlags.MOUSEEVENTF_XUP" />, then <paramref name="dwData"/> should be zero.
        /// </param>
        /// <param name="dwExtraInfo">An additional value associated with the mouse event. An application calls GetMessageExtraInfo to obtain this extra information.</param>
        [DllImport(nameof(User32))]
        public static extern unsafe void mouse_event(mouse_eventFlags dwFlags, int dx, int dy, int dwData, void* dwExtraInfo);

        /// <summary>
        /// Calculates the required size of the window rectangle, based on the desired size of the client rectangle and the provided DPI. This window rectangle can then be passed to the CreateWindowEx function to create a window with a client area of the desired size.
        /// </summary>
        /// <param name="lpRect">A pointer to a <see cref="RECT"/> structure that contains the coordinates of the top-left and bottom-right corners of the desired client area. When the function returns, the structure contains the coordinates of the top-left and bottom-right corners of the window to accommodate the desired client area.</param>
        /// <param name="dwStyle">The Window Style of the window whose required size is to be calculated. Note that you cannot specify the <see cref="WindowStyles.WS_OVERLAPPED"/> style.</param>
        /// <param name="bMenu">Indicates whether the window has a menu.</param>
        /// <param name="dwExStyle">The Extended Window Style of the window whose required size is to be calculated.</param>
        /// <param name="dpi">The DPI to use for scaling.</param>
        /// <returns>
        /// If the function succeeds, the return value is true.
        /// If the function fails, the return value is false. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool AdjustWindowRectExForDpi(
            RECT* lpRect,
            WindowStyles dwStyle,
            [MarshalAs(UnmanagedType.Bool)] bool bMenu,
            WindowStylesEx dwExStyle,
            int dpi);

        /// <summary>
        /// Determines whether two DPI_AWARENESS_CONTEXT values are identical.
        /// </summary>
        /// <param name="dpiContextA">The first value to compare.</param>
        /// <param name="dpiContextB">The second value to compare.</param>
        /// <returns>Returns true if the values are equal, otherwise false.</returns>
        /// <remarks>
        /// A DPI_AWARENESS_CONTEXT contains multiple pieces of information. For example, it includes both the current and the inherited <see cref="DPI_AWARENESS"/> values.
        /// AreDpiAwarenessContextsEqual ignores informational flags and determines if the values are equal. You can't use a direct bitwise comparison because of these informational flags.
        /// </remarks>
        [DllImport(nameof(User32))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AreDpiAwarenessContextsEqual(
            IntPtr dpiContextA,
            IntPtr dpiContextB);

        /// <summary>
        /// In high-DPI displays, enables automatic display scaling of the non-client area portions of the specified top-level window. Must be called during the initialization of that window.
        /// </summary>
        /// <param name="hwnd">The window that should have automatic scaling enabled.</param>
        /// <returns>
        /// If the function succeeds, the return value is true.
        /// If the function fails, the return value is false. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableNonClientDpiScaling(
            IntPtr hwnd);

        /// <summary>
        /// Retrieves the <see cref="DPI_AWARENESS"/> value from a DPI_AWARENESS_CONTEXT.
        /// </summary>
        /// <param name="dpiAwarenessContext">The DPI_AWARENESS_CONTEXT you want to examine.</param>
        /// <returns>The <see cref="DPI_AWARENESS"/>. If the provided <paramref name="dpiAwarenessContext"/> is null or invalid, this method will return <see cref="DPI_AWARENESS.DPI_AWARENESS_INVALID"/>.</returns>
        [DllImport(nameof(User32))]
        public static extern DPI_AWARENESS GetAwarenessFromDpiAwarenessContext(
            IntPtr dpiAwarenessContext);

        /// <summary>
        /// Returns the system DPI.
        /// </summary>
        /// <returns>The system DPI value.</returns>
        /// <remarks>
        /// The return value will be dependent based upon the calling context. If the current thread has a <see cref="DPI_AWARENESS"/> value of <see cref="DPI_AWARENESS.DPI_AWARENESS_UNAWARE"/>, the return value will be 96. That is because the current context always assumes a DPI of 96. For any other <see cref="DPI_AWARENESS"/> value, the return value will be the actual system DPI.
        /// You should not cache the system DPI, but should use GetDpiForSystem whenever you need the system DPI value.
        /// </remarks>
        [DllImport(nameof(User32))]
        public static extern int GetDpiForSystem();

        /// <summary>
        /// Returns the dots per inch (dpi) value for the associated window.
        /// </summary>
        /// <param name="hwnd">The window you want to get information about.</param>
        /// <returns>The DPI for the window which depends on the <see cref="DPI_AWARENESS"/> of the window. An invalid <paramref name="hwnd"/> value will result in a return value of 0.</returns>
        /// <remarks>
        /// The following table indicates the return value of GetDpiForWindow based on the <see cref="DPI_AWARENESS"/> of the provided <paramref name="hwnd"/>.
        /// <code>
        /// +---------------------------------+-----------------------------------------------------+
        /// |          DPI_AWARENESS          |                    Return value                     |
        /// +---------------------------------+-----------------------------------------------------+
        /// | DPI_AWARENESS_UNAWARE           | 96                                                  |
        /// | DPI_AWARENESS_SYSTEM_AWARE      | The system DPI.                                     |
        /// | DPI_AWARENESS_PER_MONITOR_AWARE | The DPI of the monitor where the window is located. |
        /// +---------------------------------+-----------------------------------------------------+
        /// </code>
        /// </remarks>
        [DllImport(nameof(User32))]
        public static extern int GetDpiForWindow(
            IntPtr hwnd);

        /// <summary>
        /// Retrieves the specified system metric or system configuration setting taking into account a provided DPI.
        /// </summary>
        /// <param name="nIndex">The system metric or configuration setting to be retrieved. See <see cref="GetSystemMetrics(SystemMetric)"/> for the possible values.</param>
        /// <param name="dpi">The DPI to use for scaling the metric.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>This function returns the same result as <see cref="GetSystemMetrics(SystemMetric)"/> but scales it according to an arbitrary DPI you provide if appropriate.</remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern int GetSystemMetricsForDpi(
            int nIndex,
            int dpi);

        /// <summary>
        /// Gets the DPI_AWARENESS_CONTEXT for the current thread.
        /// </summary>
        /// <returns>The current DPI_AWARENESS_CONTEXT for the thread.</returns>
        /// <remarks>
        /// This method will return the latest DPI_AWARENESS_CONTEXT sent to SetThreadDpiAwarenessContext. If SetThreadDpiAwarenessContext was never called for this thread, then the return value will equal the default DPI_AWARENESS_CONTEXT for the process.
        /// </remarks>
        [DllImport(nameof(User32))]
        public static extern IntPtr GetThreadDpiAwarenessContext();

        /// <summary>
        /// Returns the DPI_AWARENESS_CONTEXT associated with a window.
        /// </summary>
        /// <param name="hwnd">The window to query.</param>
        /// <returns>The DPI_AWARENESS_CONTEXT for the provided window. If the window is not valid, the return value is NULL.</returns>
        /// <remarks>
        /// The return value of GetWindowDpiAwarenessContext is not affected by the <see cref="DPI_AWARENESS"/> of the current thread. It only indicates the context of the window specified by the <paramref name="hwnd"/> input parameter.
        /// </remarks>
        [DllImport(nameof(User32))]
        public static extern IntPtr GetWindowDpiAwarenessContext(
            IntPtr hwnd);

        /// <summary>
        /// Determines if a specified DPI_AWARENESS_CONTEXT is valid and supported by the current system.
        /// </summary>
        /// <param name="dpiAwarenessContext">The context that you want to determine if it is supported.</param>
        /// <returns>true if the provided context is supported, otherwise false.</returns>
        /// <remarks>
        /// IsValidDpiAwarenessContext determines the validity of any provided DPI_AWARENESS_CONTEXT. You should make sure a context is valid before using SetThreadDpiAwarenessContext to that context.
        /// An input value of NULL is considered to be an invalid context and will result in a return value of false.
        /// </remarks>
        [DllImport(nameof(User32))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsValidDpiAwarenessContext(
            IntPtr dpiAwarenessContext);

        /// <summary>
        /// Set the DPI awareness for the current thread to the provided value.
        /// </summary>
        /// <param name="dpiContext">The new DPI_AWARENESS_CONTEXT for the current thread. This context includes the <see cref="DPI_AWARENESS"/> value.</param>
        /// <returns>The old DPI_AWARENESS_CONTEXT for the thread. If the <paramref name="dpiContext"/> is invalid, the thread will not be updated and the return value will be NULL. You can use this value to restore the old DPI_AWARENESS_CONTEXT after overriding it with a predefined value.</returns>
        [DllImport(nameof(User32))]
        public static extern IntPtr SetThreadDpiAwarenessContext(
            IntPtr dpiContext);

        /// <summary>
        /// Retrieves the value of one of the system-wide parameters, taking into account the provided DPI value.
        /// </summary>
        /// <param name="uiAction">The system-wide parameter to be retrieved. This function is only intended for use with <see cref="SystemParametersInfoAction.SPI_GETICONTITLELOGFONT"/>, <see cref="SystemParametersInfoAction.SPI_GETICONMETRICS"/>, or <see cref="SystemParametersInfoAction.SPI_GETNONCLIENTMETRICS"/>. See <see cref="SystemParametersInfoAction"/> for more information on these values.</param>
        /// <param name="uiParam">A parameter whose usage and format depends on the system parameter being queried. For more information about system-wide parameters, see the <paramref name="uiAction"/> parameter. If not otherwise indicated, you must specify zero for this parameter.</param>
        /// <param name="pvParam">A parameter whose usage and format depends on the system parameter being queried. For more information about system-wide parameters, see the <paramref name="uiAction"/> parameter. If not otherwise indicated, you must specify NULL for this parameter.</param>
        /// <param name="fWinIni">Has no effect for with this API. This parameter only has an effect if you're setting parameter.</param>
        /// <param name="dpi">The DPI to use for scaling the metric.</param>
        /// <returns>
        /// If the function succeeds, the return value is true.
        /// If the function fails, the return value is false. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function returns a similar result as SystemParametersInfo, but scales it according to an arbitrary DPI you provide (if appropriate). It only scales with the following possible values for uiAction:
        ///     SPI_GETICONTITLELOGFONT, SPI_GETICONMETRICS, SPI_GETNONCLIENTMETRICS.
        /// Other possible uiAction values do not provide ForDPI behavior, and therefore this function returns 0 if called with them.
        /// For uiAction values that contain strings within their associated structures, only Unicode(LOGFONTW) strings are supported in this function.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool SystemParametersInfoForDpi(
            SystemParametersInfoAction uiAction,
            int uiParam,
            void* pvParam,
            SystemParametersInfoFlags fWinIni,
            int dpi);

        /// <summary>
        /// Sets the current process to a specified dots per inch (dpi) awareness context.
        /// </summary>
        /// <param name="dpiAWarenessContext">The DPI awareness value to set.</param>
        /// <returns>
        /// If the function succeeds, the return value is true.
        /// If the function fails, the return value is false. To get extended error information, call <see cref="GetLastError"/>.
        ///
        /// Possible errors are <see cref="Win32ErrorCode.ERROR_INVALID_PARAMETER"/> for an invalid input, and <see cref="Win32ErrorCode.ERROR_ACCESS_DENIED"/> if the default API awareness mode for the process has already been set (via a previous API call or within the application manifest).
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetProcessDpiAwarenessContext(
            IntPtr dpiAWarenessContext);

        /// <summary>
        /// Dialogs in Per-Monitor v2 contexts are automatically DPI scaled. This method lets you customize their DPI change behavior.
        /// This function works in conjunction with the <see cref="DIALOG_DPI_CHANGE_BEHAVIORS"/> enum in order to override the default DPI scaling behavior for
        /// dialogs.This function is called on a specified dialog, for which the specified flags are individually saved.
        /// This function does not affect the DPI scaling behavior for the child windows of the dialog in question - that is done with SetDialogControlDpiChangeBehavior.
        /// </summary>
        /// <param name="hDlg">A handle for the dialog whose behavior will be modified.</param>
        /// <param name="mask">A mask specifying the subset of flags to be changed.</param>
        /// <param name="values">The desired value to be set for the specified subset of flags.</param>
        /// <returns>
        /// If the function succeeds, the return value is true.
        /// If the function fails, the return value is false. To get extended error information, call <see cref="GetLastError"/>.
        ///
        /// Possible errors are <see cref="Win32ErrorCode.ERROR_INVALID_HANDLE"/> for an invalid dialog HWND, and <see cref="Win32ErrorCode.ERROR_ACCESS_DENIED"/> if if the dialog belongs to another process.
        /// </returns>
        /// <remarks>
        /// For extensibility, <see cref="DIALOG_DPI_CHANGE_BEHAVIORS"/> was modeled as a set of bit-flags representing separate behaviors. This function
        /// follows the typical two-parameter approach to setting flags, where a mask specifies the subset of the flags to be changed.
        /// It is not an error to call this API outside of Per Monitor v2 contexts, though the flags will have no effect on the behavior of the
        /// specified dialog until the context is changed to Per Monitor v2.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetDialogDpiChangeBehavior(
            IntPtr hDlg,
            DIALOG_DPI_CHANGE_BEHAVIORS mask,
            DIALOG_DPI_CHANGE_BEHAVIORS values);

        /// <summary>
        /// Returns the flags that might have been set on a given dialog by an earlier call to SetDialogDpiChangeBehavior.
        /// If that function was never called on the dialog, the return value will be 0.
        /// </summary>
        /// <param name="hDlg">The handle for the dialog to examine.</param>
        /// <returns>The flags set on the given dialog. If passed an invalid handle, this function will return 0, and set its last error to <see cref="Win32ErrorCode.ERROR_INVALID_HANDLE"/>.</returns>
        /// <remarks>
        /// It can be difficult to distinguish between a return value of <see cref="DIALOG_DPI_CHANGE_BEHAVIORS.DDC_DEFAULT"/> and the error case, which is zero. To determine between the two, it is recommended that you call <see cref="GetLastError"/> to check the error.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern DIALOG_DPI_CHANGE_BEHAVIORS GetDialogDpiChangeBehavior(
            IntPtr hDlg);

        /// <summary>
        /// Overrides the default per-monitor DPI scaling behavior of a child window in a dialog.
        /// </summary>
        /// <param name="hwnd">A handle for the window whose behavior will be modified.</param>
        /// <param name="mask">A mask specifying the subset of flags to be changed.</param>
        /// <param name="values">The desired value to be set for the specified subset of flags.</param>
        /// <returns>
        /// If the function succeeds, the return value is true.
        /// If the function fails, the return value is false. To get extended error information, call <see cref="GetLastError"/>.
        ///
        /// Possible errors are <see cref="Win32ErrorCode.ERROR_INVALID_HANDLE"/> if passed an invalid HWND, and <see cref="Win32ErrorCode.ERROR_ACCESS_DENIED"/> if the windows belongs to another process.
        /// </returns>
        /// <remarks>
        /// The behaviors are specified as values from the <see cref="DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS"/> enum. This function follows the typical two-parameter approach
        /// to setting flags, where a mask specifies the subset of the flags to be changed.
        /// It is valid to set these behaviors on any window.It does not matter if the window is currently a child of a dialog at the point in time that SetDialogControlDpiChangeBehavior is
        /// called.The behaviors are retained and will take effect only when the window is an immediate child of a dialog that has per-monitor DPI scaling enabled.
        /// This API influences individual controls within dialogs.The dialog-wide per-monitor DPI scaling behavior is controlled by SetDialogDpiChangeBehavior.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetDialogControlDpiChangeBehavior(
            IntPtr hwnd,
            DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS mask,
            DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS values);

        /// <summary>
        /// Retrieves and per-monitor DPI scaling behavior overrides of a child window in a dialog.
        /// </summary>
        /// <param name="hWnd">The handle for the window to examine.</param>
        /// <returns>The flags set on the given window. If passed an invalid handle, this function will return zero, and set its last error to <see cref="Win32ErrorCode.ERROR_INVALID_HANDLE"/>.</returns>
        /// <remarks>It can be difficult to distinguish between a return value of <see cref="DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS.DCDC_DEFAULT"/> and the error case, which is zero. To determine between the two, it is recommended that you call <see cref="GetLastError"/> to check the error.</remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS GetDialogControlDpiChangeBehavior(
            IntPtr hWnd);

        /// <summary>
        /// Retrieves the system DPI associated with a given process. This is useful for avoiding compatibility issues that arise from sharing DPI-sensitive information between multiple system-aware processes with different system DPI values.
        /// </summary>
        /// <param name="hProcess">The handle for the process to examine. If this value is null, this API behaves identically to <see cref="GetDpiForSystem"/>.</param>
        /// <returns>The process's system DPI value.</returns>
        /// <remarks>
        /// The return value will be dependent based upon the process passed as a parameter. If the specified process has a
        /// <see cref="DPI_AWARENESS"/> value of <see cref="DPI_AWARENESS.DPI_AWARENESS_UNAWARE"/>, the return value will be 96. That is because the current context always assumes a DPI of 96.
        /// For any other <see cref="DPI_AWARENESS"/> value, the return value will be the actual system DPI of the given process.
        /// </remarks>
        [DllImport(nameof(User32))]
        public static extern int GetSystemDpiForProcess(
            SafeObjectHandle hProcess);

        /// <summary>
        /// Retrieves the DPI from a given DPI_AWARENESS_CONTEXT handle. This enables you to determine the DPI of a thread without needed to examine a window created within that thread.
        /// </summary>
        /// <param name="dpiAwarenessContext">The DPI_AWARENESS_CONTEXT handle to examine.</param>
        /// <returns>The DPI value associated with the DPI_AWARENESS_CONTEXT handle.</returns>
        /// <remarks>
        /// DPI_AWARENESS_CONTEXT handles associated with values of <see cref="DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE"/> and
        /// <see cref="DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2"/> will return a value of 0 for their DPI. This is because the DPI of a
        /// per-monitor-aware window can change, and the actual DPI cannot be returned without the window's HWND.
        /// </remarks>
        [DllImport(nameof(User32))]
        public static extern int GetDpiFromDpiAwarenessContext(
            IntPtr dpiAwarenessContext);

        /// <summary>
        /// Sets the thread's <see cref="DPI_HOSTING_BEHAVIOR"/>. This behavior allows windows created in the thread to host child windows with a different DPI_AWARENESS_CONTEXT.
        /// </summary>
        /// <param name="dpiHostingBehavior">The new <see cref="DPI_HOSTING_BEHAVIOR"/> value for the current thread.</param>
        /// <returns>
        /// The previous <see cref="DPI_HOSTING_BEHAVIOR"/> for the thread. If the hosting behavior passed in is invalid, the thread will not be updated and the return value will be
        /// <see cref="DPI_HOSTING_BEHAVIOR.DPI_HOSTING_BEHAVIOR_INVALID"/>. You can use this value to restore the old <see cref="DPI_HOSTING_BEHAVIOR"/> after overriding it with a predefined value.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="DPI_HOSTING_BEHAVIOR"/> enables a mixed content hosting behavior, which allows parent windows created in the thread to host child windows with a different DPI_AWARENESS_CONTEXT value.
        /// This property only effects new windows created within this thread while the mixed hosting behavior is active. A parent window with this hosting behavior is able to host child windows with
        /// different DPI_AWARENESS_CONTEXT values, regardless of whether the child windows have mixed hosting behavior enabled.
        /// </para>
        /// <para>
        /// This hosting behavior does not allow for windows with per-monitor DPI_AWARENESS_CONTEXT values to be hosted until windows with DPI_AWARENESS_CONTEXT values of system or unaware.
        /// </para>
        /// <para>
        /// To avoid unexpected outcomes, a thread's <see cref="DPI_HOSTING_BEHAVIOR"/> should be changed to support mixed hosting behaviors only when creating a new window which needs to support those behaviors.
        /// Once that window is created, the hosting behavior should be switched back to its default value.
        /// </para>
        /// <para>
        /// This API is used to change the thread's <see cref="DPI_HOSTING_BEHAVIOR"/> from its default value. This is only necessary if your app needs to host child windows from plugins and third-party
        /// components that do not support per-monitor-aware context. This is most likely to occur if you are updating complex applications to support per-monitor DPI_AWARENESS_CONTEXT behaviors.
        /// </para>
        /// <para>
        /// Enabling mixed hosting behavior will not automatically adjust the thread's DPI_AWARENESS_CONTEXT to be compatible with legacy content. The thread's awareness context must
        /// still be manually changed before new windows are created to host such content.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32))]
        public static extern DPI_HOSTING_BEHAVIOR SetThreadDpiHostingBehavior(
            DPI_HOSTING_BEHAVIOR dpiHostingBehavior);

        /// <summary>
        /// Retrieves the <see cref="DPI_HOSTING_BEHAVIOR"/> from the current thread.
        /// </summary>
        /// <returns>The <see cref="DPI_HOSTING_BEHAVIOR"/> of the current thread.</returns>
        /// <remarks>
        /// This API returns the hosting behavior set by an earlier call of <see cref="SetThreadDpiHostingBehavior(DPI_HOSTING_BEHAVIOR)"/>,
        /// or <see cref="DPI_HOSTING_BEHAVIOR.DPI_HOSTING_BEHAVIOR_DEFAULT"/> if no earlier call has been made.
        /// </remarks>
        [DllImport(nameof(User32))]
        public static extern DPI_HOSTING_BEHAVIOR GetThreadDpiHostingBehavior();

        /// <summary>
        /// Returns the <see cref="DPI_HOSTING_BEHAVIOR"/> of the specified window.
        /// </summary>
        /// <param name="hwnd">The handle for the window to examine.</param>
        /// <returns>The <see cref="DPI_HOSTING_BEHAVIOR"/> of the specified window.</returns>
        /// <remarks>
        /// This API allows you to examine the hosting behavior of a window after it has been created. A window's hosting behavior
        /// is the hosting behavior of the thread in which the window was created, as set by a call to <see cref="SetThreadDpiHostingBehavior(DPI_HOSTING_BEHAVIOR)"/>.
        /// This is a permanent value and cannot be changed after the window is created, even if the thread's hosting behavior is changed.
        /// </remarks>
        [DllImport(nameof(User32))]
        public static extern DPI_HOSTING_BEHAVIOR GetWindowDpiHostingBehavior(
            IntPtr hwnd);

        /// <summary>
        /// Calculates the required size of the window rectangle, based on the desired size of the client rectangle.
        /// The window rectangle can then be passed to the CreateWindowEx function to create a window whose client area
        /// is the desired size.
        /// </summary>
        /// <param name="lpRect">
        /// A pointer to a RECT structure that contains the coordinates of the top-left and bottom-right corners
        /// of the desired client area. When the function returns, the structure contains the coordinates of the top-left
        /// and bottom-right corners of the window to accommodate the desired client area.
        /// </param>
        /// <param name="dwStyle">
        /// The window style of the window whose required size is to be calculated. Note that you cannot specify
        /// the <see cref="WindowStyles.WS_OVERLAPPED"/> style.</param>
        /// <param name="bMenu">Indicates whether the window has a menu.</param>
        /// <param name="dwExStyle">The extended window style of the window whose required size is to be calculated.</param>
        /// <returns>
        /// If the function succeeds, the return value is true.
        /// If the function fails, the return value is false.
        /// To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// <para>
        /// A client rectangle is the smallest rectangle that completely encloses a client area.
        /// A window rectangle is the smallest rectangle that completely encloses the window, which includes
        /// the client area and the nonclient area.
        /// </para>
        /// <para>
        /// The AdjustWindowRectEx function does not add extra space when a menu bar wraps to two or more rows.
        /// </para>
        /// <para>
        /// The AdjustWindowRectEx function does not take the <see cref="WindowStyles.WS_VSCROLL"/> or
        /// <see cref="WindowStyles.WS_HSCROLL"/> styles into account.
        /// To account for the scroll bars, call the GetSystemMetrics function with <see cref="SystemMetric.SM_CXVSCROLL"/> or
        /// <see cref="SystemMetric.SM_CYHSCROLL"/>.
        /// </para>
        /// <para>
        /// This API is not DPI aware, and should not be used if the calling thread is per-monitor DPI aware.
        /// For the DPI-aware version of this API, see AdjustWindowsRectExForDPI.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool AdjustWindowRectEx(
            RECT* lpRect,
            WindowStyles dwStyle,
            [MarshalAs(UnmanagedType.Bool)] bool bMenu,
            WindowStylesEx dwExStyle);

        /// <summary>
        /// Waits until one or all of the specified objects are in the signaled state,
        /// an I/O completion routine or asynchronous procedure call (APC) is queued to the thread,
        /// or the time-out interval elapses. The array of objects can include input event objects,
        /// which you specify using the <paramref name="dwWakeMask"/> parameter.
        /// </summary>
        /// <param name="nCount">The number of object handles in the array pointed to by pHandles. The maximum number of object handles is MAXIMUM_WAIT_OBJECTS minus one. If this parameter has the value zero, then the function waits only for an input event.</param>
        /// <param name="pHandles">
        /// An array of object handles. For a list of the object types whose handles you can specify, see the Remarks section later in this topic. The array can contain handles to multiple types of objects. It may not contain multiple copies of the same handle.
        /// If one of these handles is closed while the wait is still pending, the function's behavior is undefined.
        /// The handles must have the SYNCHRONIZE access right. For more information, see Standard Access Rights.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds. If a nonzero value is specified, the function waits until the specified objects are signaled,
        /// an I/O completion routine or APC is queued, or the interval elapses.
        /// If dwMilliseconds is zero, the function does not enter a wait state if the criteria is not met; it always returns immediately.
        /// If dwMilliseconds is <see cref="Timeout.Infinite"/>, the function will return only when the specified objects are signaled or
        /// an I/O completion routine or APC is queued.
        /// </param>
        /// <param name="dwWakeMask">The input types for which an input event object handle will be added to the array of object handles.</param>
        /// <param name="dwFlags">The wait type.</param>
        /// <returns>If the function succeeds, the return value indicates the event that caused the function to return. See docs for values.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static unsafe extern uint MsgWaitForMultipleObjectsEx(
            uint nCount,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Array)] IntPtr* pHandles,
            uint dwMilliseconds,
            WakeMask dwWakeMask,
            MsgWaitForMultipleObjectsExFlags dwFlags);

        /// <summary>Modifies the User Interface Privilege Isolation (UIPI) message filter for a specified window.</summary>
        /// <param name = "hwnd">
        /// <para>Type: <b>HWND</b></para>
        /// <para>A handle to the window whose UIPI message filter is to be modified.</para>
        /// <para><see href = "https://docs.microsoft.com/en-us/windows/win32/api//winuser/nf-winuser-changewindowmessagefilterex#parameters">Read more on docs.microsoft.com</see>.</para>
        /// </param>
        /// <param name = "message">
        /// <para>Type: <b>UINT</b></para>
        /// <para>The message that the message filter allows through or blocks.</para>
        /// <para><see href = "https://docs.microsoft.com/en-us/windows/win32/api//winuser/nf-winuser-changewindowmessagefilterex#parameters">Read more on docs.microsoft.com</see>.</para>
        /// </param>
        /// <param name = "action">
        /// <para>Type: <b>DWORD</b>The action to be performed, and can take one of the following values:</para>
        /// <para>This doc was truncated.</para>
        /// <para><see href = "https://docs.microsoft.com/en-us/windows/win32/api//winuser/nf-winuser-changewindowmessagefilterex#parameters">Read more on docs.microsoft.com</see>.</para>
        /// </param>
        /// <param name = "pChangeFilterStruct">
        /// <para>Type: <b>PCHANGEFILTERSTRUCT</b></para>
        /// <para>Optional pointer to a <a href = "https://docs.microsoft.com/windows/desktop/api/winuser/ns-winuser-changefilterstruct">CHANGEFILTERSTRUCT</a> structure.</para>
        /// <para><see href = "https://docs.microsoft.com/en-us/windows/win32/api//winuser/nf-winuser-changewindowmessagefilterex#parameters">Read more on docs.microsoft.com</see>.</para>
        /// </param>
        /// <returns>
        /// <para>Type: <b>BOOL</b></para>
        /// <para>If the function succeeds, it returns <b>TRUE</b>; otherwise, it returns <b>FALSE</b>. To get extended error information, call <a href = "https://docs.microsoft.com/windows/desktop/api/errhandlingapi/nf-errhandlingapi-getlasterror">GetLastError</a>.</para>
        /// </returns>
        /// <remarks>
        /// <para><see href = "https://docs.microsoft.com/en-us/windows/win32/api//winuser/nf-winuser-changewindowmessagefilterex">Learn more about this API from docs.microsoft.com</see>.</para>
        /// </remarks>
        [DllImport("User32", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool ChangeWindowMessageFilterEx(IntPtr hwnd, uint message, uint action, [Friendly(FriendlyFlags.Bidirectional | FriendlyFlags.Optional)] CHANGEFILTERSTRUCT* pChangeFilterStruct);

        /// <summary>Retrieves a handle to the specified window's parent or owner.</summary>
        /// <param name = "hWnd">
        /// <para>Type: <b>HWND</b></para>
        /// <para>A handle to the window whose parent window handle is to be retrieved.</para>
        /// <para><see href = "https://docs.microsoft.com/en-us/windows/win32/api//winuser/nf-winuser-getparent#parameters">Read more on docs.microsoft.com</see>.</para>
        /// </param>
        /// <returns>
        /// <para>Type: <b>HWND</b>If the window is a child window, the return value is a handle to the parent window. If the window is a top-level window with the <b>WS_POPUP</b> style, the return value is a handle to the owner window.If the function fails, the return value is <b>NULL</b>. To get extended error information, call <a href = "https://docs.microsoft.com/windows/desktop/api/errhandlingapi/nf-errhandlingapi-getlasterror">GetLastError</a>.This function typically fails for one of the following reasons:</para>
        /// <para></para>
        /// <para>This doc was truncated.</para>
        /// </returns>
        /// <remarks>
        /// <para><see href = "https://docs.microsoft.com/en-us/windows/win32/api//winuser/nf-winuser-getparent">Learn more about this API from docs.microsoft.com</see>.</para>
        /// </remarks>
        [DllImport("User32", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        /// <summary>Enumerates the child windows that belong to the specified parent window by passing the handle to each child window, in turn, to an application-defined callback function.</summary>
        /// <param name = "hWndParent">
        /// <para>Type: <b>HWND</b></para>
        /// <para>A handle to the parent window whose child windows are to be enumerated. If this parameter is <b>NULL</b>, this function is equivalent to <a href = "https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-enumwindows">EnumWindows</a>.</para>
        /// <para><see href = "https://docs.microsoft.com/en-us/windows/win32/api//winuser/nf-winuser-enumchildwindows#parameters">Read more on docs.microsoft.com</see>.</para>
        /// </param>
        /// <param name = "lpEnumFunc">
        /// <para>Type: <b>WNDENUMPROC</b></para>
        /// <para>A pointer to an application-defined callback function. For more information, see <a href = "https://docs.microsoft.com/previous-versions/windows/desktop/legacy/ms633493(v=vs.85)">EnumChildProc</a>.</para>
        /// <para><see href = "https://docs.microsoft.com/en-us/windows/win32/api//winuser/nf-winuser-enumchildwindows#parameters">Read more on docs.microsoft.com</see>.</para>
        /// </param>
        /// <param name = "lParam">
        /// <para>Type: <b>LPARAM</b></para>
        /// <para>An application-defined value to be passed to the callback function.</para>
        /// <para><see href = "https://docs.microsoft.com/en-us/windows/win32/api//winuser/nf-winuser-enumchildwindows#parameters">Read more on docs.microsoft.com</see>.</para>
        /// </param>
        /// <returns>
        /// <para>Type: <b>BOOL</b></para>
        /// <para>The return value is not used.</para>
        /// </returns>
        /// <remarks>
        /// <para><see href = "https://docs.microsoft.com/en-us/windows/win32/api//winuser/nf-winuser-enumchildwindows">Learn more about this API from docs.microsoft.com</see>.</para>
        /// </remarks>
        [DllImport("User32", ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr hWndParent, IntPtr lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// Retrieves the time of the last input event.
        /// </summary>
        /// <param name="plii">A pointer to a <see cref="LASTINPUTINFO"/> structure that receives the time of the last input event.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// This function is useful for input idle detection. However, GetLastInputInfo does not provide system-wide
        /// user input information across all running sessions. Rather, GetLastInputInfo provides session-specific user input
        /// information for only the session that invoked the function.
        /// The tick count when the last input event was received (see <see cref="LASTINPUTINFO"/>) is not guaranteed to be incremental.
        /// In some cases, the value might be less than the tick count of a prior event. For example, this can be caused by
        /// a timing gap between the raw input thread and the desktop thread or an event raised by SendInput, which supplies its own tick count.
        /// </remarks>
        [DllImport(nameof(User32))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool GetLastInputInfo(
            [Friendly(FriendlyFlags.Out)] LASTINPUTINFO* plii);

        /// <summary>
        /// Retrieves a data handle from the property list of the specified window. The character string identifies the handle to be retrieved. The string and handle must have been added to the property list by a previous call to the <see cref="SetProp(IntPtr, string, IntPtr)" /> function.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose property list is to be searched.</param>
        /// <param name="lpString">An atom that identifies a string. If this parameter is an atom, it must have been created by using the GlobalAddAtom function. The atom, a 16-bit value, must be placed in the low-order word of the <paramref name="lpString"/> parameter; the high-order word must be zero.</param>
        /// <returns>If the property list contains the string, the return value is the associated data handle. Otherwise, the return value is NULL.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr GetProp(IntPtr hWnd, string lpString);

        /// <summary>
        /// Retrieves a data handle from the property list of the specified window. The character string identifies the handle to be retrieved. The string and handle must have been added to the property list by a previous call to the <see cref="SetProp(IntPtr, string, IntPtr)" /> function.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose property list is to be searched.</param>
        /// <param name="atom">An atom that identifies a string. If this parameter is an atom, it must have been created by using the GlobalAddAtom function.</param>
        /// <returns>If the property list contains the string, the return value is the associated data handle. Otherwise, the return value is NULL.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr GetProp(IntPtr hWnd, int atom);

        /// <summary>
        /// Adds a new entry or changes an existing entry in the property list of the specified window. The function adds a new entry to the list if the specified character string does not exist already in the list. The new entry contains the string and the handle. Otherwise, the function replaces the string's current handle with the specified handle.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose property list receives the new entry.</param>
        /// <param name="lpString">A null-terminated string or an atom that identifies a string. If this parameter is an atom, it must be a global atom created by a previous call to the GlobalAddAtom function. The atom must be placed in the low-order word of <paramref name="lpString" />; the high-order word must be zero.</param>
        /// <param name="hData">A handle to the data to be copied to the property list. The data handle can identify any value useful to the application.</param>
        /// <returns>
        /// If the data handle and string are added to the property list, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError" />.
        /// </returns>
        /// <remarks>
        /// Before a window is destroyed (that is, before it returns from processing the <see cref="WindowMessage.WM_NCDESTROY" /> message), an application must remove all entries it has added to the property list. The application must use the RemoveProp function to remove the entries.
        /// SetProp is subject to the restrictions of User Interface Privilege Isolation (UIPI). A process can only call this function on a window belonging to a process of lesser or equal integrity level. When UIPI blocks property changes, <see cref="GetLastError" /> will return 5.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetProp(IntPtr hWnd, string lpString, IntPtr hData);

        /// <summary>
        /// Adds a new entry or changes an existing entry in the property list of the specified window. The function adds a new entry to the list if the specified character string does not exist already in the list. The new entry contains the string and the handle. Otherwise, the function replaces the string's current handle with the specified handle.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose property list receives the new entry.</param>
        /// <param name="atom">An atom that identifies a string. It must be a global atom created by a previous call to the GlobalAddAtom function.</param>
        /// <param name="hData">A handle to the data to be copied to the property list. The data handle can identify any value useful to the application.</param>
        /// <returns>
        /// If the data handle and string are added to the property list, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError" />.
        /// </returns>
        /// <remarks>
        /// Before a window is destroyed (that is, before it returns from processing the <see cref="WindowMessage.WM_NCDESTROY" /> message), an application must remove all entries it has added to the property list. The application must use the RemoveProp function to remove the entries.
        /// SetProp is subject to the restrictions of User Interface Privilege Isolation (UIPI). A process can only call this function on a window belonging to a process of lesser or equal integrity level. When UIPI blocks property changes, <see cref="GetLastError" /> will return 5.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetProp(IntPtr hWnd, int atom, IntPtr hData);

        /// <summary>
        /// Removes an entry from the property list of the specified window. The specified character string identifies the entry to be removed.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose property list is to be changed.</param>
        /// <param name="lpString">A null-terminated character string or an atom that identifies a string. If this parameter is an atom, it must have been created using the GlobalAddAtom function. The atom, a 16-bit value, must be placed in the low-order word of <paramref name="lpString" />; the high-order word must be zero.</param>
        /// <returns>The return value identifies the specified data. If the data cannot be found in the specified property list, the return value is NULL.</returns>
        /// <remarks>
        /// The return value is the hData value that was passed to <see cref="SetProp(IntPtr, string, IntPtr)" />; it is an application-defined value. Note, this function only destroys the association between the data and the window. If appropriate, the application must free the data handles associated with entries removed from a property list. The application can remove only those properties it has added. It must not remove properties added by other applications or by the system itself.
        /// The RemoveProp function returns the data handle associated with the string so that the application can free the data associated with the handle.
        /// Starting with Windows Vista, RemoveProp is subject to the restrictions of User Interface Privilege Isolation (UIPI). A process can only call this function on a window belonging to a process of lesser or equal integrity level. When UIPI blocks property changes, <see cref="GetLastError" /> will return 5.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr RemoveProp(IntPtr hWnd, string lpString);

        /// <summary>
        /// Removes an entry from the property list of the specified window. The specified character string identifies the entry to be removed.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose property list is to be changed.</param>
        /// <param name="atom">An atom that identifies a string. If this parameter is an atom, it must have been created using the GlobalAddAtom function.</param>
        /// <returns>The return value identifies the specified data. If the data cannot be found in the specified property list, the return value is NULL.</returns>
        /// <remarks>
        /// The return value is the hData value that was passed to <see cref="SetProp(IntPtr, string, IntPtr)" />; it is an application-defined value. Note, this function only destroys the association between the data and the window. If appropriate, the application must free the data handles associated with entries removed from a property list. The application can remove only those properties it has added. It must not remove properties added by other applications or by the system itself.
        /// The RemoveProp function returns the data handle associated with the string so that the application can free the data associated with the handle.
        /// Starting with Windows Vista, RemoveProp is subject to the restrictions of User Interface Privilege Isolation (UIPI). A process can only call this function on a window belonging to a process of lesser or equal integrity level. When UIPI blocks property changes, <see cref="GetLastError" /> will return 5.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr RemoveProp(IntPtr hWnd, int atom);

        /// <summary>
        /// The BeginPaint function prepares the specified window for painting and fills a <see cref="PAINTSTRUCT"/> structure with information about the painting.
        /// </summary>
        /// <param name="hwnd">Handle to the window to be repainted.</param>
        /// <param name="lpPaint">Pointer to the <see cref="PAINTSTRUCT"/> structure that will receive painting information.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to a display device context for the specified window.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>, indicating that no display device context is available..</returns>
        /// <remarks>
        /// <para>
        /// The BeginPaint function automatically sets the clipping region of the device context to exclude any area outside the update region.
        /// The update region is set by the InvalidateRect or InvalidateRgn function and by the system after sizing, moving, creating, scrolling,
        /// or any other operation that affects the client area. If the update region is marked for erasing, BeginPaint sends a <see cref="WindowMessage.WM_ERASEBKGND"/> message to the window.
        /// </para>
        /// <para>
        /// An application should not call BeginPaint except in response to a <see cref="WindowMessage.WM_PAINT"/> message.
        /// Each call to BeginPaint must have a corresponding call to the <see cref="EndPaint(IntPtr, PAINTSTRUCT*)"/> function.
        /// </para>
        /// <para>
        /// If the caret is in the area to be painted, BeginPaint automatically hides the caret to prevent it from being erased.
        /// If the window's class has a background brush, BeginPaint uses that brush to erase the background of the update region before returning.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), EntryPoint = "BeginPaint", SetLastError = true)]
        private static extern unsafe IntPtr BeginPaint_IntPtr(
            IntPtr hwnd,
            [Friendly(FriendlyFlags.Out)] PAINTSTRUCT* lpPaint);

        /// <summary>
        /// The <see cref="GetDC"/> function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen.
        /// You can use the returned handle in subsequent GDI functions to draw in the DC. The device context is an opaque data structure, whose values are used internally by GDI.
        /// The GetDCEx function is an extension to <see cref="GetDC"/>, which gives an application more control over how and whether clipping occurs in the client area.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose DC is to be retrieved. If this value is NULL, <see cref="GetDC"/> retrieves the DC for the entire screen.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the DC for the specified window's client area.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// </returns>
        [DllImport(nameof(User32), EntryPoint = "GetDC", SetLastError = false)]
        private static extern IntPtr GetDC_IntPtr(IntPtr hWnd);

        /// <summary>
        /// The GetDCEx function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen.
        /// You can use the returned handle in subsequent GDI functions to draw in the DC. The device context is an opaque data structure, whose values are used internally by GDI.
        /// This function is an extension to the <see cref="GetDC"/> function, which gives an application more control over how and whether clipping occurs in the client area.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose DC is to be retrieved. If this value is <see cref="IntPtr.Zero"/>, GetDCEx retrieves the DC for the entire screen.</param>
        /// <param name="hrgnClip">
        /// A clipping region that may be combined with the visible region of the DC.
        /// If the value of flags is <see cref="DeviceContextValues.DCX_INTERSECTRGN"/> or <see cref="DeviceContextValues.DCX_EXCLUDERGN"/>,
        /// then the operating system assumes ownership of the region and will automatically delete it when it is no longer needed.
        /// In this case, the application should not use or delete the region after a successful call to GetDCEx.</param>
        /// <param name="flags">Specifies how the DC is created.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the DC for the specified window. If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// An invalid value for the hWnd parameter will cause the function to fail.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Unless the display DC belongs to a window class, the <see cref="ReleaseDC"/> function must be called to release the DC after painting.
        /// Also, <see cref="ReleaseDC"/> must be called from the same thread that called GetDCEx. The number of DCs is limited only by available memory.
        /// </para>
        /// <para>
        /// The function returns a handle to a DC that belongs to the window's class if CS_CLASSDC, CS_OWNDC or CS_PARENTDC was specified as a style in the WNDCLASS structure when the class was registered.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), EntryPoint = "GetDCEx", SetLastError = false)]
        private static extern IntPtr GetDCEx_IntPtr(IntPtr hWnd, IntPtr hrgnClip, DeviceContextValues flags);

        /// <summary>
        /// The GetWindowDC function retrieves the device context (DC) for the entire window, including title bar, menus, and scroll bars.
        /// A window device context permits painting anywhere in a window, because the origin of the device context is the upper-left corner of the window instead of the client area.
        /// GetWindowDC assigns default attributes to the window device context each time it retrieves the device context. Previous attributes are lost.
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window with a device context that is to be retrieved. If this value is <see cref="IntPtr.Zero"/>, GetWindowDC retrieves the device context for the entire screen.
        /// If this parameter is <see cref="IntPtr.Zero"/>, GetWindowDC retrieves the device context for the primary display monitor.
        /// To get the device context for other display monitors, use the <see cref="EnumDisplayMonitors(IntPtr, RECT*, MONITORENUMPROC, void*)"/> and CreateDC functions.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to a device context for the specified window.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>, indicating an error or an invalid hWnd parameter.
        /// </returns>
        /// <remarks>
        /// <para>
        /// GetWindowDC is intended for special painting effects within a window's nonclient area. Painting in nonclient areas of any window is not recommended.
        /// </para>
        /// <para>
        /// The <see cref="GetSystemMetrics"/> function can be used to retrieve the dimensions of various parts of the nonclient area, such as the title bar, menu, and scroll bars.
        /// The <see cref="GetDC"/> function can be used to retrieve a device context for the entire screen.
        /// After painting is complete, the <see cref="ReleaseDC"/> function must be called to release the device context.
        /// Not releasing the window device context has serious effects on painting requested by applications.
        /// </para>
        /// </remarks>
        [DllImport(nameof(User32), EntryPoint = "GetWindowDC", SetLastError = true)]
        private static extern IntPtr GetWindowDC_IntPtr(IntPtr hWnd);

        /// <summary>
        ///     Removes a hook procedure installed in a hook chain by the
        ///     <see cref="SetWindowsHookEx(WindowsHookType,IntPtr,IntPtr,int)" /> function.
        /// </summary>
        /// <param name="hhk">
        ///     A handle to the hook to be removed. This parameter is a hook handle obtained by a previous call to
        ///     <see cref="SetWindowsHookEx(WindowsHookType,IntPtr,IntPtr,int)" />.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is true.
        ///     <para>If the function fails, the return value is false. To get extended error information, call GetLastError.</para>
        /// </returns>
#if NETFRAMEWORK || NETSTANDARD2_0_ORLATER
        [SuppressUnmanagedCodeSecurity]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        /// <summary>
        ///     Removes a hook procedure installed in a hook chain by the
        ///     <see cref="SetWinEventHook(WindowsEventHookType, WindowsEventHookType, IntPtr, IntPtr, int, int, WindowsEventHookFlags)" /> function.
        /// </summary>
        /// <param name="hWinEventHook">
        ///     A handle to the hook to be removed. This parameter is a hook handle obtained by a previous call to
        ///     <see cref="SetWinEventHook(WindowsEventHookType, WindowsEventHookType, IntPtr, IntPtr, int, int, WindowsEventHookFlags)" />.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is true.
        ///     <para>If the function fails, the return value is false. To get extended error information, call GetLastError.</para>
        /// </returns>
#if NETFRAMEWORK || NETSTANDARD2_0_ORLATER
        [SuppressUnmanagedCodeSecurity]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        /// <summary>
        /// Destroys a cursor and frees any memory the cursor occupied. Do not use this function to destroy a shared cursor.
        /// </summary>
        /// <param name="hCursor">A handle to the cursor to be destroyed. The cursor must not be in use.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError" />.</returns>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DestroyCursor(IntPtr hCursor);

        /// <summary>
        /// Creates an overlapped, pop-up, or child window with an
        /// extended window style; otherwise, this function is identical to the CreateWindow function.
        /// </summary>
        /// <param name="dwExStyle">Specifies the extended window style of the window being created.</param>
        /// <param name="lpClassName">
        /// Pointer to a class atom created by a previous call to the
        /// RegisterClass or RegisterClassEx function. The atom must be in the low-order word of
        /// lpClassName; the high-order word must be zero.
        /// </param>
        /// <param name="lpWindowName">
        /// Pointer to a null-terminated string that specifies the window name. If the window style
        /// specifies a title bar, the window title pointed to by lpWindowName is displayed in the
        /// title bar. When using CreateWindow to create controls, such as buttons, check boxes, and
        /// static controls, use lpWindowName to specify the text of the control. When creating a
        /// static control with the SS_ICON style, use lpWindowName to specify the icon name or
        /// identifier. To specify an identifier, use the syntax "#num".
        /// </param>
        /// <param name="dwStyle">
        /// Specifies the style of the window being created. This parameter can be a combination of
        /// window styles, plus the control styles indicated in the Remarks section.
        /// </param>
        /// <param name="x">
        /// Specifies the initial horizontal position of the window. For an overlapped or pop-up
        /// window, the x parameter is the initial x-coordinate of the window's upper-left corner, in
        /// screen coordinates. For a child window, x is the x-coordinate of the upper-left corner of
        /// the window relative to the upper-left corner of the parent window's client area. If x is
        /// set to CW_USEDEFAULT, the system selects the default position for the window's upper-left
        /// corner and ignores the y parameter. CW_USEDEFAULT is valid only for overlapped windows;
        /// if it is specified for a pop-up or child window, the x and y parameters are set to zero.
        /// </param>
        /// <param name="y">
        /// Specifies the initial vertical position of the window. For an overlapped or pop-up
        /// window, the y parameter is the initial y-coordinate of the window's upper-left corner, in
        /// screen coordinates. For a child window, y is the initial y-coordinate of the upper-left
        /// corner of the child window relative to the upper-left corner of the parent window's
        /// client area. For a list box y is the initial y-coordinate of the upper-left corner of the
        /// list box's client area relative to the upper-left corner of the parent window's client area.
        /// <para>
        /// If an overlapped window is created with the WS_VISIBLE style bit set and the x parameter
        /// is set to CW_USEDEFAULT, then the y parameter determines how the window is shown. If the
        /// y parameter is CW_USEDEFAULT, then the window manager calls ShowWindow with the SW_SHOW
        /// flag after the window has been created. If the y parameter is some other value, then the
        /// window manager calls ShowWindow with that value as the nCmdShow parameter.
        /// </para>
        /// </param>
        /// <param name="nWidth">
        /// Specifies the width, in device units, of the window. For overlapped windows, nWidth is
        /// the window's width, in screen coordinates, or CW_USEDEFAULT. If nWidth is CW_USEDEFAULT,
        /// the system selects a default width and height for the window; the default width extends
        /// from the initial x-coordinates to the right edge of the screen; the default height
        /// extends from the initial y-coordinate to the top of the icon area. CW_USEDEFAULT is valid
        /// only for overlapped windows; if CW_USEDEFAULT is specified for a pop-up or child window,
        /// the nWidth and nHeight parameter are set to zero.
        /// </param>
        /// <param name="nHeight">
        /// Specifies the height, in device units, of the window. For overlapped windows, nHeight is
        /// the window's height, in screen coordinates. If the nWidth parameter is set to
        /// CW_USEDEFAULT, the system ignores nHeight.
        /// </param>
        /// <param name="hWndParent">
        /// Handle to the parent or owner window of the window being created. To create a child
        /// window or an owned window, supply a valid window handle. This parameter is optional for
        /// pop-up windows.
        /// <para>
        /// Windows 2000/XP: To create a message-only window, supply HWND_MESSAGE or a handle to an
        /// existing message-only window.
        /// </para>
        /// </param>
        /// <param name="hMenu">
        /// Handle to a menu, or specifies a child-window identifier, depending on the window style.
        /// For an overlapped or pop-up window, hMenu identifies the menu to be used with the window;
        /// it can be NULL if the class menu is to be used. For a child window, hMenu specifies the
        /// child-window identifier, an integer value used by a dialog box control to notify its
        /// parent about events. The application determines the child-window identifier; it must be
        /// unique for all child windows with the same parent window.
        /// </param>
        /// <param name="hInstance">
        /// Handle to the instance of the module to be associated with the window.
        /// </param>
        /// <param name="lpParam">
        /// Pointer to a value to be passed to the window through the CREATESTRUCT structure
        /// (lpCreateParams member) pointed to by the lParam param of the WM_CREATE message. This
        /// message is sent to the created window by this function before it returns.
        /// <para>
        /// If an application calls CreateWindow to create a MDI client window, lpParam should point
        /// to a CLIENTCREATESTRUCT structure. If an MDI client window calls CreateWindow to create
        /// an MDI child window, lpParam should point to a MDICREATESTRUCT structure. lpParam may be
        /// NULL if no additional data is needed.
        /// </para>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the new window.
        /// <para>
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </para>
        /// <para>This function typically fails for one of the following reasons:</para>
        /// <list type="">
        /// <item>an invalid parameter value</item>
        /// <item>the system class was registered by a different module</item>
        /// <item>The WH_CBT hook is installed and returns a failure code</item>
        /// <item>
        /// if one of the controls in the dialog template is not registered, or its window window
        /// procedure fails WM_CREATE or WM_NCCREATE
        /// </item>
        /// </list>
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern unsafe IntPtr CreateWindowEx(
           WindowStylesEx dwExStyle,
           IntPtr lpClassName,
           string lpWindowName,
           WindowStyles dwStyle,
           int x,
           int y,
           int nWidth,
           int nHeight,
           IntPtr hWndParent,
           IntPtr hMenu,
           IntPtr hInstance,
           void* lpParam);

        /// <summary>
        /// Changes an attribute of the specified window. The function also sets a value at the specified
        /// offset in the extra window memory.
        /// </summary>
        /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="nIndex">The zero-based offset to the value to be set.</param>
        /// <param name="dwNewLong">The replacement value.</param>
        /// <returns>
        /// <para>If the function succeeds, the return value is the previous value of the specified offset.</para>
        /// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
        /// <para>If the previous value is zero and the function succeeds, the return value is zero, but the function does
        /// not clear the last error information. To determine success or failure, clear the last error information by
        /// calling SetLastError with 0, then call SetWindowLongPtr. Function failure will be indicated by a return value of
        /// zero and a GetLastError result that is nonzero.</para>
        /// </returns>
        /// <remarks>
        /// When compiling for 32-bit Windows, SetWindowLongPtr is defined as a call to the SetWindowLong function. This
        /// function is exposed using a helper that conditionally calls SetWindowLong in 32-bit processes.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true, EntryPoint = "SetWindowLongPtr")]
        private static extern unsafe void* SetWindowLongPtr64(IntPtr hWnd, WindowLongIndexFlags nIndex, void* dwNewLong);
    }
}
