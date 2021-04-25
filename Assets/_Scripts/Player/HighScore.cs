using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScore : MonoBehaviour
{
    [SerializeField]private Text scoreText;
    private ScoreManager score;
    private int highScoreNumber;
    void Start()
    {
        highScoreNumber = PlayerPrefs.GetInt("HighScore");
        score = FindObjectOfType<ScoreManager>();
        scoreText.text = "High Score: " + highScoreNumber;
    }
}
