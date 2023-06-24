using UnityEngine;

public class EnemyHealthh : MonoBehaviour
{
	public int health = 40;

	public GameObject bloodParticle;

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "PlayerBullet")
		{
			health -= 2;
			Object.Destroy(col.gameObject);
			if (health <= 0)
			{
				Object.Instantiate(bloodParticle, base.transform.position, Quaternion.identity);
				Object.Destroy(base.gameObject);
			}
		}
	}
}
