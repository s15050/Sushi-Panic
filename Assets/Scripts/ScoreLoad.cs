using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreLoad : MonoBehaviour
{

    private float wait = 0f;
    public float interval = 1000f;

    void Start()
    {
        GetComponent<Text>().text = ScoreKeeper.getScore() + "";

    }

    void Update()
    {
        wait += Time.deltaTime;
        if (wait > interval)
        {
            if (Input.anyKeyDown)
                SceneManager.LoadScene(0);
        }

    }

}
