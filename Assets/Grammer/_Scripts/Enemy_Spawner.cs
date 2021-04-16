using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [Tooltip("Spawning Min and Max of Enemy Ships in the Space.")]
    
    public float min_Y = -4.3f, max_Y = 4.3f;

    public GameObject[] asteroid_Prefabs;
    public GameObject enemyPrefabs;

    [SerializeField]private float spawnTime = 5.0f;
    [SerializeField]private float spawnDelay = 3.0f;

    private void Start() {
        Invoke("SpawnEnemies",  spawnTime);
    }
    private void Update() {
        if(PauseMenu.IsPaused){
            Time.timeScale = 0.0f;
        }else{
           Time.timeScale = 1.0f;   
        }
    }
    //Spawning the asteroids and enemy ships and Randoming the numerous of them
    private void SpawnEnemies(){
        float pos_Y = Random.Range(min_Y, max_Y);
        Vector3 temp = transform.position;
        temp.y = pos_Y;

        if(Random.Range(0, 2) > 0){
            Instantiate(asteroid_Prefabs[Random.Range(0, asteroid_Prefabs.Length)],
            temp, Quaternion.identity);
        }else{
            Instantiate(enemyPrefabs, temp, Quaternion.Euler(0f, 0f, 90f));
        }

        Invoke("SpawnEnemies", spawnTime);
    }
    
}
