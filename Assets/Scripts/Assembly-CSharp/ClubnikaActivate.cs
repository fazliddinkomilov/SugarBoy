using CandiceAIforGames.AI;
using UnityEngine;
using UnityMovementAI;

public class ClubnikaActivate : MonoBehaviour
{
	public GameObject mainClub;

	public GameObject nav;

	private Animator anim;

	public GameObject[] metalgear_sounds;

	private bool addRig;

	public Transform xz;

	public MovementAIRigidbody movementAiScript;

	public ColAvoidUnit colAvoidScript;

	public Collider col;

	public Rigidbody rig;

	public bool navClubnika = true;

	[SerializeField] Collider coliderOn;

	private void Start()
	{
		anim = gameObject.GetComponent<Animator>();
		addRig = true;
	}

	public void Activate()
	{
	/*	if (!ca.Follow)
		{
			return;
		}*/
		if (navClubnika)
		{
            int rint = Random.Range(0, metalgear_sounds.Length);

            metalgear_sounds[rint].SetActive(true);
            movementAiScript.enabled = false;
			colAvoidScript.enabled = false;
			col.enabled = false;
			coliderOn.enabled = true;
			mainClub.GetComponent<Rigidbody>().isKinematic =false;
			mainClub.GetComponent<EnemyFollow>().enabled = true;
			Destroy(mainClub.GetComponent<Collider>().material);

			nav.SetActive(false);
			if (addRig)
			{
				Rigidbody rigidbody = mainClub.AddComponent<Rigidbody>();
				rigidbody.mass = 50f;
				rigidbody.constraints = (RigidbodyConstraints)80;
				mainClub.transform.parent = xz.parent;
				addRig = false;
			}
			Destroy(rig);
		}
		else
		{
			anim.Play("clubnikaActivate");
		}
	}
}
