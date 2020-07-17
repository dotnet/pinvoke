// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains information about the initialization and environment of a printer or a display device.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct DEVMODE
    {
        public const int CCHDEVICENAME = 32;
        public const int CCHFORMNAME = 32;

        /// <summary>
        /// A zero-terminated character array that specifies the "friendly" name of the printer or display; for example, "PCL/HP LaserJet" in the case of PCL/HP LaserJet.
        /// This string is unique among device drivers. Note that this name may be truncated to fit in the <see cref="dmDeviceName"/> array.
        /// </summary>
        [FieldOffset(0)]
        public fixed char dmDeviceName[CCHDEVICENAME];

        /// <summary>
        /// The version number of the initialization data specification on which the structure is based.
        /// To ensure the correct version is used for any operating system, use <c>DM_SPECVERSION</c>.
        /// </summary>
        [FieldOffset(64)]
        public ushort dmSpecVersion;

        /// <summary>
        /// The driver version number assigned by the driver developer.
        /// </summary>
        [FieldOffset(66)]
        public ushort dmDriverVersion;

        /// <summary>
        /// Specifies the size, in bytes, of the <see cref="DEVMODE"/> structure, not including any private driver-specific data that might follow the structure's public members
        /// Set this member to size of <see cref="DEVMODE"/> to indicate the version of the <see cref="DEVMODE"/> structure being used.
        /// </summary>
        [FieldOffset(68)]
        public ushort dmSize;

        /// <summary>
        /// Contains the number of bytes of private driver-data that follow this structure.
        /// If a device driver does not use device-specific information, set this member to zero.
        /// </summary>
        [FieldOffset(70)]
        public ushort dmDriverExtra;

        /// <summary>
        /// Specifies whether certain members of the <see cref="DEVMODE"/> structure have been initialized.
        /// If a member is initialized, its corresponding bit is set, otherwise the bit is clear. A driver supports only those <see cref="DEVMODE"/> members that are appropriate for the printer or display technology.
        /// </summary>
        [FieldOffset(72)]
        public FieldUseFlags dmFields;

        /// <summary>
        /// For printers, specifies the paper orientation.
        /// </summary>
        /// <remarks>
        /// This member is not used for displays.
        /// </remarks>
        [FieldOffset(76)]
        public PrinterOrientationOptions dmOrientation;

        /// <summary>
        /// For printers, specifies the size of the paper to be printed on.
        /// This member must be zero if the length and width of the paper are specified by the <see cref="dmPaperLength"/> and <see cref="dmPaperWidth"/> members.
        /// Otherwise, this member must be one of the <see cref="PrintPaperOptions"/>.
        /// </summary>
        /// <remarks>
        /// This member is not used for displays.
        /// </remarks>
        [FieldOffset(78)]
        public PrintPaperOptions dmPaperSize;

        /// <summary>
        /// For printers, specifies the length of the paper, in units of 1/10 of a millimeter.
        /// This value overrides the length of the paper specified by the <see cref="dmPaperSize"/> member, and is used if the paper is of a custom size, or if the device is a dot matrix printer, which can print a page of arbitrary length.
        /// </summary>
        /// <remarks>
        /// This member is not used for displays.
        /// </remarks>
        [FieldOffset(80)]
        public short dmPaperLength;

        /// <summary>
        /// For printers, specifies the width of the paper, in units of 1/10 of a millimeter.
        /// This value overrides the width of the paper specified by the <see cref="dmPaperSize"/> member.
        /// This member must be used if <see cref="dmPaperLength"/> is used.
        /// </summary>
        /// <remarks>
        /// This member is not used for displays.
        /// </remarks>
        [FieldOffset(82)]
        public short dmPaperWidth;

        /// <summary>
        /// For printers, specifies the percentage by which the image is to be scaled for printing.
        /// The image's page size is scaled to the physical page by a factor of <see cref="dmScale"/>/100.
        /// For example, a 17-inch by 22-inch image with a scale value of 100 requires 17x22-inch paper, while the same image with a scale value of 50 should print as half-sized and fit on letter-sized paper.
        /// </summary>
        /// <remarks>
        /// This member is not used for displays.
        /// </remarks>
        [FieldOffset(84)]
        public short dmScale;

        /// <summary>
        /// For printers, specifies the number of copies to be printed, if the device supports multiple copies.
        /// </summary>
        /// <remarks>
        /// This member is not used for displays.
        /// </remarks>
        [FieldOffset(86)]
        public short dmCopies;

        /// <summary>
        /// For printers, specifies the printer's default input bin.
        /// </summary>
        /// <remarks>
        /// This member is not used for displays.
        /// </remarks>
        [FieldOffset(88)]
        public PrintBinSelectionOptions dmDefaultSource;

        /// <summary>
        /// For printers, specifies the printer resolution.
        /// If a positive value is specified, it represents the number of dots per inch (DPI) for the x resolution, and the y resolution is specified by <see cref="dmYResolution"/>.
        /// </summary>
        /// <remarks>
        /// This member is not used for displays.
        /// </remarks>
        [FieldOffset(90)]
        public PrintQualityOptions dmPrintQuality;

        /// <summary>
        /// For displays, specifies a <see cref="POINT"/> structure containing the x- and y-coordinates of upper-left corner of the display, in desktop coordinates.
        /// This member is used to determine the relative position of monitors in a multiple monitor environment.
        /// </summary>
        /// <remarks>
        /// This member is not used for printers.
        /// </remarks>
        [FieldOffset(76)]
        public POINT dmPosition;

        /// <summary>
        /// This member is defined only for Windows XP and later.
        /// For displays, specifies the orientation at which images should be presented.
        /// When the <see cref="FieldUseFlags.DM_DISPLAYORIENTATION"/> bit is not set in the <see cref="dmFields"/> member, this member must be set to zero.
        /// When the <see cref="FieldUseFlags.DM_DISPLAYORIENTATION"/> bit is set in the <see cref="dmFields"/> member, this member must be set to one of the <see cref="DisplayOrientationOptions"/> values.
        /// </summary>
        /// <remarks>
        /// This member is not used for printers.
        /// </remarks>
        [FieldOffset(84)]
        public DisplayOrientationOptions dmDisplayOrientation;

        /// <summary>
        /// This member is defined only for Windows XP and later.
        /// For fixed-resolution displays, specifies how the device can present a lower - resolution mode on a higher - resolution display.
        /// For example, if a display device's resolution is fixed at 1024 X 768, and its mode is set to 640 x 480, the device can either display a 640 X 480 image within the 1024 X 768 screen space, or stretch the 640 X 480 image to fill the larger screen space.
        /// When the <see cref="FieldUseFlags.DM_DISPLAYFIXEDOUTPUT"/> bit is not set in the <see cref="dmFields"/> member, this member must be set to zero.
        /// When the <see cref="FieldUseFlags.DM_DISPLAYFIXEDOUTPUT"/> bit is set in the <see cref="dmFields"/> member, this member must be set to one of the <see cref="DisplayFixedOutputOptions"/> values.
        /// </summary>
        /// <remarks>
        /// This member is not used for printers.
        /// </remarks>
        [FieldOffset(88)]
        public DisplayFixedOutputOptions dmDisplayFixedOutput;

        /// <summary>
        /// For printers, specifies whether a color printer should print color or monochrome.
        /// </summary>
        /// <remarks>
        /// This member is not used for displays.
        /// </remarks>
        [FieldOffset(92)]
        public PrintColorOptions dmColor;

        /// <summary>
        /// For printers, specifies duplex (double-sided) printing for duplex-capable printers.
        /// </summary>
        /// <remarks>
        /// This member is not used for displays.
        /// </remarks>
        [FieldOffset(94)]
        public PrintDuplexOptions dmDuplex;

        /// <summary>
        /// Specifies the y-resolution, in dots per inch, of the printer. If the printer initializes this member, the <c>dmPrintQuality</c> member specifies the x-resolution, in dots per inch, of the printer.
        /// </summary>
        /// <remarks>
        /// This member is not used for displays.
        /// </remarks>
        [FieldOffset(96)]
        public short dmYResolution;

        /// <summary>
        /// For printers, specifies how TrueType fonts should be printed. This member must be one of the <see cref="TrueTypeOptions"/> values.
        /// </summary>
        /// <remarks>
        /// This member is not used for displays.
        /// </remarks>
        [FieldOffset(98)]
        public TrueTypeOptions dmTTOption;

        /// <summary>
        /// For printers, specifies whether multiple copies should be collated. This member can be one of <see cref="CollationSelectionOptions"/> values.
        /// </summary>
        /// <remarks>
        /// This member is not used for displays.
        /// </remarks>
        [FieldOffset(100)]
        public CollationSelectionOptions dmCollate;

        /// <summary>
        /// A zero-terminated character array that specifies the name of the form to use; for example, "Letter" or "Legal". A complete set of names can be retrieved by using the EnumForms function.
        /// </summary>
        /// <remarks>
        /// This member is not used for displays.
        /// </remarks>
        [FieldOffset(102)]
        public fixed char dmFormName[CCHFORMNAME];

        /// <summary>
        /// The number of pixels per logical inch. Printer drivers do not use this member.
        /// </summary>
        /// <remarks>
        /// This member is not used for printers.
        /// </remarks>
        [FieldOffset(166)]
        public ushort dmLogPixels;

        /// <summary>
        /// Specifies the color resolution, in bits per pixel, of the display device (for example: 4 bits for 16 colors, 8 bits for 256 colors, or 16 bits for 65,536 colors).
        /// Display drivers use this member, for example, in the <c>User32.EnumDisplaySettings</c> function.
        /// Printer drivers do not use this member.
        /// </summary>
        /// <remarks>
        /// This member is not used for printers.
        /// </remarks>
        [FieldOffset(168)]
        public uint dmBitsPerPel;

        /// <summary>
        /// Specifies the width, in pixels, of the visible device surface.
        /// Display drivers use this member, for example, in the <c>User32.EnumDisplaySettings</c> function.
        /// Printer drivers do not use this member.
        /// </summary>
        /// <remarks>
        /// This member is not used for printers.
        /// </remarks>
        [FieldOffset(172)]
        public uint dmPelsWidth;

        /// <summary>
        /// Specifies the height, in pixels, of the visible device surface.
        /// Display drivers use this member, for example, in the <c>User32.EnumDisplaySettings</c> function.
        /// Printer drivers do not use this member.
        /// </summary>
        /// <remarks>
        /// This member is not used for printers.
        /// </remarks>
        [FieldOffset(176)]
        public uint dmPelsHeight;

        /// <summary>
        /// For displays, specifies a display device's display mode. This member can be one of the <see cref="DisplayOptions"/> flags.
        /// </summary>
        /// <remarks>
        /// This member is not used for printers.
        /// </remarks>
        [FieldOffset(180)]
        public DisplayOptions dmDisplayFlags;

        /// <summary>
        /// For printers, specifies whether the print system handles "N-up" printing (playing multiple EMF logical pages onto a single physical page).
        /// </summary>
        /// <remarks>
        /// This member is not used for displays.
        /// </remarks>
        [FieldOffset(180)]
        public PrinterOptions dmNup;

        /// <summary>
        /// Specifies the frequency, in hertz (cycles per second), of the display device in a particular mode.
        /// This value is also known as the display device's vertical refresh rate. Display drivers use this member.
        /// It is used, for example, in the ChangeDisplaySettings function. Printer drivers do not use this member.
        /// </summary>
        /// <remarks>
        /// When you call the <c>User32.EnumDisplaySettings</c> function, the <see cref="dmDisplayFrequency"/> member may return with the value 0 or 1.
        /// These values represent the display hardware's default refresh rate.
        /// This default rate is typically set by switches on a display card or computer motherboard, or by a configuration program that does not use display functions such as <c>User32.EnumDisplaySettings</c>.
        /// </remarks>
        /// <remarks>
        /// This member is not used for printers.
        /// </remarks>
        [FieldOffset(148)]
        public uint dmDisplayFrequency;

        /// <summary>
        /// Specifies one of the <see cref="DeviceIcmMethodOptions"/> constants.
        /// </summary>
        [FieldOffset(188)]
        public DeviceIcmMethodOptions dmICMMethod;

        /// <summary>
        /// Specifies one of the <see cref="DeviceIcmIntentOptions"/> constants.
        /// </summary>
        [FieldOffset(192)]
        public DeviceIcmIntentOptions dmICMIntent;

        /// <summary>
        /// Specifies one of the <see cref="DeviceMediaTypeOptions"/> constants.
        /// </summary>
        [FieldOffset(196)]
        public DeviceMediaTypeOptions dmMediaType;

        /// <summary>
        /// Specifies one of the <see cref="DitherTypeOptions"/> constants.
        /// </summary>
        [FieldOffset(200)]
        public DitherTypeOptions dmDitherType;

        /// <summary>
        /// Not used; must be zero.
        /// </summary>
        [FieldOffset(204)]
        public uint dmReserved1;

        /// <summary>
        /// Not used; must be zero.
        /// </summary>
        [FieldOffset(208)]
        public uint dmReserved2;

        /// <summary>
        /// This member must be zero.
        /// </summary>
        [FieldOffset(212)]
        public uint dmPanningWidth;

        /// <summary>
        /// This member must be zero.
        /// </summary>
        [FieldOffset(216)]
        public uint dmPanningHeight;

        /// <summary>
        /// Initializes a new instance of the <see cref="DEVMODE"/> struct
        /// with the <see cref="dmSize" /> field initialized.
        /// </summary>
        /// <returns>
        /// An instance of the structure.
        /// </returns>
        public static DEVMODE Create() => new DEVMODE { dmSize = (ushort)sizeof(DEVMODE) };

        /// <summary>Defines the values that may be used in the <see cref="DEVMODE.dmFields" /> member.</summary>
        [Flags]
        [SuppressMessage("Compiler", "SA1201:Elements should appear in the correct order", Justification = "Special")]
        public enum FieldUseFlags : uint
        {
            /// <summary>
            /// Not set.
            /// </summary>
            NONE = 0,
            DM_ORIENTATION = 0x00000001,
            DM_PAPERSIZE = 0x00000002,
            DM_PAPERLENGTH = 0x00000004,
            DM_PAPERWIDTH = 0x00000008,
            DM_SCALE = 0x00000010,

            // #if (WINVER >= 0x0500)
            DM_POSITION = 0x00000020,
            DM_NUP = 0x00000040,

            // #endif /* WINVER >= 0x0500 */

            // #if (WINVER >= 0x0501)
            DM_DISPLAYORIENTATION = 0x00000080,

            // #endif /* WINVER >= 0x0501 */
            DM_COPIES = 0x00000100,
            DM_DEFAULTSOURCE = 0x00000200,
            DM_PRINTQUALITY = 0x00000400,
            DM_COLOR = 0x00000800,
            DM_DUPLEX = 0x00001000,
            DM_YRESOLUTION = 0x00002000,
            DM_TTOPTION = 0x00004000,
            DM_COLLATE = 0x00008000,
            DM_FORMNAME = 0x00010000,
            DM_LOGPIXELS = 0x00020000,
            DM_BITSPERPEL = 0x00040000,
            DM_PELSWIDTH = 0x00080000,
            DM_PELSHEIGHT = 0x00100000,
            DM_DISPLAYFLAGS = 0x00200000,
            DM_DISPLAYFREQUENCY = 0x00400000,

            // #if (WINVER >= 0x0400)
            DM_ICMMETHOD = 0x00800000,
            DM_ICMINTENT = 0x01000000,
            DM_MEDIATYPE = 0x02000000,
            DM_DITHERTYPE = 0x04000000,
            DM_PANNINGWIDTH = 0x08000000,
            DM_PANNINGHEIGHT = 0x10000000,

            // #endif /* WINVER >= 0x0400 */

            // #if (WINVER >= 0x0501)
            DM_DISPLAYFIXEDOUTPUT = 0x20000000,
        }

        /// <summary>Defines the values that may be used in the <see cref="DEVMODE.dmOrientation" /> member.</summary>
        public enum PrinterOrientationOptions : short
        {
            DMORIENT_PORTRAIT = 1,
            DMORIENT_LANDSCAPE = 2,
        }

        /// <summary>Defines the values that may be used in the <see cref="DEVMODE.dmPaperSize" /> member.</summary>
        public enum PrintPaperOptions : short
        {
            /// <summary>
            ///  If the length and width of the paper are both set by the <see cref="DEVMODE.dmPaperLength"/> and <see cref="DEVMODE.dmPaperWidth"/> members.
            /// </summary>
            NONE = 0,

            /// <summary>
            /// DMPAPER_FIRST.
            /// </summary>
            DMPAPER_FIRST = DMPAPER_LETTER,

            /// <summary>
            /// Letter 8 1/2 x 11 in.
            /// </summary>
            DMPAPER_LETTER = 1,

            /// <summary>
            /// Letter Small 8 1/2 x 11 in.
            /// </summary>
            DMPAPER_LETTERSMALL = 2,

            /// <summary>
            /// Tabloid 11 x 17 in.
            /// </summary>
            DMPAPER_TABLOID = 3,

            /// <summary>
            /// Ledger 17 x 11 in.
            /// </summary>
            DMPAPER_LEDGER = 4,

            /// <summary>
            /// Legal 8 1/2 x 14 in.
            /// </summary>
            DMPAPER_LEGAL = 5,

            /// <summary>
            /// Statement 5 1/2 x 8 1/2 in.
            /// </summary>
            DMPAPER_STATEMENT = 6,

            /// <summary>
            /// Executive 7 1/4 x 10 1/2 in.
            /// </summary>
            DMPAPER_EXECUTIVE = 7,

            /// <summary>
            /// A3 297 x 420 mm.
            /// </summary>
            DMPAPER_A3 = 8,

            /// <summary>
            /// A4 210 x 297 mm.
            /// </summary>
            DMPAPER_A4 = 9,

            /// <summary>
            /// A4 Small 210 x 297 mm.
            /// </summary>
            DMPAPER_A4SMALL = 10,

            /// <summary>
            /// A5 148 x 210 mm.
            /// </summary>
            DMPAPER_A5 = 11,

            /// <summary>
            /// B4 (JIS) 250 x 354.
            /// </summary>
            DMPAPER_B4 = 12,

            /// <summary>
            /// B5 (JIS) 182 x 257 mm.
            /// </summary>
            DMPAPER_B5 = 13,

            /// <summary>
            /// Folio 8 1/2 x 13 in.
            /// </summary>
            DMPAPER_FOLIO = 14,

            /// <summary>
            /// Quarto 215 x 275 mm.
            /// </summary>
            DMPAPER_QUARTO = 15,

            /// <summary>
            /// 10x14 in.
            /// </summary>
            DMPAPER_10X14 = 16,

            /// <summary>
            /// 11x17 in.
            /// </summary>
            DMPAPER_11X17 = 17,

            /// <summary>
            /// Note 8 1/2 x 11 in.
            /// </summary>
            DMPAPER_NOTE = 18,

            /// <summary>
            /// Envelope #9 3 7/8 x 8 7/8.
            /// </summary>
            DMPAPER_ENV_9 = 19,

            /// <summary>
            /// Envelope #10 4 1/8 x 9 1/2.
            /// </summary>
            DMPAPER_ENV_10 = 20,

            /// <summary>
            /// Envelope #11 4 1/2 x 10 3/8.
            /// </summary>
            DMPAPER_ENV_11 = 21,

            /// <summary>
            /// Envelope #12 4 \276 x 11.
            /// </summary>
            DMPAPER_ENV_12 = 22,

            /// <summary>
            /// Envelope #14 5 x 11 1/2.
            /// </summary>
            DMPAPER_ENV_14 = 23,

            /// <summary>
            /// C size sheet.
            /// </summary>
            DMPAPER_CSHEET = 24,

            /// <summary>
            /// D size sheet.
            /// </summary>
            DMPAPER_DSHEET = 25,

            /// <summary>
            /// E size sheet.
            /// </summary>
            DMPAPER_ESHEET = 26,

            /// <summary>
            /// Envelope DL 110 x 220mm.
            /// </summary>
            DMPAPER_ENV_DL = 27,

            /// <summary>
            /// Envelope C5 162 x 229 mm.
            /// </summary>
            DMPAPER_ENV_C5 = 28,

            /// <summary>
            /// Envelope C3  324 x 458 mm.
            /// </summary>
            DMPAPER_ENV_C3 = 29,

            /// <summary>
            /// Envelope C4  229 x 324 mm.
            /// </summary>
            DMPAPER_ENV_C4 = 30,

            /// <summary>
            /// Envelope C6  114 x 162 mm.
            /// </summary>
            DMPAPER_ENV_C6 = 31,

            /// <summary>
            /// Envelope C65 114 x 229 mm.
            /// </summary>
            DMPAPER_ENV_C65 = 32,

            /// <summary>
            /// Envelope B4  250 x 353 mm.
            /// </summary>
            DMPAPER_ENV_B4 = 33,

            /// <summary>
            /// Envelope B5  176 x 250 mm.
            /// </summary>
            DMPAPER_ENV_B5 = 34,

            /// <summary>
            /// Envelope B6  176 x 125 mm.
            /// </summary>
            DMPAPER_ENV_B6 = 35,

            /// <summary>
            /// Envelope 110 x 230 mm.
            /// </summary>
            DMPAPER_ENV_ITALY = 36,

            /// <summary>
            /// Envelope Monarch 3.875 x 7.5 in.
            /// </summary>
            DMPAPER_ENV_MONARCH = 37,

            /// <summary>
            /// 6 3/4 Envelope 3 5/8 x 6 1/2 in.
            /// </summary>
            DMPAPER_ENV_PERSONAL = 38,

            /// <summary>
            /// US Std Fanfold 14 7/8 x 11 in.
            /// </summary>
            DMPAPER_FANFOLD_US = 39,

            /// <summary>
            /// German Std Fanfold 8 1/2 x 12 in.
            /// </summary>
            DMPAPER_FANFOLD_STD_GERMAN = 40,

            /// <summary>
            /// German Legal Fanfold 8 1/2 x 13 in.
            /// </summary>
            DMPAPER_FANFOLD_LGL_GERMAN = 41,

            /// <summary>
            /// B4 (ISO) 250 x 353 mm.
            /// </summary>
            DMPAPER_ISO_B4 = 42,

            /// <summary>
            /// Japanese Postcard 100 x 148 mm.
            /// </summary>
            DMPAPER_JAPANESE_POSTCARD = 43,

            /// <summary>
            /// 9 x 11 in.
            /// </summary>
            DMPAPER_9X11 = 44,

            /// <summary>
            /// 10 x 11 in.
            /// </summary>
            DMPAPER_10X11 = 45,

            /// <summary>
            /// 15 x 11 in.
            /// </summary>
            DMPAPER_15X11 = 46,

            /// <summary>
            /// Envelope Invite 220 x 220 mm.
            /// </summary>
            DMPAPER_ENV_INVITE = 47,

            /// <summary>
            /// RESERVED--DO NOT USE.
            /// </summary>
            DMPAPER_RESERVED_48 = 48,

            /// <summary>
            /// RESERVED--DO NOT USE.
            /// </summary>
            DMPAPER_RESERVED_49 = 49,

            /// <summary>
            /// Letter Extra 9 \275 x 12 in.
            /// </summary>
            DMPAPER_LETTER_EXTRA = 50,

            /// <summary>
            /// Legal Extra 9 \275 x 15 in.
            /// </summary>
            DMPAPER_LEGAL_EXTRA = 51,

            /// <summary>
            /// Tabloid Extra 11.69 x 18 in.
            /// </summary>
            DMPAPER_TABLOID_EXTRA = 52,

            /// <summary>
            /// A4 Extra 9.27 x 12.69 in.
            /// </summary>
            DMPAPER_A4_EXTRA = 53,

            /// <summary>
            /// Letter Transverse 8 \275 x 11 in.
            /// </summary>
            DMPAPER_LETTER_TRANSVERSE = 54,

            /// <summary>
            /// A4 Transverse 210 x 297 mm.
            /// </summary>
            DMPAPER_A4_TRANSVERSE = 55,

            /// <summary>
            /// Letter Extra Transverse 9\275 x 12 in.
            /// </summary>
            DMPAPER_LETTER_EXTRA_TRANSVERSE = 56,

            /// <summary>
            /// SuperA/SuperA/A4 227 x 356 mm.
            /// </summary>
            DMPAPER_A_PLUS = 57,

            /// <summary>
            /// SuperB/SuperB/A3 305 x 487 mm.
            /// </summary>
            DMPAPER_B_PLUS = 58,

            /// <summary>
            /// Letter Plus 8.5 x 12.69 in.
            /// </summary>
            DMPAPER_LETTER_PLUS = 59,

            /// <summary>
            /// A4 Plus 210 x 330 mm.
            /// </summary>
            DMPAPER_A4_PLUS = 60,

            /// <summary>
            /// A5 Transverse 148 x 210 mm.
            /// </summary>
            DMPAPER_A5_TRANSVERSE = 61,

            /// <summary>
            /// B5 (JIS) Transverse 182 x 257 mm.
            /// </summary>
            DMPAPER_B5_TRANSVERSE = 62,

            /// <summary>
            /// A3 Extra 322 x 445 mm.
            /// </summary>
            DMPAPER_A3_EXTRA = 63,

            /// <summary>
            /// A5 Extra 174 x 235 mm.
            /// </summary>
            DMPAPER_A5_EXTRA = 64,

            /// <summary>
            /// B5 (ISO) Extra 201 x 276 mm.
            /// </summary>
            DMPAPER_B5_EXTRA = 65,

            /// <summary>
            /// A2 420 x 594 mm.
            /// </summary>
            DMPAPER_A2 = 66,

            /// <summary>
            /// A3 Transverse 297 x 420 mm.
            /// </summary>
            DMPAPER_A3_TRANSVERSE = 67,

            /// <summary>
            /// A3 Extra Transverse 322 x 445 mm.
            /// </summary>
            DMPAPER_A3_EXTRA_TRANSVERSE = 68,

            /// <summary>
            /// Japanese Double Postcard 200 x 148 mm.
            /// </summary>
            DMPAPER_DBL_JAPANESE_POSTCARD = 69,

            /// <summary>
            /// A6 105 x 148 mm.
            /// </summary>
            DMPAPER_A6 = 70,

            /// <summary>
            /// Japanese Envelope Kaku #2.
            /// </summary>
            DMPAPER_JENV_KAKU2 = 71,

            /// <summary>
            /// Japanese Envelope Kaku #3.
            /// </summary>
            DMPAPER_JENV_KAKU3 = 72,

            /// <summary>
            /// Japanese Envelope Chou #3.
            /// </summary>
            DMPAPER_JENV_CHOU3 = 73,

            /// <summary>
            /// Japanese Envelope Chou #4.
            /// </summary>
            DMPAPER_JENV_CHOU4 = 74,

            /// <summary>
            /// Letter Rotated 11 x 8 1/2 11 in.
            /// </summary>
            DMPAPER_LETTER_ROTATED = 75,

            /// <summary>
            /// A3 Rotated 420 x 297 mm.
            /// </summary>
            DMPAPER_A3_ROTATED = 76,

            /// <summary>
            /// A4 Rotated 297 x 210 mm.
            /// </summary>
            DMPAPER_A4_ROTATED = 77,

            /// <summary>
            /// A5 Rotated 210 x 148 mm.
            /// </summary>
            DMPAPER_A5_ROTATED = 78,

            /// <summary>
            /// B4 (JIS) Rotated 364 x 257 mm.
            /// </summary>
            DMPAPER_B4_JIS_ROTATED = 79,

            /// <summary>
            /// B5 (JIS) Rotated 257 x 182 mm.
            /// </summary>
            DMPAPER_B5_JIS_ROTATED = 80,

            /// <summary>
            /// Japanese Postcard Rotated 148 x 100 mm.
            /// </summary>
            DMPAPER_JAPANESE_POSTCARD_ROTATED = 81,

            /// <summary>
            /// Double Japanese Postcard Rotated 148 x 200 mm.
            /// </summary>
            DMPAPER_DBL_JAPANESE_POSTCARD_ROTATED = 82,

            /// <summary>
            /// A6 Rotated 148 x 105 mm.
            /// </summary>
            DMPAPER_A6_ROTATED = 83,

            /// <summary>
            /// Japanese Envelope Kaku #2 Rotated.
            /// </summary>
            DMPAPER_JENV_KAKU2_ROTATED = 84,

            /// <summary>
            /// Japanese Envelope Kaku #3 Rotated.
            /// </summary>
            DMPAPER_JENV_KAKU3_ROTATED = 85,

            /// <summary>
            /// Japanese Envelope Chou #3 Rotated.
            /// </summary>
            DMPAPER_JENV_CHOU3_ROTATED = 86,

            /// <summary>
            /// Japanese Envelope Chou #4 Rotated.
            /// </summary>
            DMPAPER_JENV_CHOU4_ROTATED = 87,

            /// <summary>
            /// B6 (JIS) 128 x 182 mm.
            /// </summary>
            DMPAPER_B6_JIS = 88,

            /// <summary>
            /// B6 (JIS) Rotated 182 x 128 mm.
            /// </summary>
            DMPAPER_B6_JIS_ROTATED = 89,

            /// <summary>
            /// 12 x 11 in.
            /// </summary>
            DMPAPER_12X11 = 90,

            /// <summary>
            /// Japanese Envelope You #4.
            /// </summary>
            DMPAPER_JENV_YOU4 = 91,

            /// <summary>
            /// Japanese Envelope You #4 Rotated.
            /// </summary>
            DMPAPER_JENV_YOU4_ROTATED = 92,

            /// <summary>
            /// PRC 16K 146 x 215 mm.
            /// </summary>
            DMPAPER_P16K = 93,

            /// <summary>
            /// PRC 32K 97 x 151 mm.
            /// </summary>
            DMPAPER_P32K = 94,

            /// <summary>
            /// PRC 32K(Big) 97 x 151 mm.
            /// </summary>
            DMPAPER_P32KBIG = 95,

            /// <summary>
            /// PRC Envelope #1 102 x 165 mm.
            /// </summary>
            DMPAPER_PENV_1 = 96,

            /// <summary>
            /// PRC Envelope #2 102 x 176 mm.
            /// </summary>
            DMPAPER_PENV_2 = 97,

            /// <summary>
            /// PRC Envelope #3 125 x 176 mm.
            /// </summary>
            DMPAPER_PENV_3 = 98,

            /// <summary>
            /// PRC Envelope #4 110 x 208 mm.
            /// </summary>
            DMPAPER_PENV_4 = 99,

            /// <summary>
            /// PRC Envelope #5 110 x 220 mm.
            /// </summary>
            DMPAPER_PENV_5 = 100,

            /// <summary>
            /// PRC Envelope #6 120 x 230 mm.
            /// </summary>
            DMPAPER_PENV_6 = 101,

            /// <summary>
            /// PRC Envelope #7 160 x 230 mm.
            /// </summary>
            DMPAPER_PENV_7 = 102,

            /// <summary>
            /// PRC Envelope #8 120 x 309 mm.
            /// </summary>
            DMPAPER_PENV_8 = 103,

            /// <summary>
            /// PRC Envelope #9 229 x 324 mm.
            /// </summary>
            DMPAPER_PENV_9 = 104,

            /// <summary>
            /// PRC Envelope #10 324 x 458 mm.
            /// </summary>
            DMPAPER_PENV_10 = 105,

            /// <summary>
            /// PRC 16K Rotated.
            /// </summary>
            DMPAPER_P16K_ROTATED = 106,

            /// <summary>
            /// PRC 32K Rotated.
            /// </summary>
            DMPAPER_P32K_ROTATED = 107,

            /// <summary>
            /// PRC 32K(Big) Rotated.
            /// </summary>
            DMPAPER_P32KBIG_ROTATED = 108,

            /// <summary>
            /// PRC Envelope #1 Rotated 165 x 102 mm.
            /// </summary>
            DMPAPER_PENV_1_ROTATED = 109,

            /// <summary>
            /// PRC Envelope #2 Rotated 176 x 102 mm.
            /// </summary>
            DMPAPER_PENV_2_ROTATED = 110,

            /// <summary>
            /// PRC Envelope #3 Rotated 176 x 125 mm.
            /// </summary>
            DMPAPER_PENV_3_ROTATED = 111,

            /// <summary>
            /// PRC Envelope #4 Rotated 208 x 110 mm.
            /// </summary>
            DMPAPER_PENV_4_ROTATED = 112,

            /// <summary>
            /// PRC Envelope #5 Rotated 220 x 110 mm.
            /// </summary>
            DMPAPER_PENV_5_ROTATED = 113,

            /// <summary>
            /// PRC Envelope #6 Rotated 230 x 120 mm.
            /// </summary>
            DMPAPER_PENV_6_ROTATED = 114,

            /// <summary>
            /// PRC Envelope #7 Rotated 230 x 160 mm.
            /// </summary>
            DMPAPER_PENV_7_ROTATED = 115,

            /// <summary>
            /// PRC Envelope #8 Rotated 309 x 120 mm.
            /// </summary>
            DMPAPER_PENV_8_ROTATED = 116,

            /// <summary>
            /// PRC Envelope #9 Rotated 324 x 229 mm.
            /// </summary>
            DMPAPER_PENV_9_ROTATED = 117,

            /// <summary>
            /// PRC Envelope #10 Rotated 458 x 324 mm.
            /// </summary>
            DMPAPER_PENV_10_ROTATED = 118,

            /// <summary>
            /// DMPAPER_LAST.
            /// </summary>
            DMPAPER_LAST = DMPAPER_PENV_10_ROTATED,

            /// <summary>
            /// DMPAPER_USER.
            /// </summary>
            DMPAPER_USER = 256,
        }

        /// <summary>Defines the values that may be used in the <see cref="DEVMODE.dmDefaultSource" /> member.</summary>
        public enum PrintBinSelectionOptions : short
        {
            DMBIN_FIRST = DMBIN_UPPER,
            DMBIN_UPPER = 1,
            DMBIN_ONLYONE = 1,
            DMBIN_LOWER = 2,
            DMBIN_MIDDLE = 3,
            DMBIN_MANUAL = 4,
            DMBIN_ENVELOPE = 5,
            DMBIN_ENVMANUAL = 6,
            DMBIN_AUTO = 7,
            DMBIN_TRACTOR = 8,
            DMBIN_SMALLFMT = 9,
            DMBIN_LARGEFMT = 10,
            DMBIN_LARGECAPACITY = 11,
            DMBIN_CASSETTE = 14,
            DMBIN_FORMSOURCE = 15,
            DMBIN_LAST = DMBIN_FORMSOURCE,

            DMBIN_USER = 256,    /* device specific bins start here */
        }

        /// <summary>Defines the values that may be used in the <see cref="DEVMODE.dmPrintQuality" /> member.</summary>
        public enum PrintQualityOptions : short
        {
            DMRES_HIGH = -4,
            DMRES_MEDIUM = -3,
            DMRES_LOW = -2,
            DMRES_DRAFT = -1,
        }

        /// <summary>Defines the values that may be used in the <see cref="DEVMODE.dmDisplayOrientation" /> member.</summary>
        public enum DisplayOrientationOptions : uint
        {
            /// <summary>
            /// The current mode's display device orientation is the natural orientation of the device, and should be used as the default.
            /// </summary>
            DMDO_DEFAULT = 0,

            /// <summary>
            /// The display device orientation is 90 degrees (measured clockwise) from that of <see cref="DMDO_DEFAULT"/>.
            /// </summary>
            DMDO_90 = 1,

            /// <summary>
            /// The display device orientation is 180 degrees (measured clockwise) from that of <see cref="DMDO_DEFAULT"/>.
            /// </summary>
            DMDO_180 = 2,

            /// <summary>
            /// The display device orientation is 270 degrees (measured clockwise) from that of <see cref="DMDO_DEFAULT"/>.
            /// </summary>
            DMDO_270 = 3,
        }

        /// <summary>Defines the values that may be used in the <see cref="DEVMODE.dmDisplayFixedOutput" /> member.</summary>
        public enum DisplayFixedOutputOptions : uint
        {
            /// <summary>
            /// The display's default setting.
            /// </summary>
            DMDFO_DEFAULT = 0,

            /// <summary>
            /// The display device presents a lower-resolution mode image by stretching it to fill the larger screen space.
            /// </summary>
            DMDFO_STRETCH = 1,

            /// <summary>
            /// The display device presents a lower resolution mode image by centering it in the larger screen space.
            /// </summary>
            DMDFO_CENTER = 2,
        }

        /// <summary>Defines the values that may be used in the <see cref="DEVMODE.dmColor" /> member.</summary>
        public enum PrintColorOptions : short
        {
            DMCOLOR_MONOCHROME = 1,
            DMCOLOR_COLOR = 2,
        }

        /// <summary>Defines the values that may be used in the <see cref="DEVMODE.dmDuplex" /> member.</summary>
        public enum PrintDuplexOptions : short
        {
            /// <summary>
            /// Print single-sided.
            /// </summary>
            DMDUP_SIMPLEX = 1,

            /// <summary>
            /// Print double-sided, using long edge binding.
            /// </summary>
            DMDUP_VERTICAL = 2,

            /// <summary>
            /// Print double-sided, using short edge binding.
            /// </summary>
            DMDUP_HORIZONTAL = 3,
        }

        /// <summary>Defines the values that may be used in the <see cref="DEVMODE.dmTTOption" /> member.</summary>
        public enum TrueTypeOptions : short
        {
            /// <summary>
            /// Print TT fonts as graphics.
            /// </summary>
            DMTT_BITMAP = 1,

            /// <summary>
            /// Download TT fonts as soft fonts.
            /// </summary>
            DMTT_DOWNLOAD = 2,

            /// <summary>
            /// Substitute device fonts for TT fonts.
            /// </summary>
            DMTT_SUBDEV = 3,

            // #if (WINVER >= 0x0400)

            /// <summary>
            /// Download TT fonts as outline soft fonts.
            /// </summary>
            DMTT_DOWNLOAD_OUTLINE = 4,
        }

        /// <summary>Defines the values that may be used in the <see cref="DEVMODE.dmCollate" /> member.</summary>
        public enum CollationSelectionOptions : short
        {
            /// <summary>
            /// Do not collate when printing multiple copies.
            /// </summary>
            DMCOLLATE_FALSE = 0,

            /// <summary>
            /// Collate when printing multiple copies.
            /// </summary>
            DMCOLLATE_TRUE = 1,
        }

        /// <summary>Defines the values that may be used in the <see cref="DEVMODE.dmDisplayFlags" /> member.</summary>
        [Flags]
        public enum DisplayOptions : uint
        {
            /// <summary>
            /// Not set.
            /// </summary>
            NONE = 0x00000000,

            /// <summary>
            /// Specifies that the display is a noncolor device.
            /// If this flag is not set, color is assumed.
            /// </summary>
            DM_INTERLACED = 0x00000002,

            /// <summary>
            /// Specifies that the display mode is interlaced.
            /// If the flag is not set, noninterlaced is assumed.
            /// </summary>
            DMDISPLAYFLAGS_TEXTMODE = 0x00000004,
        }

        /// <summary>Defines the values that may be used in the <see cref="DEVMODE.dmNup" /> member.</summary>
        public enum PrinterOptions : uint
        {
            /// <summary>
            /// The print system handles "N-up" printing.
            /// </summary>
            DMNUP_SYSTEM = 1,

            /// <summary>
            /// The print system does not handle "N-up" printing. An application can set <see cref="DEVMODE.dmNup"/> to <see cref="DMNUP_ONEUP"/> if it intends to carry out "N-up" printing on its own.
            /// </summary>
            DMNUP_ONEUP = 2,
        }

        /// <summary>Defines the values that may be used in the <see cref="DEVMODE.dmICMMethod" /> member.</summary>
        public enum DeviceIcmMethodOptions : uint
        {
            /// <summary>
            /// ICM disabled.
            /// </summary>
            DMICMMETHOD_NONE = 1,

            /// <summary>
            /// ICM handled by system.
            /// </summary>
            DMICMMETHOD_SYSTEM = 2,

            /// <summary>
            /// ICM handled by driver.
            /// </summary>
            DMICMMETHOD_DRIVER = 3,

            /// <summary>
            /// ICM handled by device.
            /// </summary>
            DMICMMETHOD_DEVICE = 4,

            /// <summary>
            /// Device-specific methods start here.
            /// </summary>
            DMICMMETHOD_USER = 256,
        }

        /// <summary>Defines the values that may be used in the <see cref="DEVMODE.dmICMIntent" /> member.</summary>
        public enum DeviceIcmIntentOptions : uint
        {
            /// <summary>
            /// Maximize color saturation.
            /// </summary>
            DMICM_SATURATE = 1,

            /// <summary>
            /// Maximize color contrast.
            /// </summary>
            DMICM_CONTRAST = 2,

            /// <summary>
            /// Use specific color metric.
            /// </summary>
            DMICM_COLORIMETRIC = 3,

            /// <summary>
            /// Use specific color metric.
            /// </summary>
            DMICM_ABS_COLORIMETRIC = 4,

            /// <summary>
            /// Device-specific intents start here.
            /// </summary>
            DMICM_USER = 256,
        }

        /// <summary>Defines the values that may be used in the <see cref="DEVMODE.dmMediaType" /> member.</summary>
        public enum DeviceMediaTypeOptions : uint
        {
            /// <summary>
            /// Standard paper.
            /// </summary>
            DMMEDIA_STANDARD = 1,

            /// <summary>
            /// Transparency.
            /// </summary>
            DMMEDIA_TRANSPARENCY = 2,

            /// <summary>
            /// Glossy paper.
            /// </summary>
            DMMEDIA_GLOSSY = 3,

            /// <summary>
            /// Device-specific media start here.
            /// </summary>
            DMMEDIA_USER = 256,
        }

        /// <summary>Defines the values that may be used in the <see cref="DEVMODE.dmDitherType" /> member.</summary>
        public enum DitherTypeOptions : uint
        {
            /// <summary>
            /// No dithering.
            /// </summary>
            DMDITHER_NONE = 1,

            /// <summary>
            /// Dither with a coarse brush.
            /// </summary>
            DMDITHER_COARSE = 2,

            /// <summary>
            /// Dither with a fine brush.
            /// </summary>
            DMDITHER_FINE = 3,

            /// <summary>
            /// LineArt dithering.
            /// </summary>
            DMDITHER_LINEART = 4,

            /// <summary>
            /// LineArt dithering.
            /// </summary>
            DMDITHER_ERRORDIFFUSION = 5,

            /// <summary>
            /// LineArt dithering.
            /// </summary>
            DMDITHER_RESERVED6 = 6,

            /// <summary>
            /// LineArt dithering.
            /// </summary>
            DMDITHER_RESERVED7 = 7,

            /// <summary>
            /// LineArt dithering.
            /// </summary>
            DMDITHER_RESERVED8 = 8,

            /// <summary>
            /// LineArt dithering.
            /// </summary>
            DMDITHER_RESERVED9 = 9,

            /// <summary>
            /// Device does grayscaling.
            /// </summary>
            DMDITHER_GRAYSCALE = 10,

            /// <summary>
            /// Device-specific dithers start here.
            /// </summary>
            DMDITHER_USER = 256,
        }
    }
}
