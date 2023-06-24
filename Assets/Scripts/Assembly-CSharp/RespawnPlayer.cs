using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
	private GameObject Player;

	public GameObject PlayerPrefab;

	private void Update()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		if (!Player)
		{
			Object.Instantiate(PlayerPrefab, base.transform.position, Quaternion.identity);
		}
	}
}
