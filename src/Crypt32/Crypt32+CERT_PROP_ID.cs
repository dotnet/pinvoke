// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="CERT_PROP_ID"/> nested type.
    /// </content>
    public partial class Crypt32
    {
        /// <summary>
        /// Certificate property identifiers.
        /// </summary>
        public enum CERT_PROP_ID : uint
        {
            CERT_KEY_PROV_HANDLE_PROP_ID = 1,
            CERT_KEY_PROV_INFO_PROP_ID = 2,
            CERT_SHA1_HASH_PROP_ID = 3,
            CERT_MD5_HASH_PROP_ID = 4,
            CERT_KEY_CONTEXT_PROP_ID = 5,
            CERT_KEY_SPEC_PROP_ID = 6,
            CERT_IE30_RESERVED_PROP_ID = 7,
            CERT_PUBKEY_HASH_RESERVED_PROP_ID = 8,
            CERT_ENHKEY_USAGE_PROP_ID = 9,
            CERT_NEXT_UPDATE_LOCATION_PROP_ID = 10,
            CERT_FRIENDLY_NAME_PROP_ID = 11,
            CERT_PVK_FILE_PROP_ID = 12,
            CERT_DESCRIPTION_PROP_ID = 13,
            CERT_ACCESS_STATE_PROP_ID = 14,
            CERT_SIGNATURE_HASH_PROP_ID = 15,
            CERT_SMART_CARD_DATA_PROP_ID = 16,
            CERT_EFS_PROP_ID = 17,
            CERT_FORTEZZA_DATA_PROP_ID = 18,
            CERT_ARCHIVED_PROP_ID = 19,
            CERT_KEY_IDENTIFIER_PROP_ID = 20,
            CERT_AUTO_ENROLL_PROP_ID = 21,
            CERT_PUBKEY_ALG_PARA_PROP_ID = 22,
            CERT_CROSS_CERT_DIST_POINTS_PROP_ID = 23,
            CERT_ISSUER_PUBLIC_KEY_MD5_HASH_PROP_ID = 24,
            CERT_SUBJECT_PUBLIC_KEY_MD5_HASH_PROP_ID = 25,
            CERT_ENROLLMENT_PROP_ID = 26,
            CERT_DATE_STAMP_PROP_ID = 27,
            CERT_ISSUER_SERIAL_NUMBER_MD5_HASH_PROP_ID = 28,
            CERT_SUBJECT_NAME_MD5_HASH_PROP_ID = 29,
            CERT_EXTENDED_ERROR_INFO_PROP_ID = 30,
        }
    }
}
