using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace BoilerplatePOC.Localization
{
    public static class BoilerplatePOCLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BoilerplatePOCConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BoilerplatePOCLocalizationConfigurer).GetAssembly(),
                        "BoilerplatePOC.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
