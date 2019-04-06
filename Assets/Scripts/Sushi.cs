using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sushi : MonoBehaviour
{
    public Transform trackUL;
    public Transform trackLL;
    public Transform trackUR;
    public Transform trackLR;
    public int pointValue = 10;

    private Transform selectedTrack;
    public bool isInstance = false;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform getSelectedTrack()
    {
        return selectedTrack;
    }

    public void Init()
    {
        if (isInstance)
        {
            tag = "sushi";
            Transform[] tracks = { trackUL, trackLL, trackUR, trackLR };
            int sel = Random.Range(0, 4);
            selectedTrack = tracks[sel];
            transform.SetParent(selectedTrack);
            SetStartLocation();
        }
    }

    private void SetStartLocation()
    {
        bool left = selectedTrack.gameObject.GetComponent<Track>().isLeft; //tak jeśli jest po lewej; nie, jeśli jest po prawej

        if (left)
            transform.localPosition = new Vector2(-1f, 1f);
        else
            transform.localPosition = new Vector3(1f, 1f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInstance)
        {
            if (collision.tag.Equals("jumpPoint"))
            {
                transform.SetParent(null);
                Destroy(this.gameObject);
            }
        }
    }
}
