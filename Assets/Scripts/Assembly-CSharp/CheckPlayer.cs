using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
	public bool canHit;

	public GameObject hit;

	private void Update()
	{
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			canHit = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			canHit = false;
		}
	}
}
