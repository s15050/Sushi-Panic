using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chopsticks : MonoBehaviour
{
    public Text scoreText;
    public PlayerHealth player;
    private int score;
    private Transform sushi;

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
            sushi = collision.gameObject.transform;
            player.Chomp();
            //Dodanie pktów
            int pkt = sushi.GetComponent<Sushi>().pointValue;
            score += pkt;
            ScoreKeeper.setScore(pkt);
            scoreText.text = score + "";
            sushi.GetComponent<Sushi>().Boom();
            sushi = null;
        }
    }
}
