// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="ProcessorType"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        public enum ProcessorType
        {
            PROCESSOR_INTEL_386 = 386,
            PROCESSOR_INTEL_486 = 486,
            PROCESSOR_INTEL_PENTIUM = 586,
            PROCESSOR_INTEL_IA64 = 2200,
            PROCESSOR_AMD_X8664 = 8664,
        }
    }
}
