using UnityEngine;

public class CheckPlayer1 : MonoBehaviour
{
	public Collider HitBox;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			HitBox.enabled = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "CheckPlayer")
		{
			HitBox.enabled = false;
		}
	}
}
