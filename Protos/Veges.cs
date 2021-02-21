using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xiaoye97;
using Unity;
using UnityEngine;

namespace MorePlanetTypes.Protos {
    public static class Veges {
        public static void Add() {
            VegeProto vege126 = LDB.veges.Select(126);
            Debug.LogWarning("");
            VegeProto newVege = vege126.Copy();
            newVege.ID = 250;
            newVege.name = "TestVege";
            LDBTool.PreAddProto(ProtoType.Vege, newVege);
        }
    }
}

