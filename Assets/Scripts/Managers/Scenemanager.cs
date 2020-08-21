/// <summary>
/// SceneLoaderClass is a class which has some methods related to scene loading and other options.
/// </summary>
public static class Scenemanager
{
	/// <summary>
	/// This Loads Scene by string input.
	/// </summary>
	/// <param name="sceneName">sceneName is the string input</param>
	public static void Loadscene(string sceneName)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
	}

	/// <summary>
	/// This Loads Scene by int input.
	/// </summary>
	/// <param name="sceneNumber">sceneNumber is the int input</param>
	public static void Loadscene(int sceneNumber)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNumber);
	}

	/// <summary>
	/// This Reload the current Scene by taking bool scene index
	/// </summary>
	/// <param name="loadwithindex">sceneNumber is the int input</param>
	public static void ReloadCurrentScene(bool loadwithindex = true)
	{
		if (loadwithindex)
			Loadscene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
		else
			Loadscene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
	}
}
