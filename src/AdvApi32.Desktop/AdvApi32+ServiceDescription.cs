// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="ServiceDescription"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Contains a service description.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceDescription
        {
            /// <summary>
            /// The description of the service. If this member is NULL, the description remains unchanged.
            /// If this value is an empty string (""), the current description is deleted.
            /// The service description must not exceed the size of a registry value of type REG_SZ.
            /// </summary>
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpDescription;
        }
    }
}
