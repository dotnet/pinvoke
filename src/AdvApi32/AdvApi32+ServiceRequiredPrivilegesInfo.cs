// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="ServiceRequiredPrivilegesInfo"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Represents the required privileges for a service.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceRequiredPrivilegesInfo
        {
            /// <summary>
            /// A multi-string that specifies the privileges. For a list of possible values, see Privilege Constants.
            /// A multi-string is a sequence of null-terminated strings, terminated by an empty string (\0).
            /// <example>The following is an example:</example>
            /// <code>String1\0String2\0String3\0LastString\0\0</code>
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string pmszRequiredPrivileges;
        }
    }
}
