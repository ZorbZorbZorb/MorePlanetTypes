using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MorePlanetTypes.Algos {
    public class PlanetAlgorithmRedForest : PlanetAlgorithm1 {
		public override void GenerateTerrain(double modX, double modY) {
			// Unknown
			double num = 0.01;      //  0.01	//  0.01?		// ?
			double num2 = 0.012;    //  0.012	//  0.012?		// ?
			double num3 = 0.01;		//  0.01	//  0.01?		// ?
			// Kind of known
			double num5 = -0.8;		// -0.2		// -1.0?		// Amount of water on planet. -0.2 = ~55% land, -2.2 = ~9% land
			double num6 = 1.2;      //  0.9		//  0.9?		// Highlands amount
			double num7 = 0.8;		//  0.5		//	0.5?		// Land amount?
			double num8 = 2.0;		//  2.5		//  3.5?		// Lake size?
			double num9 = 0.5;		//  0.3		//  0.5?		// Land blob number? Land blobiness?
			// Known
			double numLandHeightFactor = 4.0;		//  3.0		//	5.0?		// Water depth and terrain height
			
			System.Random random = new System.Random(this.planet.seed);
			int seed = random.Next();
			int seed2 = random.Next();
			SimplexNoise simplexNoise = new SimplexNoise(seed);
			SimplexNoise simplexNoise2 = new SimplexNoise(seed2);
			PlanetRawData data = this.planet.data;
			for ( int i = 0; i < data.dataLength; i++ ) {
				double num10 = (double)( data.vertices[i].x * this.planet.radius );
				double num11 = (double)( data.vertices[i].y * this.planet.radius );
				double num12 = (double)( data.vertices[i].z * this.planet.radius );
				double num13 = simplexNoise.Noise3DFBM(num10 * num, num11 * num2, num12 * num3, 6, 0.5, 2.0) * numLandHeightFactor + num5;
				double num14 = simplexNoise2.Noise3DFBM(num10 * 0.0025, num11 * 0.0025, num12 * 0.0025, 3, 0.5, 2.0) * numLandHeightFactor * num6 + num7;
				double num15 = ( num14 <= 0.0 ) ? num14 : ( num14 * 0.5 );
				double num16 = num13 + num15;
				double num17 = ( num16 <= 0.0 ) ? ( num16 * 1.6 ) : ( num16 * 0.5 );
				double num18 = ( num17 <= 0.0 ) ? Maths.Levelize2(num17, 0.5, 0.0) : Maths.Levelize3(num17, 0.7, 0.0);
				double num19 = simplexNoise2.Noise3DFBM(num10 * num * 2.5, num11 * num2 * 8.0, num12 * num3 * 2.5, 2, 0.5, 2.0) * 0.6 - 0.3;
				double num20 = num17 * num8 + num19 + num9;
				double num21 = ( num20 >= 1.0 ) ? ( ( num20 - 1.0 ) * 0.8 + 1.0 ) : num20;
				double num22 = num18;
				double num23 = num21;
				data.heightData[i] = (ushort)( ( (double)this.planet.radius + num22 + 0.2 ) * 100.0 );
				data.biomoData[i] = (byte)Mathf.Clamp((float)( num23 * 100.0 ), 0f, 200f);
			}
		}
    }
}
