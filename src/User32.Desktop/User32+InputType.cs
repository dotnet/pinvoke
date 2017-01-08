// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="InputType"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// The type of the input event used by <see cref="INPUT.type" />.
        /// </summary>
        public enum InputType : uint
        {
            /// <summary>
            /// The event is a mouse event. Use the <see cref="INPUT.InputUnion.mi"/> structure of the union.
            /// </summary>
            INPUT_MOUSE = 0,

            /// <summary>
            /// The event is a keyboard event. Use the <see cref="INPUT.InputUnion.ki"/> structure of the union.
            /// </summary>
            INPUT_KEYBOARD = 1,

            /// <summary>
            /// The event is a hardware event. Use the <see cref="INPUT.InputUnion.hi"/> structure of the union.
            /// </summary>
            INPUT_HARDWARE = 2,
        }
    }
}