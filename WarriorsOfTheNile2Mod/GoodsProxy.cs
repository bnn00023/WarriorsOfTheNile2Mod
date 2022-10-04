using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClassLibrary1
{
    public static class GoodsProxy
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(Goods), "getIDRareType")]
        public static void Goods_getIDRareType_Postfix(Goods __instance, ref CardRareType __result)
        {
            Debug.Log("Goods_getIDRareType_Postfix 執行中");
            if (__instance.GoodsType == GoodsType.EquipPlugin)
            {
                __result = CardRareType.Epic;
            }
        }
    }
}
