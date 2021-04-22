using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;
public class PauseMenu : MonoBehaviour
{
    public ThalmicMyo myo;
    [SerializeField] private GameObject menuUI;

    private KeyCode pauseKey = KeyCode.Escape;
    private ScoreKeeper sc;
    private SetVolume volume;

    private static bool isPaused = false;

    public static bool IsPaused
    {
        get => isPaused;
    }

    void Start()
    {
        myo = myo.GetComponent<ThalmicMyo> ();
        sc = FindObjectOfType<ScoreKeeper>();
        volume = FindObjectOfType<SetVolume>();
        menuUI.SetActive(false);
    }

    void Update()
    {// If Escape button is pressed
        if (Input.GetKeyDown(pauseKey) )//||(myo.pose == Thalmic.Myo.Pose.DoubleTap))
        {
            SetPauseStatus(!isPaused);
        }

    }

    void OnDisable()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Pause() => SetPauseStatus(true);
    public void Resume() => SetPauseStatus(false);

    private void SetPauseStatus(bool status)
    {// Setting the Status of th game either pause or not
        Time.timeScale = status ? 0f : 1f;
        menuUI.SetActive(status);
        isPaused = status;


        if (status)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void RestartLevel()
    // Restart Level Button to Level 1
    {
        SceneManager.LoadScene(1);
    }
    // Back to Main Menu when in Pause Menu
    public void BackToMenu()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(0);
        menuUI.SetActive(true);
    }
}
