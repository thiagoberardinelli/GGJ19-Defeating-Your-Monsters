using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    private void Awake()
    {
        if (FindObjectsOfType<LevelManager>().Length > 1)
        {
            Destroy(gameObject); // Destruindo possíveis duplicatas do LevelManager.
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
}

