namespace Legal.Localization;

/// <summary>One selectable interface language. The name is written in the language itself so it can
/// be recognised without understanding the language currently in use.</summary>
public sealed record SupportedLanguage(
    string Code,
    string NativeName,
    string CountryCode,
    LanguageContinent Continent)
{
    public string FlagVectorUrl => $"https://flagcdn.com/{CountryCode}.svg";

    /// <summary>Bitmap flag for the clients that cannot render SVG (WPF).</summary>
    public string FlagImageUrl => $"https://flagcdn.com/w40/{CountryCode}.png";
}
