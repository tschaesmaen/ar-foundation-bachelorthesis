﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMovementTouch : MonoBehaviour
{
    public Transform startMarker;
    public Vector3 endMarker;
    public float speed = 0.8f;

    private float startTime;
    private float journeyLength;

    private Animator anim;

    void Start()
    {
        journeyLength = 0;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(journeyLength>0)
        {
            float distance = (Time.time - startTime) * speed;
            float fracJourney = distance / journeyLength;
            transform.position = Vector3.Lerp(startMarker.position, endMarker, fracJourney);

            // Rotating at the begin of the Movement
            if (fracJourney<0.1)
            {
                var lookPos = endMarker - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 20f);
            }
        }

        if(Vector3.Distance(startMarker.position, endMarker)<0.1)
        {
            anim.SetBool("IsRunning", false);
        }
    }

    // Method is called in PlaceObjectsOnPlane.cs
    public void StartMove(Vector3 endPos)
    {
        anim.SetBool("IsRunning", true);
        startMarker = this.transform;
        endMarker = endPos;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker);
    }
}
