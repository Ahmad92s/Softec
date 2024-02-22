using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Player playerInfo;

    [SerializeField]
    GameObject bulletHitFx;

    private void Awake()
    {
        playerInfo = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "EnemyBullet")
        {
            Instantiate(bulletHitFx, transform.position + Vector3.up, Quaternion.identity);
            playerInfo.health -= playerInfo.smallBulletDamage;
            playerInfo.gotHit = true;
        }
    }
}
