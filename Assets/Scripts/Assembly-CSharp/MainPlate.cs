using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MainPlate : MonoBehaviour
{
	public bool win;



	public Timer timer1;

	public ParticleSystem particle;

	public GameObject gmWin;

	public GameObject timer;

	[SerializeField] GameObject[] invObjects;
	[SerializeField] AudioSource getsound;

    public Text receptsText;

	public GameObject[] foodComponent;


	private int sum;

	public GameObject TargetCanvas;

	public bool bath;
	int rint;

    private void Start()
    {
		StartCoroutine(AudiosOn());
    }
	IEnumerator AudiosOn()
	{
		yield return new WaitForSeconds(5);
		getsound.gameObject.SetActive(true);

    }

    private void Update()
	{
		
			receptsText.text = rint.ToString();
		

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Food")
		{
			
			if (!bath)
			{
				timer1.timeRemaining += 40.0;
			}
			particle.Play();
			getsound.Play(); 
			TargetCanvas.SetActive(value: true);

	
	

			
			Destroy(other.gameObject);
			foodComponent[rint].SetActive(value: true);
			invObjects[rint].SetActive(false);
			rint++;
			if(rint>=6)
			{
                if (timer != null)
                {
                    timer.SetActive(false);
                }
                gmWin.SetActive(true);
            }

        }
	}
}
