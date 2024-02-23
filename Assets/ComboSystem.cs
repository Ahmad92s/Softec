using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    internal int count = 0;
    public float coolDownTime;
    float timeSinceLastHit;

    private void Start()
    {
        count = 0;

        Messenger.AddListener(GameEvent.Player_Hit, OnHit);
    }
    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.Player_Hit, OnHit);
    }

    private void Update()
    {
        if(timeSinceLastHit > coolDownTime)
        {
            count = 0;
            Messenger.Broadcast(GameEvent.Combo_Ended);
        }
        else
        {
            timeSinceLastHit += Time.deltaTime;
            Debug.Log(timeSinceLastHit);
        }
    }

    void OnHit()
    {
        count++;
        if(count == 1)
        {
            Messenger.Broadcast(GameEvent.Combo_Started);
        }
        GameManager.instance.score += count * 50;
        timeSinceLastHit = 0;
        Debug.Log(count);
    }


}
