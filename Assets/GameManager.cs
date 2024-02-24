using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    internal int score;

    public GameObject Act2ClosingScene;

    public GameObject failScreen;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Messenger.AddListener(GameEvent.Player_Died, OnDeath);
        Messenger.AddListener(GameEvent.Level_Complete, OnActComplete);
    }
    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.Player_Died, OnDeath);
        Messenger.RemoveListener(GameEvent.Level_Complete, OnActComplete);
    }

    void OnDeath()
    {
        StartCoroutine(ShowFailScreen());
    }
    void OnActComplete()
    {
        if(PlayerPrefs.GetInt("Progress") == 0)
        {
            PlayerPrefs.SetInt("Progress", 1);
        }
        Act2ClosingScene.SetActive(true);
    }

    IEnumerator ShowFailScreen()
    {
        yield return new WaitForSeconds(2.5f);
        failScreen.SetActive(true);
    }
}
