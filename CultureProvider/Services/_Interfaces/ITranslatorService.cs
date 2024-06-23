using CultureProvider.Culture;

namespace CultureProvider.Services
{
    public interface ITranslatorService
    {
        string? GetTranslation(string sourceWord, string targetLanguageCountryCode);
    }
}
