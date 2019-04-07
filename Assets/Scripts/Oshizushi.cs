using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oshizushi : Sushi
{

    public float rotation = 100f;
    private float currentRotation = 90f;
    private bool left;
    

    Animator anim;

    void Start()
    {
        if (isInstance)
        {
            Init();
            setRotationDirection();
            InvokeRepeating("Rotate", 2f, 2f);
            anim = transform.GetChild(0).GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (left)
            anim.SetBool("isLeft", true);
    }

    private void Rotate()
    {
        //this.transform.Rotate(0, 0, 90);
        /*var child = transform.GetChild(0);
        var rotationLimit = 360f;
        if (left)
        {
            rotationLimit = -rotationLimit;
            if (child.rotation.z < rotationLimit)
            {
                child.eulerAngles = new Vector3(0, 0, 0);
                currentRotation = -90f;
            }
        }
        if (child.rotation.z > rotationLimit)
        {
            child.eulerAngles = new Vector3(0, 0, 0);
            currentRotation = 90f;
        }
        Debug.Log("here");
        //child.transform.Rotate(0, 0, rotation * Time.deltaTime);
        while (child.rotation.z < currentRotation)
            transform.GetChild(0).transform.Rotate(0, 0, rotation * Time.deltaTime);
        currentRotation += 90f;*/
    }

    private void setRotationDirection()
    {
        if (left)
        {
            rotation = -rotation;
            currentRotation = -currentRotation;
        }
    }


}
