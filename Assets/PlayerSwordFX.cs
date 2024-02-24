using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordFX : MonoBehaviour
{
    [SerializeField]
    GameObject hitFX;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Instantiate(hitFX, other.ClosestPoint(transform.position), Quaternion.identity);
            Messenger.Broadcast(GameEvent.Player_Hit);
        }
    }
}
