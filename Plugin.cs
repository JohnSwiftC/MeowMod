using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using BepInEx.Configuration;
using GameNetcodeStuff;
using MeowMod.Patches;

namespace MeowMod
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class MeowModBase : BaseUnityPlugin
    {
        const string modGUID = "Aries.MeowMod";
        const string modName = "Mouth Dog Meow";
        const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static MeowModBase Instance;

        internal ManualLogSource val;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            val = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            val.LogWarning("ICD is online!");

            harmony.PatchAll(typeof(MeowModBase));
            harmony.PatchAll(typeof(MeowPatch));

        }

    }

}