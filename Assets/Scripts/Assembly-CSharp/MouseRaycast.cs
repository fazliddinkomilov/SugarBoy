using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseRaycast : MonoBehaviour
{
	public GameObject box1;

	public GameObject boxFalse1;

	public GameObject boxFalse2;

	public GameObject plane;

	public Animator animLevels;

	public string buttonType;

	public LevelsManager manager;

	public AudioSource audio;

	public AudioSource audioOff;

	private Transform transformP;

	public float buttonDown = 0.2f;

	private void Start()
	{
		transformP = base.transform;
		Time.timeScale = 1f;
	}

	private void OnMouseEnter()
	{
		base.transform.position = new Vector3(transformP.position.x, transformP.position.y, transformP.position.z + buttonDown);
	}

	private void OnMouseExit()
	{
		base.transform.position = new Vector3(transformP.position.x, transformP.position.y, transformP.position.z - buttonDown);
	}

	private void OnMouseOver()
	{
		if (buttonType == "firstButton" && Input.GetMouseButtonDown(0))
		{
			box1.SetActive(value: true);
			plane.SetActive(value: true);
			boxFalse1.SetActive(value: false);
			boxFalse2.SetActive(value: false);
			base.gameObject.SetActive(value: false);
			audio.Play();
			audioOff.Stop();
			animLevels.Play("buttons");
		}
		if (buttonType == "Play" && Input.GetMouseButtonDown(0))
		{
			if (manager.SelectedScene == 1)
			{
				SceneManager.LoadScene("Tutorial");
			}
			if (manager.SelectedScene == 2)
			{
				SceneManager.LoadScene("Cafe1");
			}
			if (manager.SelectedScene == 3)
			{
				SceneManager.LoadScene("Cafe2");
			}
			if (manager.SelectedScene == 4)
			{
				SceneManager.LoadScene("Cafe3");
			}
			if (manager.SelectedScene == 5)
			{
				SceneManager.LoadScene("Cafe4");
			}
			if (manager.SelectedScene == 6)
			{
				SceneManager.LoadScene("Cafe5");
			}
		}
		if (buttonType == "moveButtonUp" && Input.GetMouseButtonDown(0))
		{
			manager.SelectedScene--;
			animLevels.Play("moveLevels", -1, 0f);
			audio.Play();
		}
		if (buttonType == "moveButtonDown" && Input.GetMouseButtonDown(0))
		{
			manager.SelectedScene++;
			audio.Play();
			animLevels.Play("moveLevels", -1, 0f);
		}
	}
}
