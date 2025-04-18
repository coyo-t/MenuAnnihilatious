

using UnityEngine;

public static class Debugzor
{
	public static bool doShowDebugMessages = true;
	
	private static void SDM(String what)
	{
		Debug.Log($"COYOTE - {what}");
	}

	public static void Show(object what)
	{
		if (doShowDebugMessages)
		{
			SDM(what.ToString());
		}
	}

	public static void Show(string what)
	{
		if (doShowDebugMessages)
		{
			SDM(what);
		}
	}
}
