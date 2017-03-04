// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="KeyStorageProviders"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        public static class KeyStorageProviders
        {
            /// <summary>
            /// Identifies the software key storage provider that is provided by Microsoft.
            /// </summary>
            public const string MS_KEY_STORAGE_PROVIDER = "Microsoft Software Key Storage Provider";

            /// <summary>
            /// Identifies the smart card key storage provider that is provided by Microsoft.
            /// </summary>
            public const string MS_SMART_CARD_KEY_STORAGE_PROVIDER = "Microsoft Smart Card Key Storage Provider";
        }
    }
}
