using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClassLibrary1
{
    public static class BaseRoomInfoProxy
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(BaseRoomInfo), nameof(BaseRoomInfo.AddRewardType))]
        public static bool BaseRoomInfo_AddRewardType_Prefix(BaseRoomInfo __instance, RewardType type)
        {
            Debug.Log("Mecha_SetForNewGame_Prefix 執行中");
            if (type == RewardType.SilverCoin || type == RewardType.PharaohCoin || type == RewardType.Card)
            {
                __instance.RewardTypes.Add(type);
            }
            else
            {
                __instance.RewardTypes.Add(type);
                __instance.RewardTypes.Add(type);
                __instance.RewardTypes.Add(type);
            }
            return false;
        }
    }
}
