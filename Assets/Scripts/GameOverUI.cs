using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTextController : MonoBehaviour
{
    private TextMeshProUGUI gameOverText;
    public RestartUI restartUI;

    void Start()
    {
        gameOverText = GetComponent<TextMeshProUGUI>();
        gameOverText.enabled = false;
    }

    // this shows the restart text on game over
    public void ShowGameOverText()
    {
        gameOverText.enabled = true;
        restartUI.ShowRestartText();
    }
    // this reset the game, hides the restart text and resets the score
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restartUI.HideRestartText();
        Asteroid.score = 0;
    }
    // if the game is over and you press R game restarts
    void Update()
    {
        if (gameOverText.enabled && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
}
