using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    GameObject ComboGraphic;
    Vector3 comboGraphicDefPosition;
    [SerializeField]
    TextMeshProUGUI ComboText;

    private void Start()
    {
        comboGraphicDefPosition = ComboGraphic.transform.localPosition;

        Messenger.AddListener(GameEvent.Player_Hit, OnHit);
        Messenger.AddListener(GameEvent.Combo_Started, ShowComboCount);
        Messenger.AddListener(GameEvent.Combo_Ended, DisableComboCount);
    }
    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.Player_Hit, OnHit);
        Messenger.RemoveListener(GameEvent.Combo_Started, ShowComboCount);
        Messenger.RemoveListener(GameEvent.Combo_Ended, DisableComboCount);
    }

    void ShowComboCount()
    {
        ComboGraphic.SetActive(true);
        //Debug.Log("Show");
        //DOTween.Kill(ComboGraphic);
        //ComboGraphic.SetActive(true);
        //ComboGraphic.transform.DOScale(1f, 0.5f);
    }
    void DisableComboCount()
    {
        ComboGraphic.SetActive(false);
        //DOTween.Kill(ComboGraphic);
        //Debug.Log("unshow");
        //ComboGraphic.transform.DOScale(0f, 0.5f).OnComplete(() =>
        //{
        //    ComboGraphic.SetActive(false);
        //});
    }

    void OnHit()
    {
        ComboText.text = "X" + ComboSystem.instance.count.ToString();
        DOTween.Kill(ComboGraphic);
        ComboGraphic.transform.DOShakePosition(0.5f, 20).OnComplete(() =>
        {
            ComboGraphic.transform.localPosition = comboGraphicDefPosition;
        });
    }
}
