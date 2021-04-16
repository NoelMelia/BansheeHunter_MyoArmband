using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;



    void Start()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        gameOver = false;

    }

    void Update()
    {
        

        //Game Over
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
