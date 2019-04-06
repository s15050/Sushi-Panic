using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceKeeper : MonoBehaviour
{
    public Sprite face1;
    public Sprite face2;
    public Sprite face3;
    public Sprite face4;
    public Sprite face5;
    public Sprite face6;
    private List<Sprite> faces;

    // Start is called before the first frame update
    void Start()
    {
        faces = new List<Sprite>();
        faces.Add(face1);
        faces.Add(face2);
        faces.Add(face3);
        faces.Add(face4);
        faces.Add(face5);
        faces.Add(face6);
    }

    public Sprite FetchFace()
    {
        int a = Random.Range(0, 6);
        return faces[a];
    }
}
