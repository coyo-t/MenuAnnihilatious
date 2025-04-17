
namespace MenuAnnihilatious;

using UnityEngine;
using UnityEngine.SceneManagement;

[KSPAddon(KSPAddon.Startup.MainMenu, false)]
public class Unfuckitizer : MonoBehaviour
{
	private bool triggered = false;
	
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
			triggered = true;
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