using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
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
            forest1Birth.VeinCount = birthProto.VeinCount;
            forest1Birth.VeinOpacity = birthProto.VeinOpacity;
            forest1Birth.Distribute = EThemeDistribute.Birth;

            return forest1Birth;
        }
        public static ThemeProto GetMolten(ThemeProtoSet themes, int newId) {
            ThemeProto jungleProto = themes.dataArray[7].Copy();
            ThemeProto lavaProto = themes.dataArray[8].Copy();
            ThemeProto oceanProto = themes.dataArray[15].Copy();

            ThemeProto molten = lavaProto.Copy();
            molten.ID = newId;
            molten.DisplayName = "Molten World";
            molten.WaterHeight = jungleProto.WaterHeight * 0.8f;
            molten.IonHeight = jungleProto.IonHeight;
            //molten.Algos = new int[] { 41 };
            molten.atmosMat = oceanProto.atmosMat;
            molten.Algos = jungleProto.Algos;
            molten.ModX = jungleProto.ModX;
            molten.ModY = jungleProto.ModY;
            molten.Temperature = lavaProto.Temperature * 1.1f;
            molten.atmosMat = oceanProto.atmosMat;

            return molten;
        }
        public static ThemeProto GetCliffs(ThemeProtoSet themes, int newId) {
            ThemeProto birthProto = themes.dataArray[0].Copy();
            ThemeProto jungleProto = themes.dataArray[7].Copy();
            ThemeProto lavaProto = themes.dataArray[8].Copy();
            ThemeProto gobiProto = themes.dataArray[11].Copy();  // May not be gobi proto
            ThemeProto mushroomProto = themes.dataArray[13].Copy();
            ThemeProto prarieProto = themes.dataArray[14].Copy();
            ThemeProto oceanProto = themes.dataArray[15].Copy();

            ThemeProto cliffs = gobiProto;
            cliffs.ID = newId;



            throw new NotImplementedException();
        }
        public static ThemeProto GetRedForest(ThemeProtoSet themes, int newId) {
            ThemeProto birthProto = themes.dataArray[0].Copy();
            ThemeProto jungleProto = themes.dataArray[7].Copy();
            ThemeProto lavaProto = themes.dataArray[8].Copy();
            ThemeProto mushroomProto = themes.dataArray[13].Copy();
            ThemeProto prarieProto = themes.dataArray[14].Copy();
            ThemeProto oceanProto = themes.dataArray[15].Copy();

            ThemeProto redForest = jungleProto;

            redForest.ID = newId;
            redForest.DisplayName = "Red Forest";
            redForest.Name = "MorePlanetTypes-Forest-2-Interstellar";

            //redForest.MaterialPath = mushroomProto.MaterialPath;
            redForest.MaterialPath = jungleProto.MaterialPath;
            Debug.LogWarning($"MaterialPath:'{mushroomProto.MaterialPath}'");

            //redForest.Vegetables0 = birthProto.Vegetables0;
            //redForest.Vegetables1 = birthProto.Vegetables1;
            //redForest.Vegetables2 = birthProto.Vegetables2;
            //redForest.Vegetables3 = birthProto.Vegetables3;
            //redForest.Vegetables4 = birthProto.Vegetables4;
            //redForest.Vegetables5 = birthProto.Vegetables5;

            //List<int> newVeges5 = redForest.Vegetables5.ToList();
            //newVeges5.Add(45);
            //redForest.Vegetables5 = newVeges5.ToArray();

            Debug.LogWarning("red forest algos: " + string.Join(",", redForest.Algos.Select(x => x.ToString()).ToArray()));
            redForest.Algos = new int[] { 41 };

            redForest.RareSettings = mushroomProto.RareSettings;
            redForest.RareVeins = mushroomProto.RareVeins;
            redForest.VeinCount = mushroomProto.VeinCount;
            redForest.VeinOpacity = mushroomProto.VeinOpacity;
            redForest.VeinSpot = mushroomProto.VeinSpot;

            redForest.Vegetables0 = new int[] { 26, 26, 45, 603, 604 };  // lowlands
            redForest.Vegetables1 = new int[] { 1001, 1001, 1001, 1001, 1001, 1001, 45, 26, 26 };  // Ground scatter, highlands
            redForest.Vegetables2 = new int[] { 1001 };  // Grass ground scatter, highlands
            redForest.Vegetables3 = new int[] { 26, 26, 26, 26, 45, 602, 603, 604};  // Ground
            redForest.Vegetables4 = new int[] { 1001, 26, 602, 603, 604 };  // Semi clumped shoreline
            redForest.Vegetables5 = new int[] {  25, 32, 36, 37, 39, 41 };  // Water

            Debug.LogWarning(redForest.WaterHeight);  // 0f

            // Atmos mat, terrain mat, minimpa map and thumb mat are all null at loadtime
            //Debug.LogError($"atmos mat is null? {redForest.atmosMat == null}");       // true
            //Debug.LogError($"terrain mat is null? {redForest.terrainMat == null}");   // true
            //Debug.LogError($"minimap mat is null? {redForest.minimapMat == null}");   // true
            //Debug.LogError($"thumb mat is null? {redForest.thumbMat == null}");       // true

            //Color color = new Color();
            //Debug.LogError($"a:{currentColor.a} r:{currentColor.r} g:{currentColor.g} b:{currentColor.b} gamma:{currentColor.gamma}");

            return redForest;
        }
    }
}

