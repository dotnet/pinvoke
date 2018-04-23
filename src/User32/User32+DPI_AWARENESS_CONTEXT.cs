// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <summary>
    /// Contains nested type <see cref="DPI_AWARENESS_CONTEXT"/>
    /// </summary>
    public partial class User32
    {
        /// <summary>
        /// Contains well-known handles that identify DPI awareness context for a window.
        /// </summary>
        /// <remarks>DPI_AWARENESS_CONTEXT values should never be compared directly. Instead, use AreDpiAwarenessContextsEqual function</remarks>
        public static class DPI_AWARENESS_CONTEXT
        {
            /// <summary>
            /// Gets DPI unaware. This window does not scale for DPI changes and is always assumed to have a scale factor of 100% (96 DPI). It will be automatically scaled by the system on any other DPI setting.
            /// </summary>
            public static readonly IntPtr DPI_AWARENESS_CONTEXT_UNAWARE = new IntPtr(-1);

            /// <summary>
            /// Gets System DPI aware. This window does not scale for DPI changes. It will query for the DPI once and use that value for the lifetime of the process. If the DPI changes, the process will not adjust to the new DPI value. It will be automatically scaled up or down by the system when the DPI changes from the system value.
            /// </summary>
            public static readonly IntPtr DPI_AWARENESS_CONTEXT_SYSTEM_AWARE = new IntPtr(-2);

            /// <summary>
            /// Gets Per monitor DPI aware. This window checks for the DPI when it is created and adjusts the scale factor whenever the DPI changes. These processes are not automatically scaled by the system.
            /// </summary>
            public static readonly IntPtr DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE = new IntPtr(-3);

            /// <summary>
            /// Also known as Per Monitor v2. An advancement over the original per-monitor DPI awareness mode, which enables applications to access new DPI-related scaling behaviors on a per top-level window basis.
            /// Per Monitor v2 was made available in the Creators Update of Windows 10, and is not available on earlier versions of the operating system.
            /// The additional behaviors introduced are as follows:
            /// <list type="bullet">
            /// <item>Child window DPI change notifications - In Per Monitor v2 contexts, the entire window tree is notified of any DPI changes that occur.</item>
            /// <item>Scaling of non-client area - All windows will automatically have their non-client area drawn in a DPI sensitive fashion. Calls to EnableNonClientDpiScaling are unnecessary.</item>
            /// <item>Scaling of Win32 menus - All NTUSER menus created in Per Monitor v2 contexts will be scaling in a per-monitor fashion.</item>
            /// <item>Dialog Scaling - Win32 dialogs created in Per Monitor v2 contexts will automatically respond to DPI changes.</item>
            /// <item>Improved scaling of comctl32 controls - Various comctl32 controls have improved DPI scaling behavior in Per Monitor v2 contexts.</item>
            /// <item>Improved theming behavior - UxTheme handles opened in the context of a Per Monitor v2 window will operate in terms of the DPI associated with that window.</item>
            /// </list>
            /// </summary>
            public static readonly IntPtr DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = new IntPtr(-4);
        }
    }
}
