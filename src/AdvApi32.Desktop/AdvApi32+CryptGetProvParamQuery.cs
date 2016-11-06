// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>Contains the <see cref="CryptGetProvParamQuery" /> nested type.</content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Defines the query types for <see cref="CryptGetProvParam(SafeHandle,CryptGetProvParamQuery,byte*,ref int,uint)"/> API
        /// as documented by https://msdn.microsoft.com/en-us/library/windows/desktop/aa380196(v=vs.85).aspx
        /// </summary>
        public enum CryptGetProvParamQuery : uint
        {
            PP_ADMIN_PIN = 0x1F,
            PP_APPLI_CERT = 0x12,
            PP_CHANGE_PASSWORD = 0x7,
            PP_CERTCHAIN = 0x9,
            PP_CONTAINER = 0x6,
            PP_CRYPT_COUNT_KEY_USE = 0x29,
            PP_ENUMALGS = 0x1,
            PP_ENUMALGS_EX = 0x16,
            PP_ENUMCONTAINERS = 0x2,
            PP_ENUMELECTROOTS = 0x1A,
            PP_ENUMEX_SIGNING_PROT = 0x28,
            PP_ENUMMANDROOTS = 0x19,
            PP_IMPTYPE = 0x3,
            PP_KEY_TYPE_SUBTYPE = 0xA,
            PP_KEYEXCHANGE_PIN = 0x20,
            PP_KEYSET_SEC_DESCR = 0x8,
            PP_KEYSET_TYPE = 0x1B,
            PP_KEYSPEC = 0x27,
            PP_KEYSTORAGE = 0x11,
            PP_KEYX_KEYSIZE_INC = 0x23,
            PP_NAME = 0x4,
            PP_PROVTYPE = 0x10,
            PP_ROOT_CERTSTORE = 0x2E,
            PP_SESSION_KEYSIZE = 0x14,
            PP_SGC_INFO = 0x25,
            PP_SIG_KEYSIZE_INC = 0x22,
            PP_SIGNATURE_PIN = 0x21,
            PP_SMARTCARD_GUID = 0x2D,
            PP_SMARTCARD_READER = 0x2B,
            PP_SYM_KEYSIZE = 0x13,
            PP_UI_PROMPT = 0x15,
            PP_UNIQUE_CONTAINER = 0x24,
            PP_USE_HARDWARE_RNG = 0x26,
            PP_USER_CERTSTORE = 0x2A,
            PP_VERSION = 0x5,
        }
    }
}
