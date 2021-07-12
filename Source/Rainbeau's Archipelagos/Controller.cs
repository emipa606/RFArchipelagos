using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace RA_Code
{
    public class Controller : Mod
    {
        public static Settings Settings;

        public Controller(ModContentPack content) : base(content)
        {
            var harmony = new Harmony("net.rainbeau.rimworld.mod.archipelagos");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Settings = GetSettings<Settings>();
        }

        public override string SettingsCategory()
        {
            return "RFA.Archipelagos".Translate();
        }

        public override void DoSettingsWindowContents(Rect canvas)
        {
            Settings.DoWindowContents(canvas);
        }
    }
}