using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMovementFollow : MonoBehaviour
{

    public GameObject target;
    public GameObject avatar;

    public Vector3 playerMarker;
    public Vector3 updatedPos;

    float speed = 0.5f;
    float stoppingDistance = 0.2f;
    public float distance = 0f;

    private Animator anim;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera");
        anim = GetComponent<Animator>();
    }

    public void StartFollow()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera");
        //avatar = GameObject.FindGameObjectWithTag("Avatar");

        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (target != null)
        {
            target.transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

            if (distance > stoppingDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);

                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
            }
        }
    }
}
