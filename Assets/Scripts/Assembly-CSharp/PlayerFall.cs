using UnityEngine;

public class PlayerFall : MonoBehaviour
{
	public PlayerDead player;

	public ParticleSystem particle;

	public CharShooting PlayerShooting;

	public Animator PlayerAnim;

	public Transform SpawnPosition;

	public Rigidbody rig;

	public Vector3 jump;

	public float jumpForce = 2f;

	public AudioSource hit_audio;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Floor")
		{
			player.Kill();
		}
		if (other.gameObject.tag == "Hit")
		{
			player.Health -= 10;
			particle.Play();
			hit_audio.Play();
			if (player.Health <= 0)
			{
				player.Kill();
			}
		}
		if (other.gameObject.tag == "Ketchup" && PlayerShooting.ammo < 100)
		{
			other.gameObject.GetComponent<Animator>().Play("KetChop");
			Object.Destroy(other.gameObject, 3f);
			PlayerAnim.Play("GetKetchup");
			PlayerShooting.ammo = 100;
		}
		if (other.gameObject.tag == "Spong")
		{
			rig.AddForce(jump * jumpForce, ForceMode.Impulse);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Portal")
		{
			player.transform.position = SpawnPosition.position;
		}
	}
}
