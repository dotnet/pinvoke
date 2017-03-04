// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="TextFormats"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Values to pass to the <see cref="DrawText(SafeDCHandle, char*, int, RECT*, TextFormats)"/> method describing format the text.
        /// </summary>
        [Flags]
        public enum TextFormats : uint
        {
            /// <summary>
            /// Justifies the text to the top of the rectangle.
            /// </summary>
            DT_TOP = 0x00000000,

            /// <summary>
            /// Aligns text to the left.
            /// </summary>
            DT_LEFT = 0x00000000,

            /// <summary>
            /// Centers text horizontally in the rectangle.
            /// </summary>
            DT_CENTER = 0x00000001,

            /// <summary>
            /// Aligns text to the right.
            /// </summary>
            DT_RIGHT = 0x00000002,

            /// <summary>
            /// Centers text vertically. This value is used only with the DT_SINGLELINE value.
            /// </summary>
            DT_VCENTER = 0x00000004,

            /// <summary>
            /// Justifies the text to the bottom of the rectangle. This value is used only with the <see cref="DT_SINGLELINE"/> value.
            /// </summary>
            DT_BOTTOM = 0x00000008,

            /// <summary>
            /// Breaks words. Lines are automatically broken between words if a word would extend past the edge of the rectangle specified by the lpRect parameter.
            /// A carriage return-line feed sequence also breaks the line.
            /// </summary>
            /// <remarks>f this is not specified, output is on one line.</remarks>
            DT_WORDBREAK = 0x00000010,

            /// <summary>
            /// Displays text on a single line only. Carriage returns and line feeds do not break the line.
            /// </summary>
            DT_SINGLELINE = 0x00000020,

            /// <summary>
            /// Expands tab characters. The default number of characters per tab is eight.
            /// </summary>
            /// <remarks>The <see cref="DT_WORD_ELLIPSIS"/>, <see cref="DT_PATH_ELLIPSIS"/>, and <see cref="DT_END_ELLIPSIS"/> values cannot be used with the DT_EXPANDTABS value.</remarks>
            DT_EXPANDTABS = 0x00000040,

            /// <summary>
            /// Sets tab stops. Bits 15-8 (high-order byte of the low-order word) of the uFormat parameter specify the number of characters for each tab.
            /// The default number of characters per tab is eight.
            /// If you are using the <see cref="DrawTextEx(SafeDCHandle, char*, int, RECT*, uint, DRAWTEXTPARAMS*)"/> function, the <see cref="DRAWTEXTPARAMS"/> structure pointed to by the lpDTParams parameter specifies the number of average character widths per tab stop.
            /// </summary>
            /// <remarks>The <see cref="DT_CALCRECT"/>, <see cref="DT_EXTERNALLEADING"/>, <see cref="DT_INTERNAL"/>, <see cref="DT_NOCLIP"/>, and <see cref="DT_NOPREFIX"/> values cannot be used with the DT_TABSTOP value.</remarks>
            DT_TABSTOP = 0x00000080,

            /// <summary>
            /// Tab stops with 1 character length
            /// Auxiliary value to help map the <see cref="DT_TABSTOP"/> settings for the number of tab charaters with <see cref="DrawText(SafeDCHandle, char*, int, RECT*, TextFormats)"/>
            /// </summary>
            TABSTOP_1CHAR = 0x00000100,

            /// <summary>
            /// Tab stops with 2 characters length
            /// Auxiliary value to help map the <see cref="DT_TABSTOP"/> settings for the number of tab charaters with <see cref="DrawText(SafeDCHandle, char*, int, RECT*, TextFormats)"/>
            /// </summary>
            TABSTOP_2CHAR = 0x00000200,

            /// <summary>
            /// Tab stops with 4 characters length
            /// Auxiliary value to help map the <see cref="DT_TABSTOP"/> settings for the number of tab charaters with <see cref="DrawText(SafeDCHandle, char*, int, RECT*, TextFormats)"/>
            /// </summary>
            TABSTOP_4CHAR = 0x00000400,

            /// <summary>
            /// Tab stops with 8 characters length
            /// Auxiliary value to help map the <see cref="DT_TABSTOP"/> settings for the number of tab charaters with <see cref="DrawText(SafeDCHandle, char*, int, RECT*, TextFormats)"/>
            /// </summary>
            TABSTOP_8CHAR = 0x00000800,

            /// <summary>
            /// Tab stops with 16 characters length
            /// Auxiliary value to help map the <see cref="DT_TABSTOP"/> settings for the number of tab charaters with <see cref="DrawText(SafeDCHandle, char*, int, RECT*, TextFormats)"/>
            /// </summary>
            TABSTOP_16CHAR = 0x00001000,

            /// <summary>
            /// Tab stops with 32 characters length
            /// Auxiliary value to help map the <see cref="DT_TABSTOP"/> settings for the number of tab charaters with <see cref="DrawText(SafeDCHandle, char*, int, RECT*, TextFormats)"/>
            /// </summary>
            TABSTOP_32CHAR = 0x00002000,

            /// <summary>
            /// Tab stops with 64 characters length
            /// Auxiliary value to help map the <see cref="DT_TABSTOP"/> settings for the number of tab charaters with <see cref="DrawText(SafeDCHandle, char*, int, RECT*, TextFormats)"/>
            /// </summary>
            TABSTOP_64CHAR = 0x00004000,

            /// <summary>
            /// Tab stops with 128 characters length
            /// Auxiliary value to help map the <see cref="DT_TABSTOP"/> settings for the number of tab charaters with <see cref="DrawText(SafeDCHandle, char*, int, RECT*, TextFormats)"/>
            /// </summary>
            TABSTOP_128CHAR = 0x00008000,

            /// <summary>
            /// Draws without clipping. <see cref="DrawText(SafeDCHandle, char*, int, RECT*, TextFormats)"/> is somewhat faster when DT_NOCLIP is used.
            /// </summary>
            DT_NOCLIP = 0x00000100,

            /// <summary>
            /// Includes the font external leading in line height.
            /// Normally, external leading is not included in the height of a line of text.
            /// </summary>
            DT_EXTERNALLEADING = 0x00000200,

            /// <summary>
            /// Determines the width and height of the rectangle.
            /// If there are multiple lines of text, <see cref="DrawText(SafeDCHandle, char*, int, RECT*, TextFormats)"/> uses the width of the rectangle pointed to by the lpRect parameter
            /// and extends the base of the rectangle to bound the last line of text.
            /// If the largest word is wider than the rectangle, the width is expanded.
            /// If the text is less than the width of the rectangle, the width is reduced.
            /// If there is only one line of text, <see cref="DrawText(SafeDCHandle, char*, int, RECT*, TextFormats)"/> modifies the right side of the rectangle so that it bounds the last character in the line.
            /// In either case, <see cref="DrawText(SafeDCHandle, char*, int, RECT*, TextFormats)"/> returns the height of the formatted text but does not draw the text.
            /// </summary>
            DT_CALCRECT = 0x00000400,

            /// <summary>
            /// Turns off processing of prefix characters. Normally, <see cref="DrawText(SafeDCHandle, char*, int, RECT*, TextFormats)"/> interprets the mnemonic-prefix character &amp; as a directive to underscore the character that follows,
            /// and the mnemonic-prefix characters &amp;&amp; as a directive to print a single &amp;.
            /// By specifying DT_NOPREFIX, this processing is turned off.
            /// </summary>
            /// <example>
            /// input string: "A&amp;bc&amp;&amp;d"
            /// normal: "Abc&amp;d"
            /// DT_NOPREFIX: "A&amp;bc&amp;&amp;d"
            /// </example>
            /// <remarks>Compare with <see cref="DT_HIDEPREFIX"/> and <see cref="DT_PREFIXONLY"/>.</remarks>
            DT_NOPREFIX = 0x00000800,

            /// <summary>
            /// Uses the system font to calculate text metrics.
            /// </summary>
            DT_INTERNAL = 0x00001000,

            /// <summary>
            /// Duplicates the text-displaying characteristics of a multiline edit control.
            /// Specifically, the average character width is calculated in the same manner as for an edit control,
            /// and the function does not display a partially visible last line.
            /// </summary>
            DT_EDITCONTROL = 0x00002000,

            /// <summary>
            /// For displayed text, replaces characters in the middle of the string with ellipses so that the result fits in the specified rectangle.
            /// If the string contains backslash (\) characters, DT_PATH_ELLIPSIS preserves as much as possible of the text after the last backslash.
            /// The string is not modified unless the <see cref="DT_MODIFYSTRING"/> flag is specified.
            /// </summary>
            /// <remarks>Compare with <see cref="DT_END_ELLIPSIS"/> and <see cref="DT_WORD_ELLIPSIS"/>.</remarks>
            DT_PATH_ELLIPSIS = 0x00004000,

            /// <summary>
            /// For displayed text, if the end of a string does not fit in the rectangle, it is truncated and ellipses are added.
            /// If a word that is not at the end of the string goes beyond the limits of the rectangle, it is truncated without ellipses.
            /// The string is not modified unless the <see cref="DT_MODIFYSTRING"/> flag is specified.
            /// </summary>
            /// <remarks>Compare with <see cref="DT_PATH_ELLIPSIS"/> and <see cref="DT_WORD_ELLIPSIS"/>.</remarks>
            DT_END_ELLIPSIS = 0x00008000,

            /// <summary>
            /// Modifies the specified string to match the displayed text.
            /// </summary>
            /// <remarks>This value has no effect unless <see cref="DT_END_ELLIPSIS"/> or <see cref="DT_PATH_ELLIPSIS"/> is specified.</remarks>
            DT_MODIFYSTRING = 0x00010000,

            /// <summary>
            /// Layout in right-to-left reading order for bidirectional text when the font selected into the hdc is a Hebrew or Arabic font.
            /// The default reading order for all text is left-to-right.
            /// </summary>
            DT_RTLREADING = 0x00020000,

            /// <summary>
            /// Truncates any word that does not fit in the rectangle and adds ellipses.
            /// </summary>
            /// <remarks>Compare with <see cref="DT_END_ELLIPSIS"/> and <see cref="DT_PATH_ELLIPSIS"/>.</remarks>
            DT_WORD_ELLIPSIS = 0x00040000,

            /// <summary>
            /// Prevents a line break at a DBCS (double-wide character string), so that the line breaking rule is equivalent to SBCS strings.
            /// For example, this can be used in Korean windows, for more readability of icon labels.
            /// </summary>
            /// <remarks>This value has no effect unless <see cref="DT_WORDBREAK"/> is specified.</remarks>
            DT_NOFULLWIDTHCHARBREAK = 0x00080000,

            /// <summary>
            /// Ignores the ampersand (&amp;) prefix character in the text. The letter that follows will not be underlined,
            /// but other mnemonic-prefix characters are still processed.
            /// </summary>
            /// <example>
            /// input string: "A&amp;b&amp;&amp;d"
            /// normal: "Abc&amp;d"
            /// DT_HIDEPREFIX: "Abc&amp;d"
            /// </example>
            /// <remarks>Compare with <see cref="DT_NOPREFIX"/> and <see cref="DT_PREFIXONLY"/>.</remarks>
            DT_HIDEPREFIX = 0x00100000,

            /// <summary>
            /// Draws only an underline at the position of the character following the ampersand (&amp;) prefix character.
            /// Does not draw any other characters in the string.
            /// </summary>
            /// <example>
            /// input string: "A&amp;b&amp;&amp;d"
            /// normal: "Abc&amp;d"
            /// DT_HIDEPREFIX: " _ "
            /// </example>
            /// <remarks>Compare with <see cref="DT_HIDEPREFIX "/> and <see cref="DT_NOPREFIX"/>.</remarks>
            DT_PREFIXONLY = 0x00200000
        }
    }
}