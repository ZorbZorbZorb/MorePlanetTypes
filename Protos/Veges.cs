using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xiaoye97;
using Unity;
using UnityEngine;
using MorePlanetTypes.Extensions;

namespace MorePlanetTypes.NewContent {
    public static class Veges {

        public static readonly Dictionary<string, int> newVegeIdLookup = new Dictionary<string, int>() {
            { "RedForestGrass1", 4001 }
        };

        public static VegeProto GetSequoia1(VegeProtoSet veges, int newId) {
            VegeProto sequoia = veges.Select(46);
            sequoia.ID = newId;
            //Debug.LogError(string.Join(",", sequoia?.MiningChance?.Select(x => x.ToString())?.ToArray()));
            //Debug.LogError(string.Join(",", sequoia?.MiningCount?.Select(x => x.ToString())?.ToArray()));
            //Debug.LogError(string.Join(",", sequoia?.MiningItem?.Select(x => x.ToString())?.ToArray()));
            //sequoia.MiningCount[0] = 55;
            return sequoia;
        }

        //public static VegeProto GetRedForestGrass1(VegeProtoSet veges, bool postAdd = false) {
        //    int newId = newVegeIdLookup["RedForestGrass1"];

        //    VegeProto vege;

        //    if (!postAdd) {
        //        vege = veges.Select(1001).Copy();

        //        Debug.LogError(vege.ModelIndex);
        //        vege.ModelIndex = Patches.PatchResources.testModelId;

        //        vege.ID = newId;
        //    }
        //    else {
        //        vege = veges.Select(newId);
        //        // Working
        //        //Debug.LogError(vege.prefabDesc.materials[0].GetColor("_Tint"));
        //        //Debug.LogError(vege.prefabDesc.materials[0].GetColor("_Tint1"));
        //        vege.prefabDesc.materials[0].SetColor("_Tint", new Color() {
        //            a = 1.00f,
        //            r = 1.00f,
        //            g = 0.20f,
        //            b = 0.80f,
        //        });
        //        vege.prefabDesc.materials[0].SetColor("_Tint1", new Color() {
        //            a = 1.00f,
        //            r = 1.00f,
        //            g = 0.20f,
        //            b = 0.80f,
        //        });
        //        //Debug.LogError(vege.prefabDesc.materials[0].GetColor("_Tint"));
        //        //Debug.LogError(vege.prefabDesc.materials[0].GetColor("_Tint1"));
        //    }
        //    return vege;
        //}
    }
}

