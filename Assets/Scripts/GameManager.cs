﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public string homeSceneName;
    public void Return()
    {
        SceneManager.LoadScene(homeSceneName);
    }
}
