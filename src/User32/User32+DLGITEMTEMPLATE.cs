// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.namespace PInvoke{    using System.Runtime.InteropServices;    /// <content>    /// Contains the <see cref="DLGITEMTEMPLATE"/> nested type.    /// </content>    public partial class User32    {        /// <summary>
        ///     Defines the dimensions and style of a control in a dialog box. One or more of these structures are combined with a
        ///     <see cref="DLGTEMPLATE" /> structure to form a standard template for a dialog box.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        public struct DLGITEMTEMPLATE
        {
            /// <summary>
            ///     The style of the control. This member can be a combination of window style values (such as WS_BORDER) and one or
            ///     more of the control style values (such as BS_PUSHBUTTON and ES_LEFT).
            /// </summary>
            public int style;

            /// <summary>
            ///     The extended styles for a window. This member is not used to create controls in dialog boxes, but applications that
            ///     use dialog box templates can use it to create other types of windows.
            /// </summary>
            public int dwExtendedStyle;

            /// <summary>
            ///     The x-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative
            ///     to the upper-left corner of the dialog box's client area.
            /// </summary>
            public byte x;

            /// <summary>
            ///     The y-coordinate, in dialog box units, of the upper-left corner of the control. This coordinate is always relative
            ///     to the upper-left corner of the dialog box's client area.
            /// </summary>
            public byte y;

            /// <summary>
            ///     The width, in dialog box units, of the control.
            /// </summary>
            public byte cx;

            /// <summary>
            ///     The height, in dialog box units, of the control.
            /// </summary>
            public byte cy;

            /// <summary>
            ///     The control identifier.
            /// </summary>
            public short id;
        }    }}