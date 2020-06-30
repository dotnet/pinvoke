// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <content>
    /// Contains the <see cref="GetClassDevsFlags"/> nested type.
    /// </content>
    public partial class SetupApi
    {
        /// <summary>
        /// Controls how the device information element is opened.
        /// </summary>
        [Flags]
        public enum SetupDiOpenDeviceInfoFlags : uint
        {
            None = 0,

            /// <summary>
            /// If this flag is specified and the device had been marked for pending removal, the operating system cancels the pending removal.
            /// </summary>
            DIOD_CANCEL_REMOVE = 0x00000004,

            /// <summary>
            /// <para>
            /// If this flag is specified, the resulting device information element inherits the class driver list, if any, associated with the
            /// device information set. In addition, if there is a selected driver for the device information set, that same driver is selected
            /// for the new device information element.
            /// </para>
            /// <para>
            /// If the device information element was already present, its class driver list, if any, is replaced with the inherited list.
            /// </para>
            /// </summary>
            DIOD_INHERIT_CLASSDRVS = 0x00000002,
        }
    }
}
