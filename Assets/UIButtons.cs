using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ARPlaneManager))]
[RequireComponent(typeof(ARPointCloudManager))]
[RequireComponent(typeof(AROcclusionManager))]
public class UIButtons : MonoBehaviour
{

    // BUTTON PLANE && FEATURE POINTS ENABLE/DISABLE

    void Awake()
    {
        //planeManager = GetComponent<ARPlaneManager>();
        m_ARPlaneManager = GetComponent<ARPlaneManager>();
        m_PointCloudManager = GetComponent<ARPointCloudManager>();
    }


    /// <summary>
    /// Toggles plane detection and the visualization of the planes.
    /// </summary>
    public void ToggleTrackedVisuals()
    {
        m_ARPlaneManager.enabled = !m_ARPlaneManager.enabled;
        m_PointCloudManager.enabled = !m_PointCloudManager.enabled;

        // Check if PlaneManager is enabled, and show Visuals
        if (m_ARPlaneManager.enabled)
        {
            SetAllPlanesActive(true);
        }
        else
        {
            SetAllPlanesActive(false);
        }

        // Check if PointCloudManager is enabled, and show Visuals
        if (m_PointCloudManager.enabled)
        {
            m_PointCloudManager.SetTrackablesActive(true);
            m_PointCloudManager.enabled = true;
        }
        else
        {
            m_PointCloudManager.SetTrackablesActive(false);
            m_PointCloudManager.enabled = false;
        }

    }

    /// <summary>
    /// Iterates over all the existing planes and activates
    /// or deactivates their <c>GameObject</c>s'.
    /// </summary>
    /// <param name="value">Each planes' GameObject is SetActive with this value.</param>
    void SetAllPlanesActive(bool value)
    {
        foreach (var plane in m_ARPlaneManager.trackables)
            plane.gameObject.SetActive(value);
    }

    ARPlaneManager m_ARPlaneManager;
    ARPointCloudManager m_PointCloudManager;

    // BUTTON QUIT APPLICATION

    public void QuitApplication()
    {
        Application.Quit();
    }
}
