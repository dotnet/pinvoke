// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Exported functions from the NCrypt.dll Windows library
    /// that are available to Desktop and Store apps.
    /// </summary>
    public partial class NCrypt
    {
        /// <summary>
        /// Loads and initializes a CNG key storage provider.
        /// </summary>
        /// <param name="phProvider">
        /// A pointer to a <see cref="SafeProviderHandle"/> variable that receives the provider handle. When you have finished using this handle, release it by passing it to the <see cref="NCryptFreeObject"/> function.
        /// </param>
        /// <param name="pszProviderName">
        /// A pointer to a null-terminated Unicode string that identifies the key storage provider to load. This is the registered alias of the key storage provider. This parameter is optional and can be NULL. If this parameter is NULL, the default key storage provider is loaded. The <see cref="KeyStorageProviders"/> class identifies the built-in key storage providers.
        /// </param>
        /// <param name="dwFlags">Flags that modify the behavior of the function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt), CharSet = CharSet.Unicode)]
        public static extern SECURITY_STATUS NCryptOpenStorageProvider(
            out SafeProviderHandle phProvider,
            string pszProviderName,
            NCryptOpenStorageProviderFlags dwFlags = NCryptOpenStorageProviderFlags.None);

        /// <summary>
        /// Creates a new key and stores it in the specified key storage provider. After you create a key by using this function, you can use the NCryptSetProperty function to set its properties; however, the key cannot be used until the NCryptFinalizeKey function is called.
        /// </summary>
        /// <param name="hProvider">
        /// The handle of the key storage provider to create the key in. This handle is obtained by using the <see cref="NCryptOpenStorageProvider(string, NCryptOpenStorageProviderFlags)"/> function.
        /// </param>
        /// <param name="phKey">
        /// The address of an <see cref="SafeKeyHandle"/> variable that receives the handle of the key. When you have finished using this handle, release it by disposing it.
        /// </param>
        /// <param name="pszAlgId">
        /// A null-terminated Unicode string that contains the identifier of the cryptographic algorithm to create the key. This can be one of the standard CNG Algorithm Identifiers defined in <see cref="BCrypt.AlgorithmIdentifiers"/> or the identifier for another registered algorithm.
        /// </param>
        /// <param name="pszKeyName">
        /// A pointer to a null-terminated Unicode string that contains the name of the key. If this parameter is NULL, this function will create an ephemeral key that is not persisted.
        /// </param>
        /// <param name="dwLegacyKeySpec">
        /// A legacy identifier that specifies the type of key.
        /// </param>
        /// <param name="dwFlags">A set of flags that modify the behavior of this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt))]
        public static extern SECURITY_STATUS NCryptCreatePersistedKey(
            SafeProviderHandle hProvider,
            out SafeKeyHandle phKey,
            string pszAlgId,
            string pszKeyName = null,
            LegacyKeySpec dwLegacyKeySpec = LegacyKeySpec.None,
            NCryptCreatePersistedKeyFlags dwFlags = NCryptCreatePersistedKeyFlags.None);

        /// <summary>
        /// Completes a CNG key storage key. The key cannot be used until this function has been called.
        /// </summary>
        /// <param name="hKey">
        /// The handle of the key to complete. This handle is obtained by calling the <see cref="NCryptCreatePersistedKey(SafeProviderHandle, string, string, LegacyKeySpec, NCryptCreatePersistedKeyFlags)"/> function.
        /// </param>
        /// <param name="dwFlags">
        /// Flags that modify function behavior.
        /// </param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt))]
        public static extern SECURITY_STATUS NCryptFinalizeKey(
            SafeKeyHandle hKey,
            NCryptFinalizeKeyFlags dwFlags = NCryptFinalizeKeyFlags.None);

        /// <summary>
        /// Retrieves the value of a named property for a key storage object.
        /// </summary>
        /// <param name="hObject">
        /// The handle of the object to get the property for. This can be a provider handle (<see cref="SafeProviderHandle"/>) or a key handle (<see cref="SafeKeyHandle"/>).
        /// </param>
        /// <param name="pszProperty">
        /// A pointer to a null-terminated Unicode string that contains the name of the property to retrieve. This can be one of the predefined <see cref="KeyStoragePropertyIdentifiers"/> or a custom property identifier.
        /// </param>
        /// <param name="pbOutput">
        /// The address of a buffer that receives the property value. The <paramref name="cbOutput"/> parameter contains the size of this buffer.
        /// To calculate the size required for the buffer, set this parameter to NULL. The size, in bytes, required is returned in the location pointed to by the <paramref name="pcbResult"/> parameter.
        /// </param>
        /// <param name="cbOutput">
        /// The size, in bytes, of the <paramref name="pbOutput"/> buffer.
        /// </param>
        /// <param name="pcbResult">
        /// A pointer to a DWORD variable that receives the number of bytes that were copied to the <paramref name="pbOutput"/> buffer.
        /// If the <paramref name="pbOutput"/> parameter is NULL, the size, in bytes, required for the buffer is placed in the location pointed to by this parameter.
        /// </param>
        /// <param name="dwFlags">Flags that modify function behavior.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt), CharSet = CharSet.Unicode)]
        public static extern SECURITY_STATUS NCryptGetProperty(
            SafeHandle hObject,
            string pszProperty,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pbOutput,
            int cbOutput,
            out int pcbResult,
            NCryptGetPropertyFlags dwFlags);

        /// <summary>
        /// Sets the value for a named property for a CNG key storage object.
        /// </summary>
        /// <param name="hObject">The handle of the key storage object to set the property for.</param>
        /// <param name="pszProperty">
        /// A pointer to a null-terminated Unicode string that contains the name of the property to set. This can be one of the predefined <see cref="KeyStoragePropertyIdentifiers"/> or a custom property identifier.
        /// </param>
        /// <param name="pbInput">
        /// The address of a buffer that contains the new property value. The <paramref name="cbInput"/> parameter contains the size of this buffer.
        /// </param>
        /// <param name="cbInput">
        /// The size, in bytes, of the <paramref name="pbInput"/> buffer.
        /// </param>
        /// <param name="dwFlags">Flags that modify function behavior.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt), CharSet = CharSet.Unicode)]
        public static extern SECURITY_STATUS NCryptSetProperty(
            SafeHandle hObject,
            string pszProperty,
            byte[] pbInput,
            int cbInput,
            NCryptSetPropertyFlags dwFlags);

        /// <summary>
        /// Frees a CNG key storage object.
        /// </summary>
        /// <param name="hObject">
        /// The handle of the object to free. This can be either a provider handle (<see cref="SafeProviderHandle"/>) or a key handle (<see cref="SafeKeyHandle"/>).
        /// </param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt))]
        private static extern SECURITY_STATUS NCryptFreeObject(IntPtr hObject);
    }
}
