using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NingaClubnika : MonoBehaviour
{
    Animator animator;
    bool clubnikaActive = false;
    [SerializeField] EnemyFollow followScript;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            if (clubnikaActive != true)
            {
                followScript.enabled = true;
                animator.Play("clubnikaActivate");
                Destroy(gameObject.GetComponent<Collider>());
                clubnikaActive = false;
            }
        }
    }


}
