using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int level;
    [SerializeField]private int currentScore;
    private ScoreKeeper scoreKeeper;
    [SerializeField] private int NextLevelAmount;
    [SerializeField] public bool active = false;

    private void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        
    }
    private void Update()
    {
        currentScore = scoreKeeper.currentScore;
        Debug.Log("Score " + currentScore);
        if (currentScore >= NextLevelAmount)
        {
            active = true;
            SceneManager.LoadScene(level);
        }

        
    }
}
