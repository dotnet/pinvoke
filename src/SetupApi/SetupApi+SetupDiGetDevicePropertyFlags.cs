// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="SetupDiGetDevicePropertyFlags"/> nested type.
    /// </content>
    public partial class SetupApi
    {
        /// <summary>
        /// Flags for the <see cref="SetupDiGetDeviceProperty(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DEVPROPKEY*, uint*, byte*, uint, uint*, SetupDiGetDevicePropertyFlags)"/> method.
        /// </summary>
        [Flags]
        public enum SetupDiGetDevicePropertyFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0,
        }
    }
}
