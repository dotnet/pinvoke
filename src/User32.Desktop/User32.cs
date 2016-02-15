// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Exported functions from the User32.dll Windows library.
    /// </summary>
    [OfferFriendlyOverloads]
    public static partial class User32
    {
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

        public delegate int WindowsHookDelegate(int code, IntPtr wParam, IntPtr lParam);

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

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern bool SetWindowPos(
            IntPtr hWnd,
            IntPtr hWndInsertAfter,
            int X,
            int Y,
            int cx,
            int cy,
            SetWindowPosFlags uFlags);

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

        [DllImport(nameof(User32), SetLastError = true)]
        public static extern IntPtr FindWindowEx(
            IntPtr parentHandle,
            IntPtr childAfter,
            string className,
            string windowTitle);

        [DllImport(nameof(User32))]
        public static extern bool ShowWindow(IntPtr hWnd, WindowShowStyle nCmdShow);

        [DllImport(nameof(User32))]
        public static extern IntPtr GetForegroundWindow();

        [DllImport(nameof(User32))]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

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
        public static extern bool ReleaseCapture();

        /// <summary>Flashes the specified window. It does not change the active state of the window.</summary>
        /// <param name="pwfi">A pointer to a <see cref="FLASHWINFO" /> structure.</param>
        /// <returns>
        ///     The return value specifies the window's state before the call to the FlashWindowEx function. If the window
        ///     caption was drawn as active before the call, the return value is nonzero. Otherwise, the return value is zero.
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
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
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

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
        public static extern bool SetMenuItemInfo(
            IntPtr hMenu,
            uint uItem,
            bool fByPosition,
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
        public static extern bool GetMenuItemInfo(
            IntPtr hMenu,
            uint uItem,
            bool fByPosition,
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

        /// <summary>
        /// The GetDC function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen. You can use the returned handle in subsequent GDI functions to draw in the DC. The device context is an opaque data structure, whose values are used internally by GDI.
        /// The GetDCEx function is an extension to GetDC, which gives an application more control over how and whether clipping occurs in the client area.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose DC is to be retrieved. If this value is NULL, GetDC retrieves the DC for the entire screen.</param>
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
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
    }
}
