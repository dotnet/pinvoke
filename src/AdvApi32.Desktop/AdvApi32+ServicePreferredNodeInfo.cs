// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="ServicePreferredNodeInfo"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Represents the preferred node on which to run a service.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ServicePreferredNodeInfo
        {
            /// <summary>
            /// The node number of the preferred node.
            /// </summary>
            public uint usPreferredNode;

            /// <summary>
            /// If this member is TRUE, the preferred node setting is deleted.
            /// </summary>
            public bool fDelete;
        }
    }
}
