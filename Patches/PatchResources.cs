using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using UnityEngine;
using xiaoye97;
using MorePlanetTypes.Helpers;

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

                VegeProto neqSequoia1 = veges.Select(46).Copy();
                neqSequoia1.ID = 250;
                veges.AddProto(neqSequoia1);

                __result = veges;
            }
            
            else if ( __result is ThemeProtoSet themes ) {

                ThemeProto birthProto = themes.dataArray[0].Copy();
                ThemeProto jungleProto = themes.dataArray[7].Copy();
                ThemeProto lavaProto = themes.dataArray[8].Copy();
                ThemeProto mushroomProto = themes.dataArray[13].Copy();
                ThemeProto prarieProto = themes.dataArray[14].Copy();
                ThemeProto oceanProto = themes.dataArray[15].Copy();

                #region Forest1
                // Add the normal forest proto
                ThemeProto forest1 = prarieProto.Copy();
                forest1.ID = 40;
                forest1.DisplayName = "Gigantic Forest";
                forest1.Name = "MorePlanetTypes-Forest-1-Interstellar";
                forest1.Vegetables0 = new int[] { }; // Unused
                forest1.Vegetables1 = new int[] { 42, 42, 42, 46, 101, 101, 101, 101, 101, 101, 102, 102, 102, 102, 102, 102, 103, 103, 103, 103, 103, 103, 104, 104, 104, 104, 104, 104, 125, 125, 125, 125, 125, 125, 601, 601, 601, 601, 601, 601, 602, 602, 602, 602, 602, 602, 603, 603, 603, 603, 603, 603, 604, 604, 604, 604, 604, 604, 605, 605, 605, 605, 605, 605 }; // Medium density, Biome border only
                forest1.Vegetables2 = new int[] { 1001, 1002, 1003, 1005, 1006, 1007  }; // Dense clumped ground scatter, everywhere
                forest1.Vegetables3 = new int[] { 43, 46, 47, 47, 101, 102, 103, 104, 106, 601, 602, 604 }; // Sparse, lowland only
                forest1.Vegetables4 = new int[] { }; // Unused
                forest1.Vegetables5 = new int[] { 42, 42, 42, 42, 42, 42, 42, 42, 42, 42, 42, 43, 43, 43, 43, 43, 43, 46, 46, 47, 47, 47, 47, 47, 47, 47, 102, 103, 103, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 125, 125, 125, 125, 125, 125, 125, 604, 604, 604, 604, 604, 604, 604, 605, 605, 605, 605, 605, 605, 605, 1001, 1001, 1001, 1001, 1001, 1001, 1001, 1002, 1002, 1002, 1002, 1002, 1002, 1002, 1002, 1002 }; // Dense, Highland only
                //Debug.LogWarning(string.Join(",", forest1.Vegetables1.OrderBy(x => x).Select(x => x.ToString()).ToArray()));
                //Debug.LogWarning(string.Join(",", forest1.Vegetables2.OrderBy(x => x).Select(x => x.ToString()).ToArray()));
                //Debug.LogWarning(string.Join(",", forest1.Vegetables3.OrderBy(x => x).Select(x => x.ToString()).ToArray()));
                //Debug.LogWarning(string.Join(",", forest1.Vegetables5.OrderBy(x => x).Select(x => x.ToString()).ToArray()));
                forest1.terrainMat = jungleProto.terrainMat;
                forest1.lowMat = jungleProto.lowMat;
                forest1.MaterialPath = jungleProto.MaterialPath;
                forest1.oceanMat = birthProto.oceanMat;
                forest1.Distribute = EThemeDistribute.Interstellar;
                themes.AddProto(forest1);
                // Create a copy that can be used as a birth planet
                ThemeProto forest1Birth = forest1.Copy();
                forest1Birth.ID = 30;
                forest1Birth.Name = "MorePlanetTypes-Forest-1-Birth";
                forest1Birth.RareSettings = birthProto.RareSettings;
                forest1Birth.RareVeins = birthProto.RareVeins;
                forest1Birth.Distribute = EThemeDistribute.Birth;
                //themes.AddProto(forest1Birth);
                #endregion

                #region LavaOcean
                // Vein generation is really bugged on this one, at least when used as the birth planet
                ThemeProto lavaOcean1 = oceanProto.Copy();
                lavaOcean1.ID = 41;
                lavaOcean1.DisplayName = "Molten World";
                lavaOcean1.oceanMat = lavaProto.oceanMat;
                lavaOcean1.WaterHeight = jungleProto.WaterHeight;
                lavaOcean1.PlanetType = EPlanetType.Vocano;
                lavaOcean1.Distribute = EThemeDistribute.Default;
                lavaOcean1.MaterialPath = lavaProto.MaterialPath;
                lavaOcean1.lowMat = lavaProto.lowMat;
                lavaOcean1.minimapMat = lavaProto.minimapMat;
                lavaOcean1.IonHeight = jungleProto.IonHeight;
                lavaOcean1.Algos = jungleProto.Algos;
                lavaOcean1.ModX = jungleProto.ModX;
                lavaOcean1.ModY = jungleProto.ModY;
                lavaOcean1.Vegetables0 = lavaProto.Vegetables0;
                lavaOcean1.Vegetables1 = lavaProto.Vegetables1;
                lavaOcean1.Vegetables2 = lavaProto.Vegetables2;
                lavaOcean1.Vegetables3 = lavaProto.Vegetables3;
                lavaOcean1.Vegetables4 = lavaProto.Vegetables4;
                lavaOcean1.Vegetables5 = lavaProto.Vegetables5;
                lavaOcean1.RareSettings = lavaProto.RareSettings;
                lavaOcean1.RareVeins = lavaProto.RareVeins;
                lavaOcean1.Temperature = lavaProto.Temperature * 1.2f;
                lavaOcean1.terrainMat = lavaProto.terrainMat;
                lavaOcean1.thumbMat = lavaProto.thumbMat;
                lavaOcean1.WaterItemId = lavaProto.WaterItemId;
                lavaOcean1.ambientDesc = lavaProto.ambientDesc;
                lavaOcean1.ambientSfx = lavaProto.ambientSfx;
                //lavaOcean1.atmosMat = lavaProto.atmosMat;  // Ocean atmos mat looks nicer
                lavaOcean1.Musics = lavaProto.Musics;
                lavaOcean1.SFXPath = lavaProto.SFXPath;
                lavaOcean1.SFXVolume = lavaProto.SFXVolume;
                lavaOcean1.VeinOpacity = lavaProto.VeinOpacity;
                lavaOcean1.VeinCount = lavaProto.VeinCount;
                lavaOcean1.Wind = (float)Math.Round(lavaProto.Wind * 0.8d);
                //themes.AddProto(lavaOcean1);

                //lavaOcean1.ID = 1;
                //lavaOcean1.Distribute = EThemeDistribute.Birth;
                //themes.dataArray[0] = lavaOcean1;
                #endregion

                #region AridWorld

                #endregion
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