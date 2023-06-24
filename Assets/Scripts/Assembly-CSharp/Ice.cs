using System.Collections;
using UnityEngine;

public class Ice : MonoBehaviour
{
	public GameObject particle;

	private Animator anim;

	private void Start()
	{
		anim = base.gameObject.GetComponent<Animator>();
	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player")
		{
			particle.SetActive(value: true);
		}
	}

	private IEnumerator Destroying()
	{
		yield return new WaitForSeconds(10f);
		Object.Destroy(base.gameObject);
	}
}
