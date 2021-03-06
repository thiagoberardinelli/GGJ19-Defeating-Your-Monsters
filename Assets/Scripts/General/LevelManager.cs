﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);       
    }

    public void LoadLevel(string levelName) // Loada o level de nome do paramentro "levelName"
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadNextLevel() // Passa obrigatoriamente para o proximo level.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel() // Restarta o level.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    } 

    public void CurrentLevelToGo() 
    {
        SceneManager.LoadScene(CurrentLevel.indexLevel);
    }

    public void LoadHomeScene()
    {
        CurrentLevel.indexLevel = 1;
        SceneManager.LoadScene("Home");
    }
}

