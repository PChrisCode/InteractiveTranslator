using CultureProvider.Translator;

namespace CultureProvider.Services
{
    public class TranslatorService : ITranslatorService
    {
        public string? GetTranslation(string sourceWord, string targetLanguageCountryCode)
        {
            var translationDataSource = new JsonDataSourceTranslator(@".\DataSource\TranslationsDatabase.json");

            var translators = new ITranslator[] {
                translationDataSource,
                new GoogleTranslator()
            };

            var translatorPool = new TranslatorPool(translators);

            var word = translatorPool.GetWord(sourceWord, targetLanguageCountryCode);
            if (word != null)
            {
                //translationDataSource.SaveWord(word);
            }

            var translation = word?.Translations.FirstOrDefault(t => t.Key == targetLanguageCountryCode);

            return translation?.Value;
        }
    }
}
