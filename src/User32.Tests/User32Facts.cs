// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using PInvoke;
using Xunit;
using static PInvoke.User32;

public partial class User32Facts
{
    [Fact]
    public void MessageBeep_Asterisk()
    {
        Assert.True(MessageBeep(MessageBeepType.MB_ICONASTERISK));
    }

    [Fact]
    public void INPUT_Union()
    {
        INPUT i = default(INPUT);
        i.type = InputType.INPUT_HARDWARE;

        // Assert that the first field (type) has its own memory space.
        Assert.Equal(0u, i.Inputs.hi.uMsg);
        Assert.Equal(0, (int)i.Inputs.ki.wScan);
        Assert.Equal(0, i.Inputs.mi.dx);

        // Assert that these three fields (hi, ki, mi) share memory space.
        i.Inputs.hi.uMsg = 1;
        Assert.Equal(1, (int)i.Inputs.ki.wVk);
        Assert.Equal(1, i.Inputs.mi.dx);
    }

    /// <summary>
    /// Validates that the union fields are all exactly 4 bytes (or 8 bytes on x64)
    /// after the start of the struct.
    /// </summary>
    /// <devremarks>
    /// From http://www.pinvoke.net/default.aspx/Structures/INPUT.html:
    /// The last 3 fields are a union, which is why they are all at the same memory offset.
    /// On 64-Bit systems, the offset of the <see cref="INPUT.InputUnion.mi"/>, <see cref="INPUT.InputUnion.ki"/> and <see cref="INPUT.InputUnion.hi"/> fields is 8,
    /// because the nested struct uses the alignment of its biggest member, which is 8
    /// (due to the 64-bit pointer in <see cref="KEYBDINPUT.dwExtraInfo"/>).
    /// By separating the union into its own structure, rather than placing the
    /// <see cref="INPUT.InputUnion.mi"/>, <see cref="INPUT.InputUnion.ki"/> and <see cref="INPUT.InputUnion.hi"/> fields directly in the INPUT structure,
    /// we assure that the .NET structure will have the correct alignment on both 32 and 64 bit.
    /// </devremarks>
    [Fact]
    public unsafe void INPUT_UnionMemoryAlignment()
    {
        INPUT input;
        Assert.Equal(IntPtr.Size, (long)&input.Inputs.hi - (long)&input);
        Assert.Equal(IntPtr.Size, (long)&input.Inputs.mi - (long)&input);
        Assert.Equal(IntPtr.Size, (long)&input.Inputs.ki - (long)&input);
    }

    [Fact]
    [Trait("skiponcloud", "true")]
    [Trait("TestCategory", "FailsInCloudTest")]
    public void GetWindowTextHelper_WithNonzeroLastError()
    {
        IntPtr hwnd = CreateWindow(
            "BUTTON",
            string.Empty, // empty window name
            WindowStyles.WS_OVERLAPPED,
            0,
            0,
            0,
            0,
            IntPtr.Zero,
            IntPtr.Zero,
            Process.GetCurrentProcess().Handle,
            IntPtr.Zero);
        if (hwnd == IntPtr.Zero)
        {
            throw new Win32Exception();
        }

        try
        {
            Kernel32.SetLastError(2);
            Assert.Equal(string.Empty, GetWindowText(hwnd));
        }
        finally
        {
            if (!DestroyWindow(hwnd))
            {
                throw new Win32Exception();
            }
        }
    }

    /// <summary>
    /// Validates that User32.SetWindowLongPtr works as intended.
    /// SetWindowLongPtr is implemented as a call into User32.SetWindowLong on 32-bit platforms. This
    /// test...
    /// ... a. Creates a window
    /// ... b. Subclasses it by calling SetWindowLongPtr.
    ///          On 32-bit processes, it will indirectly call into SetWindowLong, and validate that our implementation is accurate.
    ///     c. Wait a few seconds for window messages to appear in the new wndow procedure, and declare success as soon as the first message
    ///         appears, which would indicate that the subclassing was successful.
    /// </summary>
    [Fact]
    [STAThread]
    public void SetWindowLongPtr_Test()
    {
        IntPtr hwnd = CreateWindow(
            "static",
            "Window",
            WindowStyles.WS_BORDER | WindowStyles.WS_CAPTION | WindowStyles.WS_OVERLAPPED | WindowStyles.WS_VISIBLE,
            0,
            0,
            100,
            100,
            IntPtr.Zero,
            IntPtr.Zero,
            Process.GetCurrentProcess().Handle,
            IntPtr.Zero);

        if (hwnd == IntPtr.Zero)
        {
            throw new Win32Exception();
        }

        SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        var hwndSubClass = new HwndSubClass(hwnd);
        hwndSubClass.WindowMessage += (_, __) =>
        {
            semaphore.Release();
        };

        try
        {
            Assert.True(semaphore.Wait(TimeSpan.FromSeconds(5)));
        }
        finally
        {
            hwndSubClass.Dispose();
            if (hwnd != IntPtr.Zero)
            {
                DestroyWindow(hwnd);
            }
        }
    }

    [Fact]
    public unsafe void MENUBARINFO_MarshalSizeAsExpected()
    {
        MENUBARINFO info = default;
        int expectedSize = IntPtr.Size == 4 ? 0x20 : 0x30;
        Assert.Equal(expectedSize, Marshal.SizeOf(info));
        Assert.Equal(expectedSize, MENUBARINFO.Create().cbSize);
    }

    [Fact]
    public unsafe void EnumDisplayMonitors_GetMonitorInfo_Test()
    {
        Assert.True(EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, Callback, IntPtr.Zero));

        bool Callback(IntPtr hMonitor, IntPtr hdcMonitor, RECT* lprcMonitor, void* dwData)
        {
            MONITORINFO info = default;
            info.cbSize = sizeof(MONITORINFO);
            Assert.True(GetMonitorInfo(hMonitor, ref info));
            Assert.True(info.rcMonitor.bottom > 0);
            return true;
        }
    }
}
