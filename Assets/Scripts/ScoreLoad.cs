using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreLoad : MonoBehaviour
{

    private float wait = 0f;
    public float interval = 1000f;

    //Highscory
    public Text hs1;
    public Text hs2;
    public Text hs3;
    public Text hs4;
    public Text hs5;
    public Text hs6;
    public Text hs7;
    public Text hs8;
    public Text hs9;
    public Text hs10;

    private List<Text> hsList;

    void Start()
    {
        GetComponent<Text>().text = ScoreKeeper.getScore() + "";
        hsList = new List<Text>();
        SetHsList();
        SetHighscores();
    }

    private void SetHsList()
    {
        hsList.Add(hs1);
        hsList.Add(hs2);
        hsList.Add(hs3);
        hsList.Add(hs4);
        hsList.Add(hs5);
        hsList.Add(hs6);
        hsList.Add(hs7);
        hsList.Add(hs8);
        hsList.Add(hs9);
        hsList.Add(hs10);
    }

    private void SetHighscores()
    {
        //Załadowanie Highscorów
        int i = 1;
        foreach (Text hs in hsList)
        {
            string score = "Wynik"; //Tutaj załadowany wynik
            string spc = "";
            if (i < 10)
                spc= " ";

            hs.text = spc + i + ". "+score;
            i++;
        }
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
