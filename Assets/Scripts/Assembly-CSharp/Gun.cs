using UnityEngine;

public class Gun : MonoBehaviour
{
	public enum ShootState
	{
		Ready = 0,
		Shooting = 1,
		Reloading = 2
	}

	private float muzzleOffset;

	[Header("Magazine")]
	public GameObject round;

	public int ammunition;

	[Range(0.5f, 10f)]
	public float reloadTime;

	private int remainingAmmunition;

	[Header("Shooting")]
	[Range(0.25f, 25f)]
	public float fireRate;

	public int roundsPerShot;

	[Range(0.5f, 100f)]
	public float roundSpeed;

	[Range(0f, 45f)]
	public float maxRoundVariation;

	private ShootState shootState;

	private float nextShootTime;

	private void Start()
	{
		muzzleOffset = GetComponent<Renderer>().bounds.extents.z;
		remainingAmmunition = ammunition;
	}

	private void Update()
	{
		switch (shootState)
		{
		case ShootState.Shooting:
			if (Time.time > nextShootTime)
			{
				shootState = ShootState.Ready;
			}
			break;
		case ShootState.Reloading:
			if (Time.time > nextShootTime)
			{
				remainingAmmunition = ammunition;
				shootState = ShootState.Ready;
			}
			break;
		}
	}

	public void Shoot()
	{
		for (int i = 0; i < roundsPerShot; i++)
		{
			GameObject gameObject = Object.Instantiate(round, base.transform.position + base.transform.forward * muzzleOffset, base.transform.rotation);
			gameObject.transform.Rotate(new Vector3(Random.Range(-1f, 1f) * maxRoundVariation, Random.Range(-1f, 1f) * maxRoundVariation, 0f));
			gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * roundSpeed;
		}
		remainingAmmunition--;
		if (remainingAmmunition > 0)
		{
			nextShootTime = Time.time + 1f / fireRate;
			shootState = ShootState.Shooting;
		}
		else
		{
			Reload();
		}
	}

	public void Reload()
	{
		if (shootState == ShootState.Ready)
		{
			nextShootTime = Time.time + reloadTime;
			shootState = ShootState.Reloading;
		}
	}
}
