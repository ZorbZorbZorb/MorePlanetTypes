using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using xiaoye97;
using MorePlanetTypes.Extensions;

namespace MorePlanetTypes.NewContent {
    public static class Themes {
        /* Vanilla Game Themes:
         * 
         *  1: Birth
         *  2: 
         *  3: Gas giant
         *  4: 
         *  5: Ice giant
         *  6: Arid Desert
         *  7: 
         *  8:
         *  9: Lava
         * 10: 
         * 11: Barren Desert
         * 12: Gobi
         * 13: Volcanic Ash
         * 14: Red Stone
         * 15: Prarie
         * 16: Ocean
        */

        // Theme lookup in one centralized place to prevent id related accidents
        public static readonly Dictionary<string, int> newThemeIdLookup = new Dictionary<string, int>() {
            { "Molten", 20 },
            { "Sulfur", 21 },
            { "Cliffs", 22 },
            { "GiantForestBirth", 30 },
            { "GiantForest", 40 },
            { "RedForest", 41 },
        };

        // Debugging functions
        public static void DebugForceSpawnTo(ThemeProtoSet themes, int id) {
            // Instruct all other birth themes of the irrefutable fact that they can now fuck off
            themes.dataArray.Where(x => x.Distribute == EThemeDistribute.Birth).ToList().ForEach(x => x.Distribute = EThemeDistribute.Interstellar);
            // Promote selected theme to birth theme
            themes.Select(id).Distribute = EThemeDistribute.Birth;
        }

        // Themes
        public static ThemeProto GetForest1(ThemeProtoSet themes, bool postAdd = false) {
            int newId = newThemeIdLookup["GiantForest"];

            ThemeProto birthProto = themes.dataArray[0].Copy();
            ThemeProto jungleProto = themes.dataArray[7].Copy();
            ThemeProto lavaProto = themes.dataArray[8].Copy();
            ThemeProto mushroomProto = themes.dataArray[13].Copy();
            ThemeProto prarieProto = themes.dataArray[14].Copy();
            ThemeProto oceanProto = themes.dataArray[15].Copy();

            ThemeProto forest1;
            if (!postAdd) {
                forest1 = prarieProto.Copy();
                forest1.ID = newId;
                forest1.DisplayName = "Gigantic Forest";
                forest1.Name = "MorePlanetTypes-Forest-1-Interstellar";
                forest1.Vegetables0 = new int[] { }; // Unused
                forest1.Vegetables1 = new int[] { 42, 42, 42, 46, 101, 101, 101, 101, 101, 101, 102, 102, 102, 102, 102, 102, 103, 103, 103, 103, 103, 103, 104, 104, 104, 104, 104, 104, 125, 125, 125, 125, 125, 125, 601, 601, 601, 601, 601, 601, 602, 602, 602, 602, 602, 602, 603, 603, 603, 603, 603, 603, 604, 604, 604, 604, 604, 604, 605, 605, 605, 605, 605, 605 }; // Medium density, Biome border only
                forest1.Vegetables2 = new int[] { 1001, 1002, 1003, 1005, 1006, 1007 }; // Dense clumped ground scatter, everywhere
                forest1.Vegetables3 = new int[] { 43, 46, 47, 47, 101, 102, 103, 104, 106, 601, 602, 604 }; // Sparse, lowland only
                forest1.Vegetables4 = new int[] { }; // Unused
                forest1.Vegetables5 = new int[] { 42, 42, 42, 42, 42, 42, 42, 42, 42, 42, 42, 43, 43, 43, 43, 43, 43, 46, 46, 47, 47, 47, 47, 47, 47, 47, 102, 103, 103, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 125, 125, 125, 125, 125, 125, 125, 604, 604, 604, 604, 604, 604, 604, 605, 605, 605, 605, 605, 605, 605, 1001, 1001, 1001, 1001, 1001, 1001, 1001, 1002, 1002, 1002, 1002, 1002, 1002, 1002, 1002, 1002 }; // Dense, Highland only
                forest1.MaterialPath = jungleProto.MaterialPath;
                forest1.Distribute = EThemeDistribute.Interstellar;
            }
            else {
                forest1 = themes.Select(newId);
                forest1.lowMat = jungleProto.lowMat;
                forest1.terrainMat = jungleProto.terrainMat;
                forest1.oceanMat = birthProto.oceanMat;
            }

            return forest1;
        }
        public static ThemeProto GetForest1Birth(ThemeProtoSet themes, bool postAdd = false) {
            // Create a copy that can be used as a birth planet
            int newId = newThemeIdLookup["GiantForestBirth"];

            ThemeProto birthProto = themes.dataArray[0].Copy();

            ThemeProto forest1Birth;
            if (!postAdd) {
                forest1Birth = themes.Select(newThemeIdLookup["GiantForest"]).Copy();

                forest1Birth.ID = newId;
                forest1Birth.Name = "MorePlanetTypes-Forest-1-Birth";
                forest1Birth.RareSettings = birthProto.RareSettings;
                forest1Birth.RareVeins = birthProto.RareVeins;
                forest1Birth.VeinCount = birthProto.VeinCount;
                forest1Birth.VeinOpacity = birthProto.VeinOpacity;
                forest1Birth.Distribute = EThemeDistribute.Birth;
            }
            else {
                forest1Birth = themes.Select(newId);
            }

            return forest1Birth;
        }
        public static ThemeProto GetMolten(ThemeProtoSet themes, bool postAdd = false) {
            int newId = newThemeIdLookup["Molten"];

            ThemeProto jungleProto = themes.dataArray[7].Copy();
            ThemeProto lavaProto = themes.dataArray[8].Copy();
            ThemeProto oceanProto = themes.dataArray[15].Copy();

            ThemeProto molten;
            if (!postAdd) {
                molten = lavaProto.Copy();
                molten.ID = newId;
                molten.DisplayName = "Molten World";
                molten.IonHeight = jungleProto.IonHeight;
                molten.Algos = jungleProto.Algos;
                molten.ModX = jungleProto.ModX;
                molten.ModY = jungleProto.ModY;
                molten.Temperature = lavaProto.Temperature * 1.2f;
            }
            else {
                molten = themes.Select(newId);
                molten.VeinOpacity = molten.VeinOpacity.Select(x => (float)Math.Round(x * 1.3f, 1)).ToArray();
            }
            
            return molten;
        }
        public static ThemeProto GetCliffs(ThemeProtoSet themes, bool postAdd = false) {
            int newId = newThemeIdLookup["Cliffs"];

            ThemeProto birthProto = themes.dataArray[0].Copy();
            ThemeProto jungleProto = themes.dataArray[7].Copy();
            ThemeProto lavaProto = themes.dataArray[8].Copy();
            ThemeProto gobiProto = themes.dataArray[11].Copy();  // May not be gobi proto
            ThemeProto mushroomProto = themes.dataArray[13].Copy();
            ThemeProto prarieProto = themes.dataArray[14].Copy();
            ThemeProto oceanProto = themes.dataArray[15].Copy();

            ThemeProto cliffs;

            if (!postAdd) {
                cliffs = gobiProto.Copy();
                cliffs.ID = newId;
            }
            else {

            }

            throw new NotImplementedException();
        }
        public static ThemeProto GetRedForest(ThemeProtoSet themes, bool postAdd = false) {
            int newId = newThemeIdLookup["RedForest"];

            ThemeProto jungleProto = themes.dataArray[7].Copy();
            ThemeProto mushroomProto = themes.dataArray[13].Copy();

            ThemeProto redForest = null;

            if (!postAdd) {
                redForest = jungleProto.Copy();

                redForest.ID = newId;
                redForest.DisplayName = "Red Forest";
                redForest.Name = "MorePlanetTypes-Forest-2-Interstellar";

                redForest.MaterialPath = jungleProto.MaterialPath;
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

            }
            else {
                redForest = themes.Select(newId);

                redForest.terrainMat = redForest.terrainMat.CreateCopy();
                redForest.terrainMat.color = new Color() {
                    a = 1.00f,
                    r = 1.10f,
                    g = 0.60f,
                    b = 1.05f,
                };
            }

            return redForest;
        }
        public static ThemeProto GetSulfur(ThemeProtoSet themes, bool postAdd = false) {
            int newId = newThemeIdLookup["Sulfur"];

            ThemeProto jungleProto = themes.dataArray[7].Copy();
            ThemeProto lavaProto = themes.dataArray[8].Copy();
            ThemeProto oceanProto = themes.dataArray[15].Copy();
            ThemeProto barrenProto = themes.Select(11).Copy();
            ThemeProto ashProto = themes.Select(13).Copy();
            ThemeProto gobiProto = themes.Select(12).Copy();
            ThemeProto mushroomProto = themes.Select(13).Copy();

            ThemeProto sulfur;

            if (!postAdd) {
                sulfur = ashProto.Copy();

                sulfur.ID = newId;
                sulfur.DisplayName = "Sulphurous Sea";
                sulfur.displayName = "Sulphurous Sea";
                sulfur.name = "Sulphurous Sea";
                sulfur.Name = "Sulphurous Sea";
                sulfur.Algos = new int[] { 21 };
                sulfur.ModX = jungleProto.ModX;
                sulfur.ModY = jungleProto.ModY;
                sulfur.VeinOpacity = sulfur.VeinOpacity.Select(x => (float)Math.Round(x * 1.2f, 1)).ToArray();
                sulfur.Distribute = EThemeDistribute.Rare;

                sulfur.Vegetables0 = new int[] {  };  // lowlands
                sulfur.Vegetables1 = new int[] {  };  // Ground scatter, highlands
                sulfur.Vegetables2 = new int[] {  };  // Grass ground scatter, highlands
                sulfur.Vegetables3 = new int[] { 601, 602, 603, 604, 605 };  // Ground
                sulfur.Vegetables4 = new int[] { 601, 602, 603, 604, 605 };  // Semi clumped shoreline
                sulfur.Vegetables5 = new int[] {  };  // Water
            }
            else {
                sulfur = themes.Select(newId);

                sulfur.terrainMat = UnityEngine.Object.Instantiate(gobiProto.terrainMat);
                sulfur.oceanMat = UnityEngine.Object.Instantiate(ashProto.oceanMat);
                //sulfur.atmosMat = UnityEngine.Object.Instantiate(ashProto.atmosMat);
                //sulfur.atmosMat.SetColor("_Tint", new Color() {
                //    a = 0.80f,
                //    r = 0.10f,
                //    g = 1.00f,
                //    b = 1.00f
                //});
                //sulfur.atmosMat.SetColor("_Tint1", new Color() {
                //    a = 0.80f,
                //    r = 0.10f,
                //    g = 1.00f,
                //    b = 1.00f
                //});
                sulfur.terrainMat.color = new Color() {
                    a = 1.00f,
                    r = 0.80f,
                    g = 0.70f,
                    b = 0.60f
                };
                sulfur.thumbMat = gobiProto.thumbMat;
                sulfur.minimapMat = gobiProto.minimapMat;
                // Vein count is number of veins per vein cluster
                // Vein opacity is amount in each vein
                // Vein spot is the number of vein clusters on a planet
                //sulfur.VeinCount = sulfur.VeinCount.Select(x => x * 0.5f).ToArray();
                //sulfur.VeinOpacity = sulfur.VeinOpacity.Select(x => x * 0.8f).ToArray();
                sulfur.VeinSpot = sulfur.VeinSpot.Select(x => (int)(x * 0.5)).ToArray();
            }

            return sulfur;
        }

        // Experimental code to make adding new content simplier

        //public static List<NewTheme> themesToAdd = new List<NewTheme>();

        //public abstract class NewTheme<T> : Interfaces.INewContent where T:ThemeProto {
        //    public abstract string GetDisplayName();
        //    public int GetId() {
        //        return newThemeIdLookup[GetInternalName()];
        //    }
        //    public ThemeProto proto;
        //    public abstract string GetInternalName();
        //    public abstract T PostAddDataAction<T>(ProtoSet<T> protoSet) where T : ThemeProto;
        //    public abstract T PreAddDataAction<T>(ProtoSet<T> protoSet) where T : ThemeProto;
        //}

        //public class Sulfur : NewTheme<ThemeProto> {
        //    public override string GetDisplayName() {
        //        return "Sulfurous Sea";
        //    }
        //    public override string GetInternalName() {
        //        return "Sulfur";
        //    }
        //    public override T PreAddDataAction<T>(ProtoSet<T> protoSet) {
        //        ThemeProtoSet themes = protoSet as ThemeProtoSet;
        //        ThemeProto jungleProto = themes.dataArray[7].Copy();
        //        ThemeProto lavaProto = themes.dataArray[8].Copy();
        //        ThemeProto oceanProto = themes.dataArray[15].Copy();
        //        ThemeProto barrenProto = themes.Select(11).Copy();
        //        ThemeProto ashProto = themes.Select(13).Copy();
        //        ThemeProto gobiProto = themes.Select(12).Copy();
        //        ThemeProto mushroomProto = themes.Select(13).Copy();
        //        proto = ashProto.Copy();
        //        proto.ID = GetId();
        //        proto.DisplayName = "Sulphurous Sea";
        //        proto.displayName = "Sulphurous Sea";
        //        proto.name = "Sulphurous Sea";
        //        proto.Name = "Sulphurous Sea";
        //        proto.Algos = new int[] { 21 };
        //        proto.ModX = jungleProto.ModX;
        //        proto.ModY = jungleProto.ModY;
        //        proto.VeinOpacity = proto.VeinOpacity.Select(x => (float)Math.Round(x * 1.2f, 1)).ToArray();
        //        proto.Vegetables0 = new int[] { 601, 602, 603, 604, 605 };  // lowlands
        //        proto.Vegetables1 = new int[] { };  // Ground scatter, highlands
        //        proto.Vegetables2 = new int[] { };  // Grass ground scatter, highlands
        //        proto.Vegetables3 = new int[] { };  // Ground
        //        proto.Vegetables4 = new int[] { };  // Semi clumped shoreline
        //        proto.Vegetables5 = new int[] { };  // Water
        //        return proto;
        //    }

        //    public override T PostAddDataAction<T>(ProtoSet<T> protoSet) {
        //        throw new NotImplementedException();
        //    }

        //}
    }
}

