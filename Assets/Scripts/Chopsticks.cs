using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chopsticks : MonoBehaviour
{
    public Text scoreText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("sushi"))
        {
            //Zjedzenie sushi
            //???

            //Dodanie pktów
            int pkt = collision.gameObject.GetComponent<Sushi>().pointValue;
            score += pkt;
            ScoreKeeper.setScore(pkt);
            scoreText.text = score + "";
            //sprawdzenie zyc
            collision.gameObject.GetComponent<Sushi>().Hit();
            int lifes = collision.gameObject.GetComponent<Sushi>().sushiLifes;
            if (lifes <= 0)
                Destroy(collision.gameObject);

        }
    }
}
