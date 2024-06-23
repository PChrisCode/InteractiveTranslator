namespace CultureProvider.Culture
{
    internal class Word : IWord
    {
        public IDictionary<string, string> Translations { get; }

        public Word(IDictionary<string, string> translations)
        {
            Translations = translations ?? throw new ArgumentNullException(nameof(translations));
        }
    }
}
