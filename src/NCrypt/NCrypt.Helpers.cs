// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class NCrypt
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
