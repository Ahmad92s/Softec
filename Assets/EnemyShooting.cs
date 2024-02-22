using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class EnemyShooting : MonoBehaviour
{
    NavMeshAgent agent;
    Enemy enemyInfo;

    bool isShooting;
    internal bool shotTaken;

    [SerializeField]
    Renderer aimLineRenderer;

    [SerializeField]
    GameObject projectile;

    [SerializeField]
    float 
        minShootTime, 
        maxShootTime,
        shotWarningTime,
        shotForce;

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

                //if not stunned
                if (enemyInfo.timeSinceLastHit >= enemyInfo.coolDownTime)
                {
                    if (!isShooting)
                    {
                        StartCoroutine(Shoot());
                    }
                }
                else
                {
                    StopAllCoroutines();
                    isShooting = false;
                }
            }
        }

    }

    IEnumerator Shoot()
    {
        isShooting = true;
        yield return new WaitForSeconds(Random.Range(minShootTime, maxShootTime));
        aimLineRenderer.material.DOColor(Color.red, shotWarningTime);
        yield return new WaitForSeconds(shotWarningTime + 0.2f);
        aimLineRenderer.enabled = false;
        shotTaken = true;
        var bullet = Instantiate(projectile, aimLineRenderer.transform.parent.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(aimLineRenderer.transform.parent.transform.forward * shotForce);
        aimLineRenderer.material.DOColor(Color.yellow, 0f);
        yield return new WaitForSeconds(0.5f);
        aimLineRenderer.enabled = true;

        isShooting = false;
    }
}
