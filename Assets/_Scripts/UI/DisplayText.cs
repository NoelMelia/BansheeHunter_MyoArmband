using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    [SerializeField] private GameObject myo = null;
    private ThalmicHub hub;
    [SerializeField] private Text displayText;

    // Display details to attached to UI
    void Update()
    {
        hub = ThalmicHub.instance;

        if (Input.GetKeyDown("q"))
        {
            hub.ResetHub();
        }
        // Checking if the Myo is Linked to a User
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

        if (!hub.hubInitialized)
        {
            displayText.text = "Cannot contact Myo Connect. Is Myo Connect running?\n" +
                "Press Q to try again.";
        }
        else if (!thalmicMyo.isPaired)
        {
            displayText.text =
                "No Myo currently paired.";
        }
        else if (!thalmicMyo.armSynced)
        {
            displayText.text =
                "Perform the Sync Gesture.";
        }
        else
        {
            displayText.text =
                "Fingers spread: Relocate the Position\n" +
                "Movement: Move Arm around to Look in Screen\n" +
                "Fist: Fire Weapon";
        }
    }
}
