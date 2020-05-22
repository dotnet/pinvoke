// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="SymmetricKeyBlobTypes"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// Identifies the blob types of symmetric keys.
        /// </summary>
        public class SymmetricKeyBlobTypes : BCrypt.SymmetricKeyBlobTypes
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SymmetricKeyBlobTypes"/> class.
            /// </summary>
            /// <remarks>
            /// Suppresses generation of a public default constructor.
            /// </remarks>
            protected SymmetricKeyBlobTypes()
            {
            }
        }
    }
}
