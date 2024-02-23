using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    int waveNumber = 0,
        totalWaves = 0;
    [SerializeField]
    Transform[] waves;
    [SerializeField]
    Animator waveInfoAnimator;
    [SerializeField]
    TextMeshProUGUI waveInfoText;

    bool levelEnded;

    private void Awake()
    {
        totalWaves = waves.Length;
    }

    private void Update()
    {
        if (levelEnded)
        {
            return;
        }

        CheckWaveStatus();
    }


    IEnumerator UpdateWave()
    {
        waves[waveNumber].gameObject.SetActive(false);
        waveNumber++;

        if(waveNumber >= totalWaves)
        {
            //finish level
            levelEnded = true;
            yield return new WaitForSeconds(2);
            Messenger.Broadcast(GameEvent.Level_Complete);
        }
        else
        {
            yield return new WaitForSeconds(2);
            waveInfoText.text = "WAVE " + (waveNumber + 1).ToString();
            waveInfoAnimator.SetTrigger("Swoosh");
            waves[waveNumber].gameObject.SetActive(true);
        }
    }

    void CheckWaveStatus()
    {
        int aliveEnemies = 0;
        for (int i = 0; i < waves[waveNumber].childCount; i++)
        {
            if (waves[waveNumber].GetChild(i).GetComponent<BoxCollider>().enabled)
            {
                aliveEnemies++;
            }
        }

        if (aliveEnemies == 0)
        {
            StartCoroutine(UpdateWave());
        }
    }
}
