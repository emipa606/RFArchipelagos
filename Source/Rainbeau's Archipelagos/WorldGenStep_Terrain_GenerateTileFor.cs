using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace RA_Code;

[HarmonyPatch(typeof(WorldGenStep_Terrain), "GenerateTileFor", null)]
public static class WorldGenStep_Terrain_GenerateTileFor
{
    public static void Postfix(int tileID, ref Tile __result)
    {
        if (!__result.biome.defName.Contains("Archipelago"))
        {
            return;
        }

        if (Rand.Value > 0.03f)
        {
            __result.biome = BiomeDef.Named("Ocean");
        }
        else
        {
            __result.elevation += 100;
            if (Rand.Value >= 0.33f)
            {
                return;
            }

            __result.hilliness = Hilliness.SmallHills;
            if (Rand.Value < 0.25f)
            {
                __result.hilliness = Hilliness.LargeHills;
            }
        }
    }
}