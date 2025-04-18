namespace MenuAnnihilatious.Patches;

using Atmosphere;
using EVEManager;
using HarmonyLib;
using UnityEngine;

[KSPAddon(KSPAddon.Startup.Instantly, true)]
public class EVEPatches : MonoBehaviour
{
	public EVEPatches ()
	{
		new Harmony("com.catsofwar.eveinatorz").PatchAll();
	}
	
	[HarmonyPatch(typeof(GlobalEVEManager), "Update")]
	private class Global
	{
		// static bool Prefix(GlobalEVEManager __instance)
		static bool Prefix ()
		{
			return HighLogic.LoadedScene != GameScenes.MAINMENU;
		}
	}

	[HarmonyPatch(typeof(CloudsPQS), "ApplyToMainMenu")]
	private class Cloudz
	{
		static bool Prefix(CloudsPQS __instance)
		{
			Debugzor.Show($"No More Clouds (${__instance}) >:]");
			return false;
		}
	}
}
