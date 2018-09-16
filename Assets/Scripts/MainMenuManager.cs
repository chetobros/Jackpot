using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    public Text highScore;
    public string sceneName;
	void Start () {
        highScore.text = PlayerPrefs.GetInt("score", 0).ToString();
	}
    public void Play()
    {
        SceneManager.LoadScene(sceneName);
    }
}
