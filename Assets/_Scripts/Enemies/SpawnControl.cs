
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnControl : MonoBehaviour
{
    [SerializeField]private Transform[] spawnPoints;
    [SerializeField]private GameObject[] enemies;
    private int randomSpawnPoint, randomEnemy;
    [SerializeField]private static bool spawnAllowed;
    private AudioSource sound;
    [SerializeField]private AudioClip bombenemy;
    [SerializeField]private float timer;

    void Start()
    {
        sound = GetComponent<AudioSource>();

        spawnAllowed = true;
        InvokeRepeating("SpawnEnemies", 1f, timer);
        // Start at 5 seconds between spawn
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
            sound.PlayOneShot(bombenemy, 1.0f);
        }
    }

}
