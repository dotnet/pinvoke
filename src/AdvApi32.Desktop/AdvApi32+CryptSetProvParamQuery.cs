// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>Contains the <see cref="CryptSetProvParamQuery" /> nested type.</content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Defines the query types for <see cref="CryptSetProvParam(SafeHandle,CryptSetProvParamQuery,byte*,uint)"/> API
        /// as documented by https://msdn.microsoft.com/en-us/library/windows/desktop/aa380276(v=vs.85).aspx
        /// </summary>
        public enum CryptSetProvParamQuery : uint
        {
            PP_CLIENT_HWND = 0x1,
            PP_DELETEKEY = 0x18,
            PP_KEYEXCHANGE_PIN = 0x20,
            PP_KEYSET_SEC_DESCR = 0x8,
            PP_PIN_PROMPT_STRING = 0x2C,
            PP_ROOT_CERTSTORE = 0x2E,
            PP_SIGNATURE_PIN = 0x21,
            PP_UI_PROMPT = 0x15,
            PP_USE_HARDWARE_RNG = 0x26,
            PP_USER_CERTSTORE = 0x2A,
            PP_SECURE_KEYEXCHANGE_PIN = 0x2F,
            PP_SECURE_SIGNATURE_PIN = 0x30,
            PP_SMARTCARD_READER = 0x2B,
            PP_SMARTCARD_GUID = 0x2D,
        }
    }
}
