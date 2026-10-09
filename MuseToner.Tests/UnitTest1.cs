using MuseToner.Core;

namespace MuseToner.Tests;

public class ScaleMathTests
{
    [Theory]
    [InlineData(0, 2, 2)]    // Do -> Re: sube 2
    [InlineData(0, 9, -3)]   // Do -> La: baja 3 (más corto que subir 9)
    [InlineData(9, 0, 3)]    // La -> Do: sube 3
    [InlineData(0, 6, -6)]   // empate: tónica destino > 5, baja
    [InlineData(6, 0, 6)]    // empate: tónica destino <= 5, sube
    public void NearestOctaveDistance_DevuelveLaDistanciaMasCorta(int desde, int hasta, int esperado)
    {
        Assert.Equal(esperado, ScaleMath.NearestOctaveDistance(desde, hasta));
    }
}
