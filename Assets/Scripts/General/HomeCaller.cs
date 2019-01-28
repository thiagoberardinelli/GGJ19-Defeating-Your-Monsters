using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeCaller : MonoBehaviour
{
    public void GoToChat() 
    {
        LevelManager.instance.LoadLevel("Chat");
    }
}
