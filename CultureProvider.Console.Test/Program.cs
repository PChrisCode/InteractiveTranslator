using CultureProvider.Services;

var translatorService = new TranslatorService();
var translation = translatorService.GetTranslation("kutya", "en-GB");
;