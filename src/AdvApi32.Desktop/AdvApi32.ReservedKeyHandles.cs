// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using Microsoft.Win32.SafeHandles;

    /// <content>
    /// Contains the special reserved registry key handles.
    /// </content>
    public partial class AdvApi32
    {
        public static readonly SafeRegistryHandle HKEY_CLASSES_ROOT
            = new SafeRegistryHandle((IntPtr)unchecked((int)0x80000000), false);

        public static readonly SafeRegistryHandle HKEY_CURRENT_USER
            = new SafeRegistryHandle((IntPtr)unchecked((int)0x80000001), false);

        public static readonly SafeRegistryHandle HKEY_LOCAL_MACHINE
            = new SafeRegistryHandle((IntPtr)unchecked((int)0x80000002), false);

        public static readonly SafeRegistryHandle HKEY_USERS
            = new SafeRegistryHandle((IntPtr)unchecked((int)0x80000003), false);

        public static readonly SafeRegistryHandle HKEY_PERFORMANCE_DATA
            = new SafeRegistryHandle((IntPtr)unchecked((int)0x80000004), false);

        public static readonly SafeRegistryHandle HKEY_PERFORMANCE_TEXT
            = new SafeRegistryHandle((IntPtr)unchecked((int)0x80000050), false);

        public static readonly SafeRegistryHandle HKEY_PERFORMANCE_NLSTEXT
            = new SafeRegistryHandle((IntPtr)unchecked((int)0x80000060), false);

        public static readonly SafeRegistryHandle HKEY_CURRENT_CONFIG
            = new SafeRegistryHandle((IntPtr)unchecked((int)0x80000005), false);

        public static readonly SafeRegistryHandle HKEY_DYN_DATA
            = new SafeRegistryHandle((IntPtr)unchecked((int)0x80000006), false);

        public static readonly SafeRegistryHandle HKEY_CURRENT_USER_LOCAL_SETTINGS
            = new SafeRegistryHandle((IntPtr)unchecked((int)0x80000007), false);
    }
}
