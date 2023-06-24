using UnityEngine;

public class CursorVisible : MonoBehaviour
{
	public GameObject Pause;

	public bool VisibleOnStart;

	public AudioSource Music;

	public void CursorOn()
	{
		Cursor.visible = true;
	}

	private void Start()
	{
		if (VisibleOnStart)
		{
			Cursor.visible = true;
		}
	}

	public void CursorOff()
	{
		Cursor.visible = false;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Pause.SetActive(value: true);
			Time.timeScale = 0f;
			if ((bool)Music)
			{
				Music.Pause();
			}
			Cursor.visible = true;
		}
	}
}
