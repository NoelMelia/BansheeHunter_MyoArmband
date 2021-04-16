using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    private int maxHealth = 5;
    [SerializeField]private int currentHealth;
    [SerializeField]public Text amountOfHealth;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private HealthBar healthBar;
    private static Health instance;
    private ScoreKeeper sc;
    public static bool active = false;
    private void Awake() {
        // Singleton
        if (instance != null){
            Destroy(this.gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        // Setting of the player at the beginning of Level
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        amountOfHealth.text =  maxHealth.ToString();
        active = false;
    }
    void Update()
    {
        // Check for amount of Health of Player
        amountOfHealth.text = currentHealth.ToString();
        if(currentHealth <= 0)
        {
            EndGame(); 
        }
    }
    //Player takes damage when hit by object
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        amountOfHealth.text = currentHealth.ToString();
    }

    private void EndGame()
    {// When the Player Dies
        active = true;
        Time.timeScale = 0f;
        ScoreKeeper.instance.ResetGameScore();
        gameOverPanel.SetActive(true);
    }
}
