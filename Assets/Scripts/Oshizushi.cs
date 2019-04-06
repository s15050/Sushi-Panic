using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oshizushi : Sushi
{

    public float rotation = 100f;

    void Start()
    {
        Init();
        setRotationDirection();
    }

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.GetChild(0).transform.Rotate(0, 0, rotation * Time.deltaTime);
    }

    private void setRotationDirection()
    {
        if (left)
        {
            rotation = -rotation;
        }
    }


}
