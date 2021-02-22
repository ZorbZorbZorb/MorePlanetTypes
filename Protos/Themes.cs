﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xiaoye97;

namespace MorePlanetTypes.Protos {
    public static class Themes {
        public static ThemeProto GetForest1(ThemeProtoSet themes, int newId) {
            ThemeProto birthProto = themes.dataArray[0].Copy();
            ThemeProto jungleProto = themes.dataArray[7].Copy();
            ThemeProto lavaProto = themes.dataArray[8].Copy();
            ThemeProto mushroomProto = themes.dataArray[13].Copy();
            ThemeProto prarieProto = themes.dataArray[14].Copy();
            ThemeProto oceanProto = themes.dataArray[15].Copy();

            ThemeProto forest1 = prarieProto.Copy();
            forest1.ID = newId;
            forest1.DisplayName = "Gigantic Forest";
            forest1.Name = "MorePlanetTypes-Forest-1-Interstellar";
            forest1.Vegetables0 = new int[] { }; // Unused
            forest1.Vegetables1 = new int[] { 42, 42, 42, 46, 101, 101, 101, 101, 101, 101, 102, 102, 102, 102, 102, 102, 103, 103, 103, 103, 103, 103, 104, 104, 104, 104, 104, 104, 125, 125, 125, 125, 125, 125, 601, 601, 601, 601, 601, 601, 602, 602, 602, 602, 602, 602, 603, 603, 603, 603, 603, 603, 604, 604, 604, 604, 604, 604, 605, 605, 605, 605, 605, 605 }; // Medium density, Biome border only
            forest1.Vegetables2 = new int[] { 1001, 1002, 1003, 1005, 1006, 1007 }; // Dense clumped ground scatter, everywhere
            forest1.Vegetables3 = new int[] { 43, 46, 47, 47, 101, 102, 103, 104, 106, 601, 602, 604 }; // Sparse, lowland only
            forest1.Vegetables4 = new int[] { }; // Unused
            forest1.Vegetables5 = new int[] { 42, 42, 42, 42, 42, 42, 42, 42, 42, 42, 42, 43, 43, 43, 43, 43, 43, 46, 46, 47, 47, 47, 47, 47, 47, 47, 102, 103, 103, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 125, 125, 125, 125, 125, 125, 125, 604, 604, 604, 604, 604, 604, 604, 605, 605, 605, 605, 605, 605, 605, 1001, 1001, 1001, 1001, 1001, 1001, 1001, 1002, 1002, 1002, 1002, 1002, 1002, 1002, 1002, 1002 }; // Dense, Highland only
            forest1.lowMat = jungleProto.lowMat;
            forest1.terrainMat = jungleProto.terrainMat;
            forest1.MaterialPath = jungleProto.MaterialPath;
            forest1.oceanMat = birthProto.oceanMat;
            forest1.Distribute = EThemeDistribute.Interstellar;

            return forest1;
        }
        public static ThemeProto GetForest1Birth(ThemeProtoSet themes, int newId, ThemeProto forest1) {
            // Create a copy that can be used as a birth planet
            ThemeProto birthProto = themes.dataArray[0].Copy();

            ThemeProto forest1Birth = forest1.Copy();
            forest1Birth.ID = newId;
            forest1Birth.Name = "MorePlanetTypes-Forest-1-Birth";
            forest1Birth.RareSettings = birthProto.RareSettings;
            forest1Birth.RareVeins = birthProto.RareVeins;
            forest1Birth.Distribute = EThemeDistribute.Birth;

            return forest1Birth;
        }
        public static ThemeProto GetMolten(ThemeProtoSet themes, int newId) {
            // Vein generation is really bugged on this one, at least when used as the birth planet

            ThemeProto jungleProto = themes.dataArray[7].Copy();
            ThemeProto lavaProto = themes.dataArray[8].Copy();
            ThemeProto oceanProto = themes.dataArray[15].Copy();

            ThemeProto molten1 = lavaProto.Copy();
            molten1.ID = newId;
            molten1.DisplayName = "Molten World";
            //molten1.WaterHeight = jungleProto.WaterHeight;
            //molten1.IonHeight = jungleProto.IonHeight;
            //molten1.Algos = jungleProto.Algos;
            //molten1.ModX = jungleProto.ModX;
            //molten1.ModY = jungleProto.ModY;
            molten1.Temperature = lavaProto.Temperature; //* 1.2f;
            molten1.atmosMat = oceanProto.atmosMat;

            return molten1;
        }
        public static ThemeProto GetCliffs(ThemeProtoSet themes, int newId) {
            ThemeProto birthProto = themes.dataArray[0].Copy();
            ThemeProto jungleProto = themes.dataArray[7].Copy();
            ThemeProto lavaProto = themes.dataArray[8].Copy();
            ThemeProto gobiProto = themes.dataArray[11].Copy();
            ThemeProto mushroomProto = themes.dataArray[13].Copy();
            ThemeProto prarieProto = themes.dataArray[14].Copy();
            ThemeProto oceanProto = themes.dataArray[15].Copy();

            ThemeProto cliffs = gobiProto;
            cliffs.ID = newId;
            return null;
        }
    }
}

