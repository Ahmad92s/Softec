using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public int 
        health = 100,
        attackPower = 15;

    [SerializeField]
    internal int smallBulletDamage;

    internal bool gotHit;

    private void Awake()
    {
        instance = this;
    }

}
