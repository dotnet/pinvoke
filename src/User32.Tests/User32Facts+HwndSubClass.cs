// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using PInvoke;

/// <content>
/// Contains the inner class <see cref="HwndSubClass"/>.
/// </content>
public partial class User32Facts
{
    /// <summary>
    /// Helper to subclass an HWND using SetWindowLongPtr.
    /// </summary>
    private class HwndSubClass : IDisposable
    {
        /// <summary>
        /// Keeps track of whether this instnace has been disposed, or not.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="HwndSubClass"/> class.
        /// </summary>
        /// <param name="hWnd">The HWND being subclassed.</param>
        internal HwndSubClass(IntPtr hWnd)
        {
            this.HWnd = hWnd;

            unsafe
            {
                this.WindowProc = new User32.WndProc(this.HookProc);
                this.WindowProcPointer = Marshal.GetFunctionPointerForDelegate(this.WindowProc);

                this.OldWindowProcPointer =
                    User32.SetWindowLongPtr(this.HWnd, User32.WindowLongIndexFlags.GWLP_WNDPROC, this.WindowProcPointer);
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="HwndSubClass"/> class.
        /// </summary>
        ~HwndSubClass()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Event fired in response to every window message
        /// </summary>
        internal event EventHandler<WindowMessage> WindowMessage;

        /// <summary>
        /// Gets the new Window proceduce's address that has been replaced in the HWND.
        /// </summary>
        internal IntPtr WindowProcPointer { get; }

        /// <summary>
        /// Gets the Window procedure delegate that has been used to subclass the supplied HWND.
        /// </summary>
        internal User32.WndProc WindowProc { get; }

        private IntPtr HWnd { get; set; }

        /// <summary>
        /// Gets or sets the original window procedures address. This will be replaced back
        /// to the HWND when this instance of <see cref="HwndSubClass"/> is disposed.
        /// </summary>
        private IntPtr OldWindowProcPointer { get; set; }

        /// <summary>
        /// Frees resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// This is the replaces Window Procedure which will be used to track all window messages,
        /// and generate events.
        /// </summary>
        /// <param name="hWnd">The window handle.</param>
        /// <param name="msg">Message ID.</param>
        /// <param name="wParam">The wParam value.</param>
        /// <param name="lParam">The lParam value.</param>
        /// <returns>Message specific return value.</returns>
        internal unsafe IntPtr HookProc(IntPtr hWnd, User32.WindowMessage msg, void* wParam, void* lParam)
        {
            this.WindowMessage?.Invoke(this, new WindowMessage(msg, new IntPtr(wParam), new IntPtr(lParam)));
            return User32.DefWindowProc(hWnd, msg, new IntPtr(wParam), new IntPtr(lParam));
        }

        /// <summary>
        /// Cleanup - replaces the HWND with its original Window Procedure and marks this
        /// instance of <see cref="HwndSubClass"/> as disposed.
        /// </summary>
        /// <param name="disposing">When true, indicates that this call is coming from a <see cref="Dispose()"/> call,
        /// and when false, indicates that this call is coming from the finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                this.disposed = true;
                if (this.HWnd != IntPtr.Zero && this.OldWindowProcPointer != IntPtr.Zero)
                {
                    User32.SetWindowLongPtr(this.HWnd, User32.WindowLongIndexFlags.GWLP_WNDPROC, this.OldWindowProcPointer);
                    this.HWnd = IntPtr.Zero;
                    this.OldWindowProcPointer = IntPtr.Zero;
                }
            }
        }
    }
}
