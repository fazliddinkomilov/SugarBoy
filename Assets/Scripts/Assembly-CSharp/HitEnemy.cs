using UnityEngine;

public class HitEnemy : MonoBehaviour
{
	public CheckPlayer checkplayerScript;

	private Animator anim;

	private void Start()
	{
		anim = gameObject.GetComponent<Animator>();
	}

	private void Update()
	{
		if (checkplayerScript.canHit)
		{
			anim.SetBool("hit", true);
		}
		else
		{
			anim.SetBool("hit", false);
		}
	}
}
