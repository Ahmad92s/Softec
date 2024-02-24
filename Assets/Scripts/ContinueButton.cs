using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Start()
    {
        text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        if(PlayerPrefs.GetInt("Progress") == 0)
        {
            text.color = new Color32(96, 96, 96, 255);
            GetComponent<Button>().interactable = false;
        }
    }
}
