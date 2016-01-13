// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="NCryptSetPropertyFlags"/> nested type.
    /// </content>
    public static partial class NCrypt
    {
        /// <summary>
        /// Flags that may be supplied to the <see cref="NCryptSetProperty(System.Runtime.InteropServices.SafeHandle, string, byte*, int, NCryptSetPropertyFlags)"/> function.
        /// </summary>
        public enum NCryptSetPropertyFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Ignore any built in values for this property and only retrieve the user-persisted properties of the key. The maximum size of the data for any persisted property is NCRYPT_MAX_PROPERTY_DATA bytes.
            /// </summary>
            NCRYPT_PERSIST_ONLY_FLAG = 0x40000000,

            /// <summary>
            /// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
            /// </summary>
            NCRYPT_SILENT_FLAG = 0x00000040,

            /// <summary>
            /// Retrieve the security identifier (SID) of the object's owner. Use the GetSecurityDescriptorOwner function to obtain the owner SID from the SECURITY_DESCRIPTOR structure.
            /// </summary>
            OWNER_SECURITY_INFORMATION = 0x00000001,

            /// <summary>
            /// Retrieve the SID of the object's primary group. Use the GetSecurityDescriptorGroup function to obtain the group SID from the SECURITY_DESCRIPTOR structure.
            /// </summary>
            GROUP_SECURITY_INFORMATION = 0x00000002,

            /// <summary>
            /// Retrieve the discretionary access control list (DACL). Use the GetSecurityDescriptorSacl function to obtain the DACL from the SECURITY_DESCRIPTOR structure.
            /// </summary>
            DACL_SECURITY_INFORMATION = 0x00000004,

            /// <summary>
            /// Retrieve the system access control list (SACL). Use the GetSecurityDescriptorDacl function to obtain the SACL from the SECURITY_DESCRIPTOR structure.
            /// </summary>
            SACL_SECURITY_INFORMATION = 0x00000008,

            /// <summary>
            /// Set the mandatory label access control entry in the SACL of the object. Use the SetSecurityDescriptorDacl function to set the SACL in the SECURITY_DESCRIPTOR structure. For more information about the mandatory label access control entry, see Windows Integrity Mechanism Design.
            /// </summary>
            LABEL_SECURITY_INFORMATION = 0x00000010,
        }
    }
}
