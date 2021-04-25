using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMainMenu : MonoBehaviour
{
    // Just for Main menu to get the ghost to go to a target point on screen
    [SerializeField]private Transform target;
    [SerializeField] private float moveSpeed = 10;

    [SerializeField]private Transform myTransform; //current transform data of this enemy

    private void Start()
    {// Find the Follow Player Target
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        MovingEnemy();
    }
    private void MovingEnemy()
    {
        //Move Towards the Player
        transform.LookAt(target);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {// Destroy the Game Object as meets target
        if(other.tag == "Player"){
            Debug.Log("Player Hit");

                Destroy(gameObject);
        }
    }
}
