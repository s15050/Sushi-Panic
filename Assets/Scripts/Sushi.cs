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

    private Transform selectedTrack;
    public bool isInstance = false;

    private float leftGo;
    private float upGo;
    private bool isAttacking;
    private bool isFading;
    private int iter;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {
            transform.position += new Vector3(0.5f * leftGo, 0.5f * 1.2f * upGo, 0);
        }
        else if (isFading)
        {
            iter++;
            transform.localScale -= new Vector3(0.05f, 0.05f, 0);
            if (iter == 20)
                Attack();
        }
        
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
            bool isLeft = selectedTrack.gameObject.GetComponent<Track>().isLeft;
            bool isUpper = selectedTrack.gameObject.GetComponent<Track>().isUpper;

            //Do ruchu
            if (isLeft) leftGo = 1f; else leftGo = -1f;
            if (isUpper) upGo = -1f; else upGo = 1f;
            isAttacking = false;
            isFading = false;
            iter = 0;
            

            Sprite face = fk.FetchFace();
            Transform faceSprite = transform.GetChild(0);
            faceSprite.GetComponent<SpriteRenderer>().sprite = face;

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
            if (collision.tag.Equals("jumpPoint") && (tag.Equals("sushi")))
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
        isAttacking = true;
    }

    public void Boom()
    {
        transform.SetParent(null);
        gameObject.tag = null;
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(transform.GetChild(0).GetComponent<GameObject>());
        GetComponent<SpriteRenderer>().sprite = fk.FetchBoom();
        isFading = true;

    }

    public void Attack()
    {
        Destroy(this.gameObject);
    }
}

