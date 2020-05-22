// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="BCRYPT_MULTI_HASH_OPERATION"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// A <see cref="BCRYPT_MULTI_HASH_OPERATION"/> structure defines a single operation in a multi-hash operation.
        /// </summary>
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct BCRYPT_MULTI_HASH_OPERATION
        {
            /// <summary>
            /// An index into the multi-object state array of the hash state on which this computation operates.
            /// The first element of the array corresponds to an iHash value of zero (0).
            /// Valid values are less than the value of the nHashes parameter of the <see cref="BCryptCreateMultiHash(SafeAlgorithmHandle, out SafeHashHandle, int, byte*, int, byte*, int, BCryptCreateHashFlags)"/> function.
            /// </summary>
            public int iHash;

            /// <summary>
            /// A hash operation type.
            /// If the value is <see cref="HashOperationType.BCRYPT_HASH_OPERATION_HASH_DATA"/>, the operation performed is equivalent to calling the <see cref="BCryptHashData(SafeHashHandle, byte[], int, BCryptHashDataFlags)"/> function on the hash object array element with <see cref="pbBuffer"/>/<see cref="cbBuffer"/> pointing to the buffer to be hashed.
            /// If the value is <see cref="HashOperationType.BCRYPT_HASH_OPERATION_FINISH_HASH"/>, the operation performed is equivalent to calling the <see cref="BCryptFinishHash(SafeHashHandle, byte[], int, BCryptFinishHashFlags)"/> function on the hash object array element with <see cref="pbBuffer"/>/<see cref="cbBuffer"/> pointing to the output buffer that receives the result.
            /// </summary>
            public HashOperationType hashOperation;

            /// <summary>
            /// The buffer on which the operation works.
            /// </summary>
            public byte* pbBuffer;

            /// <summary>
            /// The buffer on which the operation works.
            /// </summary>
            public int cbBuffer;
        }
    }
}
