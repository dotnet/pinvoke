// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <content>
    /// Contains the <see cref="DeviceInterfaceDataFlags"/> nested type.
    /// </content>
    public partial class SetupApi
    {
        /// <summary>
        /// The flags present in <see cref="SP_DEVICE_INTERFACE_DATA" /> structure.
        /// </summary>
        [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Original API names are used for consistency")]
        [Flags]
        public enum DeviceInterfaceDataFlags : uint
        {
            /// <summary>
            /// The interface is active (enabled).
            /// </summary>
            SPINT_ACTIVE,

            /// <summary>
            /// The interface is the default interface for the device class.
            /// </summary>
            SPINT_DEFAULT,

            /// <summary>
            /// The interface is removed.
            /// </summary>
            SPINT_REMOVED
        }
    }
}
