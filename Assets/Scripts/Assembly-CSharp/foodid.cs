using System.Collections;
using UnityEngine;

public class foodid : MonoBehaviour
{

	public GameObject gmOver;

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Floor")
		{
			gmOver.SetActive(value: true);
			Time.timeScale = 0.2f;
			StartCoroutine(TimeRevent());
		}
	}

	private IEnumerator TimeRevent()
	{
		yield return new WaitForSeconds(2f);
		Time.timeScale = 1f;
	}
}
