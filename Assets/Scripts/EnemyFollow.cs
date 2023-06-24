using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    CharacterController _controller;
    Transform target;
    [SerializeField]GameObject Player;

    [SerializeField]
    float _moveSpeed = 0.015f;
    Rigidbody rb;


    // Use this for initialization
    void Start()
    {


        Player = GameObject.FindWithTag("Player");
        target = Player.transform;
        rb = gameObject.GetComponent<Rigidbody>();


        _controller = gameObject.GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update()
    {
        if(Player==null)
        {
            Player = GameObject.FindWithTag("Player");
            target = Player.transform;
        }

        Vector3 direction = target.position - transform.position;

        direction = direction.normalized;

        Vector3 velocity = direction * _moveSpeed;

        /*_controller.Move(velocity * Time.deltaTime);*/

 /*       transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _moveSpeed);*/


        transform.position += transform.forward * 1.2f * Time.deltaTime;

        //look

        Vector3 lookDirection = target.position - transform.position;
        lookDirection.Normalize();

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), 2.5f * Time.deltaTime);


       

    }


}
