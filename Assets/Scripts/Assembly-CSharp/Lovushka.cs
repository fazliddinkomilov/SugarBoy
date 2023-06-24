using UnityEngine;

public class Lovushka : MonoBehaviour
{
	public CharacterJoint joint;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Object.Destroy(joint);
			Object.Destroy(base.gameObject);
		}
	}
}
