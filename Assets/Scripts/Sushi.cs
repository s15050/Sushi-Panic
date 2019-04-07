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

    public FaceKeeper fk;

    protected bool left;

    public int sushiLifes = 1;
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

            //Sprite face = fk.FetchFace();
            Transform faceSprite = transform.GetChild(0);
            //faceSprite.GetComponent<SpriteRenderer>().sprite = face;

            //Losowanie sprite'u
            Sprite body = fk.FetchHosomaki();
            GetComponent<SpriteRenderer>().sprite = body;
        }
    }

    private void SetStartLocation()
    {
        bool left = selectedTrack.gameObject.GetComponent<Track>().isLeft; //tak jeśli jest po lewej; nie, jeśli jest po prawej

        if (left)
            transform.localPosition = new Vector2(-3f, -1.8f);
        else
            transform.localPosition = new Vector3(3f, -1.8f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInstance)
        {
            if (collision.tag.Equals("jumpPoint"))
            {
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = fk.FetchAngry();
                transform.SetParent(null);
                gameObject.tag = "killersushi";
                Jump();
            }
        }
    }

    public void Jump()
    {
        Animator anim = GetComponent<Animator>();
        anim.enabled = true;
        bool isLeft = selectedTrack.gameObject.GetComponent<Track>().isLeft;
        bool isUpper = selectedTrack.gameObject.GetComponent<Track>().isUpper;
        if (isUpper)
        {
            if (isLeft)
                anim.SetInteger("Direction", 1);
            else
                anim.SetInteger("Direction", 2);
        }
        else
        {
            if (isLeft)
                anim.SetInteger("Direction", 4);
            else
                anim.SetInteger("Direction", 3);
        }
    }

    public void Attack()
    {
        Destroy(this.gameObject);
    }

    public virtual void Hit()
    {
        sushiLifes--;
    }
}

