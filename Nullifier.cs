using Atmosphere;
using HarmonyLib;
using UnityEngine;

namespace MenuAnnihilatious;

[KSPAddon(KSPAddon.Startup.Instantly, true)]
public class Nullifier : MonoBehaviour
{
	public Nullifier()
	{
		var harmony = new Harmony("com.catsofwar.anticlouds");
		harmony.PatchAll();
		Debugzor.Show("Menu Clouds Nullified");
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
