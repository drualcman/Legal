namespace Legal.Localization;

/// <summary>Continent a language is grouped under in the pickers. In Europe and Asia a language is
/// listed once, under the country it originates from; Africa keeps Arabic and Swahili under the UN
/// globe; America and Oceania list every country with the supported language it speaks.</summary>
public enum LanguageContinent
{
    Europe,
    Asia,
    Africa,
    America,
    Oceania
}
