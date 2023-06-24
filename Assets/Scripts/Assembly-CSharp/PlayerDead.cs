using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDead : MonoBehaviour
{
	public ConfigurableJoint[] joints;

	public Collider[] colliders;

	public GameObject[] sugars;
	[SerializeField] AudioSource[] deadsounds;
	public GameObject Stabilizer;

	public int Health = 100;

	private GameObject xz;

	private GameObject slidergm;

	private Slider slider;

	public bool openWorldChar = true;

	private void Start()
	{
		slidergm = GameObject.Find("Canvas/SliderHealth");
		xz = GameObject.Find("xz");
		slider = slidergm.GetComponent<Slider>();
		Time.timeScale = 1f;
	}

	public void Kill()
	{
		Time.timeScale = 0.2f;
		StartCoroutine(TimeRevent());
		Object.Destroy(Stabilizer.GetComponent<ConfigurableJoint>());
		if (joints.Length != 0)
		{
			ConfigurableJoint[] array = joints;
			for (int i = 0; i < array.Length; i++)
			{
				Object.Destroy(array[i]);
			}
		}
		if (colliders != null && colliders.Length != 0)
		{
			Collider[] array2 = colliders;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].enabled = true;
			}
		}
		int rint = Random.Range(0, deadsounds.Length);

		deadsounds[rint].Play();


        if (sugars != null && sugars.Length != 0)
		{
			GameObject[] array3 = sugars;
			foreach (GameObject gameObject in array3)
			{
				if (gameObject.GetComponent<BoxCollider>() == null)
				{
					gameObject.AddComponent<BoxCollider>();
				}
				if (gameObject.GetComponent<Rigidbody>() == null)
				{
					gameObject.AddComponent<Rigidbody>();
				}
				gameObject.transform.parent = xz.transform.parent;
			}
		}
		Object.Destroy(base.gameObject, 4f);
	}

	private IEnumerator TimeRevent()
	{
		yield return new WaitForSeconds(0.5f);
		Time.timeScale = 1f;
	}

	private void Update()
	{
		slider.value = Health;
		Stabilizer = GameObject.Find("Stabilizer");
	}
}
