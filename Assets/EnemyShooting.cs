using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class EnemyShooting : MonoBehaviour
{
    Enemy enemyInfo;
    EnemyMovement enemyMovement;

    bool isAttacking;
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

    [SerializeField]
    bool rangedEnemy;

    private void Awake()
    {
        enemyInfo = GetComponent<Enemy>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if (!enemyInfo.died)
        {
            if (enemyMovement.closeEnough)
            {
                //if not stunned
                if (enemyInfo.timeSinceLastHit >= enemyInfo.coolDownTime)
                {
                    if (!isAttacking)
                    {
                        if (rangedEnemy)
                        {
                            StartCoroutine(Shoot());
                        }
                        else
                        {
                            StartCoroutine(DoMeleeAttack());
                        }
                    }
                }
                else
                {
                    StopAllCoroutines();
                    isAttacking = false;
                }
            }
        }

    }

    IEnumerator Shoot()
    {
        isAttacking = true;
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

        isAttacking = false;
    }

    IEnumerator DoMeleeAttack()
    {
        shotTaken = true;
        isAttacking = true;

        yield return new WaitForSeconds(Random.Range(minShootTime, maxShootTime));

        isAttacking = false;
    }
}
