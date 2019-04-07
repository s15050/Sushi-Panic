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
    public Transform child;
    float startSpeed;
    private float speed;
    private bool left;
    float dir;

    bool initialRotate = true;
    bool rotate = false;

    void Start()
    {
        if (isInstance)
        {
            Init();
            child = transform.GetChild(0);
            left = this.getSelectedTrack().GetComponent<Track>().isLeft;
            speed = this.getSelectedTrack().GetComponent<Track>().speed;
            startSpeed = GetComponentInParent<Track>().speed;
            dir = GetComponentInParent<Track>().dir;
            Debug.Log(left);
            if (!left)
            {
                child.eulerAngles = new Vector3(0, 180, 0);
            }
            Sprite body = fk.FetchTemaki();
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = body;
        }
    }


    void Update()
    {
        //Debug.Log(GetComponentInParent<Track>().speed);
        
        float rotateSpeed = startSpeed * 2f / (startSpeed * 0.8f);
        if (target)
        {

            moving = true;
            if (initialRotate)
                rotate = true;
            if (!left && initialRotate)
            {

                child.transform.Rotate(0, -rotateSpeed, 0);
                initialRotate = false;
            }

            if (left)
            {
                transform.Translate(transform.right * startSpeed * 2f * Time.deltaTime);
            }
            else
            {
                transform.Translate(-transform.right * startSpeed * 2f * Time.deltaTime);
            }

            
            if (Vector3.Distance(this.transform.position, targetPos) < 2.8f)
            {
                moving = false;
                target = null;
                var newParent = GetComponentInParent<Track>().moveTarged;
                this.transform.SetParent(newParent);
                
                GetComponent<BoxCollider2D>().enabled = true;
                transform.Translate(new Vector3(0, 0, 0));
            }
        }
        if (rotate)
        {
            if (left)
            {
                
                if (child.transform.eulerAngles.y < 180f)
                {
                    child.transform.Rotate(0, rotateSpeed, 0);
                }
                else
                {
                    rotate = false;
                }

            }
            else
            {
               // transform.Translate(-transform.right * startSpeed * 2f * Time.deltaTime);
                if (child.transform.eulerAngles.y < 180f)
                {

                    child.transform.Rotate(0, -rotateSpeed, 0);
                }
                else
                {
                    rotate = false;
                }
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
