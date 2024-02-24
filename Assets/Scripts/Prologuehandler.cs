using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prologuehandler : MonoBehaviour
{
    public float prologueTime = 79;
    public string nextScene;

    private void Start()
    {
        StartCoroutine(ChangeScene(nextScene));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    IEnumerator ChangeScene(string sceneName)
    {
        yield return new WaitForSeconds(prologueTime);
        SceneManager.LoadScene(sceneName);
    }
}
