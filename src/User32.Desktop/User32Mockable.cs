// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
	using static User32;
	[System.Runtime.CompilerServices.CompilerGenerated]
	public class User32Mockable : IUser32Mockable {        [System.Runtime.CompilerServices.CompilerGenerated]
		public int InvokeSetWindowLong(IntPtr hWnd, WindowLongIndexFlags nIndex, SetWindowLongFlags dwNewLong)
			=> SetWindowLong(hWnd, nIndex, dwNewLong);
	
        [System.Runtime.CompilerServices.CompilerGenerated]
		public int InvokeGetWindowLong(IntPtr hWnd, WindowLongIndexFlags nIndex)
			=> GetWindowLong(hWnd, nIndex);
	
        [System.Runtime.CompilerServices.CompilerGenerated]
		public bool InvokeSetWindowPos(
            IntPtr hWnd,
            IntPtr hWndInsertAfter,
            int X,
            int Y,
            int cx,
            int cy,
            SetWindowPosFlags uFlags)
			=> SetWindowPos(hWnd, hWndInsertAfter, X, Y, cx, cy, uFlags);
	
        [System.Runtime.CompilerServices.CompilerGenerated]
		public IntPtr InvokeSetParent(IntPtr hWndChild, IntPtr hWndNewParent)
			=> SetParent(hWndChild, hWndNewParent);
	
        [System.Runtime.CompilerServices.CompilerGenerated]
		public IntPtr InvokeFindWindowEx(
            IntPtr parentHandle,
            IntPtr childAfter,
            string className,
            string windowTitle)
			=> FindWindowEx(parentHandle, childAfter, className, windowTitle);
	
        [System.Runtime.CompilerServices.CompilerGenerated]
		public bool InvokeShowWindow(IntPtr hWnd, WindowShowStyle nCmdShow)
			=> ShowWindow(hWnd, nCmdShow);
	
        [System.Runtime.CompilerServices.CompilerGenerated]
		public IntPtr InvokeGetForegroundWindow()
			=> GetForegroundWindow();
	
        [System.Runtime.CompilerServices.CompilerGenerated]
		public int InvokeSendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam)
			=> SendMessage(hWnd, wMsg, wParam, lParam);
	}
}
