using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ARPlaneManager))]
[RequireComponent(typeof(AROcclusionManager))]
public class UIButtons : MonoBehaviour
{

    // PLANE ENABLE/DISABLE
    private ARPlaneManager planeManager;
    [SerializeField]
    private Text togglePlaneBtnText;

    private void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
        togglePlaneBtnText.text = "Hide Planes";
    }

    // BUTTON PLANE ENABLE/DISABLE

    public void TogglePlaneDetection()
    {
        planeManager.enabled = !planeManager.enabled;
        string toggleButtonMessage = "";

        if(planeManager.enabled)
        {
            toggleButtonMessage = "Hide Planes";
            SetAllPlanesActive(true);
        }
        else
        {
            toggleButtonMessage = "Show Planes";
            SetAllPlanesActive(false);
        }

        togglePlaneBtnText.text = toggleButtonMessage;
    }

    private void SetAllPlanesActive(bool value)
    {
        foreach(var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }

    // BUTTON QUIT APPLICATION

    public void QuitApplication()
    {
        Application.Quit();
        
    }
}
