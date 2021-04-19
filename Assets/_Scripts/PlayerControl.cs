using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class PlayerControl: MonoBehaviour
{
	public ThalmicMyo myo;

	public float speed;
	private float nextShotTime;
	public float fireRateTime;

	public GameObject Bullet;
	public Transform shotSpawn;
	private int xtimesHit = 0;
	private int ytimesHit = 0;
	private int ztimesHit = 0;

	private float MinClamp = -50;
	private float MaxClamp = 50;

	void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			ytimesHit++;
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			ytimesHit--;
		}


		this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(xtimesHit * 90, Mathf.Clamp(ytimesHit * 10, MinClamp, MaxClamp), ztimesHit * 90), Time.deltaTime * speed);

	}
	private void Update()
    {
		// Takes input from fire button
		if (Input.GetButton("Fire1") || (myo.pose == Thalmic.Myo.Pose.Fist)  && Time.time > nextShotTime)
		{

			nextShotTime = Time.time + fireRateTime; // calculates the time until next fire
			Instantiate(Bullet, shotSpawn.position, shotSpawn.rotation); // create shot from player ship position1
		}
	}
}
