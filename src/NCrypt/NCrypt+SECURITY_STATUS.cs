// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="SECURITY_STATUS"/> nested enum.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// Describes the error codes that may be returned from NCrypt functions.
        /// </summary>
        /// <remarks>
        /// These values are encoded as <see cref="HResult"/> with <see cref="HResult.FacilityCode.FACILITY_SECURITY"/> as the facility code.
        /// </remarks>
        public enum SECURITY_STATUS : uint
        {
            /// <summary>
            /// The operation completed successfully.
            /// </summary>
            ERROR_SUCCESS = 0,

            /// <summary>Bad UID.</summary>
            NTE_BAD_UID = 0x80090001,

            /// <summary>Bad hash.</summary>
            NTE_BAD_HASH = 0x80090002,

            /// <summary>Bad key.</summary>
            NTE_BAD_KEY = 0x80090003,

            /// <summary>Bad length.</summary>
            NTE_BAD_LEN = 0x80090004,

            /// <summary>Bad data.</summary>
            NTE_BAD_DATA = 0x80090005,

            /// <summary>Invalid signature.</summary>
            NTE_BAD_SIGNATURE = 0x80090006,

            /// <summary>Bad version of provider.</summary>
            NTE_BAD_VER = 0x80090007,

            /// <summary>Invalid algorithm specified.</summary>
            NTE_BAD_ALGID = 0x80090008,

            /// <summary>Invalid flags specified.</summary>
            NTE_BAD_FLAGS = 0x80090009,

            /// <summary>Invalid type specified.</summary>
            NTE_BAD_TYPE = 0x8009000A,

            /// <summary>Key not valid for use in specified state.</summary>
            NTE_BAD_KEY_STATE = 0x8009000B,

            /// <summary>Hash not valid for use in specified state.</summary>
            NTE_BAD_HASH_STATE = 0x8009000C,

            /// <summary>Key does not exist.</summary>
            NTE_NO_KEY = 0x8009000D,

            /// <summary>Insufficient memory available for the operation.</summary>
            NTE_NO_MEMORY = 0x8009000E,

            /// <summary>Object already exists.</summary>
            NTE_EXISTS = 0x8009000F,

            /// <summary>Access denied.</summary>
            NTE_PERM = 0x80090010,

            /// <summary>Object was not found.</summary>
            NTE_NOT_FOUND = 0x80090011,

            /// <summary>Data already encrypted.</summary>
            NTE_DOUBLE_ENCRYPT = 0x80090012,

            /// <summary>Invalid provider specified.</summary>
            NTE_BAD_PROVIDER = 0x80090013,

            /// <summary>Invalid provider type specified.</summary>
            NTE_BAD_PROV_TYPE = 0x80090014,

            /// <summary>Invalid provider public key.</summary>
            NTE_BAD_PUBLIC_KEY = 0x80090015,

            /// <summary>Keyset does not exist</summary>
            NTE_BAD_KEYSET = 0x80090016,

            /// <summary>Provider type not defined.</summary>
            NTE_PROV_TYPE_NOT_DEF = 0x80090017,

            /// <summary>Invalid registration for provider type.</summary>
            NTE_PROV_TYPE_ENTRY_BAD = 0x80090018,

            /// <summary>The keyset not defined.</summary>
            NTE_KEYSET_NOT_DEF = 0x80090019,

            /// <summary>Invalid keyset registration.</summary>
            NTE_KEYSET_ENTRY_BAD = 0x8009001A,

            /// <summary>Provider type does not match registered value.</summary>
            NTE_PROV_TYPE_NO_MATCH = 0x8009001B,

            /// <summary>Corrupt digital signature file.</summary>
            NTE_SIGNATURE_FILE_BAD = 0x8009001C,

            /// <summary>Provider DLL failed to initialize correctly.</summary>
            NTE_PROVIDER_DLL_FAIL = 0x8009001D,

            /// <summary>Provider DLL not found.</summary>
            NTE_PROV_DLL_NOT_FOUND = 0x8009001E,

            /// <summary>Invalid keyset parameter.</summary>
            NTE_BAD_KEYSET_PARAM = 0x8009001F,

            /// <summary>Internal error occurred.</summary>
            NTE_FAIL = 0x80090020,

            /// <summary>Base error occurred.</summary>
            NTE_SYS_ERR = 0x80090021,

            /// <summary>The buffer supplied to a function was too small.</summary>
            NTE_BUFFER_TOO_SMALL = 0x80090028,

            /// <summary>The requested operation is not supported.</summary>
            NTE_NOT_SUPPORTED = 0x80090029,

            /// <summary>No more data is available.</summary>
            NTE_NO_MORE_ITEMS = 0x8009002a,
        }
    }
}
