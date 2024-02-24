using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour
{
    [SerializeField]
    GameObject Explosion;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(Explosion, collision.contacts[0].point, Quaternion.identity);
    }
}
