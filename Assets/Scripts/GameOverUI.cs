using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTextController : MonoBehaviour
{
    private TextMeshProUGUI gameOverText;
    public RestartUI restartUI;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText = GetComponent<TextMeshProUGUI>();
        gameOverText.enabled = false;
    }

    // Update is called once per frame
    public void ShowGameOverText()
    {
        gameOverText.enabled = true;
        restartUI.ShowRestartText();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restartUI.HideRestartText();
        Asteroid.score = 0;
    }
    void Update()
    {
        if (gameOverText.enabled && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
}
