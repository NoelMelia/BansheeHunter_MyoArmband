using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]private Slider slider;
    private static HealthBar instance;
    // Creating an instance
    private void Awake() {
        if (instance != null){
            Destroy(this.gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Setting up the Slider info
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
