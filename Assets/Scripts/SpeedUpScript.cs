using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpScript : MonoBehaviour
{
    public int everyHowMany = 50;
    Animator anim;

    public Track trackUL;
    public Track trackLL;
    public Track trackUR;
    public Track trackLR;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ScoreKeeper.setBound(everyHowMany);
    }

    // Update is called once per frame
    void Update()
    {
        Track[] tracks = { trackUL, trackLL, trackUR, trackLR };
        if (ScoreKeeper.ShouldSpeedUp())
        {
            anim.SetTrigger("Bop");
            Debug.Log("SpeedUp");
            foreach (Track t in tracks)
            {
                t.SpeedUp();
            }
        }
    }
}
