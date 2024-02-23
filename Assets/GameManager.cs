using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    internal int score;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Messenger.AddListener(GameEvent.Player_Died, OnDeath);
    }
    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.Player_Died, OnDeath);
    }

    void OnDeath()
    {

    }
}
