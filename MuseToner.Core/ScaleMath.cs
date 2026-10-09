namespace MuseToner.Core;

/// <summary>Cálculos sobre tónicas y escalas, sin depender de ninguna librería MIDI.</summary>
public static class ScaleMath
{
    /// <summary>
    /// Devuelve el desplazamiento en semitonos más corto para pasar de la tónica 1 a la tónica 2 (0-11).
    /// </summary>
    public static int NearestOctaveDistance(int tonic1, int tonic2)
    {
        // Ambas distancias posibles.
        int distanceUp = (tonic2 - tonic1 + 12) % 12;
        int distanceDown = distanceUp - 12;

        // Caso especial: ambas distancias valen lo mismo en valor absoluto (6 semitonos).
        // Criterio original: si la tónica destino es <= 5 se sube, si no se baja.
        if (Math.Abs(distanceUp) == Math.Abs(distanceDown))
            return tonic2 <= 5 ? distanceUp : distanceDown;

        // Caso normal: la distancia más corta.
        return Math.Abs(distanceUp) < Math.Abs(distanceDown) ? distanceUp : distanceDown;
    }




    /// <summary>Indica si una nota MIDI (0-127) pertenece a la escala con la tónica dada.</summary>
    public static bool NoteInScale(int note, int tonic, int[] scale)
    {
        // Nota relativa a la tónica, sin considerar octava (+12 evita negativos).
        int relativeNote = ((note % 12) - tonic + 12) % 12;
        return Array.IndexOf(scale, relativeNote) >= 0;
    }
}
