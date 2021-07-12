using RimWorld;
using Verse;

namespace RA_Code
{
    [StaticConstructorOnStartup]
    internal static class Archi_Initializer
    {
        static Archi_Initializer()
        {
            foreach (var current in DefDatabase<ThingDef>.AllDefsListForReading)
            {
                if (current.plant?.wildBiomes == null)
                {
                    continue;
                }

                for (var j = 0; j < current.plant.wildBiomes.Count; j++)
                {
                    var newRecord1 = new PlantBiomeRecord();
                    var newRecord2 = new PlantBiomeRecord();
                    if (current.plant.wildBiomes[j]?.biome?.defName == null)
                    {
                        continue;
                    }

                    switch (current.plant.wildBiomes[j]?.biome?.defName)
                    {
                        case "AridShrubland":
                            newRecord1.biome = BiomeDef.Named("DesertArchipelago");
                            newRecord2.biome = BiomeDef.Named("DesertArchipelago_Fresh");
                            break;
                        case "BorealForest":
                            newRecord1.biome = BiomeDef.Named("BorealArchipelago");
                            newRecord2.biome = BiomeDef.Named("BorealArchipelago_Fresh");
                            break;
                        case "ColdBog":
                            newRecord1.biome = BiomeDef.Named("ColdBogArchipelago");
                            newRecord2.biome = BiomeDef.Named("ColdBogArchipelago_Fresh");
                            break;
                        case "TemperateForest":
                            newRecord1.biome = BiomeDef.Named("TemperateArchipelago");
                            newRecord2.biome = BiomeDef.Named("TemperateArchipelago_Fresh");
                            break;
                        case "TemperateSwamp":
                            newRecord1.biome = BiomeDef.Named("TemperateSwampArchipelago");
                            newRecord2.biome = BiomeDef.Named("TemperateSwampArchipelago_Fresh");
                            break;
                        case "TropicalRainforest":
                            newRecord1.biome = BiomeDef.Named("TropicalArchipelago");
                            newRecord2.biome = BiomeDef.Named("TropicalArchipelago_Fresh");
                            break;
                        case "TropicalSwamp":
                            newRecord1.biome = BiomeDef.Named("TropicalSwampArchipelago");
                            newRecord2.biome = BiomeDef.Named("TropicalSwampArchipelago_Fresh");
                            break;
                        case "Tundra":
                            newRecord1.biome = BiomeDef.Named("TundraArchipelago");
                            newRecord2.biome = BiomeDef.Named("TundraArchipelago_Fresh");
                            break;
                    }

                    newRecord1.commonality = current.plant.wildBiomes[j].commonality;
                    newRecord2.commonality = current.plant.wildBiomes[j].commonality;
                    current.plant.wildBiomes.Add(newRecord1);
                    current.plant.wildBiomes.Add(newRecord2);
                }
            }

            foreach (var current in DefDatabase<PawnKindDef>.AllDefs)
            {
                if (current.RaceProps.wildBiomes == null || current.defName == "Cobra")
                {
                    continue;
                }

                for (var j = 0; j < current.RaceProps.wildBiomes.Count; j++)
                {
                    var newRecord1 = new AnimalBiomeRecord();
                    var newRecord2 = new AnimalBiomeRecord();
                    if (current.RaceProps.wildBiomes[j]?.biome?.defName == null)
                    {
                        continue;
                    }

                    switch (current.RaceProps.wildBiomes[j]?.biome?.defName)
                    {
                        case "AridShrubland":
                            newRecord1.biome = BiomeDef.Named("DesertArchipelago");
                            newRecord2.biome = BiomeDef.Named("DesertArchipelago_Fresh");
                            break;
                        case "BorealForest":
                            newRecord1.biome = BiomeDef.Named("BorealArchipelago");
                            newRecord2.biome = BiomeDef.Named("BorealArchipelago_Fresh");
                            break;
                        case "ColdBog":
                            newRecord1.biome = BiomeDef.Named("ColdBogArchipelago");
                            newRecord2.biome = BiomeDef.Named("ColdBogArchipelago_Fresh");
                            break;
                        case "TemperateForest":
                            newRecord1.biome = BiomeDef.Named("TemperateArchipelago");
                            newRecord2.biome = BiomeDef.Named("TemperateArchipelago_Fresh");
                            break;
                        case "TemperateSwamp":
                            newRecord1.biome = BiomeDef.Named("TemperateSwampArchipelago");
                            newRecord2.biome = BiomeDef.Named("TemperateSwampArchipelago_Fresh");
                            break;
                        case "TropicalRainforest":
                            newRecord1.biome = BiomeDef.Named("TropicalArchipelago");
                            newRecord2.biome = BiomeDef.Named("TropicalArchipelago_Fresh");
                            break;
                        case "TropicalSwamp":
                            newRecord1.biome = BiomeDef.Named("TropicalSwampArchipelago");
                            newRecord2.biome = BiomeDef.Named("TropicalSwampArchipelago_Fresh");
                            break;
                        case "Tundra":
                            newRecord1.biome = BiomeDef.Named("TundraArchipelago");
                            newRecord2.biome = BiomeDef.Named("TundraArchipelago_Fresh");
                            break;
                    }

                    newRecord1.commonality = current.RaceProps.wildBiomes[j].commonality;
                    newRecord2.commonality = current.RaceProps.wildBiomes[j].commonality;
                    current.RaceProps.wildBiomes.Add(newRecord1);
                    current.RaceProps.wildBiomes.Add(newRecord2);
                }
            }
        }
    }

    //[HarmonyPatch(typeof(World), "CoastDirectionAt", null)]
    //public static class World_CoastDirectionAt
    //{
    //    public static bool Prefix(int tileID, ref Rot4 __result, ref World __instance)
    //    {
    //        var world = Traverse.Create(__instance);
    //        WorldGrid worldGrid = world.Field("grid").GetValue<WorldGrid>();
    //        if (worldGrid[tileID].biome.defName.Contains("Archipelago"))
    //        {
    //            __result = Rot4.Invalid;
    //            return false;
    //        }
    //        return true;
    //    }
    //}
}