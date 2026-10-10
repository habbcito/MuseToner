using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;

namespace MuseToner.Core;

/// <summary>Transposition and scaling operations on MIDI files.</summary>
public static class MidiTransposer
{
    private const int MidiMin = 0;
    private const int MidiMax = 127;

    /// <summary>
    /// Returns the notes that do not belong to the specified scale (ignores the percussion channel).
    /// If the list is empty, the file uses only valid notes.
    /// </summary>
    public static List<Note> FindOutOfScaleNotes(MidiFile midi, int tonic, int[] scale)
    {
        return midi.GetNotes()
            .Where(n => (int)n.Channel != ScaleCatalog.PercussionChannel
                        && !ScaleMath.NoteInScale((int)n.NoteNumber, tonic, scale))
            .ToList();
    }




    /// <summary>Determine whether there are any notes outside the scale.</summary>
    public static bool HasOnlyRightNotes(MidiFile midi, int tonic, int[] scale)
        => FindOutOfScaleNotes(midi, tonic, scale).Count == 0;




    /// <summary>Transpose the entire melody (except the percussion) by a certain number of semitones.</summary>
    public static void TranslateByOffset(MidiFile midi, int offset)
    {
        midi.ProcessNotes(note =>
        {
            if ((int)note.Channel == ScaleCatalog.PercussionChannel) return;
            note.NoteNumber = ToNoteNumber((int)note.NoteNumber + offset);
        });
    }




    /// <summary>
    /// Change the accidentals from one scale to another while maintaining the degree of each note.
    /// Notes outside the initial scale are not modified.
    /// </summary>
    public static void ModifyScale(MidiFile midi, int tonic, int[] initialScale, int[] finalScale)
    {
        midi.ProcessNotes(note =>
        {
            if ((int)note.Channel == ScaleCatalog.PercussionChannel) return;

            int current = (int)note.NoteNumber;
            int relativeNote = ((current % 12) - tonic + 12) % 12;

            int pos = Array.IndexOf(initialScale, relativeNote);
            if (pos < 0) return;

            int offset = finalScale[pos] - initialScale[pos];
            note.NoteNumber = ToNoteNumber(current + offset);
        });
    }




    /// <summary>
    /// Converts a melody from one (tonic, scale) to another (tonic, scale) and returns a new file.
    /// It does not modify the original.
    /// </summary>
    public static MidiFile Convert(
        MidiFile input,
        int originalTonic,
        int[] initialScale,
        int finalTonic,
        int[] finalScale)
    {
        bool differentTonics = originalTonic != finalTonic;
        bool differentScales = !initialScale.SequenceEqual(finalScale);

        if (!differentTonics && !differentScales)
            throw new ArgumentException("Las dos tonalidades son las mismas, no hay nada que convertir.");

        MidiFile output = input.Clone();

        // 1) Change of tonic (if applicable). 2) Change of scale on the final tonic.
        if (differentTonics)
            TranslateByOffset(output, ScaleMath.NearestOctaveDistance(originalTonic, finalTonic));

        if (differentScales)
            ModifyScale(output, finalTonic, initialScale, finalScale);

        return output;
    }




    // Clamps to the valid MIDI range and converts to the type used by DryWetMIDI.
    private static SevenBitNumber ToNoteNumber(int value)
        => (SevenBitNumber)(byte)Math.Clamp(value, MidiMin, MidiMax);
}
