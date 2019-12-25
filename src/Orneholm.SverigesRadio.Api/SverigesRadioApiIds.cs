namespace Orneholm.SverigesRadio.Api
{
    /// <summary>
    /// ID:n för ett antal objekt som används ofta och har ganska konstanta värden.
    /// </summary>
    public static class SverigesRadioApiIds
    {
        /// <summary>
        /// Id för program. Urval bland populära program.
        /// </summary>
        public static class Programs
        {
            public const int Ekot = 4540;

            public const int P1_Dokumentar = 909;
            public const int Sommar_Och_Vinter_I_P1 = 2071;

            public const int P3_Dokumentar = 2519;
            public const int P3_Historia = 5067;
            public const int P3_Dystopia = 5188;
            public const int Morgonpasset_I_P3 = 2024;

            public const int Sa_Funkar_Det = 5073;
            public const int Melodikrysset = 2078;
        }

        /// <summary>
        /// Id för kanaler, de större kanalerna.
        /// </summary>
        public static class Channels
        {
            public const int P1_Rikskanal = 132;
            public const int P2_Rikskanal = 163;
            public const int P3_Rikskanal = 164;

            public const int P4_Blekinge_Lokalkanal = 213;
            public const int P4_Dalarna_Lokalkanal = 223;
            public const int P4_Gotland_Lokalkanal = 205;
            public const int P4_Gavleborg_Lokalkanal = 210;
            public const int P4_Goteborg_Lokalkanal = 212;
            public const int P4_Halland_Lokalkanal = 220;
            public const int P4_Jamtland_Lokalkanal = 200;
            public const int P4_Jonkoping_Lokalkanal = 203;
            public const int P4_Kalmar_Lokalkanal = 201;
            public const int P4_Kristianstad_Lokalkanal = 211;
            public const int P4_Kronoberg_Lokalkanal = 214;
            public const int P4_Malmohus_Lokalkanal = 207;
            public const int P4_Norrbotten_Lokalkanal = 209;
            public const int P4_Sjuharad_Lokalkanal = 206;
            public const int P4_Skaraborg_Lokalkanal = 208;
            public const int P4_Stockholm_Lokalkanal = 701;
            public const int P4_Sodertälje_Lokalkanal = 5283;
            public const int P4_Sormland_Lokalkanal = 202;
            public const int P4_Uppland_Lokalkanal = 218;
            public const int P4_Varmland_Lokalkanal = 204;
            public const int P4_Vast_Lokalkanal = 219;
            public const int P4_Vasterbotten_Lokalkanal = 215;
            public const int P4_Vasternorrland_Lokalkanal = 216;
            public const int P4_Vastmanland_Lokalkanal = 217;
            public const int P4_Orebro_Lokalkanal = 221;
            public const int P4_Ostergötland_Lokalkanal = 222;


            public const int SR_Sapmi_MinoritetOchSprak = 224;
            public const int Sisuradio_MinoritetOchSprak = 226;
            public const int P6_MinoritetOchSprak = 166;

            public const int EkotSanderDirekt_FlerKanaler = 4540;
            public const int P3_Dingata_FlerKanaler = 2576;
            public const int P2_Musik_FlerKanaler = 2562;
            public const int Radioapansknattekanal_FlerKanaler = 2755;
            public const int P4Plus_FlerKanaler = 4951;
        }

        /// <summary>
        /// Kanaltyper
        /// </summary>
        public static class ChannelTypes
        {
            public const string Extrakanaler = "Extrakanaler";
            public const string FlerKanaler = "Fler kanaler";
            public const string LokalKanal = "Lokal kanal";
            public const string MinoritetOchSprak = "Minoritet och språk";
            public const string Rikskanal = "Rikskanal";
        }

        /// <summary>
        /// Programkategori id.
        /// </summary>
        public static class ProgramCategories
        {
            public const int Barn3_8ar = 2;
            public const int Barn9_13ar = 132;
            public const int Dokumentar = 82;
            public const int Drama = 134;
            public const int Ekonomi = 135;
            public const int Humor = 133;
            public const int Kultur_Noje = 3;
            public const int Livsstil = 14;
            public const int Livsaskadning = 4;
            public const int Musik = 5;
            public const int NewsInOtherLanguages = 11;
            public const int Nyheter = 68;
            public const int Samhalle = 7;
            public const int Sport = 10;
            public const int Vetenskap_Miljo = 12;
        }

        /// <summary>
        /// ID för efterhandslyssningsljudtyper.
        /// </summary>
        public static class OnDemandAudioTemplates
        {
            public const int M4A_ASX = 1;
            public const int M4A_M3U = 2;
            public const int M4A_M3U8 = 3;

            public const int Mobile_M3U = 4;
            public const int Mobile_M3U8 = 5;

            public const int Iphone_M3U = 6;
            public const int Iphone_M3U8 = 8;

            public const int Html5_Desktop = 9;
        }

        /// <summary>
        /// Id för liveljudetyper.
        /// </summary>
        public static class LiveAudioTemplates
        {
            public const int MP3 = 2;

            public const int AAC_HTTP_PLS = 3;
            public const int AAC_HTTP_M3U = 4;
            public const int AAC_HTTP = 5;

            public const int HLS = 10;
            public const int DASH = 11;

            public const int IOS = 12;
        }
    }
}
