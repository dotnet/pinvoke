// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="BCRYPT_KEY_DATA_BLOB_HEADER"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Used to contain information about a key data BLOB. The key data BLOB must immediately follow this structure in memory.
        /// </summary>
        public struct BCRYPT_KEY_DATA_BLOB_HEADER
        {
            /// <summary>
            /// The magic value for the key.
            /// This member must be the following value.
            /// BCRYPT_KEY_DATA_BLOB_MAGIC (0x4d42444b)
            /// </summary>
            public uint dwMagic;

            /// <summary>
            /// Contains the numeric version of the key.
            /// </summary>
            public uint dwVersion;

            /// <summary>
            /// The size, in bytes, of the key data.
            /// </summary>
            public int cbKeyData;

            /// <summary>
            /// Initializes a new instance of the <see cref="BCRYPT_KEY_DATA_BLOB_HEADER"/> struct.
            /// </summary>
            /// <param name="cbKeyData">The size, in bytes, of the key data.</param>
            /// <returns>The initialized instance.</returns>
            public static BCRYPT_KEY_DATA_BLOB_HEADER Create(int cbKeyData = 0)
            {
                return new BCRYPT_KEY_DATA_BLOB_HEADER
                {
                    dwMagic = 0x4d42444b,
                    dwVersion = BCRYPT_KEY_DATA_BLOB_VERSION1,
                    cbKeyData = cbKeyData,
                };
            }
        }
    }
}
