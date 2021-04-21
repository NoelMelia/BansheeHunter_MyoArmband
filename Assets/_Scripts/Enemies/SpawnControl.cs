
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnControl : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    int randomSpawnPoint, randomEnemy;
    public static bool spawnAllowed;
    void Start()
    {
        //if (ShootToStart.IsReady)
        //{
            spawnAllowed = true;
            InvokeRepeating("SpawnEnemies", 1f, 5f); 

        //}

    }

    // Update is called once per frame
    void SpawnEnemies()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomEnemy], spawnPoints[randomSpawnPoint].position,
                Quaternion.identity);
        }
    }
}
