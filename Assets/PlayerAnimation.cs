using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    PlayerMovement playerMovement;
    [SerializeField]
    PlayerCombat playerCombat;

    [SerializeField]
    Animator animator;

    private void Update()
    {
        //Debug.Log(playerMovement.isMoving + ", " + playerMovement.isGrounded + ", " + playerMovement.isRunning);
        animator.SetBool("isMoving", playerMovement.isMoving);
        animator.SetBool("isGrounded", playerMovement.isGrounded);
        animator.SetBool("isRunning", playerMovement.isRunning);

        if (playerCombat.attack)
        {
            Attack("attack1");
            StartCoroutine(SetNeutralState());
        }
    }

    void Attack(string attack)
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(attack))
        {
            animator.SetTrigger(attack);
        }
        else
        {
            return;
        }
        playerCombat.attack = false;
    }

    IEnumerator SetNeutralState()
    {
        animator.SetFloat("Idle Blend", 1);
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 100; i++)
        {
            animator.SetFloat("Idle Blend", animator.GetFloat("Idle Blend") - 0.01f);
            yield return new WaitForSeconds(0.0025f);
        }
        //animator.SetFloat("Idle Blend", 0f);
    }
}
