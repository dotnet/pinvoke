// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains nested type <see cref="DPI_HOSTING_BEHAVIOR"/>.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Identifies the DPI hosting behavior for a window. This behavior allows windows created in the thread to host child windows with a different DPI_AWARENESS_CONTEXT.
        /// </summary>
        public enum DPI_HOSTING_BEHAVIOR : int
        {
            /// <summary>
            /// Invalid DPI hosting behavior. This usually occurs if the previous <see cref="SetThreadDpiHostingBehavior"/> call used an invalid parameter.
            /// </summary>
            DPI_HOSTING_BEHAVIOR_INVALID = -1,

            /// <summary>
            /// Default DPI hosting behavior. The associated window behaves as normal, and cannot create or re-parent child windows with a different DPI_AWARENESS_CONTEXT.
            /// </summary>
            DPI_HOSTING_BEHAVIOR_DEFAULT = 0,

            /// <summary>
            /// Mixed DPI hosting behavior. This enables the creation and re-parenting of child windows with different DPI_AWARENESS_CONTEXT. These child windows will be independently scaled by the OS.
            /// </summary>
            DPI_HOSTING_BEHAVIOR_MIXED = 1,
        }
    }
}
