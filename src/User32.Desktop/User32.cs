// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Exported functions from the User32.dll Windows library.
    /// </summary>
    public static partial class User32
    {
        public delegate int WindowsHookDelegate(int code, IntPtr wParam, IntPtr lParam);

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
        ///     Removes a hook procedure installed in a hook chain by the
        ///     <see cref="SetWindowsHookEx(WindowsHookType,IntPtr,IntPtr,int)" /> function.
        /// </summary>
        /// <param name="hhk">
        ///     A handle to the hook to be removed. This parameter is a hook handle obtained by a previous call to
        ///     <see cref="SetWindowsHookEx(WindowsHookType,IntPtr,IntPtr,int)" />.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is a nonzero value.
        ///     <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
        /// </returns>
        [DllImport(nameof(User32), SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
    }
}
