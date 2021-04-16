using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private float speed = 5f;
    private float deactivate_Timer = 5.0f;

    [HideInInspector]
    public bool is_EnemyBullet = false;

    private void Start() {
        // Reverse the direction of bullet if Enemy 
        if(is_EnemyBullet)
            speed *= -1f;

        Invoke("DeactivateGameObject", deactivate_Timer);

        
    }
    private void Update() {
        Move();
    }
    //Direction of bullet with speed and movement
    void Move(){
        
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;

    }
    //Deactivate after a certan amount of time
    void DeactivateGameObject(){
        gameObject.SetActive(false);
    }
    //If the Player Bullet hits an enemy or their bullets
    private void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Bullet" || target.tag == "Enemy"){
            //Then destroy
            gameObject.SetActive(false);
        }
    }
}
