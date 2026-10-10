namespace Legal.Localization;

/// <summary>One selectable interface language, as offered under one country flag. The name is written
/// in the language itself so it can be recognised without understanding the language currently in
/// use. A language offered under several countries (Spanish across America, English in Oceania...)
/// has one entry per country, and those entries carry the country name so they can be told apart.</summary>
public sealed record SupportedLanguage(
    string Code,
    string NativeName,
    string CountryCode,
    LanguageContinent Continent,
    string CountryName = null)
{
    public string FlagVectorUrl => $"https://flagcdn.com/{CountryCode}.svg";

    /// <summary>Bitmap flag for the clients that cannot render SVG (WPF).</summary>
    public string FlagImageUrl => $"https://flagcdn.com/w40/{CountryCode}.png";

    public bool HasCountryName => !string.IsNullOrWhiteSpace(CountryName);
}
