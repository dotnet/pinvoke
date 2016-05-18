// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="INPUT"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Used by <see cref="SendInput(int, INPUT*, int)"/> to store information for synthesizing input events such as keystrokes, mouse movement, and mouse clicks.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public InputType type;

            public InputUnion U;

            public static int Size
            {
                get { return Marshal.SizeOf(typeof(INPUT)); }
            }
        }
    }
}