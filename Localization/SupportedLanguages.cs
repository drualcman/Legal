namespace Legal.Localization;

/// <summary>The list of languages this notice is published in. This site is standalone, so the list
/// mirrors the one in the Shotup Albums apps by hand:
/// adding a language means adding the entry in both places.</summary>
public static class SupportedLanguages
{
    public static IReadOnlyList<SupportedLanguage> All { get; } =
    [
        new SupportedLanguage("en", "English", "gb", LanguageContinent.Europe),
        new SupportedLanguage("es", "Español", "es", LanguageContinent.Europe),
        new SupportedLanguage("fr", "Français", "fr", LanguageContinent.Europe),
        new SupportedLanguage("it", "Italiano", "it", LanguageContinent.Europe),
        new SupportedLanguage("de", "Deutsch", "de", LanguageContinent.Europe),
        new SupportedLanguage("ru", "Русский", "ru", LanguageContinent.Europe),
        new SupportedLanguage("zh", "中文 (简体)", "cn", LanguageContinent.Asia),
        new SupportedLanguage("ko", "한국어", "kr", LanguageContinent.Asia),
        new SupportedLanguage("th", "ไทย", "th", LanguageContinent.Asia),
        new SupportedLanguage("id", "Bahasa Indonesia", "id", LanguageContinent.Asia),
        new SupportedLanguage("fil", "Filipino (Tagalog)", "ph", LanguageContinent.Asia)
    ];

    public static SupportedLanguage Default => All[0];

    /// <summary>Continents that actually have languages, in the order the pickers show them.</summary>
    public static IReadOnlyList<LanguageContinent> Continents { get; } =
        All.Select(language => language.Continent).Distinct().ToList();

    public static IReadOnlyList<SupportedLanguage> ByContinent(LanguageContinent continent) =>
        All.Where(language => language.Continent == continent).ToList();

    /// <summary>Finds a language by code, tolerating region qualified cultures ("es-ES") and falling
    /// back to the default so a stored or browser culture we do not offer never blanks the picker.</summary>
    public static SupportedLanguage Find(string code)
    {
        SupportedLanguage result = Default;

        if (!string.IsNullOrWhiteSpace(code))
        {
            string languagePart = code.Split('-')[0];
            SupportedLanguage match = All.FirstOrDefault(language =>
                string.Equals(language.Code, languagePart, StringComparison.OrdinalIgnoreCase));
            if (match is not null)
            {
                result = match;
            }
        }

        return result;
    }
}
