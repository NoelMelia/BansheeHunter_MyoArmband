using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMainMenu : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float moveSpeed = 10;
    //public GameObject explosion;
    public Transform myTransform; //current transform data of this enemy

    private void Start()
    {
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
    {
        if(other.tag == "Player"){
            Debug.Log("Player Hit");

                Destroy(gameObject);
        }
    }
}
