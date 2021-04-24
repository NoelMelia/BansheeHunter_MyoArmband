
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnControl : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    private int randomSpawnPoint, randomEnemy;
    public static bool spawnAllowed;
    private AudioSource source;
    public AudioClip bombenemy;
    private ScoreManager score;
    [SerializeField]private float timer;

    void Start()
    {
        score = FindObjectOfType<ScoreManager>();
        source = GetComponent<AudioSource>();
        //if (ShootToStart.IsReady)
        //{
        spawnAllowed = true;
        InvokeRepeating("SpawnEnemies", 1f, timer);// Start at 5 seconds between spawn

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
            source.PlayOneShot(bombenemy, 1.0f);
        }
    }

}
