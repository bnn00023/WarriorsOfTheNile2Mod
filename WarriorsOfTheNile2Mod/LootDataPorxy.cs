using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClassLibrary1
{
    public static class LootDataPorxy
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(LootData), nameof(LootData.FromConfig))]
        public static bool LootData_FromConfig_Prefix(LootData __instance, LootSheetData data)
        {
            Debug.Log("LootData_FromConfig_Prefix 執行中");
            data.Silvercoinlootrange = new[] { 1000, 1000 };
            data.Pharaohcoinlootrange = new[] { 10, 10 };
            return true;
        }
    }
}
