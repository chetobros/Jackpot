using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JackpotCells : MonoBehaviour {
    int[] cells = new int[9];
    [Header("Cells")]
    public Button[] buttons;
    public Sprite[] btnImages = new Sprite[9];
    //Game vars
    [Header("Game vars")]
    public int maxTries;
    int score = 0;
    int tries = 0;
    float time;
    //UI vars
    [Header("UI")]
    public Text scoreText;
    public Text triesText;
    public Text timeText;
    public GameObject gameOverScreen;
    public Text gameOverScore;
    public Text gameOverTime;

    bool playing = false;

    private void Start()
    {
        NewGame();
    }
    private void Update()
    {
        if (playing)
            time += Time.deltaTime;
        timeText.text = time.ToString();
    }
    public void NewGame()
    {
        score = 0;
        tries = 0;
        time = 0;
        gameOverScreen.SetActive(false);
        FillCells();
        scoreText.text = score.ToString();
        playing = true;
    }
    void FillCells()
    {
        for(int i = 0; i < 9; i++)
        {
            int auxCell = Random.Range(0, 9);
            cells[i] = auxCell;
            buttons[i].GetComponent<Cell>().value = auxCell;
        }
        SetImages();
    }
    public void ChangeCell(int pos)
    {
        switch (pos)
        {
            case 1:
                cells[0] = IncreaseCell(buttons[0].GetComponent<Cell>().value);
                cells[1] = IncreaseCell(buttons[1].GetComponent<Cell>().value);
                cells[3] = IncreaseCell(buttons[3].GetComponent<Cell>().value);
                break;
            case 2:
                cells[0] = IncreaseCell(buttons[0].GetComponent<Cell>().value);
                cells[1] = IncreaseCell(buttons[1].GetComponent<Cell>().value);
                cells[2] = IncreaseCell(buttons[2].GetComponent<Cell>().value);
                cells[4] = IncreaseCell(buttons[4].GetComponent<Cell>().value);
                break;
            case 3:
                cells[1] = IncreaseCell(buttons[1].GetComponent<Cell>().value);
                cells[2] = IncreaseCell(buttons[2].GetComponent<Cell>().value);
                cells[5] = IncreaseCell(buttons[5].GetComponent<Cell>().value);
                break;
            case 4:
                cells[0] = IncreaseCell(buttons[0].GetComponent<Cell>().value);
                cells[3] = IncreaseCell(buttons[3].GetComponent<Cell>().value);
                cells[4] = IncreaseCell(buttons[4].GetComponent<Cell>().value);
                cells[6] = IncreaseCell(buttons[6].GetComponent<Cell>().value);
                break;
            case 5:
                cells[1] = IncreaseCell(buttons[1].GetComponent<Cell>().value);
                cells[3] = IncreaseCell(buttons[3].GetComponent<Cell>().value);
                cells[4] = IncreaseCell(buttons[4].GetComponent<Cell>().value);
                cells[5] = IncreaseCell(buttons[5].GetComponent<Cell>().value);
                cells[7] = IncreaseCell(buttons[7].GetComponent<Cell>().value);
                break;
            case 6:
                cells[2] = IncreaseCell(buttons[2].GetComponent<Cell>().value);
                cells[4] = IncreaseCell(buttons[4].GetComponent<Cell>().value);
                cells[5] = IncreaseCell(buttons[5].GetComponent<Cell>().value);
                cells[8] = IncreaseCell(buttons[8].GetComponent<Cell>().value);
                break;
            case 7:
                cells[3] = IncreaseCell(buttons[3].GetComponent<Cell>().value);
                cells[6] = IncreaseCell(buttons[6].GetComponent<Cell>().value);
                cells[7] = IncreaseCell(buttons[7].GetComponent<Cell>().value);
                break;
            case 8:
                cells[4] = IncreaseCell(buttons[4].GetComponent<Cell>().value);
                cells[6] = IncreaseCell(buttons[6].GetComponent<Cell>().value);
                cells[7] = IncreaseCell(buttons[7].GetComponent<Cell>().value);
                cells[8] = IncreaseCell(buttons[8].GetComponent<Cell>().value);
                break;
            case 9:
                cells[5] = IncreaseCell(buttons[5].GetComponent<Cell>().value);
                cells[7] = IncreaseCell(buttons[7].GetComponent<Cell>().value);
                cells[8] = IncreaseCell(buttons[8].GetComponent<Cell>().value);
                break;
        }
        UpdateCells();
    }
    int IncreaseCell(int cellVal)
    {
        cellVal += 1;
        if (cellVal > 8)
        {
            cellVal -= 9;
        }
        return cellVal;
    }
    void UpdateCells()
    {
        for(int i = 0; i < cells.Length; i++)
        {
            buttons[i].GetComponent<Cell>().value = cells[i];
        }
        SetImages();
    }
    void SetImages()
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            Image img = buttons[i].transform.GetChild(0).GetComponent<Image>();
            img.sprite = btnImages[(buttons[i].GetComponent<Cell>().value)];
        }
    }
    public void Lever()
    {
        //Check center line
        if(cells[3]  == cells[4] && cells[4] == cells[5])
        {
            int correctValue = buttons[3].GetComponent<Cell>().value;
            int lines = 1;
            if (cells[0] == correctValue && cells[8] == correctValue)
                lines++;
            if (cells[2] == correctValue && cells[6] == correctValue)
                lines++;
            if (cells[0] == correctValue && cells[6] == correctValue)
                lines++;
            if (cells[1] == correctValue && cells[7] == correctValue)
                lines++;
            if (cells[2] == correctValue && cells[8] == correctValue)
                lines++;
            score += (lines * 10) * correctValue;
        }
        FillCells();
        scoreText.text = score.ToString();
        tries++;
        triesText.text = (maxTries - tries).ToString();
        if (tries == maxTries)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        playing = false;
        gameOverScreen.SetActive(true);
        gameOverScore.text = score.ToString();
        gameOverTime.text = time.ToString();
        if (PlayerPrefs.GetInt("score", 0) < score)
            PlayerPrefs.SetInt("score", score);
    }
}
