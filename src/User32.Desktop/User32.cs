// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

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
        /// See https://msdn.microsoft.com/en-us/library/windows/desktop/ms646254(v=vs.85).aspx
        /// </remarks>
        public const int WHEEL_DELTA = 120;

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
        /// An application-defined or library-defined callback function used with the <see cref="SetWindowsHookEx(WindowsHookType, IntPtr, IntPtr, int)"/> function.
        /// This is a generic function to Hook callbacks. For specific callback functions see this <see href="https://msdn.microsoft.com/en-us/library/windows/desktop/ms632589(v=vs.85).aspx" >API documentation on MSDN</see>.
        /// </summary>
        /// <param name="nCode">An action code for the callback. Can be used to indicate if the hook procedure must process the message or not.</param>
        /// <param name="wParam">First message parameter</param>
        /// <param name="lParam">Second message parameter</param>
        /// <returns>
        /// An LRESULT. Usually if nCode is less than zero, the hook procedure must return the value returned by CallNextHookEx.
        /// If nCode is greater than or equal to zero, it is highly recommended that you call CallNextHookEx and return the value it returns;
        /// otherwise, other applications that have installed hooks will not receive hook notifications and may behave incorrectly as a result.
        /// If the hook procedure does not call CallNextHookEx, the return value should be zero.
        /// </returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int WindowsHookDelegate(int nCode, IntPtr wParam, IntPtr lParam);

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
        [return:MarshalAs(UnmanagedType.Bool)]
        public delegate bool WNDENUMPROC(IntPtr hwnd, IntPtr lParam);

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
        public static extern int SetWindowLong(IntPtr hWnd, WindowLongIndexFlags nIndex, SetWindowLongFlags dwNewLong);

        [DllImport(nameof(User32), SetLastError = true)]
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
            [Friendly(FriendlyFlags.Array)] char* lpClassName,
            int nMaxCount);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

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
        [DllImport(nameof(User32), SetLastError = false)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        /// <summary>
        /// Retrieves a handle to the top-level window whose class name and window name match the specified strings. This function does not search child windows. This function does not perform a case-sensitive search. To search child windows, beginning with a specified child window, use the FindWindowEx function.
        /// </summary>
        /// <param name="lpClassName">The window class name. If lpClassName is NULL, it finds any window whose title matches the lpWindowName parameter. </param>
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

        [DllImport(nameof(User32))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, WindowShowStyle nCmdShow);

        /// <summary>
        /// Retrieves a handle to the desktop window. The desktop window covers the entire screen. The desktop window is the area on top of which other windows are painted.
        /// </summary>
        /// <returns>The return value is a handle to the desktop window.</returns>
        [DllImport(nameof(User32))]
        public static extern IntPtr GetDesktopWindow();

        [DllImport(nameof(User32))]
        public static extern IntPtr GetForegroundWindow();

#pragma warning disable SA1625 // Element documentation must not be copied and pasted
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
        [DllImport(nameof(User32), SetLastError = true)]
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
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool PostMessage(IntPtr hWnd, WindowMessage wMsg, void* wParam, void* lParam);
#pragma warning restore SA1625 // Element documentation must not be copied and pasted

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
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)] bool bRevert);

        /// <summary>
        ///     Appends a new item to the end of the specified menu bar, drop-down menu, submenu, or shortcut menu. You can
        ///     use this function to specify the content, appearance, and behavior of the menu item.
        /// </summary>
        /// <param name="hMenu">A handle to the menu bar, drop-down menu, submenu, or shortcut menu to be changed.</param>
        /// <param name="uFlags">Controls the appearance and behavior of the new menu item</param>
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
        public static extern bool SetMenuItemInfo(
            IntPtr hMenu,
            uint uItem,
            [MarshalAs(UnmanagedType.Bool)] bool fByPosition,
            [In] ref MENUITEMINFO lpmii);

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
        ///     <para>If the function fails, the return value is false. To get extended error information, call GetLastError.</para>
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMenuItemInfo(
            IntPtr hMenu,
            uint uItem,
            [MarshalAs(UnmanagedType.Bool)] bool fByPosition,
            ref MENUITEMINFO lpmii);

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
            byte* presbits,
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
            byte* presbits,
            [MarshalAs(UnmanagedType.Bool)] bool fIcon,
            int cxDesired,
            int cyDesired,
            LookupIconIdFromDirectoryExFlags Flags);

        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int RegisterWindowMessage(string lpString);

        /// <summary>
        /// Retrieves the name of the format from the clipboard.
        /// </summary>
        /// <param name="format">The type of format to be retrieved. This parameter must not specify any of the predefined clipboard formats.</param>
        /// <param name="lpszFormatName">The format name string.</param>
        /// <param name="nMaxCount">
        /// The length of the <paramref name="lpszFormatName"/> buffer, in characters. The buffer must be large enough to include the terminating null character; otherwise, the format name string is truncated to <paramref name="nMaxCount"/>-1 characters.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of characters copied to the buffer.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern unsafe int GetClipboardFormatName(
            int format,
            [Friendly(FriendlyFlags.Array)] char* lpszFormatName,
            int nMaxCount);

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
            [Friendly(FriendlyFlags.Array)] INPUT* pInputs,
            int cbSize);

        /// <summary>
        /// Waits until the specified process has finished processing its initial input and is waiting for user input with no input pending, or until the time-out interval has elapsed.
        /// </summary>
        /// <param name="hProcess">A handle to the process. If this process is a console application or does not have a message queue, WaitForInputIdle returns immediately.</param>
        /// <param name="dwMilliseconds">The time-out interval, in milliseconds. If dwMilliseconds is INFINITE, the function does not return until the process is idle.</param>
        /// <returns>0 if the wait was satisfied successfully., WAIT_TIMEOUT if the wait was terminated because the time-out interval elapsed, and WAIT_FAILED if an error occurred.</returns>
        /// <remarks>Raymond Chen has a series of articles that give a bit more depth to how this function was intended to be used.
        /// <a href="http://blogs.msdn.com/b/oldnewthing/archive/2010/03/25/9984720.aspx">Here</a> and <a href="http://blogs.msdn.com/b/oldnewthing/archive/2010/03/26/9985422.aspx">here</a>.
        /// The jist of it is that this function should have been really called WaitForProcessStartupComplete, as this is all it does.</remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        public static extern int WaitForInputIdle(IntPtr hProcess, int dwMilliseconds);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern short GetAsyncKeyState(VirtualKey vKey);

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern short GetKeyState(VirtualKey vKey);

        /// <summary>
        /// <para>
        /// Converts a point in a window from logical coordinates into physical coordinates, regardless of the dots per inch (dpi) awareness of the caller.
        /// For more information about DPI awareness levels, see <see cref="PROCESS_DPI_AWARENESS"/>
        /// </para>
        /// <para>
        /// Tip: Since an application with a value of <see cref="PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE"/> uses the actual DPI of the monitor,
        /// physical and logical coordinates are the same for this app.
        /// </para>
        /// </summary>
        /// <param name="hwnd">A handle to the window whose transform is used for the conversion</param>
        /// <param name="lpPoint">
        /// A pointer to a <see cref="POINT"/> structure that specifies the physical/screen coordinates to be converted.
        /// The new logical coordinates are copied into this structure if the function succeeds
        /// </param>
        /// <returns>Returns TRUE if successful, or FALSE otherwise</returns>
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
        /// Converts the physical coordinates of a point in a window to logical coordinates
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window whose transform is used for the conversion. Top level windows are fully supported.
        /// In the case of child windows, only the area of overlap between the parent and the child window is converted
        /// </param>
        /// <param name="lpPoint">
        /// A pointer to a <see cref="POINT"/> structure that specifies the physical/screen coordinates to be converted.
        /// The new logical coordinates are copied into this structure if the function succeeds
        /// </param>
        /// <returns>Returns TRUE if successful, or FALSE otherwise</returns>
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
        /// <param name="hwnd">A handle to the window whose transform is used for the conversion</param>
        /// <param name="lpPoint">
        /// A pointer to a <see cref="POINT"/> structure that specifies the logical coordinates to be converted.
        /// The new physical coordinates are copied into this structure if the function succeeds
        /// </param>
        /// <returns>Returns true if successful, or false otherwise</returns>
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
        /// Converts the logical coordinates of a point in a window to physical coordinates
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window whose transform is used for the conversion. Top level windows are fully supported.
        /// In the case of child windows, only the area of overlap between the parent and the child window is converted
        /// </param>
        /// <param name="lpPoint">
        /// A pointer to a <see cref="POINT"/> structure that specifies the logical coordinates to be converted.
        /// The new physical coordinates are copied into this structure if the function succeeds
        /// </param>
        /// <returns>Returns TRUE if successful, or FALSE otherwise</returns>
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
        /// <returns>TRUE if the process is dpi aware; otherwise, FALSE</returns>
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
        /// A handle to the desktop. This handle is returned by the <see cref="CreateDesktop(string, string, IntPtr, DesktopCreationFlags, Kernel32.ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/> and <see cref="OpenDesktop"/> functions.
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
        /// This handle is returned by the <see cref="CreateDesktop(string, string, IntPtr, DesktopCreationFlags, Kernel32.ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/>, <see cref="GetThreadDesktop"/>, <see cref="OpenDesktop"/>, or <see cref="OpenInputDesktop"/> function.
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
        /// <param name="dwFlags">Access control flags</param>
        /// <param name="fInherit">If this value is true, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.</param>
        /// <param name="dwDesiredAccess">The access to the desktop. For a list of access rights, see <see cref="Kernel32.ACCESS_MASK"/>.</param>
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
            Kernel32.ACCESS_MASK dwDesiredAccess);

        /// <summary>
        /// Enumerates all top-level windows associated with the specified desktop. It passes the handle to each window, in turn, to an application-defined callback function.
        /// </summary>
        /// <param name="hDesktop">
        /// A handle to the desktop whose top-level windows are to be enumerated. This handle is returned by the <see cref="CreateDesktop(string, string, IntPtr, DesktopCreationFlags, Kernel32.ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/>, <see cref="GetThreadDesktop"/>, <see cref="OpenDesktop"/>, or <see cref="OpenInputDesktop"/> function,
        /// and must have the <see cref="Kernel32.ACCESS_MASK.DesktopSpecificRight.DESKTOP_READOBJECTS"/> access right.
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
        /// <param name="hWinsta">A handle to the window station whose desktops are to be enumerated. This handle is returned by the <see cref="CreateWindowStation(string, WindowStationCreationFlags, Kernel32.ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/>, <see cref="GetProcessWindowStation"/>, or <see cref="OpenWindowStation"/> function, and must have the WINSTA_ENUMDESKTOPS access right.</param>
        /// <param name="lpEnumFunc">An application-defined <see cref="DESKTOPENUMPROC"/> callback function.</param>
        /// <param name="lParam">An application-defined value to be passed to the callback function.</param>
        /// <returns>
        /// If the function succeeds, it returns the nonzero value returned by the callback function that was pointed to by <paramref name="lpEnumFunc"/>.
        /// If the function is unable to perform the enumeration, the return value is zero. Call GetLastError to get extended error information.
        /// If the callback function fails, the return value is zero. The callback function can call SetLastError to set an error code for the caller to retrieve by calling GetLastError.
        /// </returns>
        /// <remarks>
        /// The EnumDesktops function enumerates only those desktops for which the calling process has the <see cref="Kernel32.ACCESS_MASK.DesktopSpecificRight.DESKTOP_ENUMERATE"/> access right.
        /// The EnumDesktops function repeatedly invokes the lpEnumFunc callback function until the last desktop is enumerated or the callback function returns zero.
        /// </remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern int EnumDesktops(SafeWindowStationHandle hWinsta, DESKTOPENUMPROC lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// Opens the desktop that receives user input.
        /// </summary>
        /// <param name="dwFlags">Access control flags</param>
        /// <param name="fInherit">If this value is true, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.</param>
        /// <param name="dwDesiredAccess">The requested access to the desktop. For a list of values, see <see cref="Kernel32.ACCESS_MASK"/>.</param>
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
            Kernel32.ACCESS_MASK dwDesiredAccess);

        /// <summary>
        /// Creates a new desktop with the specified heap, associates it with the current window station of the calling process, and assigns it to the calling thread.
        /// The calling process must have an associated window station, either assigned by the system at process creation time or set by the <see cref="SetProcessWindowStation"/> function.
        /// </summary>
        /// <param name="lpszDesktop">The name of the desktop to be created. Desktop names are case-insensitive and may not contain backslash characters (\).</param>
        /// <param name="lpszDevice">This parameter is reserved and must be <see cref="IntPtr.Zero"/></param>
        /// <param name="pDevmode">This parameter is reserved and must be <see cref="IntPtr.Zero"/>.</param>
        /// <param name="dwFlags">Access control flags</param>
        /// <param name="dwDesiredAccess">
        /// The requested access to the desktop. For a list of values, see <see cref="Kernel32.ACCESS_MASK"/>.
        /// This parameter must include the <see cref="Kernel32.ACCESS_MASK.DesktopSpecificRight.DESKTOP_CREATEWINDOW"/> access right, because internally <see cref="CreateDesktop(string, string, IntPtr, DesktopCreationFlags, Kernel32.ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/> uses the handle to create a window.
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
        public static unsafe extern SafeDesktopHandle CreateDesktopEx(
           string lpszDesktop,
           IntPtr lpszDevice,
           IntPtr pDevmode,
           DesktopCreationFlags dwFlags,
           Kernel32.ACCESS_MASK dwDesiredAccess,
           [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] Kernel32.SECURITY_ATTRIBUTES* lpsa,
           uint ulHeapSize,
           IntPtr pvoid = default(IntPtr));

        /// <summary>
        /// Creates a new desktop, associates it with the current window station of the calling process, and assigns it to the calling thread. The calling process must have an associated window station, either assigned by the system at process creation time or set by the <see cref="SetProcessWindowStation"/> function.
        /// </summary>
        /// <param name="lpszDesktop">The name of the desktop to be created. Desktop names are case-insensitive and may not contain backslash characters (\).</param>
        /// <param name="lpszDevice">This parameter is reserved and must be <see cref="IntPtr.Zero"/></param>
        /// <param name="pDevmode">This parameter is reserved and must be <see cref="IntPtr.Zero"/>.</param>
        /// <param name="dwFlags">Access control flags</param>
        /// <param name="dwDesiredAccess">
        /// The requested access to the desktop. For a list of values, see <see cref="Kernel32.ACCESS_MASK"/>.
        /// This parameter must include the <see cref="Kernel32.ACCESS_MASK.DesktopSpecificRight.DESKTOP_CREATEWINDOW"/> access right, because internally <see cref="CreateDesktop(string, string, IntPtr, DesktopCreationFlags, Kernel32.ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/> uses the handle to create a window.
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
        public static unsafe extern SafeDesktopHandle CreateDesktop(
            string lpszDesktop,
            string lpszDevice,
            IntPtr pDevmode,
            DesktopCreationFlags dwFlags,
            Kernel32.ACCESS_MASK dwDesiredAccess,
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
        /// A handle to the desktop to be closed. This can be a handle returned by the <see cref="CreateDesktop(string, string, IntPtr, DesktopCreationFlags, Kernel32.ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/>, <see cref="OpenDesktop"/>, or <see cref="OpenInputDesktop"/> functions.
        /// Do not specify the handle returned by the <see cref="GetThreadDesktop"/> function.
        /// </param>
        /// <returns>If the function succeeds, the return value is true, if it fails, the return value is false.</returns>
        /// <remarks>The CloseDesktop function will fail if any thread in the calling process is using the specified desktop handle or if the handle refers to the initial desktop of the calling process.</remarks>
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseDesktop(IntPtr hDesktop);

        /// <summary>
        /// Retrieves information about the specified window station or desktop object.
        /// </summary>
        /// <param name="hObj">A handle to the window station or desktop object. This handle is returned by the <see cref="CreateWindowStation(string, WindowStationCreationFlags, Kernel32.ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/>, <see cref="OpenWindowStation"/>, <see cref="CreateDesktop(string, string, IntPtr, DesktopCreationFlags, Kernel32.ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/>, or <see cref="OpenDesktop"/> function.</param>
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
        public static unsafe extern bool GetUserObjectInformation(IntPtr hObj, ObjectInformationType nIndex, void* pvInfo, uint nLength, uint* lpnLengthNeeded);

        /// <summary>
        /// Assigns the specified window station to the calling process.
        /// This enables the process to access objects in the window station such as desktops, the clipboard, and global atoms. All subsequent operations on the window station use the access rights granted to <paramref name="hWinSta"/>.
        /// </summary>
        /// <param name="hWinSta">
        /// A handle to the window station. This can be a handle returned by the <see cref="CreateWindowStation(string, WindowStationCreationFlags, Kernel32.ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/>, <see cref="OpenWindowStation"/>, or <see cref="GetProcessWindowStation"/> function.
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
        /// This handle is returned by the <see cref="CreateWindowStation(string, WindowStationCreationFlags, Kernel32.ACCESS_MASK, Kernel32.SECURITY_ATTRIBUTES*)"/> or <see cref="OpenWindowStation"/> function.
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
        /// The requested access to the window station. For a list of values, see <see cref="Kernel32.ACCESS_MASK"/>.
        /// In addition, you can specify any of the standard access rights, such as <see cref="Kernel32.ACCESS_MASK.StandardRight.READ_CONTROL"/> or <see cref="Kernel32.ACCESS_MASK.StandardRight.WRITE_DAC"/>, and a combination of the window station-specific access rights.
        /// </param>
        /// <param name="lpsa">
        /// A pointer to a <see cref="Kernel32.SECURITY_ATTRIBUTES"/> structure that determines whether the returned handle can be inherited by child processes. If lpsa is NULL, the handle cannot be inherited.
        /// The <see cref="Kernel32.SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new window station.
        /// If lpsa is NULL, the window station (and any desktops created within the window) gets a security descriptor that grants <see cref="Kernel32.ACCESS_MASK.GenericRight.GENERIC_ALL"/> access to all users.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created window station.
        /// If the specified window station already exists, the function succeeds and returns a handle to the existing window station.
        /// If the function fails, the return value is an invalid handle.
        /// </returns>
        /// <remarks>After you are done with the handle, you must call <see cref="CloseWindowStation"/> to free the handle.</remarks>
        [DllImport(nameof(User32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static unsafe extern SafeWindowStationHandle CreateWindowStation(
            string lpwinsta,
            WindowStationCreationFlags dwFlags,
            Kernel32.ACCESS_MASK dwDesiredAccess,
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
        /// The EnumWindowStations function enumerates only those window stations for which the calling process has the <see cref="Kernel32.ACCESS_MASK.WindowStationSpecificRight.WINSTA_ENUMERATE"/> access right.
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
        /// <param name="dwDesiredAccess">The access to the window station. For a list of access rights</param>
        /// <returns>If the function succeeds, the return value is the handle to the specified window station. If the function fails, the return value is NULL. </returns>
        /// <remarks>After you are done with the handle, you must call <see cref="CloseWindowStation"/> to free the handle.</remarks>
        [DllImport(nameof(User32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern SafeWindowStationHandle OpenWindowStation(
            string lpszWinSta,
            [MarshalAs(UnmanagedType.Bool)] bool fInherit,
            Kernel32.ACCESS_MASK dwDesiredAccess);

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
        [DllImport(nameof(User32), SetLastError = true)]
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
            [Friendly(FriendlyFlags.Array)] char* lpString,
            int nMaxCount);

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

        /// <summary>
        /// The <see cref="GetDC"/> function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen. You can use the returned handle in subsequent GDI functions to draw in the DC. The device context is an opaque data structure, whose values are used internally by GDI.
        /// The GetDCEx function is an extension to <see cref="GetDC"/>, which gives an application more control over how and whether clipping occurs in the client area.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose DC is to be retrieved. If this value is NULL, <see cref="GetDC"/> retrieves the DC for the entire screen.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the DC for the specified window's client area.
        /// If the function fails, the return value is NULL.
        /// </returns>
        [DllImport(nameof(User32), EntryPoint = "GetDC", SetLastError = false)]
        private static extern IntPtr GetDC_IntPtr(IntPtr hWnd);

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
        [DllImport(nameof(User32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
    }
}
