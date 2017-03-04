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
        /// Possible values for the <see cref="PropertyNames.BCRYPT_CHAINING_MODE"/> property.
        /// </summary>
        public static class ChainingModes
        {
            /// <summary>
            /// Sets the algorithm's chaining mode to cipher block chaining.
            /// </summary>
            public const string Cbc = "ChainingModeCBC";

            /// <summary>
            /// Sets the algorithm's chaining mode to counter with CBC-MAC mode (CCM).
            /// Windows Vista:  This value is supported beginning with Windows Vista with SP1.
            /// </summary>
            public const string Ccm = "ChainingModeCCM";

            /// <summary>
            /// Sets the algorithm's chaining mode to cipher feedback.
            /// </summary>
            public const string Cfb = "ChainingModeCFB";

            /// <summary>
            /// Sets the algorithm's chaining mode to electronic codebook.
            /// </summary>
            public const string Ecb = "ChainingModeECB";

            /// <summary>
            /// Sets the algorithm's chaining mode to Galois/counter mode (GCM).
            /// Windows Vista:  This value is supported beginning with Windows Vista with SP1.
            /// </summary>
            public const string Gcm = "ChainingModeGCM";

            /// <summary>
            /// The algorithm does not support chaining.
            /// </summary>
            public const string NotApplicable = "ChainingModeN/A";
        }
    }
}
