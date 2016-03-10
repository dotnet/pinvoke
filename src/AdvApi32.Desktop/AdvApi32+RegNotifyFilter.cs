// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="RegNotifyFilter"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        public enum RegNotifyFilter
        {
            REG_NOTIFY_CHANGE_NAME = 0x00000001,
            REG_NOTIFY_CHANGE_ATTRIBUTES = 0x00000002,
            REG_NOTIFY_CHANGE_LAST_SET = 0x00000004,
            REG_NOTIFY_CHANGE_SECURITY = 0x00000008,
            REG_NOTIFY_THREAD_AGNOSTIC = 0x10000000
        }
    }
}