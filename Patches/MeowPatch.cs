using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace MeowMod.Patches
{
    [HarmonyPatch(typeof(MouthDogAI))]
    internal class MeowPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void soundPatch(ref AudioClip ___breathingSFX)
        {
            AssetBundle meowBundle = AssetBundle.LoadFromMemory(MeowMod.Properties.Resources.meowbundle);
            AudioClip meow = meowBundle.LoadAsset<AudioClip>("Assets/meow.mp3");

            ___breathingSFX = meow;
        }
    }
}
