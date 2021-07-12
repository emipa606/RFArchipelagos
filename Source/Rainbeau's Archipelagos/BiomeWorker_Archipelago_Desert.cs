using RimWorld;
using RimWorld.Planet;

namespace RA_Code
{
    public class BiomeWorker_Archipelago_Desert : BiomeWorker
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

            if (tile.temperature < -10f)
            {
                return -100f;
            }

            if (tile.rainfall >= 2000f)
            {
                return 0f;
            }

            if (tile.rainfall < 600f)
            {
                return tile.temperature + 0.0001f;
            }

            return 22.5f + ((tile.temperature - 20f) * 2.2f) + ((tile.rainfall - 600f) / 100f);
        }
    }
}