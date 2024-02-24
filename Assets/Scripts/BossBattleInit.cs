using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleInit : MonoBehaviour
{
    [SerializeField]
    GameObject Boss;

    private void Start()
    {
        StartCoroutine(EnableBoss());
    }

    IEnumerator EnableBoss()
    {
        yield return new WaitForSeconds(7.5f);
        Boss.SetActive(true);
    }
}
