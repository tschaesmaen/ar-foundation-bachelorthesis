using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarInteraction : MonoBehaviour
{
    private Animator anim;
    private GameObject setAvatar;

    public GameObject user;
    private bool IsJumping;

    public void Jump()
    {
        setAvatar = GameObject.FindGameObjectWithTag("Avatar");

        if (setAvatar != null)
        {
            anim = setAvatar.GetComponent<Animator>();
            anim.SetTrigger("Jump");
            IsJumping = true;
        }  
    }

    /// <summary>
    /// More interactions possible like FollowMe, Speak, Attack, ...
    /// </summary>
}
