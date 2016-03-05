// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Exported functions from the BCrypt.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    public static partial class BCrypt
    {
        public const uint CRYPT_PRIORITY_TOP = 0x00000000;

        public const uint CRYPT_PRIORITY_BOTTOM = 0xFFFFFFFF;

        /// <summary>
        /// The BCryptAddContextFunction function adds a cryptographic function to the list of functions that are supported by an existing CNG context.
        /// </summary>
        /// <param name="dwTable">Identifies the configuration table that the context exists in.</param>
        /// <param name="pszContext">A pointer to a null-terminated Unicode string that contains the identifier of the context to add the function to.</param>
        /// <param name="dwInterface">Identifies the cryptographic interface to add the function to.</param>
        /// <param name="pszFunction">A pointer to a null-terminated Unicode string that contains the identifier of the cryptographic function to add.</param>
        /// <param name="dwPosition">Specifies the position in the list at which to insert this function. The function is inserted at this position ahead of any existing functions. The <see cref="CRYPT_PRIORITY_TOP"/> value is used to insert the function at the top of the list. The <see cref="CRYPT_PRIORITY_BOTTOM"/> value is used to insert the function at the end of the list.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        /// <remarks>
        /// If the function added is already in the list, it will be removed and inserted at the new position.
        /// </remarks>
        [DllImport(nameof(BCrypt), CharSet = CharSet.Unicode)]
        public static extern NTSTATUS BCryptAddContextFunction(
            ConfigurationTable dwTable,
            string pszContext,
            InterfaceIdentifiers dwInterface,
            string pszFunction,
            uint dwPosition);
    }
}
