// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="BCRYPT_KEY_DATA_BLOB_HEADER"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Used to contain information about a key data BLOB. The key data BLOB must immediately follow this structure in memory.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct BCRYPT_KEY_DATA_BLOB_HEADER
        {
            /// <summary>
            /// The version of the <see cref="BCRYPT_KEY_DATA_BLOB_HEADER"/> struct.
            /// </summary>
            public const uint BCRYPT_KEY_DATA_BLOB_VERSION1 = 1;

            /// <summary>
            /// The magic value for the key.
            /// This member must be the following value: <see cref="MagicNumber.BCRYPT_KEY_DATA_BLOB_MAGIC"/>
            /// </summary>
            public MagicNumber dwMagic;

            /// <summary>
            /// Contains the numeric version of the key.
            /// </summary>
            public uint dwVersion;

            /// <summary>
            /// The size, in bytes, of the key data.
            /// </summary>
            public int cbKeyData;

            /// <summary>
            /// Values for the <see cref="dwMagic"/> field.
            /// </summary>
            public enum MagicNumber : uint
            {
                BCRYPT_KEY_DATA_BLOB_MAGIC = 0x4d42444b,
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="BCRYPT_KEY_DATA_BLOB_HEADER"/> struct.
            /// </summary>
            /// <param name="cbKeyData">The size, in bytes, of the key data.</param>
            /// <returns>The initialized instance.</returns>
            public static BCRYPT_KEY_DATA_BLOB_HEADER Create(int cbKeyData = 0)
            {
                return new BCRYPT_KEY_DATA_BLOB_HEADER
                {
                    dwMagic = MagicNumber.BCRYPT_KEY_DATA_BLOB_MAGIC,
                    dwVersion = BCRYPT_KEY_DATA_BLOB_VERSION1,
                    cbKeyData = cbKeyData,
                };
            }

            /// <summary>
            /// Initializes a key header and returns a buffer with that and the specified key material.
            /// </summary>
            /// <param name="keyMaterial">The symmetric secret.</param>
            /// <returns>A buffer with the symmetric secret, and a header.</returns>
            public static byte[] InsertBeforeKey(byte[] keyMaterial)
            {
                if (keyMaterial == null)
                {
                    throw new ArgumentNullException(nameof(keyMaterial));
                }

                var header = Create(keyMaterial.Length);
                return header.AddHeaderToKey(keyMaterial);
            }

            private byte[] AddHeaderToKey(byte[] keyMaterial)
            {
                int headerLength = Marshal.SizeOf(typeof(BCRYPT_KEY_DATA_BLOB_HEADER));
                byte[] keyWithHeader = new byte[headerLength + keyMaterial.Length];
                Array.Copy(BitConverter.GetBytes((uint)this.dwMagic), keyWithHeader, sizeof(uint));
                Array.Copy(BitConverter.GetBytes(this.dwVersion), 0, keyWithHeader, sizeof(uint), sizeof(uint));
                Array.Copy(BitConverter.GetBytes(this.cbKeyData), 0, keyWithHeader, sizeof(uint) * 2, sizeof(int));
                Array.Copy(keyMaterial, 0, keyWithHeader, headerLength, keyMaterial.Length);
                return keyWithHeader;
            }
        }
    }
}
