using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField]private Transform target;
    [SerializeField] private float moveSpeed = 10;
    //public GameObject explosion;
    [SerializeField]private Transform myTransform; //current transform data of this enemy
    private ScoreManager score;
    [SerializeField] private int scoreValue = 5;
    private HealthController health;


    private void Start()
    {
        health = FindObjectOfType<HealthController>();
        score = FindObjectOfType<ScoreManager>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //moveSpeed = Random.Range(5f, 10f);

    }

    private void Update()
    {
        MovingEnemy();
        if (score.increaseSpeedx2)
        {
            moveSpeed = 30;
        }
        else if (score.increaseSpeedx4)
        {
            moveSpeed = 30;
        }
        else
        {
            moveSpeed = 5;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        switch (other.gameObject.tag)
        {
            case "Player":
                // Player Take Damage
                Destroy(gameObject);
                health.TakeDamage(1);
                break;

            case "Bullet":
                // Event Happens when Bullet hits
                ProcessHit();
                Destroy(other);
                Destroy(gameObject);
                break;
        }
    }

    private void MovingEnemy()
    {
        //look
        transform.LookAt(target);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    private void ProcessHit()
    {
        score.AddToScore(scoreValue);
    }
}
