// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="EnumProcessModulesFlags"/> nested type.
    /// </content>
    public partial class Psapi
    {
        /// <summary>
        /// An enumeration determining whether to enumerate 32-bit, 64-bit or both even both architectured modules on EnumProcessModulesEx function.
        /// </summary>
        public enum EnumProcessModulesFlags : uint
        {
            LIST_MODULES_DEFAULT,
            LIST_MODULES_32BIT,
            LIST_MODULES_64BIT,
            LIST_MODULES_ALL,
        }
    }
}
