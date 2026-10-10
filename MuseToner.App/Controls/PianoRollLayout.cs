namespace MuseToner.App.Controls;

public static class PianoRollLayout
{
    public static int MinNote { get; private set; } = 36;
    public static int MaxNote { get; private set; } = 96;
    public const double RowHeight = 14;
    public const double KeyWidth = 70;
    public const double PixelsPerSecond = 100;



    public static void SetRange(int minNote, int maxNote)
    {
        MinNote = minNote;
        MaxNote = maxNote;
    }


    public static int RowsCount()
    {
        return MaxNote - MinNote + 1;
    }

    public static double TotalHeight()
    {
        return RowsCount() * RowHeight;
    }

    // y = 0 is at the top, so high notes have a small Y value.
    public static double YValueOfNote(int nota)
    {
        return (MaxNote - nota) * RowHeight;
    }

    // Sharps/Flats: 1, 3, 6, 8, 10 in every octave.
    public static bool IsBlackKey(int note)
    {
        int classNote = note % 12;
        return classNote == 1 || classNote == 3 || classNote == 6 || classNote == 8 || classNote == 10;
    }
}