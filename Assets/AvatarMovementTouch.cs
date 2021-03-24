using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMovementTouch : MonoBehaviour
{
    GameObject aRAvatar;

    public Transform startMarker;
    public Vector3 endMarker;
    public float speed = 1.0f;

    private float startTime;
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        aRAvatar = GameObject.FindGameObjectWithTag("Avatar");
        journeyLength = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(journeyLength>0)
        {
            float distance = (Time.time - startTime) * speed;
            float fracJourney = distance / journeyLength;
            transform.position = Vector3.Lerp(startMarker.position, endMarker, fracJourney);
        }
    }

    public void StartMove(Vector3 endPos)
    {
        startMarker = this.transform;
        endMarker = endPos;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker);
        Debug.Log("journeyLength is " + journeyLength);
    }
}
