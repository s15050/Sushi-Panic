using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashCollider : MonoBehaviour
{
    public Transform hands;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("chopsticks")) {
            Stagger();
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("jumpPoint")) {
            Destroy(this.gameObject);
        }
    }
    public void Stagger() {

        hands.GetComponent<HandsControl>().Stun();
    }
}
