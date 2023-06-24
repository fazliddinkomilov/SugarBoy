using System.Collections;
using UnityEngine;

public class TargetInCanvas : MonoBehaviour
{
	private bool enablebool;

	private void Update()
	{
		if (base.gameObject.active)
		{
			StartCoroutine(off());
		}
	}

	private IEnumerator off()
	{
		yield return new WaitForSeconds(5f);
		base.gameObject.SetActive(value: false);
	}
}
