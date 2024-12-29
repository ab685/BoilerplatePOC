using BoilerplatePOC.Debugging;

namespace BoilerplatePOC
{
    public class BoilerplatePOCConsts
    {
        public const string LocalizationSourceName = "BoilerplatePOC";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "8da11211b5f846bea80b937ebe501318";
    }
}
