using System;
using System.Reflection;
using BepInEx;
using ClassLibrary1;
using HarmonyLib;
using UnityEngine;
namespace MyFirstBepInExMod
{
    [BepInPlugin("aoe.top.plugins.MyFirstBepInExMod", "这是我的第一个BepIn插件", "1.0.0.0")]
    public class Main : BaseUnityPlugin
    {
        // 在插件启动时会直接调用Awake()方法
        void Awake()
        {
            // 使用Debug.Log()方法来将文本输出到控制台
            Debug.Log("Hello, world!");
        }
        // 在所有插件全部启动完成后会调用Start()方法，执行顺序在Awake()后面；
        void Start()
        {
            Debug.Log($"这里是Start()方法中的内容!");
            var harmony = Harmony.CreateAndPatchAll(typeof(BaseRoomInfoProxy));
            harmony.PatchAll(typeof(LootDataPorxy));
            harmony.PatchAll(typeof(GoodsProxy));
            foreach (var method in harmony.GetPatchedMethods())
            {
                Debug.Log($"{method.Name} was patch.");
            }
        }
        // 插件启动后会一直循环执行Update()方法，可用于监听事件或判断键盘按键，执行顺序在Start()后面
        void Update()
        {
            var key = new BepInEx.Configuration.KeyboardShortcut(KeyCode.F9);
            if (key.IsDown())
            {
                Debug.Log("这里是Updatet()方法中的内容，你看到这条消息是因为你按下了F9");
                SaveDataManager.GetPlayerSaveData().SetGameConditionValue(ConditionValueType.CurrentAdventureCanSelectTwoCardReward);
                SaveDataManager.GetPlayerSaveData().SetGameConditionValue(ConditionValueType.CurrentAdventureNoNormalCardLootReward);
                SaveDataManager.GetPlayerSaveData().SetGameConditionValue(ConditionValueType.CurrentAdventureNoNormalEquipLootReward);
                SaveDataManager.GetPlayerSaveData().SetGameConditionValue(ConditionValueType.CurrentAdventureRareOrAboveWeaponMustHaveSlot);
            }
        }
        // 在插件关闭时会调用OnDestroy()方法
        void OnDestroy()
        {
            Debug.Log("当你看到这条消息时，就表示我已经被关闭一次了!");
        }
    }
}