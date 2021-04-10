using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SelectObjectsOnPlane : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private GameObject aRAvatar;

    [SerializeField]
    private Camera aRCamera;

    private Vector2 touchPosition = default;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        anim = GetComponent<Animator>();
        aRCamera = Camera.main;
    }

    void Update()
    {
        aRAvatar = GameObject.FindGameObjectWithTag("Avatar");

        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = aRCamera.ScreenPointToRay(touchPosition);
                RaycastHit hitObject;

                if (!IsPointOverUIObject(touchPosition) && Physics.Raycast(ray, out hitObject))
                {
                    var select = hitObject.transform;
                    if(select.CompareTag("Avatar"))
                    {
                       
                    }
                }
            }
        }
    }


    private bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    private bool IsPointOverUIObject(Vector2 pos)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return false;

        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(pos.x, pos.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
