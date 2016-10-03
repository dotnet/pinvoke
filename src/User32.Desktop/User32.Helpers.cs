// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Text;
    using PInvoke;
    using static Kernel32;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class User32
    {
         /// <summary>
        /// The BeginPaint function prepares the specified window for painting and fills a <see cref="PAINTSTRUCT"/> structure with information about the painting.
        /// </summary>
        /// <param name="hwnd">Handle to the window to be repainted.</param>
        /// <param name="lpPaint">Pointer to the <see cref="PAINTSTRUCT"/> structure that will receive painting information.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to a display device context for the specified window.
        /// If the function fails, the return value is <see cref="SafeDCHandle.Null"/>, indicating that no display device context is available..</returns>
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
        public static unsafe SafeDCHandle BeginPaint(
            IntPtr hwnd,
            [Friendly(FriendlyFlags.Out)] PAINTSTRUCT* lpPaint)
        {
            var hdc = BeginPaint_IntPtr(hwnd, lpPaint);
            return hdc != IntPtr.Zero ? new SafeDCHandle(hwnd, hdc) : null;
        }

        /// <summary>
        /// The GetDC function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen.
        /// You can use the returned handle in subsequent GDI functions to draw in the DC. The device context is an opaque data structure, whose values are used internally by GDI.
        /// The GetDCEx function is an extension to GetDC, which gives an application more control over how and whether clipping occurs in the client area.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose DC is to be retrieved. If this value is NULL, GetDC retrieves the DC for the entire screen.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the DC for the specified window's client area.
        /// If the function fails, the return value is <see cref="SafeDCHandle.Null"/>.
        /// </returns>
        public static SafeDCHandle GetDC(IntPtr hWnd)
        {
            var hdc = GetDC_IntPtr(hWnd);
            return hdc != IntPtr.Zero ? new SafeDCHandle(hWnd, hdc) : null;
        }

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
        /// If the function succeeds, the return value is the handle to the DC for the specified window. If the function fails, the return value is <see cref="SafeDCHandle.Null"/>.
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
        public static SafeDCHandle GetDCEx(IntPtr hWnd, IntPtr hrgnClip, DeviceContextValues flags)
        {
            var hdc = GetDCEx_IntPtr(hWnd, hrgnClip, flags);
            return hdc != IntPtr.Zero ? new SafeDCHandle(hWnd, hdc) : null;
        }

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
        /// If the function fails, the return value is <see cref="SafeDCHandle.Null"/>, indicating an error or an invalid hWnd parameter.
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
        public static SafeDCHandle GetWindowDC(IntPtr hWnd)
        {
            var hdc = GetWindowDC_IntPtr(hWnd);
            return hdc != IntPtr.Zero ? new SafeDCHandle(hWnd, hdc) : null;
        }

        /// <summary>
        /// The CreateWindow is identical to the CreateWindowEx function, actually it is a macro on C/C++
        /// </summary>
        /// <param name="lpClassName">
        /// Pointer to a null-terminated string or a class atom created by a previous call to the
        /// RegisterClass or RegisterClassEx function. The atom must be in the low-order word of
        /// lpClassName; the high-order word must be zero. If lpClassName is a string, it specifies
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
        public static unsafe IntPtr CreateWindow(
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
           void* lpParam)
        {
            return CreateWindowEx(0, lpClassName, lpWindowName, dwStyle, x, y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam);
        }

        /// <summary>
        /// Retrieves the name of the class to which the specified window belongs.
        /// </summary>
        /// <param name = "hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="maxLength">The size of the string to return</param>
        /// <returns>The class name string.</returns>
        /// <exception cref="Win32Exception">Thrown when an error occurs.</exception>
        /// <remarks>The suggested class name length is 256 as we didn't find any reference of class name length limits</remarks>
        public static unsafe string GetClassName(IntPtr hWnd, int maxLength = 256)
        {
            char* className = stackalloc char[maxLength];
            int count = GetClassName(hWnd, className, maxLength);
            if (count == 0)
            {
                throw new Win32Exception();
            }

            return new string(className, 0, count);
        }

        /// <summary>
        /// Retrieves from the clipboard the name of the specified registered format.
        /// </summary>
        /// <param name = "format">The type of format to be retrieved. This parameter must not specify any of the predefined clipboard formats.</param>
        /// <returns>The format name string.</returns>
        /// <exception cref="Win32Exception">Thrown when an error occurs.</exception>
        public static unsafe string GetClipboardFormatName(int format)
        {
            // From MSDN: About Atom Tables - https://msdn.microsoft.com/en-us/library/windows/desktop/ms649053(v=vs.85).aspx
            // The system uses atom tables that are not directly accessible to applications.
            // However, the application uses these atoms when calling a variety of functions.
            // For example, registered clipboard formats are stored in an internal atom table
            // used by the system. An application adds atoms to this atom table using the
            // RegisterClipboardFormat function. Also, registered classes are stored in an
            // internal atom table used by the system. An application adds atoms to this atom table
            // using the RegisterClass or RegisterClassEx function.

            // If we add this knowledge of the internals of this function to the limits we get
            // from registering an Atom with GolbalAddAtom function we see that the limit of
            // the null-terminated string is 255 characters. I placed an extra for the terminating null.
            const int bufferSize = 256;

            char* formatName = stackalloc char[bufferSize]; // max name length
            int count = GetClipboardFormatName(format, formatName, bufferSize);
            if (count == 0)
            {
                throw new Win32Exception();
            }

            return new string(formatName, 0, count);
        }

        /// <summary>
        /// Get the text of the specified window's title bar (if it has one). If the specified window is a control, the
        /// text of the control is returned. However, GetWindowText cannot retrieve the text of a control in another application.
        /// </summary>
        /// <param name="hWnd">A handle to the window or control containing the text.</param>
        /// <returns>
        /// The text of the specified window's title bar. If the specified window is a control, the text of the control is
        /// returned.
        /// </returns>
        public static string GetWindowText(IntPtr hWnd)
        {
            var maxLength = GetWindowTextLength(hWnd);
            if (maxLength == 0)
            {
                var lastError = GetLastError();
                if (lastError != Win32ErrorCode.ERROR_SUCCESS)
                {
                    throw new Win32Exception(lastError);
                }

                return string.Empty;
            }

            var text = new char[maxLength + 1];
            var finalLength = GetWindowText(hWnd, text, maxLength + 1);
            if (finalLength == 0)
            {
                var lastError = GetLastError();
                if (lastError != Win32ErrorCode.ERROR_SUCCESS)
                {
                    throw new Win32Exception(lastError);
                }

                return string.Empty;
            }

            return new string(text, 0, finalLength);
        }

        /// <summary>
        /// Retrieves the position of the mouse cursor, in screen coordinates.
        /// </summary>
        /// <returns>The screen coordinates of the cursor</returns>
        public static unsafe POINT GetCursorPos()
        {
            var result = default(POINT);
            if (!GetCursorPos(&result))
            {
                throw new Win32Exception();
            }

            return result;
        }

        /// <summary>Retrieves the show state and the restored, minimized, and maximized positions of the specified window.</summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <returns>
        /// A WINDOWPLACEMENT structure with the show state and position information.
        /// </returns>
        public static unsafe WINDOWPLACEMENT GetWindowPlacement(IntPtr hWnd)
        {
            var result = WINDOWPLACEMENT.Create();
            if (!GetWindowPlacement(hWnd, &result))
            {
                throw new Win32Exception();
            }

            return result;
        }
    }
}
