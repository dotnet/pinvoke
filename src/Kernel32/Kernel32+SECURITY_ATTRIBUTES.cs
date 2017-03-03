// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

#pragma warning disable SA1401 // Fields must be private

    /// <content>
    /// Contains the <see cref="SECURITY_ATTRIBUTES"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// The SECURITY_ATTRIBUTES structure contains the security descriptor for an object and specifies whether the handle retrieved by specifying this structure is inheritable. This structure provides security settings for objects created by various functions, such as CreateFile, CreatePipe, CreateProcess, RegCreateKeyEx, or RegSaveKeyEx.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_ATTRIBUTES
        {
            /// <summary>
            /// The size, in bytes, of this structure.
            /// This value is set by the constructor to the size of the <see cref="SECURITY_ATTRIBUTES"/> structure.
            /// </summary>
            public int nLength;

            /// <summary>
            /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure that controls access to the object. If the value of this member is NULL, the object is assigned the default security descriptor associated with the access token of the calling process. This is not the same as granting access to everyone by assigning a NULL discretionary access control list (DACL). By default, the default DACL in the access token of a process allows access only to the user represented by the access token.
            /// For information about creating a security descriptor, see Creating a Security Descriptor.
            /// </summary>
            public IntPtr lpSecurityDescriptor;

            /// <summary>
            /// A Boolean value that specifies whether the returned handle is inherited when a new process is created. If this member is TRUE, the new process inherits the handle.
            /// </summary>
            public int bInheritHandle;

            /// <summary>
            /// Gets a value indicating whether the returned handle is inherited when a new process is created. If this member is TRUE, the new process inherits the handle.
            /// </summary>
            public bool InheritHandle => this.bInheritHandle != 0;

            /// <summary>
            /// Initializes a new instance of the <see cref="SECURITY_ATTRIBUTES"/> struct.
            /// </summary>
            /// <returns>A new instance of <see cref="SECURITY_ATTRIBUTES"/>.</returns>
            public static SECURITY_ATTRIBUTES Create()
            {
                return new SECURITY_ATTRIBUTES
                {
                    nLength = Marshal.SizeOf(typeof(SECURITY_ATTRIBUTES)),
                };
            }
        }
    }
}
