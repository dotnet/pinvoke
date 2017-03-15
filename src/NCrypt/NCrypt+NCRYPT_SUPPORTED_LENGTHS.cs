// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="NCRYPT_SUPPORTED_LENGTHS"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// A structure is used with the <see cref="KeyStoragePropertyIdentifiers.NCRYPT_LENGTHS_PROPERTY"/> property to contain length information for a key.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct NCRYPT_SUPPORTED_LENGTHS : IEnumerable<int>
        {
            /// <summary>
            /// The minimum length, in bits, of a key.
            /// </summary>
            public int dwMinLength;

            /// <summary>
            /// The maximum length, in bits, of a key.
            /// </summary>
            public int dwMaxLength;

            /// <summary>
            /// The number of bits that the key size can be incremented between dwMinLength and dwMaxLength.
            /// </summary>
            public int dwIncrement;

            /// <summary>
            /// The default length, in bits, of a key.
            /// </summary>
            public int dwDefaultLength;

            /// <summary>
            /// Gets a sequence of allowed key sizes, from smallest to largest.
            /// </summary>
            /// <returns>An enumerator over all allowed sizes.</returns>
            public IEnumerator<int> GetEnumerator()
            {
                if (this.dwIncrement > 0)
                {
                    for (int tagLength = this.dwMinLength; tagLength <= this.dwMaxLength; tagLength += this.dwIncrement)
                    {
                        yield return tagLength;
                    }
                }
                else
                {
                    // We can't use the for loop as it would spin forever.
                    yield return this.dwMinLength;
                }
            }

            /// <inheritdoc />
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => this.GetEnumerator();
        }
    }
}
