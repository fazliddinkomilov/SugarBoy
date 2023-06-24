using UnityEngine;

public class DestroySelf : MonoBehaviour
{
	[SerializeField]
	private float DestroyTime;

	public GameObject[] KetchupSprites;

	private void Start()
	{
	}

	private void OnBecameInvisible()
	{
		Object.Destroy(base.gameObject);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			Object.Instantiate(KetchupSprites[Random.Range(0, KetchupSprites.Length)], base.transform.position, Quaternion.Euler(90f, 0f, 0f));
		}
		if (collision.gameObject.tag == "Box")
		{
			Object.Instantiate(KetchupSprites[Random.Range(0, KetchupSprites.Length)], base.transform.position, Quaternion.Euler(0f, 90f, 0f));
		}
	}
}
