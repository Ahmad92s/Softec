using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public Animator animator;

    public AudioSource footstepSource;
    public AudioSource source;
    public AudioClip
        running,
        walking,
        sword1,
        sword2,
        jump,
        dodge,
        hurt1,
        hurt2;

    public static PlayerAudio instance;

    private void Start()
    {
        instance = this;
        animator = transform.GetChild(0).GetComponent<Animator>();
    }
    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run")) {
            if (!footstepSource.isPlaying)
            {
                footstepSource.PlayOneShot(running);
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walking"))
        {
            if (!footstepSource.isPlaying)
            {
                footstepSource.PlayOneShot(walking);
            }
        }
    }

    internal void PlaySound(string sound)
    {
        switch (sound)
        {
            case "jump":
                source.PlayOneShot(jump);
                break;
            case "dodge":
                source.PlayOneShot(dodge);
                break;
            case "attack":
                StartCoroutine(PlaySwordSound());
                break;
            case "hurt":
                if (!(source.isPlaying && source.clip == hurt1))
                {
                    if (!footstepSource.isPlaying)
                    {
                        footstepSource.Stop();
                    }
                    if (source.isPlaying)
                    {
                        source.Stop();
                    }
                    footstepSource.PlayOneShot(hurt2);
                    source.PlayOneShot(hurt1);
                }
                break;
            default:
                break;
        }
    }

    IEnumerator PlaySwordSound()
    {
        yield return new WaitUntil(() => (
                    animator.GetCurrentAnimatorStateInfo(0).IsName("standing combo 1") ||
                    animator.GetCurrentAnimatorStateInfo(0).IsName("standing combo 2") ||
                    animator.GetCurrentAnimatorStateInfo(0).IsName("standing combo 2") ||
                    animator.GetCurrentAnimatorStateInfo(0).IsName("walking combo 1") ||
                    animator.GetCurrentAnimatorStateInfo(0).IsName("walking combo 2") ||
                    animator.GetCurrentAnimatorStateInfo(0).IsName("walking combo 3") ||
                    animator.GetCurrentAnimatorStateInfo(0).IsName("running attack"))
                    );
        source.PlayOneShot(sword1);

        //while (animator.GetBool("isAttacking"))
        //{
        //    if (animator.GetCurrentAnimatorStateInfo(0).IsName("standing combo 1") ||
        //            animator.GetCurrentAnimatorStateInfo(0).IsName("standing combo 2") ||
        //            animator.GetCurrentAnimatorStateInfo(0).IsName("standing combo 2") ||
        //            animator.GetCurrentAnimatorStateInfo(0).IsName("walking combo 1") ||
        //            animator.GetCurrentAnimatorStateInfo(0).IsName("walking combo 2") ||
        //            animator.GetCurrentAnimatorStateInfo(0).IsName("walking combo 3") ||
        //            animator.GetCurrentAnimatorStateInfo(0).IsName("running attack"))
        //    {
        //        source.PlayOneShot(sword1);
        //    }
        //    yield return null;
        //}

    }
}
