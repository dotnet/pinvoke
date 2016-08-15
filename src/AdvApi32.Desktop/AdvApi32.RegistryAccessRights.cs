// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using static Kernel32;
    using static Kernel32.ACCESS_MASK.StandardRight;

    /// <content>
    /// Contains the specific <see cref="ACCESS_MASK"/> for registry keys.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>Reserved for system use.</summary>
        public static readonly ACCESS_MASK KEY_CREATE_LINK = 0x0020;

        /// <summary>Required to create a subkey of a registry key.</summary>
        public static readonly ACCESS_MASK KEY_CREATE_SUB_KEY = 0x0004;

        /// <summary>Required to enumerate the subkeys of a registry key.</summary>
        public static readonly ACCESS_MASK KEY_ENUMERATE_SUB_KEYS = 0x0008;

        /// <summary>Required to request change notifications for a registry key or for subkeys of a registry key.</summary>
        public static readonly ACCESS_MASK KEY_NOTIFY = 0x0010;

        /// <summary>Required to query the values of a registry key.</summary>
        public static readonly ACCESS_MASK KEY_QUERY_VALUE = 0x0001;

        /// <summary>Required to create, delete, or set a registry value.</summary>
        public static readonly ACCESS_MASK KEY_SET_VALUE = 0x0002;

        /// <summary>
        ///     Indicates that an application on 64-bit Windows should operate on the 32-bit registry view. This flag is ignored by
        ///     32-bit Windows.
        ///     <para>
        ///         This flag must be combined using the OR operator with the other flags in this table that either query or
        ///         access registry values.
        ///     </para>
        ///     <para>Windows 2000:  This flag is not supported.</para>
        /// </summary>
        public static readonly ACCESS_MASK KEY_WOW64_32KEY = 0x0200;

        /// <summary>
        ///     Indicates that an application on 64-bit Windows should operate on the 64-bit registry view. This flag is ignored by
        ///     32-bit Windows.
        ///     <para>
        ///         This flag must be combined using the OR operator with the other flags in this table that either query or
        ///         access registry values.
        ///     </para>
        ///     <para>Windows 2000:  This flag is not supported.</para>
        /// </summary>
        public static readonly ACCESS_MASK KEY_WOW64_64KEY = 0x0100;

        /// <summary>
        ///     Combines the <see cref="STANDARD_RIGHTS_REQUIRED" />, <see cref="KEY_QUERY_VALUE" />,
        ///     <see cref="KEY_SET_VALUE" />, <see cref="KEY_CREATE_SUB_KEY" />, <see cref="KEY_ENUMERATE_SUB_KEYS" />,
        ///     <see cref="KEY_NOTIFY" />, and <see cref="KEY_CREATE_LINK" /> access rights.
        /// </summary>
        public static readonly ACCESS_MASK KEY_ALL_ACCESS =
            (ACCESS_MASK)STANDARD_RIGHTS_REQUIRED | KEY_QUERY_VALUE | KEY_SET_VALUE | KEY_CREATE_SUB_KEY
            | KEY_ENUMERATE_SUB_KEYS | KEY_NOTIFY | KEY_CREATE_LINK;

        /// <summary>
        ///     Combines the <see cref="STANDARD_RIGHTS_READ" />, <see cref="KEY_QUERY_VALUE" />,
        ///     <see cref="KEY_ENUMERATE_SUB_KEYS" />, and <see cref="KEY_NOTIFY" /> values.
        /// </summary>
        public static readonly ACCESS_MASK KEY_READ =
            (ACCESS_MASK)STANDARD_RIGHTS_READ | KEY_QUERY_VALUE | KEY_ENUMERATE_SUB_KEYS | KEY_NOTIFY;

        /// <summary>
        ///     Combines the <see cref="STANDARD_RIGHTS_WRITE" />, <see cref="KEY_SET_VALUE" />, and
        ///     <see cref="KEY_CREATE_SUB_KEY" /> access rights.
        /// </summary>
        public static readonly ACCESS_MASK KEY_WRITE =
            (ACCESS_MASK)STANDARD_RIGHTS_WRITE | KEY_SET_VALUE | KEY_CREATE_SUB_KEY;

        /// <summary>Equivalent to <see cref="KEY_READ" />.</summary>
        public static readonly ACCESS_MASK KEY_EXECUTE = KEY_READ;
    }
}
