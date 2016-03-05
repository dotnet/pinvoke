// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Used with the <see cref="BCryptEncrypt(SafeKeyHandle, byte[], void*, byte[], BCryptEncryptFlags)"/> and <see cref="BCryptDecrypt(SafeKeyHandle, byte[], void*, byte[], BCryptEncryptFlags)"/> functions
        /// to contain additional information related to authenticated cipher modes.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO
        {
            /// <summary>
            /// The version of the <see cref="BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO"/> struct.
            /// </summary>
            public const uint BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO_VERSION = 1;

            /// <summary>
            /// The size, in bytes, of this structure.
            /// Do not set this field directly. Use the <see cref="Create"/> method instead.
            /// </summary>
            public int cbSize;

            /// <summary>
            /// The version number of the structure.
            /// The only supported value is <see cref="BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO_VERSION"/>.
            /// Do not set this field directly. Use the <see cref="Create"/> method instead.
            /// </summary>
            public uint dwInfoVersion;

            /// <summary>
            /// A pointer to a buffer that contains a nonce.
            /// The Microsoft algorithm providers for Advanced Encryption Standard (AES)
            /// require a nonce for the Counter with CBC-MAC (CCM) and Galois/Counter Mode (GCM)
            /// chaining modes, and will return an error if none is present.
            /// If a nonce is not used, this member must be set to NULL.
            /// </summary>
            public byte* pbNonce;

            /// <summary>
            /// The size, in bytes, of the buffer pointed to by the <see cref="pbNonce"/> member.
            /// If a nonce is not used, this member must be set to zero.
            /// </summary>
            public int cbNonce;

            /// <summary>
            /// A pointer to a buffer that contains the authenticated data.
            /// This is data that will be included in the Message Authentication Code (MAC) but not encrypted.
            /// If there is no authenticated data, this member must be set to NULL.
            /// </summary>
            public byte* pbAuthData;

            /// <summary>
            /// The size, in bytes, of the buffer pointed to by the <see cref="pbAuthData"/> member.
            /// If there is no authenticated data, this member must be set to zero.
            /// </summary>
            public int cbAuthData;

            /// <summary>
            /// A pointer to a buffer.
            /// The use of this member depends on the function to which the structure is passed.
            /// For <see cref="BCryptEncrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/>
            /// the buffer will receive the authentication tag.
            /// For <see cref="BCryptDecrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/>
            /// the buffer contains the authentication tag to be checked against.
            /// If there is no tag, this member must be set to NULL.
            /// </summary>
            public byte* pbTag;

            /// <summary>
            /// The size, in bytes, of the <see cref="pbTag"/> buffer.
            /// The buffer must be long enough to include the whole authentication tag.
            /// Some authentication modes, such as CCM and GCM, support checking against a tag
            /// with multiple lengths. To obtain the valid authentication tag lengths use
            /// <see cref="BCryptGetProperty{T}(SafeHandle, string, BCryptGetPropertyFlags)"/> to query the <see cref="PropertyNames.BCRYPT_AUTH_TAG_LENGTH"/> property.
            /// If there is no tag, this member must be set to zero.
            /// </summary>
            public int cbTag;

            /// <summary>
            /// A pointer to a buffer that stores the partially computed MAC between calls to <see cref="BCryptEncrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> and <see cref="BCryptDecrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> when chaining encryption or decryption.
            /// If the input to encryption or decryption is scattered across multiple buffers, then you must chain calls to the <see cref="BCryptEncrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> and <see cref="BCryptDecrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> functions. Chaining is indicated by setting the <see cref="AuthModeFlags.BCRYPT_AUTH_MODE_IN_PROGRESS_FLAG"/> flag in the <see cref="dwFlags"/> member.
            /// This buffer must be supplied by the caller and must be at least as large as the maximum length of an authentication tag for the cipher you are using. To get the valid authentication tag lengths, use <see cref="BCryptGetProperty{T}(SafeHandle, string, BCryptGetPropertyFlags)"/> to query the <see cref="PropertyNames.BCRYPT_AUTH_TAG_LENGTH"/> property.
            /// If <see cref="BCryptEncrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> and <see cref="BCryptDecrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> calls are not being chained, this member must be set to NULL.
            /// </summary>
            public byte* pbMacContext;

            /// <summary>
            /// The size, in bytes, of the buffer pointed to by the <see cref="pbMacContext"/> member.
            /// If <see cref="BCryptEncrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> and <see cref="BCryptDecrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> calls are not being chained, this member must be set to zero.
            /// </summary>
            public int cbMacContext;

            /// <summary>
            /// The length, in bytes, of additional authenticated data (AAD) to be used by the <see cref="BCryptEncrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> and <see cref="BCryptDecrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> functions. This member is used only when chaining calls.
            /// This member is used only when the <see cref="AuthModeFlags.BCRYPT_AUTH_MODE_IN_PROGRESS_FLAG"/> flag in the <see cref="dwFlags"/> member is set.
            /// On the first call to <see cref="BCryptEncrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> or <see cref="BCryptDecrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> you must set this field to zero.
            /// Note: During the chaining sequence, this member is maintained internally and must not be changed or the value of the computed MAC will be corrupted.
            /// </summary>
            public int cbAAD;

            /// <summary>
            /// The length, in bytes, of the payload data that was encrypted or decrypted. This member is used only when chaining calls.
            /// This member is used only when the <see cref="AuthModeFlags.BCRYPT_AUTH_MODE_IN_PROGRESS_FLAG"/> flag in the <see cref="dwFlags"/> member is set.
            /// On the first call to <see cref="BCryptEncrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> or <see cref="BCryptDecrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> you must set this field to zero.
            /// Note: During the chaining sequence, this member is maintained internally and must not be changed or the value of the computed MAC will be corrupted.
            /// </summary>
            public long cbData;

            /// <summary>
            /// This flag is used when chaining <see cref="BCryptEncrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> or <see cref="BCryptDecrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> function calls.
            /// If calls are not being chained, this member must be set to zero.
            /// </summary>
            public AuthModeFlags dwFlags;

            /// <summary>
            /// Initializes a new instance of the <see cref="BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO"/> struct.
            /// </summary>
            /// <returns>An initialized instance.</returns>
            public static BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO Create()
            {
                return new BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO
                {
                    cbSize = Marshal.SizeOf(typeof(BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO)),
                    dwInfoVersion = BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO_VERSION,
                };
            }
        }
    }
}
