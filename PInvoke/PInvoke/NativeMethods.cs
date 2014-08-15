using System;
using System.Runtime.InteropServices;

namespace PInvoke
{
    public static class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    }
}