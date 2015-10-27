// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    public static class PinnedStructExtensions
    {
        public static PinnedStruct<T> Pin<T>(this T value)
            where T : struct
        {
            return new PinnedStruct<T>(value);
        }

        public static PinnedStruct<T> Pin<T>(this T? value)
            where T : struct
        {
            return new PinnedStruct<T>(value);
        }
    }
}