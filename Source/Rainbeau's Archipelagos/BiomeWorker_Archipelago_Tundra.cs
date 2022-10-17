using RimWorld;
using RimWorld.Planet;

namespace RA_Code;

public class BiomeWorker_Archipelago_Tundra : BiomeWorker
{
    public override float GetScore(Tile tile, int tileID)
    {
        if (!tile.WaterCovered)
        {
            return -100f;
        }

        if (tile.elevation < -99)
        {
            return -100f;
        }

        if (tile.temperature < -21f)
        {
            return -100f;
        }

        return -tile.temperature;
    }
}