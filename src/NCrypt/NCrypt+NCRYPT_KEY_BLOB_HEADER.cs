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
        [StructLayout(LayoutKind.Sequential)]
        public struct NCRYPT_KEY_BLOB_HEADER
        {
            /// <summary>
            /// The size of this structure.
            /// </summary>
            public int cbSize;

            public MagicNumber dwMagic;

            /// <summary>
            /// The size of the algorithm, in bytes, including terminating 0.
            /// </summary>
            public int cbAlgName;

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
