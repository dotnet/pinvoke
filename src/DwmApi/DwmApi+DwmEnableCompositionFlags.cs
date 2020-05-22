// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="DwmEnableCompositionFlags"/> nested type.
    /// </content>
    public partial class DwmApi
    {
        /// <summary>
        /// Flags that may be passed to the <see cref="DwmEnableComposition(DwmEnableCompositionFlags)"/> function.
        /// </summary>
        public enum DwmEnableCompositionFlags : uint
        {
            /// <summary>
            /// Disables composition.
            /// </summary>
            DWM_EC_DISABLECOMPOSITION = 0,

            /// <summary>
            /// Enables DWM composition.
            /// </summary>
            DWM_EC_ENABLECOMPOSITION = 1,
        }
    }
}
