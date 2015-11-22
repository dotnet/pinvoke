// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
	using static User32;
	[System.Runtime.CompilerServices.CompilerGenerated]
	class User32Mockable : IUser32 {        [System.Runtime.CompilerServices.CompilerGenerated]
		public int SetWindowLong(IntPtr hWnd, WindowLongIndexFlags nIndex, SetWindowLongFlags dwNewLong)
			=> SetWindowLong(hWnd, nIndex, dwNewLong);
	
        [System.Runtime.CompilerServices.CompilerGenerated]
		public int GetWindowLong(IntPtr hWnd, WindowLongIndexFlags nIndex)
			=> GetWindowLong(hWnd, nIndex);
	
        [System.Runtime.CompilerServices.CompilerGenerated]
		public bool SetWindowPos(
            IntPtr hWnd,
            IntPtr hWndInsertAfter,
            int X,
            int Y,
            int cx,
            int cy,
            SetWindowPosFlags uFlags)
			=> SetWindowPos(hWnd, hWndInsertAfter, X, Y, cx, cy, uFlags);
	
        [System.Runtime.CompilerServices.CompilerGenerated]
		public IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent)
			=> SetParent(hWndChild, hWndNewParent);
	
        [System.Runtime.CompilerServices.CompilerGenerated]
		public IntPtr FindWindowEx(
            IntPtr parentHandle,
            IntPtr childAfter,
            string className,
            string windowTitle)
			=> FindWindowEx(parentHandle, childAfter, className, windowTitle);
	
        [System.Runtime.CompilerServices.CompilerGenerated]
		public bool ShowWindow(IntPtr hWnd, WindowShowStyle nCmdShow)
			=> ShowWindow(hWnd, nCmdShow);
	
        [System.Runtime.CompilerServices.CompilerGenerated]
		public IntPtr GetForegroundWindow()
			=> GetForegroundWindow();
	
        [System.Runtime.CompilerServices.CompilerGenerated]
		public int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam)
			=> SendMessage(hWnd, wMsg, wParam, lParam);
	}
}
