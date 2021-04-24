﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public static float speed = 5f;

	public Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate()
	{
		rb.MovePosition(transform.position + transform.forward * speed);
	}
	private void OnTriggerEnter(Collider other)
    {// Destroy Bullet outside Room
        if(other.tag == "Obstacles"){
            Debug.Log("Bullet Hit");

            Destroy(gameObject);
        }
    }
}
