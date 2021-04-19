using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class PlayerControl : MonoBehaviour
{
    public ThalmicMyo myo;

    public float speed;
    private float nextShotTime;
    public float fireRateTime;

    public GameObject Bullet;
    public Transform shotSpawn;
    private static Health health;

    private void Update()
    {
        // Takes input from fire button
        if (Input.GetButton("Fire1") || (myo.pose == Thalmic.Myo.Pose.Fist) && Time.time > nextShotTime)
        {

            nextShotTime = Time.time + fireRateTime; // calculates the time until next fire
            Instantiate(Bullet, shotSpawn.position, shotSpawn.rotation); // create shot from player ship position1
        }
		// Need to Set up Proper Shooting if i get time
    }
    
}
