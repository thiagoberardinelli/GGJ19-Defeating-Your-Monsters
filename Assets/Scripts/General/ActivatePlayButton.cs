using UnityEngine;
using TMPro;

public class ActivatePlayButton : MonoBehaviour
{
    public GameObject playButton;
    public GameObject textMesh;
   
    public void ActivateButton() 
    {
        playButton.SetActive(true);
        textMesh.SetActive(true);
    }

    public void PlayChatScene() 
    {
        LevelManager.instance.LoadLevel("Chat");
    }

    public void ChangeWeekTest() 
    {
        textMesh.GetComponent<TextMeshProUGUI>().text = "Week " + CurrentLevel.indexLevel.ToString();
    }
}
