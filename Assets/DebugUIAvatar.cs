using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugUIAvatar : MonoBehaviour
{
    public GameObject avatar;

    // reference the avatars x,y,z position
    public float globalPositionX;
    public float globalPositionY;
    public float globalPositionZ;

    void Start()
    {

        avatar = GameObject.FindGameObjectWithTag("Avatar");

    }

    void Update()
    {
        avatar = GameObject.FindGameObjectWithTag("Avatar");

        if (avatar != null)
        {
            // update globalPosition with player's transform position
            globalPositionX = avatar.transform.position.x;
            globalPositionY = avatar.transform.position.y;
            globalPositionZ = avatar.transform.position.z;

            TextMeshProUGUI avatarPosition = GetComponent<TextMeshProUGUI>();
            avatarPosition.text = "Global Position: " + "X: " + globalPositionX + "Y: " + globalPositionY + "Z: " + globalPositionZ;
        }
    }
}
