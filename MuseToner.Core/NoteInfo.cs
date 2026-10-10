namespace MuseToner.Core;

// <summary>A note of MIDI ready for being drawn in the piano roll.</summary>
public sealed record NoteInfo(
    double StartSeconds,
    double DurationSeconds,
    int NoteNumber,
    int Channel,
    bool OutOfScale);