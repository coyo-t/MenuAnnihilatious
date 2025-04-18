using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace MenuAnnihilatious.Patches;

using ScatUtil = Scatterer.Utils;

[KSPAddon(KSPAddon.Startup.Instantly, true)]
public class ScattererPatches
{
	public ScattererPatches()
	{
		new Harmony("com.catsofwar.scatterer_nullifier").PatchAll();
	}
	

	[HarmonyPatch(typeof(ScatUtil), "GetMainMenuObject")]
	private class MenuPatch
	{
		static bool Prefix(ref GameObject? __result, CelestialBody celestialBody)
		{
			Debugzor.Show($"No scatterer main menu for ${celestialBody} >:]");
			__result = null;
			return false;
		}
	}


	[HarmonyPatch(typeof(Scatterer.Scatterer), "LoadSettings")]
	private class ConfigHackRemover
	{
		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			var outs = new List<CodeInstruction>();
			foreach (var instr in instructions.ToList())
			{
				outs.Add(instr);
				if (instr.opcode != OpCodes.Bne_Un_S)
				{
					continue;
				}
				// remove pops. lazy.
				var i = outs.Count - 1;
				outs[i - 1].opcode = OpCodes.Nop;
				outs[i - 2].opcode = OpCodes.Nop;
				instr.opcode = OpCodes.Ret;
				instr.operand = null;
				break;
			}
			return outs.AsEnumerable();
		}
	}
}