using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    public GameObject aRPlayer;

    private void Awake()
    {
        aRPlayer = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        Vector3 targetPosition = new Vector3(aRPlayer.transform.position.x,
                                             transform.position.y,
                                             aRPlayer.transform.position.z);
        transform.LookAt(targetPosition);
    }

}
