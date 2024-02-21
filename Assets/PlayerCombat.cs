using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    PlayerMovement playerMovement;

    internal bool attack;

    void Update()
    {
        //Attack
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        attack = true;
        //playerMovement.enabled = false;
    }
}
