// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="PropertyNames"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Common property names to supply to <see cref="BCryptGetProperty(SafeHandle, string, BCryptGetPropertyFlags)"/>.
        /// </summary>
        /// <devremarks>
        /// Fill in summaries for each property as defined here: https://msdn.microsoft.com/en-us/library/windows/desktop/aa376211(v=vs.85).aspx
        /// </devremarks>
        public static class PropertyNames
        {
            /// <summary>
            /// The size, in bytes, of the subobject of a provider. This data type is a DWORD. Currently, the hash and symmetric cipher algorithm providers use caller-allocated buffers to store their subobjects. For example, the hash provider requires you to allocate memory for the hash object obtained with the BCryptCreateHash function. This property provides the buffer size for a provider's object so you can allocate memory for the object created by the provider.
            /// </summary>
            public const string BCRYPT_OBJECT_LENGTH = "ObjectLength";

            /// <summary>
            /// The name of the algorithm.
            /// </summary>
            public const string BCRYPT_ALGORITHM_NAME = "AlgorithmName";

            /// <summary>
            /// The handle of the CNG provider that created the object passed in the hObject parameter. This data type is a BCRYPT_ALG_HANDLE. This property can only be retrieved; it cannot be set.
            /// </summary>
            public const string BCRYPT_PROVIDER_HANDLE = "ProviderHandle";

            /// <summary>
            /// Represents the chaining mode of the encryption algorithm. This property can be set on an algorithm handle or a key handle to one of the following values
            /// specified in <see cref="ChainingModes"/>.
            /// </summary>
            public const string BCRYPT_CHAINING_MODE = "ChainingMode";

            /// <summary>
            /// The size, in bytes, of a cipher block for the algorithm. This property only applies to block cipher algorithms. This data type is a DWORD.
            /// </summary>
            public const string BCRYPT_BLOCK_LENGTH = "BlockLength";

            /// <summary>
            /// The size, in bits, of the key value of a symmetric key provider. This data type is a DWORD.
            /// </summary>
            public const string BCRYPT_KEY_LENGTH = "KeyLength";

            /// <summary>
            /// This property is not used. The <see cref="BCRYPT_OBJECT_LENGTH"/> property is used to obtain this information.
            /// </summary>
            public const string BCRYPT_KEY_OBJECT_LENGTH = "KeyObjectLength";

            /// <summary>
            /// The number of bits in the key. This data type is a DWORD. This property only applies to keys.
            /// </summary>
            public const string BCRYPT_KEY_STRENGTH = "KeyStrength";

            /// <summary>
            /// The key lengths that are supported by the algorithm. This property is a BCRYPT_KEY_LENGTHS_STRUCT structure. This property only applies to algorithms.
            /// </summary>
            public const string BCRYPT_KEY_LENGTHS = "KeyLengths";

            /// <summary>
            /// A list of the block lengths supported by an encryption algorithm. This data type is an array of DWORDs. The number of elements in the array can be determined by dividing the number of bytes retrieved by the size of a single DWORD.
            /// </summary>
            public const string BCRYPT_BLOCK_SIZE_LIST = "BlockSizeList";

            /// <summary>
            /// The size, in bits, of the effective length of an RC2 key. This data type is a DWORD.
            /// </summary>
            public const string BCRYPT_EFFECTIVE_KEY_LENGTH = "EffectiveKeyLength";

            /// <summary>
            /// The size, in bytes, of the hash value of a hash provider. This data type is a DWORD.
            /// </summary>
            public const string BCRYPT_HASH_LENGTH = "HashDigestLength";

            /// <summary>
            /// The list of DER-encoded hashing object identifiers (OIDs). This property is a BCRYPT_OID_LIST structure. This property can only be read.
            /// </summary>
            public const string BCRYPT_HASH_OID_LIST = "HashOIDList";

            /// <summary>
            /// Represents the padding scheme of the RSA algorithm provider. This data type is a DWORD.
            /// This can be one of the values specified in <see cref="BCrypt.PaddingSchemes"/>.
            /// </summary>
            public const string BCRYPT_PADDING_SCHEMES = "PaddingSchemes";

            /// <summary>
            /// The size, in bytes, of the length of a signature for a key. This data type is a DWORD. This property only applies to keys. This property can only be retrieved; it cannot be set.
            /// </summary>
            public const string BCRYPT_SIGNATURE_LENGTH = "SignatureLength";

            /// <summary>
            /// The size, in bytes, of the block for a hash. This property only applies to hash algorithms. This data type is a DWORD.
            /// </summary>
            public const string BCRYPT_HASH_BLOCK_LENGTH = "HashBlockLength";

            /// <summary>
            /// The authentication tag lengths that are supported by the algorithm. This property is a <see cref="BCRYPT_AUTH_TAG_LENGTHS_STRUCT"/> structure. This property only applies to algorithms.
            /// </summary>
            public const string BCRYPT_AUTH_TAG_LENGTH = "AuthTagLength";

            /// <summary>
            /// This can be set on any key handle that has the CFB chaining mode set. By default, this property is set to 1 for 8-bit CFB. Setting it to the block size in bytes causes full-block CFB to be used.
            /// </summary>
            public const string BCRYPT_MESSAGE_BLOCK_LENGTH = "MessageBlockLength";

            /// <summary>
            /// Specifies parameters to use with a Diffie-Hellman key. This data type is a pointer to a BCRYPT_DH_PARAMETER_HEADER structure. This property can only be set and must be set for the key before the key is completed.
            /// </summary>
            public const string BCRYPT_DH_PARAMETERS = "DHParameters";

            /// <summary>
            /// Specifies parameters to use with a DSA key. This property is a BCRYPT_DSA_PARAMETER_HEADER or a BCRYPT_DSA_PARAMETER_HEADER_V2 structure. This property can only be set and must be set for the key before the key is completed.
            /// Windows 8:  Beginning with Windows 8, this property can be a BCRYPT_DSA_PARAMETER_HEADER_V2 structure.Use this structure if the key size exceeds 1024 bits and is less than or equal to 3072 bits.If the key size is greater than or equal to 512 but less than or equal to 1024 bits, use the BCRYPT_DSA_PARAMETER_HEADER structure.
            /// </summary>
            public const string BCRYPT_DSA_PARAMETERS = "DSAParameters";

            /// <summary>
            /// Contains the initialization vector (IV) for a key. This property only applies to keys.
            /// </summary>
            public const string BCRYPT_INITIALIZATION_VECTOR = "IV";

            /// <summary>
            /// Undocumented.
            /// </summary>
            public const string BCRYPT_PRIMITIVE_TYPE = "PrimitiveType";

            /// <summary>
            /// Undocumented.
            /// </summary>
            public const string BCRYPT_IS_KEYED_HASH = "IsKeyedHash";

            /// <summary>
            /// Undocumented.
            /// </summary>
            public const string BCRYPT_IS_REUSABLE_HASH = "IsReusableHash";
        }
    }
}
