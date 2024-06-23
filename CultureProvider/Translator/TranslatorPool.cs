using CultureProvider.Culture;

namespace CultureProvider.Translator
{
    internal class TranslatorPool : ITranslator
    {
        private IEnumerable<ITranslator> _translators;

        public TranslatorPool(IEnumerable<ITranslator> translators)
        {
            _translators = translators ?? throw new ArgumentNullException(nameof(translators));
        }

        public IWord? GetWord(string sourceWord, string targetLanguageCountryCode)
        {
            foreach (var translator in _translators)
            {
                var translation = translator.GetWord(sourceWord, targetLanguageCountryCode);

                if (translation != null)
                {
                    return translation;
                }
            }

            return null;
        }

        public void SaveTranslation(IWord word)
        {
            throw new NotImplementedException();
        }
    }
}
