using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NigiriSushi : Sushi
{
    // Start is called before the first frame update
    void Start()
    {
        
        this.pointValue = 20;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("jumpPoint")) {
            bool isL = this.getSelectedTrack().GetComponent<Track>().isLeft;
            bool isU = this.getSelectedTrack().GetComponent<Track>().isUpper;
            this.Attack(isL, isU);
        }
    }
    
}