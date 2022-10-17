using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace RA_Code;

[HarmonyPatch(typeof(WorldGenStep_Lakes), "GenerateLakes", null)]
public static class WorldGenStep_Lakes_GenerateLakes
{
    private static bool Prefix()
    {
        var worldGrid = Find.WorldGrid;
        var bools = new bool[worldGrid.TilesCount];
        var nums = new List<int>();
        for (var i = 0; i < worldGrid.TilesCount; i++)
        {
            if (bools[i])
            {
                continue;
            }

            if (worldGrid[i].biome != BiomeDefOf.Ocean && (worldGrid[i].biome.defName == null ||
                                                           !worldGrid[i].biome.defName.Contains("Archipelago")))
            {
                continue;
            }

            Find.WorldFloodFiller.FloodFill(i,
                tid => worldGrid[tid].biome == BiomeDefOf.Ocean || worldGrid[tid].biome.defName != null &&
                    worldGrid[tid].biome.defName.Contains("Archipelago"), tid =>
                {
                    nums.Add(tid);
                    bools[tid] = true;
                });
            if (nums.Count <= 180)
            {
                foreach (var number in nums)
                {
                    switch (worldGrid[number].biome.defName)
                    {
                        case null:
                            worldGrid[number].biome = BiomeDefOf.Lake;
                            continue;
                        case "BorealArchipelago":
                            worldGrid[number].biome = BiomeDef.Named("BorealArchipelago_Fresh");
                            break;
                        case "ColdBogArchipelago":
                            worldGrid[number].biome = BiomeDef.Named("ColdBogArchipelago_Fresh");
                            break;
                        case "DesertArchipelago":
                            worldGrid[number].biome = BiomeDef.Named("DesertArchipelago_Fresh");
                            break;
                        case "TemperateArchipelago":
                            worldGrid[number].biome = BiomeDef.Named("TemperateArchipelago_Fresh");
                            break;
                        case "TemperateSwampArchipelago":
                            worldGrid[number].biome = BiomeDef.Named("TemperateSwampArchipelago_Fresh");
                            break;
                        case "TropicalArchipelago":
                            worldGrid[number].biome = BiomeDef.Named("TropicalArchipelago_Fresh");
                            break;
                        case "TropicalSwampArchipelago":
                            worldGrid[number].biome = BiomeDef.Named("TropicalSwampArchipelago_Fresh");
                            break;
                        case "TundraArchipelago":
                            worldGrid[number].biome = BiomeDef.Named("TundraArchipelago_Fresh");
                            break;
                    }
                }
            }

            nums.Clear();
        }

        return false;
    }
}