using UnityEngine;

public class AiAgent : MonoBehaviour
{
	public GameObject player;

	private void Start()
	{
	}

	private void Update()
	{
		if (!player)
		{
			player = GameObject.Find("Character(Clone)/Physical/Player/Torso/AI Agent_2POS");
			if (!player)
			{
				player = GameObject.Find("CharacterTutor(Clone)/Physical/Player/Torso/AI Agent_2POS");
			}
		}
		if (player != null)
		{
			base.transform.position = player.GetComponent<Transform>().position;
		}
	}
}
