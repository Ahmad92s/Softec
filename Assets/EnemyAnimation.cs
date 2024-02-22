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

    bool died;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyInfo = GetComponent<Enemy>();
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
        }
    }
}
