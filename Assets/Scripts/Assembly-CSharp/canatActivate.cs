using UnityEngine;

public class canatActivate : MonoBehaviour
{
	public GameObject canat;

	private Animator anim;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			anim.Play("ButtonClick");
			canat.SetActive(value: true);
			Object.Destroy(base.gameObject, 3f);
		}
	}
}
