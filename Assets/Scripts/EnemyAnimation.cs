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

    [SerializeField]
    int totalAttacks = 2;

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
                    string attack = "Attack" + Random.Range(1, totalAttacks + 1).ToString();
                    if(attack == "Attack3")
                    {
                        StartCoroutine(FreezeRotationTemp());
                    }
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

    IEnumerator FreezeRotationTemp()
    {
        float 
            speed = agent.speed,
            angularSpeed = agent.angularSpeed;

        agent.angularSpeed = 0;
        agent.speed = 0;

        yield return new WaitForSeconds(7f);

        agent.speed = speed;
        agent.angularSpeed = angularSpeed;
    }
}
