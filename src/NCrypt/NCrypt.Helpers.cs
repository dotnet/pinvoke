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
        /// <summary>
        /// Loads and initializes a CNG key storage provider.
        /// </summary>
        /// <param name="providerName">
        /// A pointer to a null-terminated Unicode string that identifies the key storage provider to load. This is the registered alias of the key storage provider. This parameter is optional and can be NULL. If this parameter is NULL, the default key storage provider is loaded. The <see cref="KeyStorageProviders"/> class identifies the built-in key storage providers.
        /// </param>
        /// <param name="flags">Flags that modify the behavior of the function.</param>
        /// <returns>
        /// A <see cref="SafeProviderHandle"/> variable that receives the provider handle. When you have finished using this handle, dispose of it.
        /// </returns>
        public static SafeProviderHandle NCryptOpenStorageProvider(
            string providerName,
            NCryptOpenStorageProviderFlags flags = NCryptOpenStorageProviderFlags.None)
        {
            SafeProviderHandle handle;
            NCryptOpenStorageProvider(out handle, providerName, flags).ThrowOnError();
            return handle;
        }

        /// <summary>
        /// Throws an exception if an NCrypt function returned a failure error code.
        /// </summary>
        /// <param name="status">The result from an NCrypt function.</param>
        public static void ThrowOnError(this SECURITY_STATUS status)
        {
            switch (status)
            {
                case SECURITY_STATUS.ERROR_SUCCESS:
                    return;
                default:
                    throw new Exception($"SECURITY_STATUS: {status}");
            }
        }

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
