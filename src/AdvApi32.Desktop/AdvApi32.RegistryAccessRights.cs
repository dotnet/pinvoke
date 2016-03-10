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
        public static readonly ACCESS_MASK KEY_CREATE_LINK = 0x0020;
        public static readonly ACCESS_MASK KEY_CREATE_SUB_KEY = 0x0004;
        public static readonly ACCESS_MASK KEY_ENUMERATE_SUB_KEYS = 0x0008;
        public static readonly ACCESS_MASK KEY_EXECUTE = 0x20019;
        public static readonly ACCESS_MASK KEY_NOTIFY = 0x0010;
        public static readonly ACCESS_MASK KEY_QUERY_VALUE = 0x0001;
        public static readonly ACCESS_MASK KEY_SET_VALUE = 0x0002;
        public static readonly ACCESS_MASK KEY_WOW64_32KEY = 0x0200;
        public static readonly ACCESS_MASK KEY_WOW64_64KEY = 0x0100;

        public static readonly ACCESS_MASK KEY_ALL_ACCESS =
            (ACCESS_MASK)STANDARD_RIGHTS_REQUIRED | KEY_QUERY_VALUE | KEY_SET_VALUE | KEY_CREATE_SUB_KEY
            | KEY_ENUMERATE_SUB_KEYS | KEY_NOTIFY | KEY_CREATE_LINK;

        public static readonly ACCESS_MASK KEY_READ =
            (ACCESS_MASK)STANDARD_RIGHTS_READ | KEY_QUERY_VALUE | KEY_ENUMERATE_SUB_KEYS | KEY_NOTIFY;

        public static readonly ACCESS_MASK KEY_WRITE =
            (ACCESS_MASK)STANDARD_RIGHTS_WRITE | KEY_SET_VALUE | KEY_CREATE_SUB_KEY;
    }
}
