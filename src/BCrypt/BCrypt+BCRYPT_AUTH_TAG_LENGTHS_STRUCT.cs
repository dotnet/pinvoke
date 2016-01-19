// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="BCRYPT_AUTH_TAG_LENGTHS_STRUCT"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// defines the range of tag sizes that are supported by the provider. This structure is used with the <see cref="PropertyNames.BCRYPT_AUTH_TAG_LENGTH"/> property.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct BCRYPT_AUTH_TAG_LENGTHS_STRUCT : IEnumerable<int>
        {
            /// <summary>
            /// The minimum length, in bytes, of a tag.
            /// </summary>
            public int dwMinLength;

            /// <summary>
            /// The maximum length, in bytes, of a tag.
            /// </summary>
            public int dwMaxLength;

            /// <summary>
            /// The number of bytes that the tag size can be incremented between dwMinLength and dwMaxLength.
            /// </summary>
            public int dwIncrement;

            /// <summary>
            /// Gets a sequence of allowed tag sizes, from smallest to largest.
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
