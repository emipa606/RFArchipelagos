using UnityEngine;
using Verse;

namespace RA_Code
{
    public class Settings : ModSettings
    {
        public float waterLevel = 2.5f;

        public void DoWindowContents(Rect canvas)
        {
            var list = new Listing_Standard
            {
                ColumnWidth = canvas.width
            };
            list.Begin(canvas);
            list.Gap();
            switch (waterLevel)
            {
                case < 1:
                    list.Label("RFA.waterLevel".Translate() + "  " + "RFA.WaterVeryLow".Translate());
                    break;
                case < 2:
                    list.Label("RFA.waterLevel".Translate() + "  " + "RFA.WaterLow".Translate());
                    break;
                case < 3:
                    GUI.contentColor = Color.yellow;
                    list.Label("RFA.waterLevel".Translate() + "  " + "RFA.WaterNormal".Translate());
                    GUI.contentColor = Color.white;
                    break;
                case < 4:
                    list.Label("RFA.waterLevel".Translate() + "  " + "RFA.WaterHigh".Translate());
                    break;
                default:
                    list.Label("RFA.waterLevel".Translate() + "  " + "RFA.WaterVeryHigh".Translate());
                    break;
            }

            waterLevel = list.Slider(waterLevel, 0, 5);
            list.End();
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref waterLevel, "waterLevel", 2.5f);
        }
    }
}