using CultureProvider.Culture;
using Newtonsoft.Json;

namespace CultureProvider.Translator
{
    internal class JsonDataSourceTranslator : ITranslatorDataSource
    {
        private readonly string _jsonDataSourcePath;

        public JsonDataSourceTranslator(string jsonDataSourcePath)
        {
            if (string.IsNullOrWhiteSpace(jsonDataSourcePath))
            {
                throw new ArgumentException($"'{nameof(jsonDataSourcePath)}' cannot be null or whitespace.", nameof(jsonDataSourcePath));
            }

            _jsonDataSourcePath = jsonDataSourcePath;
        }

        public IWord? GetWord(string sourceWord, string targetLanguageCountryCode)
        {
            using (var streamReader = new StreamReader(_jsonDataSourcePath))
            {
                var json = streamReader.ReadToEnd();
                var words = JsonConvert.DeserializeObject<IEnumerable<IWord>>(json, new WordJsonConverter());

                var targetWord = words?.FirstOrDefault(w =>
                    w.Translations.Any(t => t.Key == targetLanguageCountryCode)
                    && w.Translations.Any(t => t.Value == sourceWord));

                return targetWord;
            }
        }

        public void SaveWord(IWord word)
        {
            throw new NotImplementedException();
        }
    }
}
