using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	public void Load(string SceneName)
	{
		SceneManager.LoadScene(SceneName);
	}

	public void Ext()
	{
		Application.Quit();
	}
}
