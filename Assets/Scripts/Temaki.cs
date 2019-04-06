using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temaki : Sushi
{
    Transform target;
    Vector3 targetPos;
    public Transform player;
    private bool moving = false;
    //public float smooth = 10f;
    Transform startTransform;
    Transform child;
    float startSpeed;

    bool initialRotate = true;

    void Start()
    {
        if (isInstance)
        {
            Init();
            child = transform.GetChild(0);
            startSpeed = speed;
            startTransform = child.transform;
            if (!left)
            {
                child.eulerAngles = new Vector3(0, 180, 0);
            }
        }
    }


    void Update()
    {
        
        float rotateSpeed = speed * 2f / startSpeed;
        if (target)
        {

            moving = true;

            if(!left && initialRotate)
            {
                
                child.transform.Rotate(0, -rotateSpeed, 0);
                initialRotate = false;
            }

            if (left)
            {
                transform.Translate(transform.right * speed * 2f * Time.deltaTime);
                if (child.transform.eulerAngles.y < 180f)
                {
                    child.transform.Rotate(0, rotateSpeed, 0);
                }

            }
            else
            {
                transform.Translate(-transform.right * speed * 2f * Time.deltaTime);
                if (child.transform.eulerAngles.y < 180f)
                {
                    
                    child.transform.Rotate(0, -rotateSpeed, 0);
                }
            }
            if (Vector3.Distance(this.transform.position, targetPos) < 2.8f)
            {
                moving = false;
                target = null;
                speed = -speed;
               
                
                GetComponent<BoxCollider2D>().enabled = true;
                transform.Translate(new Vector3(0, 0, 0));
            }
        }
          
    }

    public override void Hit()
    {
        if (!moving)
        {
            sushiLifes--;
            target = target = this.GetComponentInParent<Track>().moveTarged;
            targetPos = target.transform.position;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
