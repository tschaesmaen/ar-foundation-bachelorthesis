using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(AROcclusionManager))]
[RequireComponent(typeof(ARCameraManager))]
public class ARRealismController : MonoBehaviour
{
    private AROcclusionManager m_AROcclusionManager;
    private ARCameraManager m_ARCameraManager;

    void Awake()
    {
        m_AROcclusionManager = GetComponent<AROcclusionManager>();
        m_ARCameraManager = GetComponent<ARCameraManager>();
    }

    public void ChangeQualityTo(EnvironmentDepthMode environmentDepthMode)
    {
        m_AROcclusionManager.requestedEnvironmentDepthMode = environmentDepthMode;
    }

    public EnvironmentDepthMode GetCurrentDepthMode()
    {
        return m_AROcclusionManager.requestedEnvironmentDepthMode;
    }
}
