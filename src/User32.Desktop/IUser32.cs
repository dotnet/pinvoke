// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
	using static User32;
	[System.Runtime.CompilerServices.CompilerGenerated]
	public interface IUser32 {        [System.Runtime.CompilerServices.CompilerGenerated]
	int SetWindowLong(IntPtr hWnd, WindowLongIndexFlags nIndex, SetWindowLongFlags dwNewLong);
	
        [System.Runtime.CompilerServices.CompilerGenerated]
	int GetWindowLong(IntPtr hWnd, WindowLongIndexFlags nIndex);
	
        [System.Runtime.CompilerServices.CompilerGenerated]
	bool SetWindowPos(
            IntPtr hWnd,
            IntPtr hWndInsertAfter,
            int X,
            int Y,
            int cx,
            int cy,
            SetWindowPosFlags uFlags);
	
        [System.Runtime.CompilerServices.CompilerGenerated]
	IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
	
        [System.Runtime.CompilerServices.CompilerGenerated]
	IntPtr FindWindowEx(
            IntPtr parentHandle,
            IntPtr childAfter,
            string className,
            string windowTitle);
	
        [System.Runtime.CompilerServices.CompilerGenerated]
	bool ShowWindow(IntPtr hWnd, WindowShowStyle nCmdShow);
	
        [System.Runtime.CompilerServices.CompilerGenerated]
	IntPtr GetForegroundWindow();
	
        [System.Runtime.CompilerServices.CompilerGenerated]
	int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
	}
}
