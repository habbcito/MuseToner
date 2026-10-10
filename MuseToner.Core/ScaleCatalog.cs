namespace MuseToner.Core;

/// <summary>A heptatonic scale: name and semitone pattern relative to the tonic.</summary>
public sealed record ScalePattern(string Name, int[] Degrees);

/// <summary>Available tonics and scales.</summary>
public static class ScaleCatalog
{
    public const int PercussionChannel = 9;

    public static readonly IReadOnlyList<string> TonicNames = new[]
    {
        "C - Do",
        "C#/Db - Do#/Reb",
        "D - Re",
        "D#/Eb - Re#/Mib",
        "E - Mi",
        "F - Fa",
        "F#/Gb - Fa#/Solb",
        "G - Sol",
        "G#/Ab - Sol#/Lab",
        "A - La",
        "A#/Bb - La#/Sib",
        "B - Si",
    };




    public static readonly IReadOnlyList<ScalePattern> Scales = new[]
    {
        new ScalePattern("Jónica (Mayor)",                      new[] { 0, 2, 4, 5, 7, 9, 11 }),  // 00
        new ScalePattern("Dórica",                              new[] { 0, 2, 3, 5, 7, 9, 10 }),  // 01
        new ScalePattern("Frigia",                              new[] { 0, 1, 3, 5, 7, 8, 10 }),  // 02
        new ScalePattern("Lidia",                               new[] { 0, 2, 4, 6, 7, 9, 11 }),  // 03
        new ScalePattern("Mixolidia",                           new[] { 0, 2, 4, 5, 7, 9, 10 }),  // 04
        new ScalePattern("Eólica (Menor)",                      new[] { 0, 2, 3, 5, 7, 8, 10 }),  // 05
        new ScalePattern("Locria",                              new[] { 0, 1, 3, 5, 6, 8, 10 }),  // 06
        new ScalePattern("Menor Armónica",                      new[] { 0, 2, 3, 5, 7, 8, 11 }),  // 07
        new ScalePattern("Mayor Armónica",                      new[] { 0, 2, 4, 5, 7, 8, 11 }),  // 08
        new ScalePattern("Frigia Dominante",                    new[] { 0, 1, 4, 5, 7, 8, 10 }),  // 09
        new ScalePattern("Dórica Ucraniana",                    new[] { 0, 2, 3, 6, 7, 9, 10 }),  // 10
        new ScalePattern("Doble Armónica (Bizantina o Árabe)",  new[] { 0, 1, 4, 5, 7, 8, 11 }),  // 11
        new ScalePattern("Pentatónica Mayor",                   new[] { 0, 2, 4, 7, 9, 10, 11 }), // 12
        new ScalePattern("Enigmática",                          new[] { 0, 1, 4, 6, 8, 10, 11 }), // 13
        new ScalePattern("Persa",                               new[] { 0, 1, 4, 5, 6, 8, 11 }),  // 14
        new ScalePattern("Húngara Mayor",                       new[] { 0, 3, 4, 6, 7, 9, 10 }),  // 15
        new ScalePattern("Mixolidia b6 (Mixolidia Menor)",      new[] { 0, 2, 4, 5, 7, 8, 10 }),  // 16
        new ScalePattern("Lidia #2 (Lidia Aumentada)",          new[] { 0, 3, 4, 6, 7, 9, 11 }),  // 17
        new ScalePattern("Locria Natural 6",                    new[] { 0, 1, 3, 5, 6, 9, 10 }),  // 18
        new ScalePattern("Mayor Napolitana",                    new[] { 0, 1, 3, 5, 7, 9, 11 }),  // 19
    };
}
