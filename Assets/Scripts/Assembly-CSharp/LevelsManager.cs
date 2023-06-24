using UnityEngine;

public class LevelsManager : MonoBehaviour
{
	public int SelectedScene = 1;

	public GameObject[] cameras;

	public GameObject[] info;

	private void Update()
	{
		if (SelectedScene <= 1)
		{
			SelectedScene = 1;
		}
		if (SelectedScene >= 7)
		{
			SelectedScene = 7;
		}
		if (SelectedScene == 1)
		{
			cameras[0].SetActive(value: true);
			cameras[1].SetActive(value: false);
			cameras[2].SetActive(value: false);
			cameras[3].SetActive(value: false);
			info[0].SetActive(value: true);
			info[1].SetActive(value: false);
			info[2].SetActive(value: false);
			info[3].SetActive(value: false);
			cameras[4].SetActive(value: false);
			cameras[5].SetActive(value: false);
			cameras[6].SetActive(value: false);
			info[4].SetActive(value: false);
			info[5].SetActive(value: false);
			info[6].SetActive(value: false);
		}
		if (SelectedScene == 2)
		{
			cameras[0].SetActive(value: false);
			cameras[1].SetActive(value: true);
			cameras[2].SetActive(value: false);
			cameras[3].SetActive(value: false);
			info[0].SetActive(value: false);
			info[1].SetActive(value: true);
			info[2].SetActive(value: false);
			info[3].SetActive(value: false);
			cameras[4].SetActive(value: false);
			cameras[5].SetActive(value: false);
			cameras[6].SetActive(value: false);
			info[4].SetActive(value: false);
			info[5].SetActive(value: false);
			info[6].SetActive(value: false);
		}
		if (SelectedScene == 3)
		{
			cameras[0].SetActive(value: false);
			cameras[1].SetActive(value: false);
			cameras[2].SetActive(value: true);
			cameras[3].SetActive(value: false);
			info[0].SetActive(value: false);
			info[1].SetActive(value: false);
			info[2].SetActive(value: true);
			info[3].SetActive(value: false);
			cameras[4].SetActive(value: false);
			cameras[5].SetActive(value: false);
			cameras[6].SetActive(value: false);
			info[4].SetActive(value: false);
			info[5].SetActive(value: false);
			info[6].SetActive(value: false);
		}
		if (SelectedScene == 4)
		{
			cameras[0].SetActive(value: false);
			cameras[1].SetActive(value: false);
			cameras[2].SetActive(value: false);
			cameras[3].SetActive(value: true);
			info[0].SetActive(value: false);
			info[1].SetActive(value: false);
			info[2].SetActive(value: false);
			info[3].SetActive(value: true);
			cameras[4].SetActive(value: false);
			cameras[5].SetActive(value: false);
			cameras[6].SetActive(value: false);
			info[4].SetActive(value: false);
			info[5].SetActive(value: false);
			info[6].SetActive(value: false);
		}
		if (SelectedScene == 5)
		{
			cameras[0].SetActive(value: false);
			cameras[1].SetActive(value: false);
			cameras[2].SetActive(value: false);
			cameras[3].SetActive(value: false);
			info[0].SetActive(value: false);
			info[1].SetActive(value: false);
			info[2].SetActive(value: false);
			info[3].SetActive(value: false);
			cameras[4].SetActive(value: true);
			cameras[5].SetActive(value: false);
			cameras[6].SetActive(value: false);
			info[4].SetActive(value: true);
			info[5].SetActive(value: false);
			info[6].SetActive(value: false);
		}
		if (SelectedScene == 6)
		{
			cameras[0].SetActive(value: false);
			cameras[1].SetActive(value: false);
			cameras[2].SetActive(value: false);
			cameras[3].SetActive(value: false);
			info[0].SetActive(value: false);
			info[1].SetActive(value: false);
			info[2].SetActive(value: false);
			info[3].SetActive(value: false);
			cameras[4].SetActive(value: false);
			cameras[5].SetActive(value: true);
			cameras[6].SetActive(value: false);
			info[4].SetActive(value: false);
			info[5].SetActive(value: true);
			info[6].SetActive(value: false);
		}
		if (SelectedScene == 7)
		{
			cameras[0].SetActive(value: false);
			cameras[1].SetActive(value: false);
			cameras[2].SetActive(value: false);
			cameras[3].SetActive(value: false);
			info[0].SetActive(value: false);
			info[1].SetActive(value: false);
			info[2].SetActive(value: false);
			info[3].SetActive(value: false);
			cameras[4].SetActive(value: false);
			cameras[5].SetActive(value: false);
			cameras[6].SetActive(value: true);
			info[4].SetActive(value: false);
			info[5].SetActive(value: false);
			info[6].SetActive(value: true);
		}
	}
}
