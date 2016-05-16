// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="ChainingModes"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Possible values for the <see cref="BCryptAddContextFunction"/>
        /// </summary>
        public enum ConfigurationTable
        {
            /// <summary>
            /// The context exists in the local-machine configuration table.
            /// </summary>
            CRYPT_LOCAL,

            /// <summary>
            /// This value is not available for use.
            /// </summary>
            CRYPT_DOMAIN,
        }
    }
}
