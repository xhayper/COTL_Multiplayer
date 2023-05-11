using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using COTL_Multiplayer.Helper;
using COTL_Multiplayer.Wrapper;
using HarmonyLib;
using UnityEngine;

namespace COTL_Multiplayer;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
// [BepInProcess("Cult Of The Lamb.exe")] // To be decided
[HarmonyPatch]
public class Plugin : BaseUnityPlugin
{
    private readonly Harmony _harmony = new(MyPluginInfo.PLUGIN_GUID);

    internal static Plugin? Instance { get; private set; }

    internal new ManualLogSource Logger { get; private set; } = new(MyPluginInfo.PLUGIN_NAME);

    internal string PluginPath { get; private set; } = "";

    internal GameObject NetworkManager { get; private set; }

    private void Awake()
    {
        Instance = this;
        Logger = base.Logger;

        PluginPath = Path.GetDirectoryName(Info.Location) ?? string.Empty;
        NetworkManager = NetworkManagerHelper.CreateNetworkManager();

        Logger.LogInfo($"{MyPluginInfo.PLUGIN_NAME} loaded!");
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Y))
        {
            var playerPrefab = PlayerHelper.CreatePlayer();

            var wrapper = new PlayerPrefabWrapper(playerPrefab);
        }
    }

    private void OnEnable()
    {
        _harmony.PatchAll(Assembly.GetExecutingAssembly());
        Logger.LogInfo($"{_harmony.GetPatchedMethods().Count()} harmony patches applied!");
    }

    private void OnDisable()
    {
        _harmony.UnpatchSelf();
        Logger.LogInfo($"{MyPluginInfo.PLUGIN_NAME} unloaded!");
    }
}