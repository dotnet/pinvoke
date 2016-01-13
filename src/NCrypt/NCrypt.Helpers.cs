// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Globalization;
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
        /// Creates a new key and stores it in the specified key storage provider. After you create a key by using this function, you can use the NCryptSetProperty function to set its properties; however, the key cannot be used until the NCryptFinalizeKey function is called.
        /// </summary>
        /// <param name="provider">
        /// The handle of the key storage provider to create the key in. This handle is obtained by using the <see cref="NCryptOpenStorageProvider(string, NCryptOpenStorageProviderFlags)"/> function.
        /// </param>
        /// <param name="algorithmId">
        /// A null-terminated Unicode string that contains the identifier of the cryptographic algorithm to create the key. This can be one of the standard CNG Algorithm Identifiers defined in <see cref="BCrypt.AlgorithmIdentifiers"/> or the identifier for another registered algorithm.
        /// </param>
        /// <param name="keyName">
        /// A pointer to a null-terminated Unicode string that contains the name of the key. If this parameter is NULL, this function will create an ephemeral key that is not persisted.
        /// </param>
        /// <param name="legacyKeySpec">
        /// A legacy identifier that specifies the type of key.
        /// </param>
        /// <param name="flags">A set of flags that modify the behavior of this function.</param>
        /// <returns>
        /// The address of an <see cref="SafeKeyHandle"/> variable that receives the handle of the key. When you have finished using this handle, release it by disposing it.
        /// </returns>
        public static SafeKeyHandle NCryptCreatePersistedKey(
            SafeProviderHandle provider,
            string algorithmId,
            string keyName = null,
            LegacyKeySpec legacyKeySpec = LegacyKeySpec.None,
            NCryptCreatePersistedKeyFlags flags = NCryptCreatePersistedKeyFlags.None)
        {
            SafeKeyHandle result;
            NCryptCreatePersistedKey(
                provider,
                out result,
                algorithmId,
                keyName,
                legacyKeySpec,
                flags).ThrowOnError();
            return result;
        }

        /// <summary>
        /// Retrieves the value of a named property for a key storage object.
        /// </summary>
        /// <param name="hObject">
        /// The handle of the object to get the property for. This can be a provider handle (<see cref="SafeProviderHandle"/>) or a key handle (<see cref="SafeKeyHandle"/>).
        /// </param>
        /// <param name="propertyName">
        /// A pointer to a null-terminated Unicode string that contains the name of the property to retrieve. This can be one of the predefined <see cref="KeyStoragePropertyIdentifiers"/> or a custom property identifier.
        /// </param>
        /// <param name="flags">Flags that modify function behavior.</param>
        /// <returns>The property value.</returns>
        public static byte[] NCryptGetProperty(SafeHandle hObject, string propertyName, NCryptGetPropertyFlags flags = NCryptGetPropertyFlags.None)
        {
            int requiredSize;
            NCryptGetProperty(hObject, propertyName, null, 0, out requiredSize, flags).ThrowOnError();
            byte[] result = new byte[requiredSize];
            NCryptGetProperty(hObject, propertyName, result, result.Length, out requiredSize, flags).ThrowOnError();
            return result;
        }

        /// <summary>
        /// Retrieves the value of a named property for a key storage object.
        /// </summary>
        /// <typeparam name="T">The type of struct to return the property value as.</typeparam>
        /// <param name="hObject">
        /// The handle of the object to get the property for. This can be a provider handle (<see cref="SafeProviderHandle"/>) or a key handle (<see cref="SafeKeyHandle"/>).
        /// </param>
        /// <param name="propertyName">
        /// A pointer to a null-terminated Unicode string that contains the name of the property to retrieve. This can be one of the predefined <see cref="KeyStoragePropertyIdentifiers"/> or a custom property identifier.
        /// </param>
        /// <param name="flags">Flags that modify function behavior.</param>
        /// <returns>The property value.</returns>
        public static T NCryptGetProperty<T>(SafeHandle hObject, string propertyName, NCryptGetPropertyFlags flags = NCryptGetPropertyFlags.None)
            where T : struct
        {
            byte[] value = NCryptGetProperty(hObject, propertyName, flags);
            unsafe
            {
                fixed (byte* pValue = value)
                {
                    return (T)Marshal.PtrToStructure(new IntPtr(pValue), typeof(T));
                }
            }
        }
    }
}
