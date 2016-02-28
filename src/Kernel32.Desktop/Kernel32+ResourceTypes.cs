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

        /// <summary>
        ///     Allows a resource editing tool to associate a string with an .rc file. Typically, the string is the name of the
        ///     header file that provides symbolic names. The resource compiler parses the string but otherwise ignores the value.
        ///     For example,
        ///     <para>
        ///         <code>1 DLGINCLUDE "MyFile.h"</code>
        ///     </para>
        /// </summary>
        public static readonly unsafe char* RT_DLGINCLUDE = MAKEINTRESOURCE(17);

        /// <summary>Plug and Play resource.</summary>
        public static readonly unsafe char* RT_PLUGPLAY = MAKEINTRESOURCE(19);

        /// <summary>VXD.</summary>
        public static readonly unsafe char* RT_VXD = MAKEINTRESOURCE(20);

        /// <summary>Animated cursor.</summary>
        public static readonly unsafe char* RT_ANICURSOR = MAKEINTRESOURCE(21);

        /// <summary>Animated icon.</summary>
        public static readonly unsafe char* RT_ANIICON = MAKEINTRESOURCE(22);

        /// <summary>HTML resource.</summary>
        public static readonly unsafe char* RT_HTML = MAKEINTRESOURCE(23);
    }
}
