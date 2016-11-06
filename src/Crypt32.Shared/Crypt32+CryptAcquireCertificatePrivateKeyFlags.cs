// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>Contains the <see cref="CryptAcquireCertificatePrivateKeyFlags" /> nested type.</content>
    public static partial class Crypt32
    {
        /// <summary>
        /// Defines the flags for <see cref="CryptAcquireCertificatePrivateKey(IntPtr,CryptAcquireCertificatePrivateKeyFlags,IntPtr,out IntPtr,out uint,out bool)"/> API as documented by https://msdn.microsoft.com/en-us/library/windows/desktop/aa379885(v=vs.85).aspx
        /// Flag values defined in the Platform SDK wincrypt.h
        /// </summary>
        [Flags]
        public enum CryptAcquireCertificatePrivateKeyFlags : uint
        {
            CRYPT_ACQUIRE_CACHE_FLAG = 0x00000001,
            CRYPT_ACQUIRE_USE_PROV_INFO_FLAG = 0x00000002,
            CRYPT_ACQUIRE_COMPARE_KEY_FLAG = 0x00000004,
            CRYPT_ACQUIRE_NO_HEALING = 0x00000008,
            CRYPT_ACQUIRE_SILENT_FLAG = 0x00000040,
            CRYPT_ACQUIRE_WINDOW_HANDLE_FLAG = 0x00000080,
            CRYPT_ACQUIRE_NCRYPT_KEY_FLAGS_MASK = 0x00070000,
            CRYPT_ACQUIRE_ALLOW_NCRYPT_KEY_FLAG = 0x00010000,
            CRYPT_ACQUIRE_PREFER_NCRYPT_KEY_FLAG = 0x00020000,
            CRYPT_ACQUIRE_ONLY_NCRYPT_KEY_FLAG = 0x00040000,
        }
    }
}
