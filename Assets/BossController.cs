using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    Enemy info;
    [SerializeField]
    GameObject forceField;

    private void Start()
    {
        info = GetComponent<Enemy>();
        Messenger.AddListener(GameEvent.Start_Boss_Attack, OnAttackStart);
    }
    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.Start_Boss_Attack, OnAttackStart);
    }


    void OnAttackStart()
    {
        StartCoroutine(MakeTemporaryInvincible());
    }


    IEnumerator MakeTemporaryInvincible()
    {
        info.invincibe = true;
        forceField.SetActive(true);
        yield return new WaitForSeconds(5.75f);
        info.invincibe = false;
        forceField.SetActive(false);
    }
}
