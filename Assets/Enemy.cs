using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    internal bool gotHit, died;

    private void Update()
    {
        if(health <= 0)
        {
            died = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerSword")
        {
            health -= Player.instance.attackPower;
            gotHit = true;
        }
    }
}
