// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="ServiceTriggerDataType"/> nested type.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Represents a service trigger data type. This is used by the <see cref="SERVICE_TRIGGER_SPECIFIC_DATA_ITEM"/> structure.
        /// </summary>
        public enum ServiceTriggerDataType
        {
            /// <summary>
            /// The trigger-specific data is in binary format.
            /// </summary>
            SERVICE_TRIGGER_DATA_TYPE_BINARY = 1,

            /// <summary>
            /// The trigger-specific data is in string format.
            /// </summary>
            SERVICE_TRIGGER_DATA_TYPE_STRING = 2,

            /// <summary>
            /// The trigger-specific data is a byte value.
            /// </summary>
            SERVICE_TRIGGER_DATA_TYPE_LEVEL = 3,

            /// <summary>
            /// The trigger-specific data is a 64-bit unsigned integer value.
            /// </summary>
            SERVICE_TRIGGER_DATA_TYPE_KEYWORD_ANY = 4,

            /// <summary>
            /// The trigger-specific data is a 64-bit unsigned integer value.
            /// </summary>
            SERVICE_TRIGGER_DATA_TYPE_KEYWORD_ALL = 5
        }
    }
}