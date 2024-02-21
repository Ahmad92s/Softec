using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    PlayerMovement playerMovement;

    [SerializeField]
    Animator animator;

    private void Update()
    {
        //Debug.Log(playerMovement.isMoving + ", " + playerMovement.isGrounded + ", " + playerMovement.isRunning);
        animator.SetBool("isMoving", playerMovement.isMoving);
        animator.SetBool("isGrounded", playerMovement.isGrounded);
        animator.SetBool("isRunning", playerMovement.isRunning);

        if (playerMovement.attack)
        {
            animator.SetTrigger("attack1");
            playerMovement.attack = false;
        }
    }
}
