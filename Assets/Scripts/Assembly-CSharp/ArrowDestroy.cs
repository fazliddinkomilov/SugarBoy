using UnityEngine;

public class ArrowDestroy : MonoBehaviour
{
	private MeshRenderer mesh;

	private void Start()
	{
		mesh = base.gameObject.GetComponent<MeshRenderer>();
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}


}
