using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xiaoye97;

namespace MorePlanetTypes.Protos {
    public static class Themes {
        public static void Add() {
            ThemeProto birthProto = LDB.themes.Select(1);
            ThemeProto jungleProto = LDB.themes.Select(8);
            ThemeProto mushroomProto = LDB.themes.Select(14);
            ThemeProto prarieProto = LDB.themes.Select(15);
            ThemeProto oceanProto = LDB.themes.Select(16);

            ThemeProto newTheme = prarieProto.Copy();
            newTheme.ID = 30;
            newTheme.DisplayName = "TestTheme2";
            newTheme.Name = "TestTheme";

            newTheme.Vegetables0 = jungleProto.Vegetables0;
            newTheme.Vegetables1 = jungleProto.Vegetables1;
            //newTheme.Vegetables2 = mushroomProto.Vegetables2;
            newTheme.Vegetables3 = mushroomProto.Vegetables3;
            newTheme.Vegetables4 = jungleProto.Vegetables1;
            newTheme.Vegetables5 = jungleProto.Vegetables0;

            newTheme.Vegetables0 = new int[] { 250 };
            newTheme.Vegetables1 = new int[] { 250 };
            newTheme.Vegetables2 = new int[] { 250 };
            //newTheme.Vegetables3 = new int[0];
            //newTheme.Vegetables4 = new int[0];
            //newTheme.Vegetables5 = new int[0];

            //newTheme.Algos = birthProto.Algos;

            newTheme.terrainMat = jungleProto.terrainMat;

            LDBTool.PostAddProto(ProtoType.Theme, newTheme);
        }
    }
}

