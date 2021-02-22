using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using UnityEngine;
using Unity;
using MorePlanetTypes.Algos;

namespace MorePlanetTypes.Patches {
	[HarmonyPatch(typeof(PlanetModelingManager))]
    public class PatchPlanetModelingManager {
		[HarmonyPrefix]
		[HarmonyPatch("Algorithm")]
		public static bool Algorithm(ref PlanetData planet, ref PlanetAlgorithm __result) {
			PlanetAlgorithm planetAlgorithm;
			switch ( planet.algoId ) {
				case 1:
				planetAlgorithm = new PlanetAlgorithm1();
				break;
				case 2:
				planetAlgorithm = new PlanetAlgorithm2();
				break;
				case 3:
				planetAlgorithm = new PlanetAlgorithm3();
				break;
				case 4:
				planetAlgorithm = new PlanetAlgorithm4();
				break;
				case 5:
				planetAlgorithm = new PlanetAlgorithm5();
				break;
				case 6:
				planetAlgorithm = new PlanetAlgorithm6();
				break;
				case 7:
				planetAlgorithm = new PlanetAlgorithm7();
				break;
				case 41:
				planetAlgorithm = new PlanetAlgorithmRedForest();
				break;
				default:
				planetAlgorithm = new PlanetAlgorithm0();
				break;
			}
			if ( planetAlgorithm != null ) {
				planetAlgorithm.Reset(planet.seed, planet);
			}
			__result = planetAlgorithm;

			return false;
		}
	}
}
