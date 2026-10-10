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
                continue;   // The percussion channel isn't drawn.
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
}