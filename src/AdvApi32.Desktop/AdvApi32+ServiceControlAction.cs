// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="ServiceControlAction"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Represents an action that the service control manager can perform.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceControlAction
        {
            /// <summary>
            /// The action to be performed.
            /// This member can be one of the following values from the <see cref="ServiceControlActionType"/> enumeration type.
            /// </summary>
            public ServiceControlActionType Type;

            /// <summary>
            /// The time to wait before performing the specified action, in milliseconds.
            /// </summary>
            public int Delay;
        }
    }
}