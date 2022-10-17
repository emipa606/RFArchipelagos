using RimWorld;
using RimWorld.Planet;

namespace RA_Code;

public class BiomeWorker_Archipelago_ColdBog : BiomeWorker
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

        if (tile.temperature is < -10f or > 15f)
        {
            return -100f;
        }

        if (tile.swampiness < 0.5f)
        {
            return 0f;
        }

        return -tile.temperature + 13f + (tile.swampiness * 8f);
    }
}