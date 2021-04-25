using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject myo = null;
    private ThalmicMyo thalmicMyo;
    [SerializeField] private float speed;
    private float nextShotTime;
    [SerializeField] private float fireRateTime;

    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform shotSpawn;
    private VolumeController sc;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private ParticleSystem muzzleFlash;

    private void Start()
    {
        sc = FindObjectOfType<VolumeController>();
    }
    private void Update()
    {
        thalmicMyo = myo.GetComponent<ThalmicMyo>();
        // Takes input from fire button
        if (Input.GetButton("Fire1") || (thalmicMyo.pose == Pose.Fist) && Time.time > nextShotTime)
        {

            nextShotTime = Time.time + fireRateTime; // calculates the time until next fire
            Instantiate(Bullet, shotSpawn.position, shotSpawn.rotation); // create shot from player ship position1

            muzzleFlash?.Play();
            sc.PlayOneShot(shootClip);
            ExtendUnlockAndNotifyUserAction(thalmicMyo);
        }
        // Need to Set up Proper Shooting if i get time
    }
    // Extend the unlock if ThalmcHub's locking policy is standard, and notifies the given myo that a user action was
    // recognized.
    void ExtendUnlockAndNotifyUserAction(ThalmicMyo myo)
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (hub.lockingPolicy == LockingPolicy.Standard)
        {
            myo.Unlock(UnlockType.Timed);
        }

        myo.NotifyUserAction();
    }

}
