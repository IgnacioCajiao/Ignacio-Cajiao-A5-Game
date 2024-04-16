using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // displays asteroid score ingame 
    void Update()
    {
        scoreText.text = "Score: " + Asteroid.score;
    }
}
