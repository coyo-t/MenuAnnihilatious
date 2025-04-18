namespace MenuAnnihilatious.Patches;

using Parallax.Scaled_System;
using HarmonyLib;
using UnityEngine;



[KSPAddon(KSPAddon.Startup.Instantly, true)]
public class ParallaxPatches
{
	public ParallaxPatches()
	{
		new Harmony("com.catsofwar.parallax_nullifier").PatchAll();
	}
	
	[HarmonyPatch(typeof(SkyboxControlMainMenu), "Start")]
	class MMA
	{
		// static bool Prefix(SkyboxControlMainMenu __instance)
		static bool Prefix()
		{
			Debugzor.Show("Die Skybox Handlerz!!!");
			return false;
		}
	}

	[HarmonyPatch(typeof(ScaledMainMenu), "Start")]
	class SclAnn
	{
		static bool Prefix(ScaledMainMenu __instance)
		{
			Debugzor.Show("NO! BAD! NO LAG, PARA||AX! >:[[[[");
			GameObject.DestroyImmediate(__instance);
			return false;
		}
	}
}

