using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AvatarMovement : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform gamePad;
    public float moveSpeed = 0.5f;

    GameObject aRAvatar;
    Vector3 move;

    bool walking;

    void Start()
    {
        aRAvatar = GameObject.FindGameObjectWithTag("Avatar");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        transform.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)gamePad.position, gamePad.rect.width * 0.5f);

        move = new Vector3(transform.localPosition.x, 0f, transform.localPosition.y).normalized; // no movement in y

        if(!walking)
        {
            walking = true;
            //aRAvatar.GetComponent<Animator>().SetBool("Walk", true); // on drag start the walk animation
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(PlacedObjectMovement()); // do the movement when touched down
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero; // Joystick return to base when not touched
        move = Vector3.zero;
        StopCoroutine(PlacedObjectMovement());
        walking = false;
        //aRAvatar.GetComponent<Animator>().SetBool("Walk", false);
    }

    IEnumerator PlacedObjectMovement()
    {
        while(true)
        {
            aRAvatar.transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

            if(move != Vector3.zero)
        
                aRAvatar.transform.rotation = Quaternion.Slerp
                    (aRAvatar.transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * 1f);

            yield return null;

        }
    }
}
