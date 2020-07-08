// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <content>
    /// Contains the <see cref="DriverType"/> nested type.
    /// </content>
    public partial class SetupApi
    {
        /// <summary>
        /// Specifies which types of drivers are to be retrieved.
        /// </summary>
        [Flags]
        public enum DriverType : uint
        {
            /// <summary>
            /// Don't build a driver list.
            /// </summary>
            SPDIT_NODRIVER = 0x00000000,

            /// <summary>
            /// Build a list of class drivers.
            /// </summary>
            SPDIT_CLASSDRIVER = 0x00000001,

            /// <summary>
            /// Build a list of compatible drivers.
            /// </summary>
            SPDIT_COMPATDRIVER = 0x00000002,
        }
    }
}
