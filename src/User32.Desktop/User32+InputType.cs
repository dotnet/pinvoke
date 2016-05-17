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
            MOUSE = 0,
            KEYBOARD = 1,
            HARDWARE = 2
        }
    }
}