// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="OBJECT_ATTRIBUTES"/> nested type.
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
            public Kernel32.SECURITY_DESCRIPTOR* SecurityDescriptor;

            /// <summary>
            /// Optional quality of service to be applied to the object when it is created. Used to indicate the security impersonation level and context tracking mode (dynamic or static). Currently, the InitializeObjectAttributes macro sets this member to <see langword="null"/>.
            /// </summary>
            public void* SecurityQualityOfService;

            /// <summary>
            /// Possible flags for the <see cref="Attributes"/> field.
            /// </summary>
            [Flags]
            public enum ObjectHandleAttributes
            {
                /// <summary>
                /// This handle can be inherited by child processes of the current process.
                /// </summary>
                OBJ_INHERIT = 0x00000002,

                /// <summary>
                /// This flag only applies to objects that are named within the object manager. By default, such objects are deleted when all open handles to them are closed. If this flag is specified, the object is not deleted when all open handles are closed. Drivers can use the ZwMakeTemporaryObject routine to make a permanent object non-permanent.
                /// </summary>
                OBJ_PERMANENT = 0x00000010,

                /// <summary>
                /// If this flag is set and the <see cref="OBJECT_ATTRIBUTES"/> structure is passed to a routine that creates an object, the object can be accessed exclusively. That is, once a process opens such a handle to the object, no other processes can open handles to this object.
                /// If this flag is set and the <see cref="OBJECT_ATTRIBUTES"/> structure is passed to a routine that creates an object handle, the caller is requesting exclusive access to the object for the process context that the handle was created in. This request can be granted only if the OBJ_EXCLUSIVE flag was set when the object was created.
                /// </summary>
                OBJ_EXCLUSIVE = 0x00000020,

                /// <summary>
                /// If this flag is specified, a case-insensitive comparison is used when matching the name pointed to by the ObjectName member against the names of existing objects. Otherwise, object names are compared using the default system settings.
                /// </summary>
                OBJ_CASE_INSENSITIVE = 0x00000040,

                /// <summary>
                /// If this flag is specified, by using the object handle, to a routine that creates objects and if that object already exists, the routine should open that object. Otherwise, the routine creating the object returns an NTSTATUS code of STATUS_OBJECT_NAME_COLLISION.
                /// </summary>
                OBJ_OPENIF = 0x00000080,

                /// <summary>
                /// If an object handle, with this flag set, is passed to a routine that opens objects and if the object is a symbolic link object, the routine should open the symbolic link object itself, rather than the object that the symbolic link refers to (which is the default behavior).
                /// </summary>
                OBJ_OPENLINK = 0x00000100,

                /// <summary>
                /// The handle is created in system process context and can only be accessed from kernel mode.
                /// </summary>
                OBJ_KERNEL_HANDLE = 0x00000200,

                /// <summary>
                /// The routine that opens the handle should enforce all access checks for the object, even if the handle is being opened in kernel mode.
                /// </summary>
                OBJ_FORCE_ACCESS_CHECK = 0x00000400,

                /// <summary>
                /// The mask of all valid attributes.
                /// </summary>
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