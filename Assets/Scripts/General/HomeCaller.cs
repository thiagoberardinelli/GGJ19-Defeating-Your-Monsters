using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeCaller : MonoBehaviour
{
    public void GoToChat() 
    {
        LevelManager.instance.LoadLevel("Chat");
    }

    public void GoToHome()
    {
        LevelManager.instance.LoadLevel("Home");
    }

    public void GoToNextGame()
    {
        LevelManager.instance.CurrentLevelToGo();
    }

    public void GoToCredits()
    {
        LevelManager.instance.LoadLevel("Credits");
    }
}
