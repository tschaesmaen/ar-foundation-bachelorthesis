using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;


public class SessionStatusDisplayer : MonoBehaviour
{
    //Component to display information
    private TextMeshProUGUI sessionStatusText;

    // Start is called before the first frame update
    void Start()
    {
        ARSession.stateChanged += HandleStateChanged;
        sessionStatusText = this.GetComponent<TextMeshProUGUI>();
    }

    private void HandleStateChanged(ARSessionStateChangedEventArgs statEventArguments)
    {
        switch (statEventArguments.state)
        {
            case ARSessionState.None:
                sessionStatusText.text = "Session Status: Unknown";
                break;
            case ARSessionState.Unsupported:
                sessionStatusText.text = "Session Status: ARFoundation not supported";
                break;

            case ARSessionState.CheckingAvailability:
                sessionStatusText.text = "Checking...";
                break;
            case ARSessionState.NeedsInstall:
                sessionStatusText.text = "Needs Install";
                break;
            case ARSessionState.Installing:
                sessionStatusText.text = "Installing";
                break;
            case ARSessionState.Ready:
                sessionStatusText.text = "Ready";
                break;
            case ARSessionState.SessionInitializing:
                sessionStatusText.text = "Poor SLAM Quality";
                break;
            case ARSessionState.SessionTracking:
                sessionStatusText.text = "Tracking Quality is good";
                break;
            default:
                sessionStatusText.text = "Session Status: Unknown";
                break;


        }
    }
}
