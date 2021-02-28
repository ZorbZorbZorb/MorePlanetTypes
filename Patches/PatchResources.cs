using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using UnityEngine;
using xiaoye97;
using MorePlanetTypes.Helpers;
using MorePlanetTypes.NewContent;

namespace MorePlanetTypes.Patches {

    [HarmonyPatch(typeof(UnityEngine.Resources), "Load", new Type[] { typeof(string), typeof(Type) })]
    public static class PatchResources {
        public static void Postfix(ref string path, ref UnityEngine.Object __result) {
            if ( __result is VegeProtoSet veges ) {
                //veges.AddProto(Veges.GetSequoia1(veges, 1400));
                //veges.AddProto(Veges.GetRedForestGrass1(veges));
            }
            else if ( __result is ThemeProtoSet themes ) {
                themes.AddProto(Themes.GetRedForest(themes));
                themes.AddProto(Themes.GetSulfur(themes));
                themes.AddProto(Themes.GetForest1(themes));
                themes.AddProto(Themes.GetForest1Birth(themes));
                themes.AddProto(Themes.GetMolten(themes));
                //themes.AddProto(Themes.GetCliffs(themes));
            }
        }
    }
}

