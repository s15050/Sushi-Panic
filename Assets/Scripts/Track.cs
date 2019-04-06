using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Track : MonoBehaviour
{
    public bool isUpper;
    public bool isLeft;
    public float speed = 2f;
    public float dir; // 1 = ruch w prawo, -1 = ruch w lewo

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.transform.position += new Vector3(dir * speed * Time.deltaTime, 0);
        }
    }
}
