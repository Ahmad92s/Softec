using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Image greenBar, orangeBar;

    [SerializeField]
    bool isBoss;

    private void Start()
    {
        Messenger.AddListener(GameEvent.Player_Damage, OnDamage);
        Messenger.AddListener(GameEvent.Boss_Damage, OnDamage);
    }
    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.Player_Damage, OnDamage);
        Messenger.RemoveListener(GameEvent.Boss_Damage, OnDamage);
    }

    void OnDamage()
    {
        float amount = 0f;
        if (isBoss)
        {
            amount = BossController.instance.info.health / 750f;
        }
        else
        {
            amount = Player.instance.health / 100f;
        }
        greenBar.DOFillAmount(amount, 0.1f);
        orangeBar.DOFillAmount(amount, 1f);
    }
}
