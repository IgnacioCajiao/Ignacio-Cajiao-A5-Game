using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RestartUI : MonoBehaviour
{
    private TextMeshProUGUI restartText;
    // Start is called before the first frame update
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
