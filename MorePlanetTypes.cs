using BepInEx;
using HarmonyLib;
using MorePlanetTypes.Patches;
using MorePlanetTypes.Protos;
using System;
using System.Security;
using System.Security.Permissions;
using xiaoye97;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace MorePlanetTypes {
    [BepInDependency("me.xiaoye97.plugin.Dyson.LDBTool", "1.8.0")]
    [BepInDependency("zorb.dsp.plugins.vegeandveinhelper", "1.0.1")]
    [BepInPlugin("org.bepinex.plugins.moreplanettypes", "More planet types", "1.0.0")]
    [BepInProcess("DSPGAME.exe")]
    public class MorePlanetTypes : BaseUnityPlugin {
        internal void Awake() {
            Harmony harmony = new Harmony("zorb.dsp.plugins.moreplanettypes");

            Harmony.CreateAndPatchAll(typeof(PatchResources), harmony.Id);
            Harmony.CreateAndPatchAll(typeof(PatchPlanetGen), harmony.Id);
            Harmony.CreateAndPatchAll(typeof(PatchUniverseGen), harmony.Id);
        }
    }
}
