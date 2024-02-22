using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Enemy enemyInfo;

    internal bool closeEnough;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyInfo = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (!enemyInfo.died)
        {
            agent.SetDestination(Player.instance.transform.position);

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                transform.LookAt(new Vector3(Player.instance.transform.position.x, transform.position.y, Player.instance.transform.position.z));
                closeEnough = true;
            }
            else
            {
                closeEnough = false;
            }
        }
    }
}
