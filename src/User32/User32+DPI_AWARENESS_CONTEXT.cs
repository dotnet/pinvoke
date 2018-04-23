// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains nested type <see cref="DPI_AWARENESS_CONTEXT"/>
    /// </summary>
    public partial class User32
    {
        /// <summary>
        /// Identifies the awareness context for a window.
        /// </summary>
        /// <remarks>DPI_AWARENESS_CONTEXT values should never be compared directly. Instead, use <see cref="AreDpiAwarenessContextsEqual"/></remarks>
        public class DPI_AWARENESS_CONTEXT : SafeHandle
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DPI_AWARENESS_CONTEXT"/> class.
            /// </summary>
            public DPI_AWARENESS_CONTEXT()
                : this(IntPtr.Zero)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="DPI_AWARENESS_CONTEXT"/> class.
            /// </summary>
            /// <param name="preexistingHandle">Native handle representing the DPI_AWARENESS_CONTEXT</param>
            /// <remarks>
            /// <list type="bullet">
            /// <item>There is no default constructor because this class must always be instantiated with a native handle</item>
            /// <item>This handle type is not 'owned', and <see cref="ReleaseHandle"/> never needs to be called</item>
            /// </list>
            /// </remarks>
            public DPI_AWARENESS_CONTEXT(IntPtr preexistingHandle)
                : base(IntPtr.Zero, false) => this.SetHandle(preexistingHandle);

            /// <summary>
            /// Gets DPI unaware. This window does not scale for DPI changes and is always assumed to have a scale factor of 100% (96 DPI). It will be automatically scaled by the system on any other DPI setting.
            /// </summary>
            public static DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_UNAWARE { get; } = new DPI_AWARENESS_CONTEXT(new IntPtr(-1));

            /// <summary>
            /// Gets System DPI aware. This window does not scale for DPI changes. It will query for the DPI once and use that value for the lifetime of the process. If the DPI changes, the process will not adjust to the new DPI value. It will be automatically scaled up or down by the system when the DPI changes from the system value.
            /// </summary>
            public static DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_SYSTEM_AWARE { get; } = new DPI_AWARENESS_CONTEXT(new IntPtr(-2));

            /// <summary>
            /// Gets Per monitor DPI aware. This window checks for the DPI when it is created and adjusts the scale factor whenever the DPI changes. These processes are not automatically scaled by the system.
            /// </summary>
            public static DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE { get; } = new DPI_AWARENESS_CONTEXT(new IntPtr(-3));

            /// <summary>
            /// Gets Per Monitor DPI aware v2. An advancement over the original per-monitor DPI awareness mode, which enables applications to access new DPI-related scaling behaviors on a per top-level window basis.
            /// Per Monitor v2 was made available in the Creators Update of Windows 10, and is not available on earlier versions of the operating system.
            /// The additional behaviors introduced are as follows:
            /// <list type="bullet">
            /// <item>Child window DPI change notifications - In Per Monitor v2 contexts, the entire window tree is notified of any DPI changes that occur.</item>
            /// <item>Scaling of non-client area - All windows will automatically have their non-client area drawn in a DPI sensitive fashion.Calls to EnableNonClientDpiScaling are unnecessary.</item>
            /// <item>Scaling of Win32 menus - All NTUSER menus created in Per Monitor v2 contexts will be scaling in a per-monitor fashion.</item>
            /// <item>Dialog Scaling - Win32 dialogs created in Per Monitor v2 contexts will automatically respond to DPI changes.</item>
            /// <item>Improved scaling of comctl32 controls - Various comctl32 controls have improved DPI scaling behavior in Per Monitor v2 contexts.</item>
            /// <item>Improved theming behavior - UxTheme handles opened in the context of a Per Monitor v2 window will operate in terms of the DPI associated with that window.</item>
            /// </list>
            /// </summary>
            public static DPI_AWARENESS_CONTEXT DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 { get; } = new DPI_AWARENESS_CONTEXT(new IntPtr(-4));

            /// <summary>
            /// Gets NULL handle
            /// </summary>
            public static DPI_AWARENESS_CONTEXT NULL { get; } = new DPI_AWARENESS_CONTEXT(IntPtr.Zero);

            /// <summary>
            /// Gets a value indicating whether a DPI_AWARENESS_CONTEXT handle is invalid
            /// </summary>
            public override bool IsInvalid => !IsValidDpiAwarenessContext(this.DangerousGetHandle());

            /// <summary>
            /// Releases the handle
            /// </summary>
            /// <returns>Always returns true</returns>
            /// <remarks>
            /// DPI_AWARENESS_CONTEXT handles do not require to be released, i.e.,
            /// these aren't really 'owned', so just return true and do nothing
            /// </remarks>
            protected override bool ReleaseHandle() => true;
        }
    }
}
