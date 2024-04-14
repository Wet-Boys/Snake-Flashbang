using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Logging;
using GameNetcodeStuff;
using LcEmotes2AndKnucklesFeaturingDante.Common;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using Unity.Netcode;
using UnityEngine;

namespace LcEmotes2AndKnucklesFeaturingDante;

[BepInDependency("com.weliveinasociety.badasscompany")]
[BepInPlugin(ModGuid, ModName, ModVersion)]
public class SnakeFlashbang : BaseUnityPlugin
{
    public const string ModGuid = "com.gemumoddo.snake_flashbang";
    public const string ModName = "Snake Flashbang";
    public const string ModVersion = "1.0.0";
    public static PluginInfo? PluginInfo { get; private set; }
    public new static ManualLogSource? Logger { get; private set; }


    private void Awake()
    {
        PluginInfo = Info;
        Logger = base.Logger;
        Assets.LoadAllAssetBundles();
        
        GameEventBus.InitHooks();


        var types = Assembly.GetExecutingAssembly().GetTypes();
        foreach (var type in types)
        {
            try
            {
                var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (var method in methods)
                {
                    var attributes = method.GetCustomAttributes(typeof(RuntimeInitializeOnLoadMethodAttribute), false);
                    if (attributes.Length > 0)
                    {
                        method.Invoke(null, null);
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}