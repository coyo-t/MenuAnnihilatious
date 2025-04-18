
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

using ScatUtil = Scatterer.Utils;

namespace MenuAnnihilatious;

[KSPAddon(KSPAddon.Startup.Instantly, true)]
public class ScattererNullifier : MonoBehaviour
{
	public ScattererNullifier()
	{
		var harmony = new Harmony("com.catsofwar.scatterer_nullifier");
		harmony.PatchAll();
		Debugzor.Show("Nullified >:]");
	}
}

[HarmonyPatch(typeof(ScatUtil), "GetMainMenuObject")]
class MenuPatch
{
	static bool Prefix(ref GameObject? __result, CelestialBody celestialBody)
	{
		Debugzor.Show($"No scatterer main menu for ${celestialBody} >:]");
		__result = null;
		return false;
	}
}

[HarmonyPatch(typeof(Scatterer.Scatterer), "LoadSettings")]
class ConfigHackRemover
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

