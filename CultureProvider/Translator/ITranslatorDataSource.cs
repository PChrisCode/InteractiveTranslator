using CultureProvider.Culture;

namespace CultureProvider.Translator
{
    internal interface ITranslatorDataSource : ITranslator
    {
        void SaveWord(IWord word);
    }
}
