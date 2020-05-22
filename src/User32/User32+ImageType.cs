// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="ImageType"/> nested type.
    /// </content>
    public static partial class User32
    {
        /// <summary>
        /// Represents various image types.
        /// </summary>
        public enum ImageType : uint
        {
            /// <summary>
            /// Loads a bitmap.
            /// </summary>
            IMAGE_BITMAP = 0,

            /// <summary>
            /// Loads an icon.
            /// </summary>
            IMAGE_ICON = 1,

            /// <summary>
            /// Loads a cursor.
            /// </summary>
            IMAGE_CURSOR = 2,
        }
    }
}
