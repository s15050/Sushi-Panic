using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    public float interval = 1f;
    public int sceneId;
    private float timeElapsed;
    private float blinkTime;
    private float halfInterval;

    public Text bg1;
    public Text bg2;
    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
        blinkTime = 0;
        halfInterval = interval / 2;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        blinkTime += Time.deltaTime;
        if (timeElapsed > interval)
            if (Input.anyKey)
                SceneManager.LoadScene(sceneId);

        //Miganie
        if (blinkTime > halfInterval)
        {
            Text txt = GetComponent<Text>();
            if (txt.enabled)
            {
                txt.enabled = false;
                bg1.enabled = false;
                bg2.enabled = false;
            }
            else
            {
                txt.enabled = true;
                bg1.enabled = true;
                bg2.enabled = true;
            }
            blinkTime = 0;
        }
    }
}
