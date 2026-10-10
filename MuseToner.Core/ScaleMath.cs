namespace MuseToner.Core;

/// <summary>Calculations regarding tonics and scales, without relying on any MIDI library.</summary>
public static class ScaleMath
{
    /// <summary>
    /// Returns the shortest semitone shift to move from tonic 1 to tonic 2 (0–11).
    /// </summary>
    public static int NearestOctaveDistance(int tonic1, int tonic2)
    {
        // Both possible distances.
        int distanceUp = (tonic2 - tonic1 + 12) % 12;
        int distanceDown = distanceUp - 12;

        // Special case: both distances are equal in absolute value (6 semitones).
        if (Math.Abs(distanceUp) == Math.Abs(distanceDown))
            return tonic2 <= 5 ? distanceUp : distanceDown;

        // Normal case: the shortest distance.
        return Math.Abs(distanceUp) < Math.Abs(distanceDown) ? distanceUp : distanceDown;
    }




    /// <summary>Indicates whether a MIDI note (0–127) belongs to the scale with the given tonic.</summary>
    public static bool NoteInScale(int note, int tonic, int[] scale)
    {
        // Note relative to the tonic, disregarding the octave (+12 avoids negative values).
        int relativeNote = ((note % 12) - tonic + 12) % 12;
        return Array.IndexOf(scale, relativeNote) >= 0;
    }
}
