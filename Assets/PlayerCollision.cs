using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Player playerInfo;

    [SerializeField]
    GameObject bulletHitFx;

    [SerializeField]
    float stunTime;

    private void Awake()
    {
        playerInfo = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "EnemyBullet" || other.transform.tag == "EnemySword")
        {
            Instantiate(bulletHitFx, transform.position + Vector3.up, Quaternion.identity);
            if(other.transform.tag == "EnemyBullet")
            {
                playerInfo.health -= playerInfo.smallBulletDamage;
            }
            else if(other.transform.tag == "EnemySword")
            {
                playerInfo.health -= playerInfo.swordDamage;
            }

            playerInfo.gotHit = true;
            playerInfo.stunned = true;
            StopAllCoroutines();
            StartCoroutine(UnStun());

            if(playerInfo.health <= 0)
            {
                playerInfo.died = true;
            }
        }
    }

    IEnumerator UnStun()
    {
        yield return new WaitForSeconds(stunTime);
        playerInfo.stunned = false;
    }
}
