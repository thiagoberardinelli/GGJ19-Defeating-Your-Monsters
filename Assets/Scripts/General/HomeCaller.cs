using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeCaller : MonoBehaviour
{
    public void GoToHome() 
    {
        LevelManager.instance.LoadLevel("Chat");
    }
}
