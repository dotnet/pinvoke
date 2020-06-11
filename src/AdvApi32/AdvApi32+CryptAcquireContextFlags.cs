// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="CryptAcquireContextFlags"/> nested type.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Flags for the <see cref="CryptAcquireContext(out SafeCryptographicProviderHandle, string, string, ProviderType, CryptAcquireContextFlags)"/> method.
        /// </summary>
        [Flags]
        public enum CryptAcquireContextFlags : uint
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// This option is intended for applications that are using ephemeral keys, or applications that do not require access to persisted private keys, such as applications that perform only hashing, encryption, and digital signature verification. Only applications that create signatures or decrypt messages need access to a private key. In most cases, this flag should be set.
            /// See Microsoft online documentation for more information.
            /// </summary>
            CRYPT_VERIFYCONTEXT = 0xF0000000,

            /// <summary>
            /// Creates a new key container with the name specified by pszContainer. If pszContainer is NULL, a key container with the default name is created.
            /// </summary>
            CRYPT_NEWKEYSET = 0x00000008,

            /// <summary>
            /// Delete the key container specified by pszContainer. If pszContainer is NULL, the key container with the default name is deleted. All key pairs in the key container are also destroyed.
            /// When this flag is set, the value returned in phProv is undefined, and thus, the CryptReleaseContext function need not be called afterward.
            /// </summary>
            CRYPT_DELETEKEYSET = 0x00000010,

            /// <summary>
            /// By default, keys and key containers are stored as user keys. For Base Providers, this means that user key containers are stored in the user's profile. A key container created without this flag by an administrator can be accessed only by the user creating the key container and a user with administration privileges.
            /// See Microsoft online documentation for more information.
            /// </summary>
            CRYPT_MACHINE_KEYSET = 0x00000020,

            /// <summary>
            /// The application requests that the CSP not display any user interface (UI) for this context. If the CSP must display the UI to operate, the call fails and the NTE_SILENT_CONTEXT error code is set as the last error. In addition, if calls are made to CryptGenKey with the CRYPT_USER_PROTECTED flag with a context that has been acquired with the CRYPT_SILENT flag, the calls fail and the CSP sets NTE_SILENT_CONTEXT.
            /// CRYPT_SILENT is intended for use with applications for which the UI cannot be displayed by the CSP.
            /// </summary>
            CRYPT_SILENT = 0x00000040,

            /// <summary>
            /// Obtains a context for a smart card CSP that can be used for hashing and symmetric key operations but cannot be used for any operation that requires authentication to a smart card using a PIN. This type of context is most often used to perform operations on an empty smart card, such as setting the PIN by using CryptSetProvParam. This flag can only be used with smart card CSPs.
            /// </summary>
            CRYPT_DEFAULT_CONTAINER_OPTIONAL = 0x00000080,
        }
    }
}
