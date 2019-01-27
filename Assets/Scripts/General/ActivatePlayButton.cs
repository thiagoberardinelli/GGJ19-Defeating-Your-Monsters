using UnityEngine;

public class ActivatePlayButton : MonoBehaviour
{
    public GameObject playButton;
    private LevelManager lvlManager;

    private void Start()
    {
        lvlManager = FindObjectOfType<LevelManager>();
    }

    public void ActivateButton() 
    {
        playButton.SetActive(true);
    }

    public void PlayCurrentLevel() 
    {
        lvlManager.CurrentLevelToGo();
    }
}
