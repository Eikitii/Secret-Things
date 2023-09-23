using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform checkpoint;
    Animator anim;
    public AudioSource laughSound;
    public static int toPlayerChance;
    public Transform player;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = agent.GetComponent<Animator>();
        Invoke("Move", 40f);
    }

    void Move()
    {
        NextPoints point = checkpoint.GetComponent<NextPoints>();
        if (point is AttackPoints)
        {
            laughSound.Play();
            AttackPoints nearPoint = checkpoint.GetComponent<AttackPoints>(); ;
            bool isOpen = nearPoint.isOpen;
            if (isOpen)
            {
                agent.destination = player.position;
                agent.speed = 5;
            }
            else
            {
                //laughSound.Play();
                checkpoint = point.getNext();
                agent.destination = checkpoint.position;
                Invoke("Move", 25f);
            }
        }
        else
        {
            checkpoint = point.getNext();
            agent.destination = checkpoint.position;
            Invoke("Move", 25f);
        }
    }

    private void Update()
    {
        if (agent.velocity.x != 0 | agent.velocity.z != 0)
        {
            anim.SetBool("IsMove", true);
        }
        else
        {
            anim.SetBool("IsMove", false);
        }
    }
}
