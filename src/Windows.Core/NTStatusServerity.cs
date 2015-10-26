// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <summary>
    /// Represent the 4 high bits of a <see cref="NTStatus"/> enumeration : Severity (2 bits), Customer code (1 bit) and Reserved (1 bit).
    /// </summary>
    internal static class NTStatusServerity
    {
        public const uint Success = (uint)0xC << 28;
        public const uint Informational = (uint)0x4 << 28;
        public const uint Warning = (uint)0x8 << 28;
        public const uint Error = (uint)0xC << 28;
    }
}