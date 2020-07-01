// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
