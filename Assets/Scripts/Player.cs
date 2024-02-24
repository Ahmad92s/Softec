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
    internal int 
        smallBulletDamage,
        swordDamage,
        bigSwordDamage;

    internal bool gotHit, stunned, died;

    private void Awake()
    {
        instance = this;
    }

}
