using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiCommander : MonoBehaviour
{
    private float timeElapsed;


    public float interval = 1000f;
    public Transform[] prefabList = new Transform[5];
    public Transform trackUL;
    public Transform trackLL;
    public Transform trackUR;
    public Transform trackLR;
    public Transform handsController; //for the Nigiri stun

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > interval)
        {
            int sel = Random.Range(0, prefabList.Length);
            var newSushi = Instantiate(prefabList[sel]);
            Sushi nS = null;
            if (sel == 0)
            {
                nS = newSushi.GetComponent<Sushi>();
            }
            else if (sel == 1)
            {
                nS = newSushi.GetComponent<Oshizushi>();
            }
            else if (sel == 2)
            {
                nS = newSushi.GetComponent<Temaki>();
            }
            else if (sel == 3)
            {
                nS = newSushi.GetComponent<NigiriSushi>();
            }
            nS.isInstance = true;
            nS.trackUL = trackUL;
            nS.trackLL = trackLL;
            nS.trackLR = trackLR;
            nS.trackUR = trackUR;

            timeElapsed = 0;
        }

    }
}
