using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MorePlanetTypes.Extensions {
    public static class MaterialExtensions {
        public static Material CreateCopy(this Material mat) {
            return UnityEngine.Object.Instantiate(mat);
        }
    }
}
