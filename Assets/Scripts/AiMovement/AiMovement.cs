using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMovement : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public Animator anim;
    public GameObject entityDoor;
    public AudioSource runSound;

    private void Start()
    {
        agent.destination = target.position;
    }

    private void Update()
    {
        if (entityDoor.activeSelf == true)
        {
            agent.speed = 0;
            anim.SetBool("IsMove", false);
        }
        else
        {
            agent.speed = 20;
            
            if (agent.velocity.x != 0 | agent.velocity.z != 0)
            {
                runSound.Play();
                anim.SetBool("IsMove", true);
                
            }
            else
            {
                anim.SetBool("IsMove", false);
            }
        }
       
    }
}