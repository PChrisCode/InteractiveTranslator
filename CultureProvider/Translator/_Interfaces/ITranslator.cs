using CultureProvider.Culture;

namespace CultureProvider.Translator
{
    internal interface ITranslator
    {
        IWord? GetWord(string sourceWord, string targetLanguageCountryCode);
    }
}
