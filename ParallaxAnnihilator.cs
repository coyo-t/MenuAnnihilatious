using Parallax.Scaled_System;
using HarmonyLib;
using UnityEngine;

namespace MenuAnnihilatious;


[KSPAddon(KSPAddon.Startup.Instantly, true)]
public class ParallaxAnnihilator
{
	public ParallaxAnnihilator()
	{
		var harmony = new Harmony("com.catsofwar.parallax_nullifier");
		harmony.PatchAll();
		Debugzor.Show("Nullified >:]");
	}
}

[HarmonyPatch(typeof(SkyboxControlMainMenu), "Start")]
class MMA
{
	static bool Prefix(SkyboxControlMainMenu __instance)
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