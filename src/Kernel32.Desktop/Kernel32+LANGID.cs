// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the language ID (LANGID) constants.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        ///     Creates a language identifier from a primary language identifier and a sublanguage identifier.
        /// </summary>
        /// <param name="usPrimaryLanguage">
        ///     Primary language identifier. This identifier can be a predefined value or a value for a user-defined primary
        ///     language. For a user-defined language, the identifier is a value in the range 0x0200 to 0x03FF. All other
        ///     values are reserved for operating system use. For more information, see Language Identifier Constants and
        ///     Strings.
        /// </param>
        /// <param name="usSubLanguage">
        ///     Sublanguage identifier. This parameter can be a predefined sublanguage identifier or a user-defined
        ///     sublanguage. For a user-defined sublanguage, the identifier is a value in the range 0x20 to 0x3F. All other
        ///     values are reserved for operating system use. For more information, see Language Identifier Constants and
        ///     Strings.
        /// </param>
        /// <returns>Returns the language identifier.</returns>
        public static LANGID MAKELANGID(ushort usPrimaryLanguage, ushort usSubLanguage)
        {
            return new LANGID
            {
                Primary = (LANGID.PrimaryLanguage)usPrimaryLanguage,
                Sub = (LANGID.SubLanguage)usSubLanguage
            };
        }

        /// <summary>
        ///     Creates a language identifier from a primary language identifier and a sublanguage identifier.
        /// </summary>
        /// <param name="ePrimaryLanguage">
        ///     Primary language identifier. This identifier can be a predefined value or a value for a user-defined primary
        ///     language. For a user-defined language, the identifier is a value in the range 0x0200 to 0x03FF. All other
        ///     values are reserved for operating system use. For more information, see Language Identifier Constants and
        ///     Strings.
        /// </param>
        /// <param name="eSubLanguage">
        ///     Sublanguage identifier. This parameter can be a predefined sublanguage identifier or a user-defined
        ///     sublanguage. For a user-defined sublanguage, the identifier is a value in the range 0x20 to 0x3F. All other
        ///     values are reserved for operating system use. For more information, see Language Identifier Constants and
        ///     Strings.
        /// </param>
        /// <returns>Returns the language identifier.</returns>
        public static LANGID MAKELANGID(LANGID.PrimaryLanguage ePrimaryLanguage, LANGID.SubLanguage eSubLanguage)
        {
            return new LANGID
            {
                Primary = ePrimaryLanguage,
                Sub = eSubLanguage
            };
        }

        /// <summary>
        /// Represents a language identifier.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct LANGID
        {
            internal const ushort PrimaryLanguageMask = 0x3FF;
            internal const ushort SubLanguageMask = 0xFC00;
            internal const int SubLanguageShift = 10;

            internal ushort data;

            public LANGID(ushort usLanguages)
            {
                this.data = usLanguages;
            }

            public enum PrimaryLanguage : ushort
            {
                LANG_NEUTRAL = 0x0,
                LANG_INVARIANT = 0x7F,
                LANG_SYSTEM_DEFAULT = 0x02,
                LANG_USER_DEFAULT = 0x0,
                LANG_AFRIKAANS = 0x36,
                LANG_ALBANIAN = 0x1C,
                LANG_ALSATIAN = 0x84,
                LANG_AMHARIC = 0x5E,
                LANG_ARABIC = 0x01,
                LANG_ARMENIAN = 0x2B,
                LANG_ASSAMESE = 0x4D,
                LANG_AZERI = 0x2C,
                LANG_BANGLA = 0x45,
                LANG_BASHKIR = 0x6D,
                LANG_BASQUE = 0x2D,
                LANG_BELARUSSIAN = 0x23,
                LANG_BOSNIAN = 0x1A,
                LANG_BRETON = 0x7E,
                LANG_BULGARIAN = 0x02,
                LANG_CENTRAL_KURDISH = 0x92,
                LANG_CHEROKEE = 0x5C,
                LANG_CATALAN = 0x03,
                LANG_CHINESE = 0x04,
                LANG_CHINESE_SIMPLIFIED = 0x04,
                LANG_CHINESE_TRADITIONAL = 0x04,
                LANG_CORSICAN = 0x83,
                LANG_CROATIAN = 0x1A,
                LANG_CZECH = 0x05,
                LANG_DANISH = 0x06,
                LANG_DARI = 0x8C,
                LANG_DIVEHI = 0x65,
                LANG_DUTCH = 0x13,
                LANG_ENGLISH = 0x09,
                LANG_ESTONIAN = 0x25,
                LANG_FAEROESE = 0x38,
                LANG_FILIPINO = 0x64,
                LANG_FINNISH = 0x0B,
                LANG_FRENCH = 0x0C,
                LANG_FRISIAN = 0x62,
                LANG_GALICIAN = 0x56,
                LANG_GEORGIAN = 0x37,
                LANG_GERMAN = 0x07,
                LANG_GREEK = 0x08,
                LANG_GREENLANDIC = 0x6F,
                LANG_GUJARATI = 0x47,
                LANG_HAUSA = 0x68,
                LANG_HAWAIIAN = 0x75,
                LANG_HEBREW = 0x0D,
                LANG_HINDI = 0x39,
                LANG_HUNGARIAN = 0x0E,
                LANG_ICELANDIC = 0x0F,
                LANG_IGBO = 0x70,
                LANG_INDONESIAN = 0x21,
                LANG_INUKTITUT = 0x5D,
                LANG_IRISH = 0x3C,
                LANG_XHOSA = 0x34,
                LANG_ZULU = 0x35,
                LANG_ITALIAN = 0x10,
                LANG_JAPANESE = 0x11,
                LANG_KANNADA = 0x4B,
                LANG_KASHMIRI = 0x60,
                LANG_KAZAK = 0x3F,
                LANG_KHMER = 0x53,
                LANG_KICHE = 0x86,
                LANG_KINYARWANDA = 0x87,
                LANG_KONKANI = 0x57,
                LANG_KOREAN = 0x12,
                LANG_KYRGYZ = 0x40,
                LANG_LAO = 0x54,
                LANG_LATVIAN = 0x26,
                LANG_LITHUANIAN = 0x27,
                LANG_LOWER_SORBIAN = 0x2E,
                LANG_LUXEMBOURGISH = 0x6E,
                LANG_MACEDONIAN = 0x2F,
                LANG_MALAY = 0x3E,
                LANG_MALAYALAM = 0x4C,
                LANG_MALTESE = 0x3A,
                LANG_MANIPURI = 0x58,
                LANG_MAORI = 0x81,
                LANG_MAPUDUNGUN = 0x7A,
                LANG_MARATHI = 0x4E,
                LANG_MOHAWK = 0x7C,
                LANG_MONGOLIAN = 0x50,
                LANG_NEPALI = 0x61,
                LANG_NORWEGIAN = 0x14,
                LANG_OCCITAN = 0x82,
                LANG_ORIYA = 0x48,
                LANG_PASHTO = 0x63,
                LANG_PERSIAN = 0x29,
                LANG_POLISH = 0x15,
                LANG_PORTUGUESE = 0x16,
                LANG_PULAR = 0x67,
                LANG_PUNJABI = 0x46,
                LANG_QUECHUA = 0x6B,
                LANG_ROMANIAN = 0x18,
                LANG_ROMANSH = 0x17,
                LANG_RUSSIAN = 0x19,
                LANG_SAKHA = 0x85,
                LANG_SAMI = 0x3B,
                LANG_SANSKRIT = 0x4F,
                LANG_SERBIAN = 0x1A,
                LANG_SOTHO = 0x6C,
                LANG_TSWANA = 0x32,
                LANG_SINDHI = 0x59,
                LANG_SINHALESE = 0x5B,
                LANG_SLOVAK = 0x1B,
                LANG_SLOVENIAN = 0x24,
                LANG_SPANISH = 0x0A,
                LANG_SWAHILI = 0x41,
                LANG_SWEDISH = 0x1D,
                LANG_SYRIAC = 0x5A,
                LANG_TAJIK = 0x28,
                LANG_TAMAZIGHT = 0x5F,
                LANG_TAMIL = 0x49,
                LANG_TATAR = 0x44,
                LANG_TELUGU = 0x4A,
                LANG_THAI = 0x1E,
                LANG_TIBETAN = 0x51,
                LANG_TIGRINYA = 0x73,
                LANG_TIGRIGNA = 0x73,
                LANG_TURKISH = 0x1F,
                LANG_TURKMEN = 0x42,
                LANG_UKRAINIAN = 0x22,
                LANG_UPPER_SORBIAN = 0x2E,
                LANG_URDU = 0x20,
                LANG_UIGHUR = 0x80,
                LANG_UZBEK = 0x43,
                LANG_VALENCIAN = 0x03,
                LANG_VIETNAMESE = 0x2A,
                LANG_WELSH = 0x52,
                LANG_WOLOF = 0x88,
                LANG_YI = 0x78,
                LANG_YORUBA = 0x6A
            }

            public enum SubLanguage : ushort
            {
                SUBLANG_CUSTOM_DEFAULT = 0x03,
                SUBLANG_UI_CUSTOM_DEFAULT = 0x05,
                SUBLANG_NEUTRAL = 0x0,
                SUBLANG_SYS_DEFAULT = 0x02,
                SUBLANG_CUSTOM_UNSPECIFIED = 0x04,
                SUBLANG_DEFAULT = 0x01,
                SUBLANG_AFRIKAANS_SOUTH_AFRICA = 0x01,
                SUBLANG_ALBANIAN_ALBANIA = 0x01,
                SUBLANG_ALSATIAN_FRANCE = 0x01,
                SUBLANG_AMHARIC_ETHIOPIA = 0x01,
                SUBLANG_ARABIC_ALGERIA = 0x05,
                SUBLANG_ARABIC_BAHRAIN = 0x0F,
                SUBLANG_ARABIC_EGYPT = 0x03,
                SUBLANG_ARABIC_IRAQ = 0x02,
                SUBLANG_ARABIC_JORDAN = 0x0B,
                SUBLANG_ARABIC_KUWAIT = 0x0D,
                SUBLANG_ARABIC_LEBANON = 0x0C,
                SUBLANG_ARABIC_LIBYA = 0x04,
                SUBLANG_ARABIC_MOROCCO = 0x06,
                SUBLANG_ARABIC_OMAN = 0x08,
                SUBLANG_ARABIC_QATAR = 0x10,
                SUBLANG_ARABIC_SAUDI_ARABIA = 0x01,
                SUBLANG_ARABIC_SYRIA = 0x0A,
                SUBLANG_ARABIC_TUNISIA = 0x07,
                SUBLANG_ARABIC_UAE = 0x0E,
                SUBLANG_ARABIC_YEMEN = 0x09,
                SUBLANG_ARMENIAN_ARMENIA = 0x01,
                SUBLANG_ASSAMESE_INDIA = 0x01,
                SUBLANG_AZERI_CYRILLIC = 0x02,
                SUBLANG_AZERI_LATIN = 0x01,
                SUBLANG_BANGLA_BANGLADESH = 0x02,
                SUBLANG_BANGLA_INDIA = 0x01,
                SUBLANG_BASHKIR_RUSSIA = 0x01,
                SUBLANG_BASQUE_BASQUE = 0x01,
                SUBLANG_BELARUSIAN_BELARUS = 0x01,
                SUBLANG_BOSNIAN_BOSNIA_HERZEGOVINA_CYRILLIC = 0x08,
                SUBLANG_BOSNIAN_BOSNIA_HERZEGOVINA_LATIN = 0x05,
                SUBLANG_BRETON_FRANCE = 0x01,
                SUBLANG_BULGARIAN_BULGARIA = 0x01,
                SUBLANG_CENTRAL_KURDISH_IRAQ = 0x01,
                SUBLANG_CHEROKEE_CHEROKEE = 0x01,
                SUBLANG_CATALAN_CATALAN = 0x01,
                SUBLANG_CHINESE_HONGKONG = 0x03,
                SUBLANG_CHINESE_MACAU = 0x05,
                SUBLANG_CHINESE_SINGAPORE = 0x04,
                SUBLANG_CHINESE_SIMPLIFIED = 0x02,
                SUBLANG_CHINESE_TRADITIONAL = 0x01,
                SUBLANG_CORSICAN_FRANCE = 0x01,
                SUBLANG_CROATIAN_BOSNIA_HERZEGOVINA_LATIN = 0x04,
                SUBLANG_CROATIAN_CROATIA = 0x01,
                SUBLANG_CZECH_CZECH_REPUBLIC = 0x01,
                SUBLANG_DANISH_DENMARK = 0x01,
                SUBLANG_DARI_AFGHANISTAN = 0x01,
                SUBLANG_DIVEHI_MALDIVES = 0x01,
                SUBLANG_DUTCH_BELGIAN = 0x02,
                SUBLANG_DUTCH = 0x01,
                SUBLANG_ENGLISH_AUS = 0x03,
                SUBLANG_ENGLISH_BELIZE = 0x0A,
                SUBLANG_ENGLISH_CAN = 0x04,
                SUBLANG_ENGLISH_CARIBBEAN = 0x09,
                SUBLANG_ENGLISH_INDIA = 0x10,
                SUBLANG_ENGLISH_EIRE = 0x06,
                SUBLANG_ENGLISH_IRELAND = 0x06,
                SUBLANG_ENGLISH_JAMAICA = 0x08,
                SUBLANG_ENGLISH_MALAYSIA = 0x11,
                SUBLANG_ENGLISH_NZ = 0x05,
                SUBLANG_ENGLISH_PHILIPPINES = 0x0D,
                SUBLANG_ENGLISH_SINGAPORE = 0x12,
                SUBLANG_ENGLISH_SOUTH_AFRICA = 0x07,
                SUBLANG_ENGLISH_TRINIDAD = 0x0B,
                SUBLANG_ENGLISH_UK = 0x02,
                SUBLANG_ENGLISH_US = 0x01,
                SUBLANG_ENGLISH_ZIMBABWE = 0x0C,
                SUBLANG_ESTONIAN_ESTONIA = 0x01,
                SUBLANG_FAEROESE_FAROE_ISLANDS = 0x01,
                SUBLANG_FILIPINO_PHILIPPINES = 0x01,
                SUBLANG_FINNISH_FINLAND = 0x01,
                SUBLANG_FRENCH_BELGIAN = 0x02,
                SUBLANG_FRENCH_CANADIAN = 0x03,
                SUBLANG_FRENCH = 0x01,
                SUBLANG_FRENCH_LUXEMBOURG = 0x05,
                SUBLANG_FRENCH_MONACO = 0x06,
                SUBLANG_FRENCH_SWISS = 0x04,
                SUBLANG_FRISIAN_NETHERLANDS = 0x01,
                SUBLANG_GALICIAN_GALICIAN = 0x01,
                SUBLANG_GEORGIAN_GEORGIA = 0x01,
                SUBLANG_GERMAN_AUSTRIAN = 0x03,
                SUBLANG_GERMAN = 0x01,
                SUBLANG_GERMAN_LIECHTENSTEIN = 0x05,
                SUBLANG_GERMAN_LUXEMBOURG = 0x04,
                SUBLANG_GERMAN_SWISS = 0x02,
                SUBLANG_GREEK_GREECE = 0x01,
                SUBLANG_GREENLANDIC_GREENLAND = 0x01,
                SUBLANG_GUJARATI_INDIA = 0x01,
                SUBLANG_HAUSA_NIGERIA_LATIN = 0x01,
                SUBLANG_HAWAIIAN_US = 0x01,
                SUBLANG_HEBREW_ISRAEL = 0x01,
                SUBLANG_HINDI_INDIA = 0x01,
                SUBLANG_HUNGARIAN_HUNGARY = 0x01,
                SUBLANG_ICELANDIC_ICELAND = 0x01,
                SUBLANG_IGBO_NIGERIA = 0x01,
                SUBLANG_INDONESIAN_INDONESIA = 0x01,
                SUBLANG_INUKTITUT_CANADA_LATIN = 0x02,
                SUBLANG_INUKTITUT_CANADA = 0x01,
                SUBLANG_IRISH_IRELAND = 0x02,
                SUBLANG_XHOSA_SOUTH_AFRICA = 0x01,
                SUBLANG_ZULU_SOUTH_AFRICA = 0x01,
                SUBLANG_ITALIAN = 0x01,
                SUBLANG_ITALIAN_SWISS = 0x02,
                SUBLANG_JAPANESE_JAPAN = 0x01,
                SUBLANG_KANNADA_INDIA = 0x01,
                SUBLANG_KASHMIRI_INDIA = 0x02,
                SUBLANG_KASHMIRI_SASIA = 0x02,
                SUBLANG_KAZAK_KAZAKHSTAN = 0x01,
                SUBLANG_KHMER_CAMBODIA = 0x01,
                SUBLANG_KICHE_GUATEMALA = 0x01,
                SUBLANG_KINYARWANDA_RWANDA = 0x01,
                SUBLANG_KONKANI_INDIA = 0x01,
                SUBLANG_KOREAN = 0x01,
                SUBLANG_KYRGYZ_KYRGYZSTAN = 0x01,
                SUBLANG_LAO_LAO = 0x01,
                SUBLANG_LATVIAN_LATVIA = 0x01,
                SUBLANG_LITHUANIAN_LITHUANIA = 0x01,
                SUBLANG_LOWER_SORBIAN_GERMANY = 0x02,
                SUBLANG_LUXEMBOURGISH_LUXEMBOURG = 0x01,
                SUBLANG_MACEDONIAN_MACEDONIA = 0x01,
                SUBLANG_MALAY_BRUNEI_DARUSSALAM = 0x02,
                SUBLANG_MALAY_MALAYSIA = 0x01,
                SUBLANG_MALAYALAM_INDIA = 0x01,
                SUBLANG_MALTESE_MALTA = 0x01,
                SUBLANG_MAORI_NEW_ZEALAND = 0x01,
                SUBLANG_MAPUDUNGUN_CHILE = 0x1,
                SUBLANG_MARATHI_INDIA = 0x01,
                SUBLANG_MOHAWK_MOHAWK = 0x01,
                SUBLANG_MONGOLIAN_CYRILLIC_MONGOLIA = 0x01,
                SUBLANG_MONGOLIAN_PRC = 0x02,
                SUBLANG_NEPALI_NEPAL = 0x01,
                SUBLANG_NEPALI_INDIA = 0x02,
                SUBLANG_NORWEGIAN_BOKMAL = 0x01,
                SUBLANG_NORWEGIAN_NYNORSK = 0x02,
                SUBLANG_OCCITAN_FRANCE = 0x01,
                SUBLANG_ORIYA_INDIA = 0x01,
                SUBLANG_PASHTO_AFGHANISTAN = 0x01,
                SUBLANG_PERSIAN_IRAN = 0x01,
                SUBLANG_POLISH_POLAND = 0x01,
                SUBLANG_PORTUGUESE_BRAZILIAN = 0x01,
                SUBLANG_PORTUGUESE = 0x02,
                SUBLANG_PULAR_SENEGAL = 0x02,
                SUBLANG_PUNJABI_INDIA = 0x01,
                SUBLANG_PUNJABI_PAKISTAN = 0x02,
                SUBLANG_QUECHUA_BOLIVIA = 0x01,
                SUBLANG_QUECHUA_ECUADOR = 0x02,
                SUBLANG_QUECHUA_PERU = 0x03,
                SUBLANG_ROMANIAN_ROMANIA = 0x01,
                SUBLANG_ROMANSH_SWITZERLAND = 0x01,
                SUBLANG_RUSSIAN_RUSSIA = 0x01,
                SUBLANG_SAKHA_RUSSIA = 0x01,
                SUBLANG_SAMI_INARI_FINLAND = 0x09,
                SUBLANG_SAMI_LULE_NORWAY = 0x04,
                SUBLANG_SAMI_LULE_SWEDEN = 0x05,
                SUBLANG_SAMI_NORTHERN_FINLAND = 0x03,
                SUBLANG_SAMI_NORTHERN_NORWAY = 0x01,
                SUBLANG_SAMI_NORTHERN_SWEDEN = 0x02,
                SUBLANG_SAMI_SKOLT_FINLAND = 0x08,
                SUBLANG_SAMI_SOUTHERN_NORWAY = 0x06,
                SUBLANG_SAMI_SOUTHERN_SWEDEN = 0x07,
                SUBLANG_SANSKRIT_INDIA = 0x01,
                SUBLANG_SERBIAN_BOSNIA_HERZEGOVINA_CYRILLIC = 0x07,
                SUBLANG_SERBIAN_BOSNIA_HERZEGOVINA_LATIN = 0x06,
                SUBLANG_SERBIAN_CROATIA = 0x01,
                SUBLANG_SERBIAN_CYRILLIC = 0x03,
                SUBLANG_SERBIAN_LATIN = 0x02,
                SUBLANG_SOTHO_NORTHERN_SOUTH_AFRICA = 0x01,
                SUBLANG_TSWANA_BOTSWANA = 0x02,
                SUBLANG_TSWANA_SOUTH_AFRICA = 0x01,
                SUBLANG_SINDHI_AFGHANISTAN = 0x02,
                SUBLANG_SINDHI_INDIA = 0x01,
                SUBLANG_SINDHI_PAKISTAN = 0x02,
                SUBLANG_SINHALESE_SRI_LANKA = 0x01,
                SUBLANG_SLOVAK_SLOVAKIA = 0x01,
                SUBLANG_SLOVENIAN_SLOVENIA = 0x01,
                SUBLANG_SPANISH_ARGENTINA = 0x0B,
                SUBLANG_SPANISH_BOLIVIA = 0x10,
                SUBLANG_SPANISH_CHILE = 0x0D,
                SUBLANG_SPANISH_COLOMBIA = 0x09,
                SUBLANG_SPANISH_COSTA_RICA = 0x05,
                SUBLANG_SPANISH_DOMINICAN_REPUBLIC = 0x07,
                SUBLANG_SPANISH_ECUADOR = 0x0C,
                SUBLANG_SPANISH_EL_SALVADOR = 0x11,
                SUBLANG_SPANISH_GUATEMALA = 0x04,
                SUBLANG_SPANISH_HONDURAS = 0x12,
                SUBLANG_SPANISH_MEXICAN = 0x02,
                SUBLANG_SPANISH_NICARAGUA = 0x13,
                SUBLANG_SPANISH_PANAMA = 0x06,
                SUBLANG_SPANISH_PARAGUAY = 0x0F,
                SUBLANG_SPANISH_PERU = 0x0A,
                SUBLANG_SPANISH_PUERTO_RICO = 0x14,
                SUBLANG_SPANISH_MODERN = 0x03,
                SUBLANG_SPANISH = 0x01,
                SUBLANG_SPANISH_US = 0x15,
                SUBLANG_SPANISH_URUGUAY = 0x0E,
                SUBLANG_SPANISH_VENEZUELA = 0x08,
                SUBLANG_SWAHILI = 0x01,
                SUBLANG_SWEDISH_FINLAND = 0x02,
                SUBLANG_SWEDISH = 0x01,
                SUBLANG_SWEDISH_SWEDEN = 0x01,
                SUBLANG_SYRIAC = 0x01,
                SUBLANG_TAJIK_TAJIKISTAN = 0x01,
                SUBLANG_TAMAZIGHT_ALGERIA_LATIN = 0x02,
                SUBLANG_TAMIL_INDIA = 0x01,
                SUBLANG_TAMIL_SRI_LANKA = 0x02,
                SUBLANG_TATAR_RUSSIA = 0x01,
                SUBLANG_TELUGU_INDIA = 0x01,
                SUBLANG_THAI_THAILAND = 0x01,
                SUBLANG_TIBETAN_PRC = 0x01,
                SUBLANG_TIGRINYA_ERITREA = 0x02,
                SUBLANG_TIGRINYA_ETHIOPIA = 0x01,
                SUBLANG_TIGRIGNA_ERITREA = 0x02,
                SUBLANG_TURKISH_TURKEY = 0x01,
                SUBLANG_TURKMEN_TURKMENISTAN = 0x01,
                SUBLANG_UKRAINIAN_UKRAINE = 0x01,
                SUBLANG_UPPER_SORBIAN_GERMANY = 0x01,
                SUBLANG_URDU_INDIA = 0x02,
                SUBLANG_URDU_PAKISTAN = 0x01,
                SUBLANG_UIGHUR_PRC = 0x01,
                SUBLANG_UZBEK_CYRILLIC = 0x02,
                SUBLANG_UZBEK_LATIN = 0x01,
                SUBLANG_VALENCIAN_VALENCIA = 0x02,
                SUBLANG_VIETNAMESE_VIETNAM = 0x01,
                SUBLANG_WELSH_UNITED_KINGDOM = 0x01,
                SUBLANG_WOLOF_SENEGAL = 0x01,
                SUBLANG_YI_PRC = 0x01,
                SUBLANG_YORUBA_NIGERIA = 0x01
            }

            public PrimaryLanguage Primary
            {
                get { return (PrimaryLanguage)(this.data & PrimaryLanguageMask); }
                set { this.data = (ushort)((PrimaryLanguage)((this.data & SubLanguageMask) | ((ushort)value & PrimaryLanguageMask)));  }
            }

            public SubLanguage Sub
            {
                get { return (SubLanguage)((this.data & SubLanguageMask) >> SubLanguageShift); }
                set { this.data = (ushort)((this.data & PrimaryLanguageMask) | (((ushort)value << SubLanguageShift) & SubLanguageMask)); }
            }

            public ushort Data
            {
                get { return this.data; }
                set { this.data = value; }
            }
        }
    }
}