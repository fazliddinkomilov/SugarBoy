using CandiceAIforGames.AI;
using UnityEngine;
using UnityMovementAI;

public class EnemyFreez : MonoBehaviour
{
	private Rigidbody gmRig;

	private ColAvoidUnit gmScriiptcolAvoid;

	private MovementAIRigidbody gmScriiptMovementAIRigidbody;

	public GameObject mainClubnika;

	private EnemyFollow scriptMain;

	private Animator mainAnim;

	public Animator FreezAnim;

	public GameObject ClubnikaBox;

	public GameObject ClubnikaWeapon;
	NingaClubnika ningaAct;

	private void Start()
	{
		gmRig = mainClubnika.GetComponent<Rigidbody>();
		gmScriiptcolAvoid = mainClubnika.GetComponent<ColAvoidUnit>();
		gmScriiptMovementAIRigidbody = mainClubnika.GetComponent<MovementAIRigidbody>();
		scriptMain = gameObject.GetComponent<EnemyFollow>();
		mainAnim = gameObject.GetComponent<Animator>();
		ningaAct = FreezAnim.gameObject.GetComponent<NingaClubnika>();


    }

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Ice")
		{
			FreezAnim.Play("clubnikaFreez");
			Object.Destroy(gmRig);
			if(gmScriiptcolAvoid!=null)
			{
                gmScriiptcolAvoid.enabled = false;
            }
            if (gmScriiptMovementAIRigidbody != null)
            {
                gmScriiptMovementAIRigidbody.enabled = false;
            }
			if(ningaAct!=null)
			{
				ningaAct.enabled = false;

            }
			scriptMain.enabled = false;
			mainAnim.enabled = false;
			ClubnikaBox.SetActive(value: false);
			ClubnikaWeapon.SetActive(value: false);
			Object.Destroy(col.gameObject);
		}
	}
}
