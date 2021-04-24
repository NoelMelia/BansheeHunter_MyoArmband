using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;
public class ShootToStart : MonoBehaviour
{
    [SerializeField] private ThalmicMyo myo;
    [SerializeField] private GameObject startUI;
    [SerializeField] private bool freezeTime = true;

    private static bool isReady = false;

    public static bool IsReady
    {
        get => isReady;
    }

    void Start()
    {
        SetReadyStatus(false);
    }

    void Update()
    {
        if (isReady)
        {
            return;
        }
        else if (!PauseMenu.IsPaused && Input.GetButtonDown("Fire1") || (myo.pose == Thalmic.Myo.Pose.Fist))
        {
            SetReadyStatus(true);
        }
    }

    private void SetReadyStatus(bool status)
    {
        startUI.SetActive(!status);
        isReady = status;

        if (freezeTime)
        {
            Time.timeScale = status ? 1f : 0f;
        }
    }
}
