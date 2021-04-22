using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float moveSpeed = 10;
    //public GameObject explosion;
    public Transform myTransform; //current transform data of this enemy
    private ScoreKeeper score;
    [SerializeField] private int scoreValue = 5;
    private Health health;


    private void Start()
    {
        health = FindObjectOfType<Health>();
        score = FindObjectOfType<ScoreKeeper>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //moveSpeed = Random.Range(5f, 10f);
    }

    private void Update()
    {
        MovingEnemy();
        if (score.increaseSpeedx2)
        {
            moveSpeed = 30;
        }else if(score.increaseSpeedx4){
            moveSpeed = 30;
        }else{
            moveSpeed = 5;
        }
        Debug.Log("Move Speed " + moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                // pLayer Getting hit

                Destroy(gameObject);
                health.TakeDamage(1);
                break;

            case "Bullet":
                // Something Happens when Bullet hits
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
