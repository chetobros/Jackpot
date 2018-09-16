using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jackpot : MonoBehaviour {
    public Text scoreText;
    public Text triesCounterText;
    public Text timeText;
    public GameObject gameOverScreen;
    public Text gameOverScore;
    public Text gameOverTime;
    [Header("FirstColumn")]
    public Text topTextFC, bottomTextFC, buttonFC;
    [Header("SecondColumn")]
    public Text topTextSC,bottomTextSC,buttonSC;
    [Header("ThirdColumn")]
    public Text topTextTC,bottomTextTC,buttonTC;

    [SerializeField]
    int score = 0;
    int triesCounter = 0;
    float time = 0;
    bool playing = false;
    void Start () {
        NewGame();
    }
    private void Update()
    {
        if (playing)
        {
            time += Time.deltaTime;
            timeText.text = time.ToString();
        }
    }
    public void NewGame()
    {
        playing = true;
        time = 0;
        score = 0;
        triesCounter = 0;
        scoreText.text = score.ToString();
        triesCounterText.text = triesCounter.ToString();
        gameOverScreen.SetActive(false);
        topTextFC.text = ((int)Random.Range(0, 9)).ToString();
        bottomTextFC.text = ((int)Random.Range(0, 9)).ToString();
        buttonFC.text = ((int)Random.Range(0, 9)).ToString();
        topTextSC.text = ((int)Random.Range(0, 9)).ToString();
        bottomTextSC.text = ((int)Random.Range(0, 9)).ToString();
        buttonSC.text = ((int)Random.Range(0, 9)).ToString();
        topTextTC.text = ((int)Random.Range(0, 9)).ToString();
        bottomTextTC.text = ((int)Random.Range(0, 9)).ToString();
        buttonTC.text = ((int)Random.Range(0, 9)).ToString();
    }
    
    public void ChangeNumber(Text number)
    {
        int num = int.Parse(number.text);
        num++;
        if (num > 9) num = 0;
        number.text = num.ToString();
    }

    public void Lever()
    {
        //Update tries
        triesCounter++;
        triesCounterText.text = triesCounter.ToString();
        //Update Columns
        UpdateColumn(topTextFC, bottomTextFC, buttonFC);    //First Column
        UpdateColumn(topTextSC, bottomTextSC, buttonSC);    //Second Column
        UpdateColumn(topTextTC, bottomTextTC, buttonTC);    //Third Column
        //Substract center values
        int fc = int.Parse(buttonFC.text);
        int sc = int.Parse(buttonSC.text);
        int tc = int.Parse(buttonTC.text);
        //Check if win
        if(fc == sc && sc == tc)
        {
            switch (fc)
            {
                case 1: score += 100; break;
                case 2: score += 200; break;
                case 3: score += 300; break;
                case 4: score += 400; break;
                case 5: score += 500; break;
                case 6: score += 600; break;
                case 7: score += 700; break;
                case 8: score += 800; break;
                case 9: score += 900; break;
            }
            scoreText.text = score.ToString();
        }
        if (triesCounter == 3)
        {
            playing = false;
            gameOverScore.text = score.ToString();
            gameOverTime.text = time.ToString();
            gameOverScreen.SetActive(true);
        }
    }
    void UpdateColumn(Text top,Text bottom,Text center)
    {
        //Substract values
        int centerValue = int.Parse(center.text);
        int topValue = int.Parse(top.text);
        int bottomValue = int.Parse(bottom.text);
        //Update center value
        centerValue += topValue + bottomValue;
        if (centerValue > 9)
        {
            while (centerValue > 9) {
                centerValue -= 10;
            }
        }
        center.text = centerValue.ToString();
        //Update top and bottom
        top.text = ((int)Random.Range(0, 9)).ToString();
        bottom.text = ((int)Random.Range(0, 9)).ToString();
    }
}
