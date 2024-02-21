using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    PlayerMovement playerMovement;

    internal bool attack, isAttacking;
    internal string attackName;

    float timeSinceLastAttack, coolDownTime = 0.2f;

    void Update()
    {
        //Attack
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        timeSinceLastAttack += Time.deltaTime;
        if(timeSinceLastAttack > coolDownTime)
        {
            isAttacking = false;
        }
    }

    void Attack()
    {
        isAttacking = true;
        timeSinceLastAttack = 0;


        int attackNum = Random.Range(1, 3);
        attackName = "attack" + attackNum.ToString();

        attack = true;
        //playerMovement.enabled = false;
    }
}
