using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;

namespace MuseToner.Core;

public static class NoteAnalyzer
{
    public static List<NoteInfo> Analyze(MidiFile midi, int tonic, int[] scale)
    {
        List<NoteInfo> result = new List<NoteInfo>();
        TempoMap tempoMap = midi.GetTempoMap();

        foreach (Note note in midi.GetNotes())
        {
            int channel = (int)note.Channel;
            if (channel == ScaleCatalog.PercussionChannel)
            {
                continue;   // The percussion channel is not drawn.
            }

            MetricTimeSpan start = note.TimeAs<MetricTimeSpan>(tempoMap);
            MetricTimeSpan length = note.LengthAs<MetricTimeSpan>(tempoMap);

            double startSeconds = start.TotalMicroseconds / 1000000.0;
            double durationSeconds = length.TotalMicroseconds / 1000000.0;

            int number = (int)note.NoteNumber;
            bool outOfScale = !ScaleMath.NoteInScale(number, tonic, scale);

            result.Add(new NoteInfo(startSeconds, durationSeconds, number, channel, outOfScale));
        }

        return result;
    }



    public static void GetNoteRange(List<NoteInfo> notes, out int minNote, out int maxNote)
    {
        // Default range.
        minNote = 36;
        maxNote = 96;

        if (notes.Count == 0)
        {
            return;
        }

        int lowest = 127;
        int highest = 0;
        foreach (NoteInfo n in notes)
        {
            if (n.NoteNumber < lowest) lowest = n.NoteNumber;
            if (n.NoteNumber > highest) highest = n.NoteNumber;
        }

        // Margin of 2 semitones.
        lowest = lowest - 2;
        highest = highest + 2;

        // Adjust to C limits: the minimum drops to the previous C, and the maximum rises to the next C.
        minNote = (lowest / 12) * 12;
        maxNote = ((highest / 12) + 1) * 12;

        // MIDI Limits.
        if (minNote < 0) minNote = 0;
        if (maxNote > 127) maxNote = 127;
    }
}