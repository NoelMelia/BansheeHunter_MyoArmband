using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;
public class ShootToStart : MonoBehaviour
{
    [SerializeField] private GameObject myo;
    private ThalmicMyo thalmicMyo;
    [SerializeField] private GameObject startUI;
    [SerializeField] private bool freezeTime = true;

    private static bool isReady = false;

    public static bool IsReady
    {
        get => isReady;
    }

    void Start()
    {
        thalmicMyo = myo.GetComponent<ThalmicMyo>();
        SetReadyStatus(false);
    }

    void Update()
    {
        if (isReady)
        {
            return;
        }
        else if (!PauseManager.IsPaused && Input.GetButtonDown("Fire1") || (thalmicMyo.pose == Pose.Fist))
        {
            SetReadyStatus(true);
            ExtendUnlockAndNotifyUserAction (thalmicMyo);
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
    // Extend the unlock if ThalmcHub's locking policy is standard, and notifies the given myo that a user action was
    // recognized.
    void ExtendUnlockAndNotifyUserAction (ThalmicMyo myo)
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (hub.lockingPolicy == LockingPolicy.Standard) {
            myo.Unlock (UnlockType.Timed);
        }

        myo.NotifyUserAction ();
    }
}
