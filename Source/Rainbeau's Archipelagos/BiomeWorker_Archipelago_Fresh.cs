using RimWorld;
using RimWorld.Planet;

namespace RA_Code;

public class BiomeWorker_Archipelago_Fresh : BiomeWorker
{
    public override float GetScore(Tile tile, int tileID)
    {
        return -100f;
    }
}