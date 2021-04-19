using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    public float speed = 5f;
    
    [Tooltip("Player can only move in a certain frame.")]
    public float min_Y, max_Y;
    [SerializeField]private GameObject player_Bullet;
    [SerializeField]private Transform attack_Point;
    private float attack_Timer = 0.35f;
    private float current_Attack_Timer;
    private bool canAttack;
    private AudioSource laserAudio;
    private Rigidbody2D rb;
    private Health health;
    private bool fireOnOff = false;

    private void Awake() {
        laserAudio = GetComponent<AudioSource>();
    }
    private void Start() {
        current_Attack_Timer = attack_Timer;
        rb = GetComponent<Rigidbody2D>();
        health = FindObjectOfType<Health>();
    }
    private void Update() {
        MovePlayer();
        Attack();
        CheckingStatusFiring();
    }  
    private void MovePlayer(){
        // Movement of PLayer with Arrows
        if(Input.GetAxisRaw("Vertical") > 0f){
            // then Checking to determine if player is moved 
            // to min or max that is already set
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;

            if(temp.y > max_Y)
               temp.y = max_Y; 

            transform.position = temp;

        
        }else if(Input.GetAxisRaw("Vertical") < 0f){
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            if(temp.y < min_Y)
               temp.y = min_Y; 

            transform.position = temp;
        }
    }
    // Movement for Voice Control. Only 1 Unit though.....
    // Tried to get the player to say the amount the player would move
    public void UpSpeech(){
        Vector3 position = this.transform.position;
        position.y++;
        this.transform.position = position;
        if(position.y > max_Y)
            position.y = max_Y; 

        transform.position = position;
    }
    public void DownSpeech(){
        Vector3 position = this.transform.position;
        position.y--;
        this.transform.position = position;
        if(position.y < min_Y)
            position.y = min_Y; 

        transform.position = position;
    }
    public void Attack(){
        //Determine the player is not holding the button
        attack_Timer += Time.deltaTime;
        if(attack_Timer > current_Attack_Timer){
            canAttack = true;
        }
        //Setting a timer to the distance the bullet will appear
        if(Input.GetKeyDown(KeyCode.Space)){
            if(canAttack){
                canAttack = false;
                attack_Timer = 0.5f;
                Instantiate(player_Bullet, attack_Point.position, Quaternion.identity);

                //play the sound effect
                laserAudio.Play();
            }
        }
    }
    // Used forVoice Gesture to activate Firing or stop
    /// Firing or Stop Firing
    public void AtackSpeech(){
        fireOnOff = true;
    }
    public void StopAtackSpeech(){
        fireOnOff = false;
    }

    // Health is Updated if player is in contact with enemy or enemy bullet
    private void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Bullet" || target.tag == "Enemy"){
            // Take Damage
            health.TakeDamage(1);
        }
    }
    // Checking to see if firing is on or off
    private void CheckingStatusFiring(){
        if(fireOnOff){
            attack_Timer += Time.deltaTime;
            if(attack_Timer > current_Attack_Timer){
                canAttack = true;
            }
            if(canAttack){
                canAttack = false;
                attack_Timer = 0.1f;
                Instantiate(player_Bullet, attack_Point.position, Quaternion.identity);

                //play the sound effect
                laserAudio.Play();
            }
        }
    }
}
