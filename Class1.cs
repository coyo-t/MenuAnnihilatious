using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace MenuAnnihilatious;


[KSPAddon(KSPAddon.Startup.MainMenu, false)]
public class Unfuckitizer : MonoBehaviour
{
	private bool triggered = false;
	private bool doShowDebugMessages = true;


	private static readonly Lazy<Scene> _scene = _createScene("MACHINE WITNESS");
	private static Scene Scene => _scene.Value;
	

	private void LateUpdate()
	{
		// Atmosphere.CloudsPQS.
		if (Input.GetKeyDown(KeyCode.A))
		{
			Debugzor.Show("MACHINE WITNESS EXECUTIONALIZING");
			var kspMenu = SceneManager.GetActiveScene();
			SceneManager.SetActiveScene(Scene);
			SceneManager.UnloadSceneAsync(kspMenu);
		}

		// if (triggered)
		// {
		// 	return;
		// }
		// SearchAndDestroyzor<MainMenuEnvLogic>("Main Menu", it =>
		// {
		// 	foreach (var thingArea in it.areas)
		// 	{
		// 		Debug.Log($"\t{thingArea}");
		// 		DestroyImmediate(thingArea);
		// 	}
		// });
		// SearchAndDestroyzor<Scatterer.Scatterer>("Atmosphere Scattererer");
		// triggered = true;
	}

	private void NO_OPERATION()
	{
	}


	private void RoundEmUpAndKILL<T>(String display, Action<T> destroy)
		where T : Object
	{
		var things = Resources.FindObjectsOfTypeAll<T>();
		foreach (var thing in things)
		{
			if (thing is null)
				continue;
			Debugzor.Show($"TIEM 2 DIEZOR '{display}'!!!!");
			destroy.Invoke(thing);
		}
	}

	private void SearchAndDestroyzor<T>(String displayName, Action<T> beforeDestroy)
		where T : Object
	{
		var scat = FindObjectOfType<T>();
		if (scat is null)
		{
			Debugzor.Show($"No '{displayName}' here!");
		}
		else
		{
			Debugzor.Show($"TIEM 2 DIEZOR '{displayName}'!!!!");
			beforeDestroy.Invoke(scat);
		}
	}

	private void SearchAndDestroyzor<T>(String displayName)
		where T : Object
	{
		SearchAndDestroyzor<T>(displayName, DestroyImmediate);
	}

	private static Lazy<Scene> _createScene(String name) => new(() => SceneManager.CreateScene(name));
	

}