using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;

namespace MuseToner.Core;

/// <summary>Operaciones de transposición y cambio de escala sobre archivos MIDI.</summary>
public static class MidiTransposer
{
    private const int MidiMin = 0;
    private const int MidiMax = 127;

    /// <summary>
    /// Devuelve las notas que no pertenecen a la escala indicada (ignora el canal de percusión).
    /// Si la lista está vacía, el archivo usa solo notas válidas.
    /// </summary>
    public static List<Note> FindOutOfScaleNotes(MidiFile midi, int tonic, int[] scale)
    {
        return midi.GetNotes()
            .Where(n => (int)n.Channel != ScaleCatalog.PercussionChannel
                        && !ScaleMath.NoteInScale((int)n.NoteNumber, tonic, scale))
            .ToList();
    }




    /// <summary>Equivalente a ScaleHasOnlyRightNotes de la versión C++.</summary>
    public static bool HasOnlyRightNotes(MidiFile midi, int tonic, int[] scale)
        => FindOutOfScaleNotes(midi, tonic, scale).Count == 0;




    /// <summary>Traslada toda la melodía (menos la percusión) un número de semitonos.</summary>
    public static void TranslateByOffset(MidiFile midi, int offset)
    {
        midi.ProcessNotes(note =>
        {
            if ((int)note.Channel == ScaleCatalog.PercussionChannel) return;
            note.NoteNumber = ToNoteNumber((int)note.NoteNumber + offset);
        });
    }




    /// <summary>
    /// Cambia las alteraciones de una escala a otra manteniendo el grado de cada nota.
    /// Las notas fuera de la escala inicial no se modifican.
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
    /// Convierte una melodía de (tónica, escala) a otra (tónica, escala) y devuelve un archivo nuevo.
    /// No modifica el original.
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

        // 1) Cambio de tónica (si corresponde). 2) Cambio de escala sobre la tónica final.
        // Cubre los tres casos de la versión C++ (ambos distintos, solo tónica, solo escala).
        if (differentTonics)
            TranslateByOffset(output, ScaleMath.NearestOctaveDistance(originalTonic, finalTonic));

        if (differentScales)
            ModifyScale(output, finalTonic, initialScale, finalScale);

        return output;
    }




    // Limita al rango MIDI válido y convierte al tipo que usa DryWetMIDI.
    private static SevenBitNumber ToNoteNumber(int value)
        => (SevenBitNumber)(byte)Math.Clamp(value, MidiMin, MidiMax);
}
