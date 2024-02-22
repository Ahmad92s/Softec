using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    internal bool gotHit, died;
    internal float timeSinceLastHit, coolDownTime = 1f;

    [SerializeField]
    GameObject destroyFX;

    private void Update()
    {
        timeSinceLastHit += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerSword")
        {
            health -= Player.instance.attackPower;
            gotHit = true;
            timeSinceLastHit = 0f;
            if(health <= 0)
            {
                died = true;
                StartCoroutine(Die(other));
            }
        }
    }

    IEnumerator Die(Collider other)
    {
        Instantiate(destroyFX, transform.position, Quaternion.identity);
        var rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(-transform.forward * 200f);
        yield return new WaitForSeconds(0.8f);
        
        rb.isKinematic = true;
        GetComponent<BoxCollider>().enabled = false;

    }
}
