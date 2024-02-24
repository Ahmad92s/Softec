using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    GameObject ComboGraphic;
    Vector3 comboGraphicDefPosition;
    [SerializeField]
    TextMeshProUGUI ComboText;
    [SerializeField]
    GameObject pausePanel;


    private void Start()
    {
        Time.timeScale = 1;

        if(SceneManager.GetActiveScene().name != "Act 1")
        {
            return;
        }
        comboGraphicDefPosition = ComboGraphic.transform.localPosition;

        Messenger.AddListener(GameEvent.Player_Hit, OnHit);
        Messenger.AddListener(GameEvent.Combo_Started, ShowComboCount);
        Messenger.AddListener(GameEvent.Combo_Ended, DisableComboCount);
    }
    private void OnDisable()
    {
        if (SceneManager.GetActiveScene().name != "Act 1")
        {
            return;
        }
        Messenger.RemoveListener(GameEvent.Player_Hit, OnHit);
        Messenger.RemoveListener(GameEvent.Combo_Started, ShowComboCount);
        Messenger.RemoveListener(GameEvent.Combo_Ended, DisableComboCount);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }


    public void EnableObj(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void DisableObj(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void StartNewGame()
    {
        PlayerPrefs.SetInt("Progress", 0);
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        if(SceneManager.GetActiveScene().name == "Act 1")
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                DisableObj(pausePanel);
                Camera.main.GetComponent<AudioListener>().enabled = true;

                Cursor.visible = false;
            }
            else
            {
                Time.timeScale = 0;
                EnableObj(pausePanel);
                Camera.main.GetComponent<AudioListener>().enabled = false;

                Cursor.visible = true;
            }
        }
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
