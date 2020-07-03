// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SC_ACTION"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Represents an action that the service control manager can perform.
        /// </summary>
        public struct SC_ACTION
        {
            /// <summary>
            /// The action to be performed.
            /// This member can be one of the following values from the <see cref="SC_ACTION_TYPE"/> enumeration type.
            /// </summary>
            public SC_ACTION_TYPE Type;

            /// <summary>
            /// The time to wait before performing the specified action, in milliseconds.
            /// </summary>
            public uint Delay;
        }
    }
}
