using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiCommander : MonoBehaviour
{
    private float timeElapsed;

    
    public float interval = 1000f;
    public Transform[] prefabList = new Transform[4];
    public Transform trackUL;
    public Transform trackLL;
    public Transform trackUR;
    public Transform trackLR;
    public Transform PlayerController; //for the Nigiri stun

    public FaceKeeper fk;

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
            switch (sel) {
                case 0: nS = newSushi.GetComponent<Sushi>(); break;
                case 1: nS = newSushi.GetComponent<Sushi>(); break;
                case 2: nS = newSushi.GetComponent<Sushi>(); break;
                case 3: nS = newSushi.GetComponent<Oshizushi>(); break;
                case 4: nS = newSushi.GetComponent<Temaki>(); break;
                default: nS = newSushi.GetComponent<Sushi>(); break;
            }
            //if (sel == 0)
            //{
            //    nS = newSushi.GetComponent<Sushi>();
            //}
            
            nS.isInstance = true;
            nS.trackUL = trackUL;
            nS.trackLL = trackLL;
            nS.trackLR = trackLR;
            nS.trackUR = trackUR;
            nS.fk = fk;

            timeElapsed = 0;
        }

    }
}
