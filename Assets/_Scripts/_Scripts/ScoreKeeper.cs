using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int highScoreNum;

    [SerializeField] Text scoreText;
    [SerializeField] public int currentScore = 0;

    // Give gameobject numbers to count
    // Good idea to keep strings like this in a field, to avoid typos later.
    private const string highScoreKey = "HighScore";
    private const string scoreKey = "Score";
    public static ScoreKeeper instance;
    private NextLevel next;
    public bool increaseSpeedx2;
    public bool increaseSpeedx4;

    // set build of Score Text
    private void Start()
    {
        increaseSpeedx2 = false;
        increaseSpeedx4 = false;
        next = FindObjectOfType<NextLevel>();
        currentScore = 0;

        //currentScore = PlayerPrefs.GetInt(scoreKey, currentScore);
        scoreText.text = "Score: " + currentScore.ToString();
        highScoreNum = PlayerPrefs.GetInt(highScoreKey);
        if (next.active)
        {
            ResetGameScore();
            next.active = false;
        }
    }

    void Update()
    {
        // Updating the Text Field in display
        //scoreText.text = "Score: " + currentScore.ToString();
        //PlayerPrefs.GetInt(scoreKey, currentScore).ToString();
        PlayerPrefs.SetInt(scoreKey, currentScore);
        SetHighScore();
        // Increase the Speed of enemy to track the player
        // If over a certain score
        if (currentScore >= 100)
        {
            increaseSpeedx2 = true;
        }
        if (currentScore >= 250)
        {
            increaseSpeedx4 = true;
        }
    }
    // Reseting the Game Details awy the Player has died or Scene is ended
    public void ResetGameScore()
    {
        PlayerPrefs.SetInt(scoreKey, 0);
        currentScore = 0;
        increaseSpeedx2 = false;
        increaseSpeedx4 = false;
    }

    public void AddToScore(int score)
    {// Add the score to Test displaying on Screen
        currentScore += score;
        scoreText.text = "Score: " + currentScore.ToString();
    }
    public void SetHighScore()
    {

        // Check if our new score is greater than our previous high score.
        if (currentScore > highScoreNum)
        {
            // Change the high score to the new current value.
            highScoreNum = currentScore;
            // Update the high score UI text.
            PlayerPrefs.SetInt(highScoreKey, highScoreNum);
            PlayerPrefs.Save();
        }
    }

}
