using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RestartUI : MonoBehaviour
{
    private TextMeshProUGUI restartText;

    // this shows and hides the restart text
    void Start()
    {
        restartText = GetComponent<TextMeshProUGUI>();
        restartText.enabled = false;
    }
    public void ShowRestartText()
    {
        restartText.enabled = true;
    }
    public void HideRestartText()
    {
        restartText.enabled = false;
    }
}
