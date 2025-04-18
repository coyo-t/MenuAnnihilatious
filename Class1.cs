
namespace MenuAnnihilatious;

using UnityEngine;
using UnityEngine.SceneManagement;
using Scatterer;
using EVEManager;

[KSPAddon(KSPAddon.Startup.MainMenu, false)]
public class Unfuckitizer : MonoBehaviour
{
	private bool triggered = false;
	private bool doShowDebugMessages = true;
	
	private void LateUpdate()
	{
		if (!triggered)
		{
			Debug.Log("COYOTE TIME!!!!!!");
			var menuEnv = FindObjectOfType<MainMenuEnvLogic>();
			
			if (menuEnv is not null)
			{
				Debug.Log(menuEnv);
				foreach (var thingArea in menuEnv.areas)
				{
					Debug.LogFormat("\t{0}", thingArea);
					DestroyImmediate(thingArea);
				}
			}
			
			SearchAndDestroyzorSingle<Scatterer>("Atmosphere Scattererer");
			SearchAndDestroyzorSingle<GlobalEVEManager>("Global EVE Manager");
			
			triggered = true;
		}
	}

	private void SearchAndDestroyzorSingle<T>(String displayName)
		where T : Object
	{
		var scat = FindObjectOfType<T>();
		if (scat is null)
		{
			ShowDebugMessage($"No '{displayName}' here!");
		}
		else
		{
			ShowDebugMessage($"TIEM 2 DIEZOR '{displayName}'!!!!");
			DestroyImmediate(scat);
		}
	}
	
	private void SDM(String what)
	{
		Debug.Log($"COYOTE - {what}");
	}

	private void ShowDebugMessage(object what)
	{
		if (doShowDebugMessages)
		{
			SDM(what.ToString());
		}
	}
	
	private void ShowDebugMessage (string what)
	{
		if (doShowDebugMessages)
		{
			SDM(what);
		}
	}

	// private Boolean GetMenu(out GameObject outs)
	// {
	// 	var maybeMenu = GameObject.Find("MainMenu");
	// 	if (maybeMenu == null)
	// 	{
	// 		// This Is Stupid
	// 		outs = dummyGameObject;
	// 		return false;
	// 	}
	// 	
	// 	outs = maybeMenu;
	// 	return true;
	// }
}