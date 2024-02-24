using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    internal int score;

    public GameObject 
        Act2ClosingScene,
        BossBattleClosingScene;

    public GameObject failScreen;

    [SerializeField]
    GameObject Act1, BossBattle;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Time.timeScale = 1f;

        if (PlayerPrefs.GetInt("Progress") == 0)
        {
            PlayerPrefs.SetInt("Progress", 1);
        }

        if(PlayerPrefs.GetInt("Progress") == 1)
        {
            Act1.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Progress") == 2)
        {
            BossBattle.SetActive(true);
        }

        Messenger.AddListener(GameEvent.Player_Died, OnDeath);
        Messenger.AddListener(GameEvent.Level_Complete, OnActComplete);
        Messenger.AddListener(GameEvent.Boss_Died, OnBossDied);
    }
    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.Player_Died, OnDeath);
        Messenger.RemoveListener(GameEvent.Level_Complete, OnBossDied);
    }

    void OnDeath()
    {
        StartCoroutine(ShowFailScreen());
    }
    void OnActComplete()
    {
        if(PlayerPrefs.GetInt("Progress") == 1)
        {
            PlayerPrefs.SetInt("Progress", 2);
        }
        Act2ClosingScene.SetActive(true);
    }
    void OnBossDied()
    {
        BossBattleClosingScene.SetActive(true);
        StartCoroutine(FreezeGame());
    }
    IEnumerator FreezeGame()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
    }

    IEnumerator ShowFailScreen()
    {
        yield return new WaitForSeconds(2.5f);
        failScreen.SetActive(true);
    }
}
