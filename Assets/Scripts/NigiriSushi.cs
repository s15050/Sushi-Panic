using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NigiriSushi : Sushi
{
    public GameObject slashColliderL;
    public GameObject slashColliderR;
    // Start is called before the first frame update
    void Start()
    {
        Init();
        this.pointValue = 20;
        if (isInstance) {
            if (this.getSelectedTrack().GetComponent<Track>().isLeft)
            {
                Destroy(slashColliderL);
            }
            else { Destroy(slashColliderR); }
        }
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("jumpPoint")) {
            bool isL = this.getSelectedTrack().GetComponent<Track>().isLeft;
            bool isU = this.getSelectedTrack().GetComponent<Track>().isUpper;
            this.Attack(isL, isU);
            Destroy(this.gameObject);
        }
    }
    


}