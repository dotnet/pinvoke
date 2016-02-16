// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="OBJECT_ATTRIBUTES"/> nested struct.
    /// </content>
    public static partial class NTDll
    {
        /// <summary>
        /// The OBJECT_ATTRIBUTES structure specifies attributes that can be applied to objects or object handles by routines that create objects and/or return handles to objects.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct OBJECT_ATTRIBUTES
        {
            /// <summary>
            /// The number of bytes of data contained in this structure. The <see cref="Create"/> method sets this member to <c>sizeof(OBJECT_ATTRIBUTES)</c>.
            /// </summary>
            public int Length;

            /// <summary>
            /// Optional handle to the root object directory for the path name specified by the ObjectName member.
            /// If RootDirectory is NULL, <see cref="ObjectName"/> must point to a fully qualified object name that includes the full path to the target object.
            /// If RootDirectory is non-NULL, <see cref="ObjectName"/> specifies an object name relative to the RootDirectory directory.
            /// The RootDirectory handle can refer to a file system directory or an object directory in the object manager namespace.
            /// </summary>
            public IntPtr RootDirectory;

            /// <summary>
            /// A <see cref="UNICODE_STRING"/> that contains the name of the object for which a handle is to be opened.
            /// This must either be a fully qualified object name, or a relative path name to the directory specified by the <see cref="RootDirectory"/> member.
            /// </summary>
            public UNICODE_STRING* ObjectName;

            /// <summary>
            /// Bitmask of flags that specify object handle attributes.
            /// </summary>
            public ObjectHandleAttributes Attributes;

            /// <summary>
            /// Specifies a security descriptor (SECURITY_DESCRIPTOR) for the object when the object is created. If this member is NULL, the object will receive default security settings.
            /// </summary>
            public IntPtr SecurityDescriptor;

            /// <summary>
            /// Optional quality of service to be applied to the object when it is created. Used to indicate the security impersonation level and context tracking mode (dynamic or static). Currently, the InitializeObjectAttributes macro sets this member to <see langword="null"/>.
            /// </summary>
            public IntPtr SecurityQualityOfService;

            [Flags]
            public enum ObjectHandleAttributes
            {
                OBJ_INHERIT = 0x00000002,
                OBJ_PERMANENT = 0x00000010,
                OBJ_EXCLUSIVE = 0x00000020,
                OBJ_CASE_INSENSITIVE = 0x00000040,
                OBJ_OPENIF = 0x00000080,
                OBJ_OPENLINK = 0x00000100,
                OBJ_KERNEL_HANDLE = 0x00000200,
                OBJ_FORCE_ACCESS_CHECK = 0x00000400,
                OBJ_VALID_ATTRIBUTES = 0x000007F2,
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="OBJECT_ATTRIBUTES"/> structure.
            /// </summary>
            /// <returns>An <see cref="OBJECT_ATTRIBUTES"/> instance with <see cref="Length"/> initialized.</returns>
            public static OBJECT_ATTRIBUTES Create()
            {
                return new OBJECT_ATTRIBUTES
                {
                    Length = Marshal.SizeOf(typeof(OBJECT_ATTRIBUTES)),
                };
            }
        }
    }
}