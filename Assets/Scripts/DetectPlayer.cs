using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ClubnikaActivate clubActivate;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            clubActivate.enabled = true;
            clubActivate.Activate();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
