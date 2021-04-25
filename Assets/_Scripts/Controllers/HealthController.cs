using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthController : MonoBehaviour
{
    private int maxHealth = 5;
    [SerializeField]public int currentHealth;
    [SerializeField]public Text amountOfHealth;
    [SerializeField] private GameObject gameOverPanel;
    private static HealthController instance;
    public static bool active = false;
    
    void Start()
    {
        // Setting of the player at the beginning of Level
        currentHealth = maxHealth;
        amountOfHealth.text = "Health: " + maxHealth.ToString();
        active = false;
    }
    void Update()
    {
        // Check for amount of Health of Player
        amountOfHealth.text = "Health: " + currentHealth.ToString();
        if(currentHealth <= 0)
        {
            EndGame(); 
        }
    }
    //Player takes damage when hit by object
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        amountOfHealth.text = "Health: " + currentHealth.ToString();
    }

    private void EndGame()
    {// When the Player Dies
        active = true;
        Time.timeScale = 0f;
        
        gameOverPanel.SetActive(true);
    }
}
