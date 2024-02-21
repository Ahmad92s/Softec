using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    private void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
            Debug.Log("died");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerSword")
        {
            health -= 10;
        }
    }
}
