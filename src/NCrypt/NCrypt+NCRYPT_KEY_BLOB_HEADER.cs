// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <content>
    /// Contains the <see cref="NCRYPT_KEY_BLOB_HEADER"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// Contains a key BLOB. This structure is used by the <see cref="NCryptExportKey(SafeKeyHandle, SafeKeyHandle, string, NCryptBufferDesc*, byte[], int, out int, NCryptExportKeyFlags)"/> and <see cref="NCryptImportKey(SafeProviderHandle, SafeKeyHandle, string, NCryptBufferDesc*, out SafeKeyHandle, byte*, int, NCryptExportKeyFlags)"/> functions.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct NCRYPT_KEY_BLOB_HEADER
        {
            /// <summary>
            /// The size of this structure.
            /// </summary>
            public int cbSize;

            /// <summary>
            /// Identifies the BLOB type.
            /// </summary>
            public MagicNumber dwMagic;

            /// <summary>
            /// Size, in bytes, of the null-terminated algorithm name, including the terminating zero.
            /// </summary>
            public int cbAlgName;

            /// <summary>
            /// Size, in bytes, of the BLOB.
            /// </summary>
            public int cbKeyData;

            /// <summary>
            /// The values that may be expected in the <see cref="dwMagic"/> field.
            /// </summary>
            public enum MagicNumber : uint
            {
                NCRYPT_CIPHER_KEY_BLOB_MAGIC = 0x52485043, // CPHR
                NCRYPT_PROTECTED_KEY_BLOB_MAGIC = 0x4B545250, // PRTK
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="NCRYPT_KEY_BLOB_HEADER"/> struct
            /// with the <see cref="cbSize"/> field set appropriately.
            /// </summary>
            /// <returns>An initialized instance of the struct.</returns>
            public static NCRYPT_KEY_BLOB_HEADER Create()
            {
                return new NCRYPT_KEY_BLOB_HEADER
                {
                    cbSize = Marshal.SizeOf(typeof(NCRYPT_KEY_BLOB_HEADER)),
                };
            }
        }
    }
}
