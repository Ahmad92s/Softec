using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveText : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        if(PlayerPrefs.GetInt("Progress") == 2)
        {
            text.text = "Mr. Dollar Dollar";
            text.fontSize = 122f;
        }
    }
}
