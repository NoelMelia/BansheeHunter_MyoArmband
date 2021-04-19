using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScore : MonoBehaviour
{
    [SerializeField] Text scoreText;
    private ScoreKeeper score;
    private int highScoreNumber;
    // Start is called before the first frame update
    void Start()
    {
        highScoreNumber = PlayerPrefs.GetInt("HighScore");
        score = FindObjectOfType<ScoreKeeper>();
        scoreText.text = "High Score: " + highScoreNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
