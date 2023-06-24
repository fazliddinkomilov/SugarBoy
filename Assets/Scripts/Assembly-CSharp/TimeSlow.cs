using UnityEngine;

public class TimeSlow : MonoBehaviour
{
	private void Start()
	{
		Cursor.visible = true;
	}

	private void Update()
	{
		Time.timeScale = 0.1f;
	}
}
