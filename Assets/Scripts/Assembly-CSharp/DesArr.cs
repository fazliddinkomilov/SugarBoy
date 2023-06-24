using UnityEngine;

public class DesArr : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Arrow")
		{
			Object.Destroy(other.gameObject);
		}
	}
}
