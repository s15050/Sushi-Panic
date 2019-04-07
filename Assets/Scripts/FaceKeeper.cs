using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceKeeper : MonoBehaviour
{
    //Twarze
    public Sprite face1;
    public Sprite face2;
    public Sprite face3;
    public Sprite face4;
    public Sprite face5;
    public Sprite face6;
    private List<Sprite> faces;

    //Hosomaki
    public Sprite hosomaki1;
    public Sprite hosomaki2;
    public Sprite hosomaki3;
    private List<Sprite> hosomakis;

    //Nigri
    public Sprite nigiri1;
    public Sprite nigiri2;
    private List<Sprite> nigiris;

    //Temaki
    public Sprite temaki;

    //Oshizushi
    public Sprite oshizushi;


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

        hosomakis = new List<Sprite>();
        hosomakis.Add(hosomaki1);
        hosomakis.Add(hosomaki2);
        hosomakis.Add(hosomaki3);

        nigiris = new List<Sprite>();
        nigiris.Add(nigiri1);
        nigiris.Add(nigiri2);
    }

    public Sprite FetchFace()
    {
        int a = Random.Range(0, 6);
        return faces[a];
    }

    public Sprite FetchHosomaki()
    {
        int a = Random.Range(0, 3);
        return hosomakis[a];
    }

    public Sprite FetchNigiri()
    {
        int a = Random.Range(0, 2);
        return nigiris[a];
    }

    public Sprite FetchTemaki()
    {
        return temaki;
    }

    public Sprite FetchOshizushi()
    {
        return oshizushi;
    }

}
