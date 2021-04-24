using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScore : MonoBehaviour
{
    [SerializeField] Text scoreText;
    private ScoreManager score;
    private int highScoreNumber;
    // Start is called before the first frame update
    void Start()
    {
        highScoreNumber = PlayerPrefs.GetInt("HighScore");
        score = FindObjectOfType<ScoreManager>();
        scoreText.text = "High Score: " + highScoreNumber;
    }
}
