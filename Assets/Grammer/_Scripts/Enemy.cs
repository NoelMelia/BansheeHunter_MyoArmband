using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private float speed = 5f;
    [SerializeField]private float rotate_Speed = 50f;
    private float bound_X = -11f;
    [SerializeField]private bool canShoot;
    [SerializeField]private bool canRotate;
    [SerializeField]private bool canMove = true;
    [SerializeField]private int scoreValue = 5;
    [SerializeField]private Transform attack_Point;
    [SerializeField]private GameObject bulletPrefab;

    private Animator anim;
    private AudioSource explosionSound;
    private ScoreKeeper score;

    private void Awake() {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
    }
    private void Start() {
        score = FindObjectOfType<ScoreKeeper>();
        if(canRotate){
            // Random the rotation of the asteriod when spawned
            // If the canRotate is active
            if(Random.Range(0, 2) > 0){
                rotate_Speed = Random.Range(rotate_Speed, rotate_Speed + 20f);
                rotate_Speed *= -1f;
            }else{
                rotate_Speed = Random.Range(rotate_Speed, rotate_Speed + 20f);
            }
        }

        if(canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f));
    }
    private void Update() {
        Move();
        RotateEnemy();
    }
    void Move(){
        if(canMove){
            //Movement is activated
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            // Destroy the Object outside the screen
            if(temp.x < bound_X)
                gameObject.SetActive(false);
        }
    }
    // Rotation of asteroid is determined 
    void RotateEnemy(){
        if(canRotate){
            transform.Rotate(new Vector3(0f, 0f, rotate_Speed * Time.deltaTime), Space.World);
        }
    }
    // Enemy ship to start shooting is trigger is active
    void StartShooting(){
        GameObject bullet = Instantiate(bulletPrefab, attack_Point.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().is_EnemyBullet = true;

        if(canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f));
    }
    void TurnOffGameObject(){
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D target) {
        // Once the bullet hits the enemy or asteroid then a number of 
        // options is activated. 
        // The enemy ship stops shooting, 
        // Gamobject is Destroyed,
        // Sound is played
        // Animation is played
        if(target.tag == "Bullet"){
            canMove = false;

            if(canShoot){
                canShoot = false;
                CancelInvoke("StartShooting");
            }
            Invoke("TurnOffGameObject", 0.5f);
            
            //Display explosion Sounds
            explosionSound.Play();
            anim.Play("Destroy");
            ProcessHit();
        }
    }
    // Process hit and add score to Scoreboard
    private void ProcessHit(){
        score.AddToScore(scoreValue);
    }
}
