// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="ServiceTriggerAction"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        public enum ServiceTriggerAction
        {
            /// <summary>
            /// Start the service when the specified trigger event occurs.
            /// </summary>
            SERVICE_TRIGGER_ACTION_SERVICE_START = 1,

            /// <summary>
            /// Stop the service when the specified trigger event occurs.
            /// </summary>
            SERVICE_TRIGGER_ACTION_SERVICE_STOP = 2,
        }
    }
}
