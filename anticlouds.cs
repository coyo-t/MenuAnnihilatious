using Atmosphere;
using EVEManager;
using HarmonyLib;
using UnityEngine;

namespace MenuAnnihilatious;

[KSPAddon(KSPAddon.Startup.Instantly, true)]
public class EVECloudsNullifier : MonoBehaviour
{
	public EVECloudsNullifier ()
	{
		var harmony = new Harmony("com.catsofwar.eve_clouds_nullifier");
		harmony.PatchAll();
		Debugzor.Show("Nullified >:]");
	}
}


[HarmonyPatch(typeof(GlobalEVEManager), "Update")]
class ShSet
{
	static bool Prefix(DynamicShadowSettings __instance)
	{
		return HighLogic.LoadedScene != GameScenes.MAINMENU;
	}
	
}

[HarmonyPatch(typeof(CloudsPQS), "ApplyToMainMenu")]
class CloudsPQSPatch
{
	static bool Prefix(CloudsPQS __instance)
	{
		Debugzor.Show($"No More Clouds (${__instance}) >:]");
		return false;
	}
}
