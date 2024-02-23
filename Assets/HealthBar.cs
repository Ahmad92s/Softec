using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Image greenBar, orangeBar;

    private void Start()
    {
        Messenger.AddListener(GameEvent.Player_Damage, OnDamage);
    }
    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.Player_Damage, OnDamage);
    }

    void OnDamage()
    {
        float amount = Player.instance.health / 100f;
        greenBar.DOFillAmount(amount, 0.1f);
        orangeBar.DOFillAmount(amount, 1f);
    }
}
