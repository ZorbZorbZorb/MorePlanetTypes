using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BepInEx;
using Unity;
using UnityEngine;
using HarmonyLib;

namespace MorePlanetTypes.Helpers {
    public static class ResourceHelpers {
        /// <summary>
        /// <para>
        ///     Adds the given proto to the proto set.
        /// </para>
        /// <para>
        ///     No checkup is performed to see if this proto shares an ID with another proto in the set.
        /// </para>
        /// </summary>
        /// <typeparam name="T">Proto type. IE: ThemeProto, VegeProto, ItemProto...</typeparam>
        /// <param name="protoSet"></param>
        /// <param name="item"></param>
        /// <param name="allowOverwriting"></param>
        /// <returns></returns>
        public static ProtoSet<T> AddProto<T>(this ProtoSet<T> protoSet, T item) where T:Proto {
            // Add the new item to the proto set
            int newIndex = protoSet.dataArray.Length;
            Array.Resize(ref protoSet.dataArray, newIndex + 1);
            protoSet.dataArray[newIndex] = item;
            protoSet.dataIndices.Add(item.ID, newIndex);
            return protoSet;
        }
    }
}
