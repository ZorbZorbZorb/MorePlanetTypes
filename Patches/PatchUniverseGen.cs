using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BepInEx;
using HarmonyLib;
using Unity;
using UnityEngine;

namespace MorePlanetTypes.Patches {
    [HarmonyPatch(typeof(UniverseGen))]
    public static class PatchUniverseGen {
        [HarmonyPostfix]
        [HarmonyPatch("CreateGalaxy")]
        static void CreateGalaxy(ref GameDesc gameDesc, ref GalaxyData __result) {
            if ( __result.birthStarId == 0 ) {
                __result.birthStarId = 1;
                Debug.LogWarning($"alternatestart -- WARNING: Reassigned birth star id to {__result.birthStarId}");
            }
            // Repair bad birth planet
            if ( __result.birthPlanetId == 0 ) {
                StarData birthStar = __result.StarById(__result.birthStarId);
                for ( int i = 0; i < birthStar.planets.Length; i++ ) {
                    // Pick the first or only ocean planet
                    if ( birthStar.planets[i].type == EPlanetType.Ocean ) {
                        __result.birthPlanetId = birthStar.planets[i].id;
                        Debug.LogWarning($"alternatestart -- WARNING: Reassigned birth planet id to {__result.birthPlanetId}");
                    }
                }
                if ( __result.birthPlanetId == 0 ) {
                    // Panic and choose any valid planet
                    int? newBirthPlanet = birthStar.planets.FirstOrDefault(x => x.type != EPlanetType.Gas).id;
                    if ( newBirthPlanet == null ) {
                        throw new Exception("Alternatestart: No birth planet or candidates for birth planet found.");
                    }
                    __result.birthPlanetId = (int)newBirthPlanet;
                    Debug.LogError($"alternatestart -- DANGER: Reassigned birth planet id to non-ocean planet {__result.birthPlanetId}");
                }
            }
        }
    }
}
