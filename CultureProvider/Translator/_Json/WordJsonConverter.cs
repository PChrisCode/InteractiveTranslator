using CultureProvider.Culture;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CultureProvider.Translator
{
    internal class WordJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(IEnumerable<IWord>))
            {
                return true;
            }

            return false;
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var translationPairs = jsonObject["Translations"];

            if (translationPairs == null)
            {
                return new List<IWord>();
            }

            var words = new List<IWord>();

            foreach (var translationPair in translationPairs)
            {
                var translationDictionary = new Dictionary<string, string>();

                foreach (var translation in translationPair)
                {
                    var languageCountryCode = translation["languageCountryCode"]?.Value<string>();
                    var word = translation["translation"]?.Value<string>();

                    if (!string.IsNullOrWhiteSpace(languageCountryCode)
                        && !string.IsNullOrWhiteSpace(word))
                    {
                        translationDictionary.Add(languageCountryCode, word);
                    }
                }

                words.Add(new Word(translationDictionary));
            }

            return words;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
