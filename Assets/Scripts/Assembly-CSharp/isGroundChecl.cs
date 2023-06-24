using UnityEngine;

public class isGroundChecl : MonoBehaviour
{
	public Jump j;

	private void OnCollisionStay(Collision col)
	{
		if (col.gameObject.tag == "Bones")
		{
			j.isGrounded = false;
		}
		else
		{
			j.isGrounded = true;
		}
	}
}
