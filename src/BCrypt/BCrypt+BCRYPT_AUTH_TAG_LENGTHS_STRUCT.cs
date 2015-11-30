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
        public struct BCRYPT_AUTH_TAG_LENGTHS_STRUCT
        {
            /// <summary>
            /// The minimum length, in bytes, of a tag.
            /// </summary>
            public int MinLength;

            /// <summary>
            /// The maximum length, in bytes, of a tag.
            /// </summary>
            public int MaxLength;

            /// <summary>
            /// The number of bytes that the tag size can be incremented between dwMinLength and dwMaxLength.
            /// </summary>
            public int Increment;

            /// <summary>
            /// Gets a sequence of allowed tag sizes, from smallest to largest.
            /// </summary>
            public IEnumerable<int> TagSizes
            {
                get
                {
                    if (this.Increment > 0)
                    {
                        for (int tagLength = this.MinLength; tagLength <= this.MaxLength; tagLength += this.Increment)
                        {
                            yield return tagLength;
                        }
                    }
                    else
                    {
                        // We can't use the for loop as it would spin forever.
                        yield return this.MinLength;
                    }
                }
            }
        }
    }
}
