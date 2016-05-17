// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="ServiceTrigger"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Represents a service trigger event. This structure is used by the <see cref="ServiceTriggerInfo"/> structure.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceTrigger
        {
            /// <summary>
            /// The trigger event type
            /// </summary>
            public ServiceTriggerType dwTriggerType;

            /// <summary>
            /// The action to take when the specified trigger event occurs.
            /// </summary>
            public ServiceTriggerAction dwAction;

            /// <summary>
            /// Points to a GUID that identifies the trigger event subtype. The value
            /// of this member depends on the value of the <see cref="dwTriggerType"/> member.
            /// </summary>
            public IntPtr pTriggerSubtype;

            /// <summary>
            /// The number of <see cref="SERVICE_TRIGGER_SPECIFIC_DATA_ITEM"/> structures in the
            /// array pointed to by <see cref="pDataItems"/>.
            /// </summary>
            public int cDataItems;

            /// <summary>
            /// A pointer to an array of <see cref="SERVICE_TRIGGER_SPECIFIC_DATA_ITEM"/>
            /// structures that contain trigger-specific data.
            /// </summary>
            public SERVICE_TRIGGER_SPECIFIC_DATA_ITEM[] pDataItems;
        }
    }
}
