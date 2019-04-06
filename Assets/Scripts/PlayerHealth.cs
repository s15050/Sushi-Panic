using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 3;
    public Image heart1;
    public Image heart2;
    public Image heart3;

    private int noOfHits;
    private Image[] hearts = new Image[3];

    // Start is called before the first frame update
    void Start()
    {
        noOfHits = 0;
        hearts[0] = heart1;
        hearts[1] = heart2;
        hearts[2] = heart3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("killersushi"))
        {
            if (noOfHits < lives)
            {
                hearts[noOfHits].color = Color.black;
                noOfHits++;
            }
            if (noOfHits == lives)
            {

            }
        }
    }
}
