using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class PlayerAnimation : MonoBehaviour
{
    Player playerInfo;
    PlayerMovement playerMovement;
    PlayerCombat playerCombat;


    [SerializeField]
    Animator animator;


    private void Awake()
    {
        playerInfo = GetComponent<Player>();
        playerMovement = GetComponent<PlayerMovement>();
        playerCombat = GetComponent<PlayerCombat>();
    }

    private void Update()
    {
        //Debug.Log(playerMovement.isMoving + ", " + playerMovement.isGrounded + ", " + playerMovement.isRunning);
        animator.SetBool("isMoving", playerMovement.isMoving);
        animator.SetBool("isGrounded", playerMovement.isGrounded);
        animator.SetBool("isRunning", playerMovement.isRunning);
        animator.SetBool("isAttacking", playerCombat.isAttacking);


        if (playerInfo.gotHit)
        {
            playerInfo.gotHit = false;
            animator.SetTrigger("hitReact");
        }

        if (!playerCombat.isAttacking && animator.GetFloat("Idle Blend") == 1)
        {
            StartCoroutine(SetNeutralState());
        }

        if (playerCombat.attack)
        {
            Attack("attack1");
            animator.SetFloat("Idle Blend", 1);
        }
        if (playerMovement.dodge)
        {
            playerMovement.dodge = false;
            animator.SetTrigger("Dodge");
        }
        else if (playerMovement.jumpAnim)
        {
            playerMovement.jumpAnim = false;
            animator.SetTrigger("Jump");
        }
    }

    internal void Attack(string attack)
    {
        //if (!animator.GetCurrentAnimatorStateInfo(0).IsName(attack))
        //{
        //    animator.SetTrigger(attack);
        //}
        //else
        //{
        //    return;
        //}
        
        animator.SetTrigger(attack);
        playerCombat.attack = false;
    }

    IEnumerator SetNeutralState()
    {
        animator.SetFloat("Idle Blend", 1);
        yield return new WaitForSeconds(10f);
        for (int i = 0; i < 1000; i++)
        {
            animator.SetFloat("Idle Blend", animator.GetFloat("Idle Blend") - 0.001f);
            yield return new WaitForSeconds(0.0025f);
        }
        //animator.SetFloat("Idle Blend", 0f);
    }
}
