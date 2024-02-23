using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    GameObject ComboGraphic;

    private void Start()
    {
        Messenger.AddListener(GameEvent.Combo_Started, ShowComboCount);
        Messenger.AddListener(GameEvent.Combo_Ended, DisableComboCount);
    }
    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.Combo_Started, ShowComboCount);
        Messenger.RemoveListener(GameEvent.Combo_Ended, DisableComboCount);
    }

    void ShowComboCount()
    {
        ComboGraphic.SetActive(true);
        ComboGraphic.transform.DOScale(1f, 0.5f);
    }
    void DisableComboCount()
    {
        ComboGraphic.transform.DOScale(0f, 0.5f).OnComplete(() =>
        {
            ComboGraphic.SetActive(false);
        });
    }
}
