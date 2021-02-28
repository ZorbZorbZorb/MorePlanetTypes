using BepInEx;
using HarmonyLib;
using MorePlanetTypes.Patches;
using System.Security;
using System.Security.Permissions;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace MorePlanetTypes {
    [BepInDependency("me.xiaoye97.plugin.Dyson.LDBTool", "1.8.0")]
    [BepInDependency("zorb.dsp.plugins.vegeandveinhelper", "1.0.1")]
    [BepInPlugin("org.bepinex.plugins.moreplanettypes", "More planet types", "1.2.0")]
    [BepInProcess("DSPGAME.exe")]
    public class MorePlanetTypes : BaseUnityPlugin {
        internal void Awake() {
            Harmony harmony = new Harmony("zorb.dsp.plugins.moreplanettypes");

            Harmony.CreateAndPatchAll(typeof(PatchResources), harmony.Id);
            //Harmony.CreateAndPatchAll(typeof(PatchPlanetGen), harmony.Id);
            Harmony.CreateAndPatchAll(typeof(PatchUniverseGen), harmony.Id);
            Harmony.CreateAndPatchAll(typeof(PatchPlanetModelingManager), harmony.Id);
            Harmony.CreateAndPatchAll(typeof(PatchGameMain), harmony.Id);
        }
    }
}
