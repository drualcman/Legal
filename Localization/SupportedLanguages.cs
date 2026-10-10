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
        new SupportedLanguage("pt", "Português", "pt", LanguageContinent.Europe),
        new SupportedLanguage("ru", "Русский", "ru", LanguageContinent.Europe),
        new SupportedLanguage("zh", "中文 (简体)", "cn", LanguageContinent.Asia),
        new SupportedLanguage("ja", "日本語", "jp", LanguageContinent.Asia),
        new SupportedLanguage("ko", "한국어", "kr", LanguageContinent.Asia),
        new SupportedLanguage("th", "ไทย", "th", LanguageContinent.Asia),
        new SupportedLanguage("id", "Bahasa Indonesia", "id", LanguageContinent.Asia),
        new SupportedLanguage("fil", "Filipino (Tagalog)", "ph", LanguageContinent.Asia),
        new SupportedLanguage("vi", "Tiếng Việt", "vn", LanguageContinent.Asia),
        new SupportedLanguage("ar", "العربية", "sa", LanguageContinent.Asia),
        new SupportedLanguage("ar", "العربية", "un", LanguageContinent.Africa),
        new SupportedLanguage("sw", "Kiswahili", "un", LanguageContinent.Africa),
        new SupportedLanguage("en", "English", "ag", LanguageContinent.America, "Antigua and Barbuda"),
        new SupportedLanguage("es", "Español", "ar", LanguageContinent.America, "Argentina"),
        new SupportedLanguage("en", "English", "bs", LanguageContinent.America, "Bahamas"),
        new SupportedLanguage("en", "English", "bb", LanguageContinent.America, "Barbados"),
        new SupportedLanguage("en", "English", "bz", LanguageContinent.America, "Belize"),
        new SupportedLanguage("es", "Español", "bo", LanguageContinent.America, "Bolivia"),
        new SupportedLanguage("pt", "Português", "br", LanguageContinent.America, "Brasil"),
        new SupportedLanguage("en", "English", "ca", LanguageContinent.America, "Canada"),
        new SupportedLanguage("fr", "Français", "ca", LanguageContinent.America, "Canada"),
        new SupportedLanguage("es", "Español", "cl", LanguageContinent.America, "Chile"),
        new SupportedLanguage("es", "Español", "co", LanguageContinent.America, "Colombia"),
        new SupportedLanguage("es", "Español", "cr", LanguageContinent.America, "Costa Rica"),
        new SupportedLanguage("es", "Español", "cu", LanguageContinent.America, "Cuba"),
        new SupportedLanguage("en", "English", "dm", LanguageContinent.America, "Dominica"),
        new SupportedLanguage("es", "Español", "ec", LanguageContinent.America, "Ecuador"),
        new SupportedLanguage("es", "Español", "sv", LanguageContinent.America, "El Salvador"),
        new SupportedLanguage("en", "English", "gd", LanguageContinent.America, "Grenada"),
        new SupportedLanguage("es", "Español", "gt", LanguageContinent.America, "Guatemala"),
        new SupportedLanguage("en", "English", "gy", LanguageContinent.America, "Guyana"),
        new SupportedLanguage("fr", "Français", "ht", LanguageContinent.America, "Haïti"),
        new SupportedLanguage("es", "Español", "hn", LanguageContinent.America, "Honduras"),
        new SupportedLanguage("en", "English", "jm", LanguageContinent.America, "Jamaica"),
        new SupportedLanguage("es", "Español", "mx", LanguageContinent.America, "México"),
        new SupportedLanguage("es", "Español", "ni", LanguageContinent.America, "Nicaragua"),
        new SupportedLanguage("es", "Español", "pa", LanguageContinent.America, "Panamá"),
        new SupportedLanguage("es", "Español", "py", LanguageContinent.America, "Paraguay"),
        new SupportedLanguage("es", "Español", "pe", LanguageContinent.America, "Perú"),
        new SupportedLanguage("es", "Español", "pr", LanguageContinent.America, "Puerto Rico"),
        new SupportedLanguage("es", "Español", "do", LanguageContinent.America, "República Dominicana"),
        new SupportedLanguage("en", "English", "kn", LanguageContinent.America, "Saint Kitts and Nevis"),
        new SupportedLanguage("en", "English", "lc", LanguageContinent.America, "Saint Lucia"),
        new SupportedLanguage("en", "English", "vc", LanguageContinent.America, "Saint Vincent and the Grenadines"),
        new SupportedLanguage("en", "English", "tt", LanguageContinent.America, "Trinidad and Tobago"),
        new SupportedLanguage("en", "English", "us", LanguageContinent.America, "United States"),
        new SupportedLanguage("es", "Español", "uy", LanguageContinent.America, "Uruguay"),
        new SupportedLanguage("es", "Español", "ve", LanguageContinent.America, "Venezuela"),
        new SupportedLanguage("en", "English", "au", LanguageContinent.Oceania, "Australia"),
        new SupportedLanguage("en", "English", "fm", LanguageContinent.Oceania, "Micronesia"),
        new SupportedLanguage("en", "English", "sb", LanguageContinent.Oceania, "Solomon Islands"),
        new SupportedLanguage("fr", "Français", "vu", LanguageContinent.Oceania, "Vanuatu")
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

    /// <summary>Finds the entry for a language under a given flag, so a reader who picked Spanish with
    /// the Mexican flag keeps seeing that flag. An unknown or missing flag falls back to the language's
    /// own entry, the first one listed for it.</summary>
    public static SupportedLanguage Find(string code, string countryCode)
    {
        SupportedLanguage result = Find(code);

        if (!string.IsNullOrWhiteSpace(countryCode))
        {
            string languageCode = result.Code;
            SupportedLanguage match = All.FirstOrDefault(language =>
                language.Code == languageCode
                && string.Equals(language.CountryCode, countryCode, StringComparison.OrdinalIgnoreCase));
            if (match is not null)
            {
                result = match;
            }
        }

        return result;
    }
}
