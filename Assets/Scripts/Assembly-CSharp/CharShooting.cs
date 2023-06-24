using UnityEngine;
using UnityEngine.UI;

public class CharShooting : MonoBehaviour
{
	public Gun gun;

	public int shootButton;

	public KeyCode reloadKey;

	private bool CanShoot = true;

	public int ammo;

	public GameObject slidergm;

	private Slider slider;

	public GameObject ketchupIcon;

	private void Start()
	{
		ammo = 100;
		slidergm = GameObject.Find("Canvas/Slider");
		ketchupIcon = GameObject.Find("Canvas/Image/Ket");
		slider = slidergm.GetComponent<Slider>();
	}

	private void Update()
	{
		if (CanShoot)
		{
			slider.value = ammo;
			if (ammo > 0 && Input.GetMouseButton(shootButton))
			{
				gun.Shoot();
				ammo--;
			}
			if (Input.GetKeyDown(reloadKey))
			{
				gun.Reload();
			}
			slidergm.SetActive(value: true);
			ketchupIcon.SetActive(value: true);
		}
		else
		{
			ketchupIcon.SetActive(value: false);
			slidergm.SetActive(value: false);
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			if (CanShoot)
			{
				CanShoot = false;
			}
			else
			{
				CanShoot = true;
			}
		}
	}
}
