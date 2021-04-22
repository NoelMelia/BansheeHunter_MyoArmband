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

    private SetVolume sc;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private ParticleSystem muzzleFlash;

    private void Start() {
        sc = FindObjectOfType<SetVolume>();
    }
    private void Update()
    {
        myo = myo.GetComponent<ThalmicMyo>();
        // Takes input from fire button
        if (Input.GetButton("Fire1") || (myo.pose == Thalmic.Myo.Pose.Fist) && Time.time > nextShotTime)
        {

            nextShotTime = Time.time + fireRateTime; // calculates the time until next fire
            Instantiate(Bullet, shotSpawn.position, shotSpawn.rotation); // create shot from player ship position1
            
            muzzleFlash?.Play();
            sc.PlayOneShot(shootClip);
        }
        // Need to Set up Proper Shooting if i get time
    }

}
