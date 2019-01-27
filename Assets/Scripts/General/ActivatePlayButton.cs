using UnityEngine;

public class ActivatePlayButton : MonoBehaviour
{
    public GameObject playButton; 

   
    public void ActivateButton() 
    {
        playButton.SetActive(true);
    }

    public void PlayCurrentLevel() 
    {
        LevelManager.instance.CurrentLevelToGo();
    }
}
