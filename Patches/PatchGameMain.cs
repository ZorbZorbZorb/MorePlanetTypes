using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using UnityEngine;
using xiaoye97;
using MorePlanetTypes.NewContent;
using MorePlanetTypes.Helpers;

namespace MorePlanetTypes.Patches {
    [HarmonyPatch(typeof(GameMain))]
    public class PatchGameMain {
        [HarmonyPrefix]
        [HarmonyPatch("Begin")]
        public static void Begin() {
            // Post add data actions for new content
            ThemeProtoSet themes = LDB.themes;
            VegeProtoSet veges = LDB.veges;

            //Veges.GetRedForestGrass1(veges, true);

            Themes.GetForest1(themes, true);
            Themes.GetForest1Birth(themes, true);
            Themes.GetMolten(themes, true);
            Themes.GetRedForest(themes, true);
            Themes.GetSulfur(themes, true);
            //Themes.GetCliffs(themes, true);

            //Themes.DebugForceSpawnTo(themes, 21);
        }
    }
}
