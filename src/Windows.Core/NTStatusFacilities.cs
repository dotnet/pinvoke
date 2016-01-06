// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <summary>
    /// Represent the 16 facility bits in <see cref="NTStatus"/> enumeration.
    /// </summary>
    internal static class NTStatusFacilities
    {
        internal const uint NTStatusFacility = 0x10000000;
        internal const uint HidErrorCode = (uint)0x11 << 16;
    }
}