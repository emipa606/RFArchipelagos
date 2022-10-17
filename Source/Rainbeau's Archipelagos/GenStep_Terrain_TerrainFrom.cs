using HarmonyLib;
using RimWorld;
using Verse;

namespace RA_Code;

[HarmonyPatch(typeof(GenStep_Terrain), "TerrainFrom", null)]
public static class GenStep_Terrain_TerrainFrom
{
    private static bool Prefix(IntVec3 c, Map map, float elevation, float fertility, ref TerrainDef __result)
    {
        if (!map.Biome.defName.Contains("Archipelago"))
        {
            return true;
        }

        var adjustment = 0.0f;
        switch (Controller.Settings.waterLevel)
        {
            case < 1:
                adjustment = -0.1f;
                break;
            case < 2:
                adjustment = -0.05f;
                break;
            case < 3:
                break;
            case < 4:
                adjustment = 0.05f;
                break;
            default:
                adjustment = 0.1f;
                break;
        }

        var lakeIsles = map.Biome.defName.Contains("_Fresh");

        if (elevation < 0.75f)
        {
            var edifice = c.GetEdifice(map);
            edifice?.Destroy();

            map.roofGrid.SetRoof(c, null);
            for (var i = -1; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                {
                    var x = c.x + i;
                    var z = c.z + j;
                    if (x < 0 || z < 0 || x >= map.Size.x || z >= map.Size.z)
                    {
                        continue;
                    }

                    var newSpot = new IntVec3(x, 0, z);
                    if (map.roofGrid.RoofAt(newSpot) == null)
                    {
                        continue;
                    }

                    if (map.roofGrid.RoofAt(newSpot).isThickRoof)
                    {
                        map.roofGrid.SetRoof(newSpot, RoofDefOf.RoofRockThin);
                    }
                    else
                    {
                        if ((i != 0 || j == 0) && (i == 0 || j != 0))
                        {
                            continue;
                        }

                        if (Rand.Value < 0.33)
                        {
                            map.roofGrid.SetRoof(newSpot, null);
                        }
                    }
                }
            }
        }

        if (elevation > 0.65f && elevation <= 0.69f)
        {
            __result = TerrainDefOf.Gravel;
            return false;
        }

        if ((elevation > 0.69f) & (elevation < 0.71f))
        {
            __result = TerrainDefOf.Gravel;
            return false;
        }

        if (elevation >= 0.71f)
        {
            __result = GenStep_RocksFromGrid.RockDefAt(c).building.naturalTerrain;
            return false;
        }

        var deepWater = TerrainDefOf.WaterOceanDeep;
        var shallowWater = TerrainDefOf.WaterOceanShallow;
        if (lakeIsles.Equals(true))
        {
            deepWater = TerrainDefOf.WaterDeep;
            shallowWater = TerrainDefOf.WaterShallow;
        }

        if (elevation < 0.35f + adjustment)
        {
            __result = deepWater;
            return false;
        }

        if (elevation < 0.45f + adjustment)
        {
            __result = shallowWater;
            return false;
        }

        var borderTerrainL = TerrainDefOf.Sand;
        var borderTerrainH = TerrainDefOf.Sand;
        if (lakeIsles.Equals(true))
        {
            if (map.Biome.defName.Contains("Boreal") || map.Biome.defName.Contains("Tundra"))
            {
                borderTerrainL = TerrainDef.Named("Mud");
                borderTerrainH = TerrainDef.Named("MossyTerrain");
            }
            else if (map.Biome.defName.Contains("ColdBog") || map.Biome.defName.Contains("Swamp"))
            {
                borderTerrainL = TerrainDef.Named("Marsh");
                borderTerrainH = TerrainDef.Named("MarshyTerrain");
            }
            else if (map.Biome.defName.Contains("Temperate") || map.Biome.defName.Contains("Tropical"))
            {
                borderTerrainL = TerrainDef.Named("Mud");
                borderTerrainH = TerrainDef.Named("SoilRich");
            }
        }

        if (elevation < 0.47f + adjustment)
        {
            __result = borderTerrainL;
            return false;
        }

        if (elevation < 0.50f + adjustment)
        {
            __result = borderTerrainH;
            return false;
        }

        var terrainDef = TerrainThreshold.TerrainAtValue(map.Biome.terrainsByFertility, fertility);
        if (terrainDef != null)
        {
            __result = terrainDef;
            return false;
        }

        __result = borderTerrainH;
        return false;
    }
}