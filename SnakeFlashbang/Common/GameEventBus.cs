using System;
using EmotesAPI;
using GameNetcodeStuff;
using LcEmotes2AndKnucklesFeaturingDante.Utils;
using MonoMod.RuntimeDetour;
using Unity.Netcode;
using UnityEngine;

namespace LcEmotes2AndKnucklesFeaturingDante.Common;

internal static class GameEventBus
{
    public static void InitHooks()
    {
        snakeAttachHook = HookUtils.NewHook<FlowerSnakeEnemy>("SetClingToPlayer",
            typeof(GameEventBus), nameof(SetClingToPlayer), false);
    }

    private static Hook? snakeAttachHook;


    public static event Action? OnRadiationWarningHUD;
    private static void SetClingToPlayer(Action<FlowerSnakeEnemy, PlayerControllerB, int, float> orig, FlowerSnakeEnemy self, PlayerControllerB playerToCling, int setClingPosition, float clingTime)
    {
        orig(self, playerToCling, setClingPosition, clingTime);
        CustomEmotesAPI.PlayAnimation("com.weliveinasociety.badasscompany__Float", BoneMapper.playersToMappers[self.gameObject]);
    }
}