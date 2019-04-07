using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 3;
    public Image heart1;
    public Image heart2;
    public Image heart3;

    private int noOfHits;
    private Image[] hearts = new Image[3];

    public AudioClip impact;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        noOfHits = 0;
        hearts[0] = heart1;
        hearts[1] = heart2;
        hearts[2] = heart3;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Chomp()
    {
        GetComponent<Animator>().SetTrigger("Bobbity");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.PlayOneShot(impact);
        if (collision.tag.Equals("killersushi"))
        {
            if (noOfHits < lives)
            {
                hearts[noOfHits].color = Color.black;
                noOfHits++;
                collision.gameObject.GetComponent<Sushi>().Attack();
            }
            if (noOfHits == lives)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
