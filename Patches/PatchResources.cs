using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using UnityEngine;
using xiaoye97;
using MorePlanetTypes.Helpers;
using MorePlanetTypes.Protos;

namespace MorePlanetTypes.Patches {

    [HarmonyPatch(typeof(UnityEngine.Resources), "Load", new Type[] { typeof(string), typeof(Type) })]
    public static class PatchResources {
        public static void Postfix(ref string path, ref UnityEngine.Object __result) {
            if ( __result is VegeProtoSet veges ) {
                //VegeProto newVege = veges.Select(46).Copy();
                //newVege.ID = 250;
                //// This can only be done at loadtime or runtime
                ////newVege.prefabDesc.prefab.transform.localScale *= 2;
                //__result = veges;

                //VegeProto neqSequoia1 = veges.Select(46).Copy();
                //neqSequoia1.ID = 250;
                //veges.AddProto(neqSequoia1);

                //__result = veges;
            }
            
            else if ( __result is ThemeProtoSet themes ) {
                ThemeProto forest1 = Themes.GetForest1(themes, 40);
                ThemeProto forest1Birth = Themes.GetForest1Birth(themes, 30, forest1);

                themes.AddProto(forest1);
                themes.AddProto(forest1Birth);

                themes.AddProto(Themes.GetMolten(themes, 42));

                //ThemeProto molten = Themes.GetMolten(themes, 41);
                //themes.AddProto(molten);
                //molten.ID = 1;
                //molten.Distribute = EThemeDistribute.Birth;
                //themes.dataArray[0] = molten;

            }
        }


        // Old code snippets below this line

        // Old code to bump sentinal vege, aka, the no dependency version
        //// Bump sentinal vege and add another index
        //VegeProto sentinalVege = veges.dataArray.Last();
        //int sentinalIndex = veges.dataArray.Length - 1;
        //Array.Resize(ref veges.dataArray, index + 2);
        //veges.dataArray[sentinalIndex + 1] = sentinalVege;
        //KeyValuePair<int, int> sentinalIndice = veges.dataIndices.OrderByDescending(x => x.Value).First();
        //Debug.LogWarning($"Sentinal vege indice is ({sentinalIndice.Key}, {sentinalIndice.Value})");
        //veges.dataIndices.Remove(sentinalIndice.Key);
        //veges.dataIndices.Add(sentinalIndice.Key, sentinalIndice.Value + 1);
        //Debug.LogWarning($"Sentinal vege bumped to ({sentinalIndice.Key}, {sentinalIndice.Value + 1})");


        // Planet gen stuff

        // Algos only determines what type of terrain generation will be used
        //newTheme.Algos = birthProto.Algos;

        // ModX ModY is terrain randomness (the wibbily wobbily of the terrain) for the chosen Algo
        //newTheme.ModX = oceanProto.ModX;
        //newTheme.ModY = oceanProto.ModY;


        // Code to print all veges
        //Debug.LogError("Veges:");
        //var protoset = veges;
        //for ( int i = 0; i < protoset.dataIndices.Count(); i++ ) {
        //    KeyValuePair<int, int> indice = protoset.dataIndices.ElementAt(i);
        //    var x = protoset.dataArray[indice.Value];
        //    Debug.LogWarning($"arrIndx: {indice.Value,3} | id:{x?.ID,4} | type: {x?.Type, 7} | name: {x?.name?.Translate(),20}");
        //}


        // Print all vege arrays for a theme proto
        //ThemeProto w = themes.dataArray[7].Copy();  // Jungle proto
        //Debug.LogWarning("Vegetables0 " + string.Join(",", w.Vegetables0.Select(x => x.ToString()).ToArray()));
        //Debug.LogWarning("Vegetables1 " + string.Join(",", w.Vegetables1.Select(x => x.ToString()).ToArray()));
        //Debug.LogWarning("Vegetables2 " + string.Join(",", w.Vegetables2.Select(x => x.ToString()).ToArray()));
        //Debug.LogWarning("Vegetables3 " + string.Join(",", w.Vegetables3.Select(x => x.ToString()).ToArray()));
        //Debug.LogWarning("Vegetables4 " + string.Join(",", w.Vegetables4.Select(x => x.ToString()).ToArray()));
        //Debug.LogWarning("Vegetables5 " + string.Join(",", w.Vegetables5.Select(x => x.ToString()).ToArray()));
    }
}