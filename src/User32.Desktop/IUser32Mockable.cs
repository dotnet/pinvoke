// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
	public interface IUser32Mockable {        int InvokeSetWindowLong(IntPtr hWnd, WindowLongIndexFlags nIndex, SetWindowLongFlags dwNewLong);
	
        int InvokeGetWindowLong(IntPtr hWnd, WindowLongIndexFlags nIndex);
	
        bool InvokeSetWindowPos(
            IntPtr hWnd,
            IntPtr hWndInsertAfter,
            int X,
            int Y,
            int cx,
            int cy,
            SetWindowPosFlags uFlags);
	
        IntPtr InvokeSetParent(IntPtr hWndChild, IntPtr hWndNewParent);
	
        IntPtr InvokeFindWindowEx(
            IntPtr parentHandle,
            IntPtr childAfter,
            string className,
            string windowTitle);
	
        bool InvokeShowWindow(IntPtr hWnd, WindowShowStyle nCmdShow);
	
        IntPtr InvokeGetForegroundWindow();
	
        int InvokeSendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
	}
}
