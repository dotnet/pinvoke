// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="SECURITY_STATUS"/> nested type.
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

            /// <summary>Provider could not perform the action since the context was acquired as silent.</summary>
            NTE_SILENT_CONTEXT = 0x80090022,

            /// <summary>The security token does not have storage space available for an additional container.</summary>
            NTE_TOKEN_KEYSET_STORAGE_FULL = 0x80090023,

            /// <summary>The profile for the user is a temporary profile.</summary>
            NTE_TEMPORARY_PROFILE = 0x80090024,

            /// <summary>The key parameters could not be set because the CSP uses fixed parameters.</summary>
            NTE_FIXEDPARAMETER = 0x80090025,

            /// <summary>The supplied handle is invalid.</summary>
            NTE_INVALID_HANDLE = 0x80090026,

            /// <summary>The parameter is incorrect.</summary>
            NTE_INVALID_PARAMETER = 0x80090027,

            /// <summary>The supplied buffers overlap incorrectly.</summary>
            NTE_BUFFERS_OVERLAP = 0x8009002B,

            /// <summary>The specified data could not be decrypted.</summary>
            NTE_DECRYPTION_FAILURE = 0x8009002C,

            /// <summary>An internal consistency check failed.</summary>
            NTE_INTERNAL_ERROR = 0x8009002D,

            /// <summary>This operation requires input from the user.</summary>
            NTE_UI_REQUIRED = 0x8009002E,

            /// <summary>The cryptographic provider does not support HMAC.</summary>
            NTE_HMAC_NOT_SUPPORTED = 0x8009002F,

            /// <summary>The device that is required by this cryptographic provider is not ready for use.</summary>
            NTE_DEVICE_NOT_READY = 0x80090030,

            /// <summary>The dictionary attack mitigation is triggered and the provided authorization was ignored by the provider.</summary>
            NTE_AUTHENTICATION_IGNORED = 0x80090031,

            /// <summary>The validation of the provided data failed the integrity or signature validation.</summary>
            NTE_VALIDATION_FAILED = 0x80090032,

            /// <summary>Incorrect password.</summary>
            NTE_INCORRECT_PASSWORD = 0x80090033,

            /// <summary>Encryption failed.</summary>
            NTE_ENCRYPTION_FAILURE = 0x80090034,

            /// <summary>The device that is required by this cryptographic provider is not found on this platform.</summary>
            NTE_DEVICE_NOT_FOUND = 0x80090035,
        }
    }
}
