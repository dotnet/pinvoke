// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="FUSION_INSTALL_REFERENCE"/> nested type.
    /// </content>
    public partial class Fusion
    {
        /// <summary>
        /// Represents a reference that an application makes to an assembly that the application has installed in the global assembly cache.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct FUSION_INSTALL_REFERENCE
        {
            /// <summary>
            /// The assembly is referenced by an application that was installed using the Microsoft Windows Installer. The szIdentifier field is set to MSI, and the szNonCanonicalData field is set to Windows Installer. This scheme is used for Windows side-by-side assemblies.
            /// </summary>
            public static readonly Guid FUSION_REFCOUNT_MSI_GUID = new Guid(0x25df0fc1, 0x7f97, 0x4070, 0xad, 0xd7, 0x4b, 0x13, 0xbb, 0xfd, 0x7c, 0xb8);

            /// <summary>
            /// The assembly is referenced by an application that appears in the Add/Remove Programs interface. The szIdentifier field provides the token that registers the application with the Add/Remove Programs interface.
            /// </summary>
            public static readonly Guid FUSION_REFCOUNT_UNINSTALL_SUBKEY_GUID = new Guid(0x8cedc215, 0xac4b, 0x488b, 0x93, 0xc0, 0xa5, 0x0a, 0x49, 0xcb, 0x2f, 0xb8);

            /// <summary>
            /// The assembly is referenced by an application that is represented by a file in the file system. The szIdentifier field provides the path to this file.
            /// </summary>
            public static readonly Guid FUSION_REFCOUNT_FILEPATH_GUID = new Guid(0xb02f9d65, 0xfb77, 0x4f7a, 0xaf, 0xa5, 0xb3, 0x91, 0x30, 0x9f, 0x11, 0xc9);

            /// <summary>
            /// The assembly is referenced by an application that is represented only by an opaque string. The szIdentifier field provides this opaque string. The global assembly cache does not check for the existence of opaque references when you remove this value.
            /// </summary>
            public static readonly Guid FUSION_REFCOUNT_OPAQUE_STRING_GUID = new Guid(0x2ec93463, 0xb0c3, 0x45e1, 0x83, 0x64, 0x32, 0x7e, 0x96, 0xae, 0xa8, 0x56);

            /// <summary>
            /// This value is reserved.
            /// </summary>
            public static readonly Guid FUSION_REFCOUNT_OSINSTALL_GUID = new Guid(0xd16d444c, 0x56d8, 0x11d5, 0x88, 0x2d, 0x00, 0x80, 0xc8, 0x47, 0xb1, 0x95);

            /// <summary>
            /// The size of the structure in bytes.
            /// </summary>
            public uint cbSize;

            /// <summary>
            /// Reserved for future extensibility. This value must be 0 (zero).
            /// </summary>
            public FusionInstallReferenceFlags dwFlags;

            /// <summary>
            /// The entity that adds the reference.
            /// This field can have one of the following values:
            /// <see cref="FUSION_REFCOUNT_MSI_GUID"/>,
            /// <see cref="FUSION_REFCOUNT_FILEPATH_GUID"/>,
            /// <see cref="FUSION_REFCOUNT_OPAQUE_STRING_GUID"/>,
            /// <see cref="FUSION_REFCOUNT_OSINSTALL_GUID"/>,
            /// <see cref="FUSION_REFCOUNT_UNINSTALL_SUBKEY_GUID"/>
            /// </summary>
            public Guid guidScheme;

            /// <summary>
            /// A unique string that identifies the application that installed the assembly in the global assembly cache. Its value depends upon the value of the <see cref="guidScheme"/> field.
            /// </summary>
            public char* szIdentifier;

            /// <summary>
            /// A string that is understood only by the entity that adds the reference. The global assembly cache stores this string, but does not use it.
            /// </summary>
            public char* szNonCannonicalData;
        }
    }
}
