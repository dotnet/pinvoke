// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <content>
    /// Contains the <see cref="DEVPROPKEY"/> nested type.
    /// </content>
    public partial class SetupApi
    {
        /// <summary>
        /// In Windows Vista and later versions of Windows, the DEVPROPKEY structure represents a device property key for a device property in the
        /// <see href="https://docs.microsoft.com/windows-hardware/drivers/install/unified-device-property-model--windows-vista-and-later-">unified device property model</see>.
        /// </summary>
        public struct DEVPROPKEY
        {
            /// <summary>
            /// A value that specifies a property category.
            /// </summary>
            public Guid fmtid;

            /// <summary>
            /// A value that uniquely identifies the property within the property category. For internal system reasons, a property identifier must be greater than or equal to two.
            /// </summary>
            public uint pid;
        }
    }
}
