﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Transform target;
    float moveSpeed;
    //public GameObject explosion;
    public Transform myTransform; //current transform data of this enemy
    private ScoreKeeper score;
    [SerializeField] private int scoreValue = 5;

    private void Start()
    {
        score = FindObjectOfType<ScoreKeeper>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        moveSpeed = Random.Range(1f, 10f);
    }

    private void Update()
    {
        MovingEnemy();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag){
            case "Player":
                // pLayer Getting hit
                Debug.Log("Player Hit");
                Destroy(gameObject);
                break;

            case "Bullet":
                // Something Happens when Bullet hits
                Debug.Log("Bullet Hit");
                ProcessHit();
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