using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    NavMeshAgent agent;
    Enemy enemyInfo;
    EnemyShooting controller;

    bool died;

    [SerializeField]
    bool meleeEnemy;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyInfo = GetComponent<Enemy>();
        controller = GetComponent<EnemyShooting>();
    }

    private void Update()
    {
        if(agent.velocity.magnitude > 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if(enemyInfo.health <= 0)
        {
            if (!died)
            {
                died = true;
                animator.SetTrigger("DiedTrig");
                animator.SetBool("Died", died);
            }
        }

        if (!died)
        {
            if (enemyInfo.gotHit)
            {
                animator.SetTrigger("hitReact");
                enemyInfo.gotHit = false;
            }
            else if (controller.shotTaken)
            {
                if (meleeEnemy)
                {
                    string attack = "Attack" + Random.Range(1, 3).ToString();
                    animator.SetTrigger(attack);
                }
                else
                {
                    animator.SetTrigger("Shoot");
                }
                controller.shotTaken = false;
            }
        }
    }
}
