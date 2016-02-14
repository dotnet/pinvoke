// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains all the "RT_" constants that represent resource types.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>Hardware-dependent cursor resource.</summary>
        public static readonly unsafe char* RT_CURSOR = MAKEINTRESOURCE(1);

        /// <summary>Bitmap resource.</summary>
        public static readonly unsafe char* RT_BITMAP = MAKEINTRESOURCE(2);

        /// <summary>Hardware-dependent icon resource.</summary>
        public static readonly unsafe char* RT_ICON = MAKEINTRESOURCE(3);

        /// <summary>Menu resource.</summary>
        public static readonly unsafe char* RT_MENU = MAKEINTRESOURCE(4);

        /// <summary>Dialog box.</summary>
        public static readonly unsafe char* RT_DIALOG = MAKEINTRESOURCE(5);

        /// <summary>String-table entry.</summary>
        public static readonly unsafe char* RT_STRING = MAKEINTRESOURCE(6);

        /// <summary>Font directory resource.</summary>
        public static readonly unsafe char* RT_FONTDIR = MAKEINTRESOURCE(7);

        /// <summary>Font resource.</summary>
        public static readonly unsafe char* RT_FONT = MAKEINTRESOURCE(8);

        /// <summary>Accelerator table.</summary>
        public static readonly unsafe char* RT_ACCELERATOR = MAKEINTRESOURCE(9);

        /// <summary>Application-defined resource (raw data).</summary>
        public static readonly unsafe char* RT_RCDATA = MAKEINTRESOURCE(10);

        /// <summary>Message-table entry.</summary>
        public static readonly unsafe char* RT_MESSAGETABLE = MAKEINTRESOURCE(11);

        /// <summary>Hardware-independent cursor resource.</summary>
        public static readonly unsafe char* RT_GROUP_CURSOR = MAKEINTRESOURCE(12);

        /// <summary>Hardware-independent icon resource.</summary>
        public static readonly unsafe char* RT_GROUP_ICON = MAKEINTRESOURCE(14);

        /// <summary>Version resource</summary>
        public static readonly unsafe char* RT_VERSION = MAKEINTRESOURCE(16);
    }
}
