using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerAnimation playerAnimation;

    internal bool attack, isAttacking;
    internal string attackName;

    float timeSinceLastAttack, coolDownTime = 0.2f;


    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }
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
        playerAnimation.StopAllCoroutines();
        timeSinceLastAttack = 0;

        attack = true;
        //playerMovement.enabled = false;
    }
}
