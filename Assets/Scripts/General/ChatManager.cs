using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatManager : MonoBehaviour
{
    public GameObject fadeInEndGame;
    public GameObject fadeInChat;
    public GameObject fadeOut;    
    
    [TextArea(5,10)]
    public string [] texts;

    public TextMeshProUGUI textMeshProText;
    public TextMeshProUGUI textMeshProTextFinal; 

    public float letterPause;

    // Start is called before the first frame update

    private void OnEnable()
    {
        if (CurrentLevel.indexLevel == 4)
        {
            fadeOut.SetActive(true);
        }
    }

    void Start()
    {
        StartCoroutine(TypeSentence(texts[CurrentLevel.indexLevel - 1]));       
    }

    IEnumerator TypeSentence(string sentence)
    {
        yield return new WaitForSeconds(4f);

        sentence = sentence.Replace("\\n", "\n");
        string[] array = sentence.Split(' ');


        for (int i = 0; i < array.Length; ++i)
        {
            yield return new WaitForSeconds(letterPause);
            if(CurrentLevel.indexLevel != 4)
            {                                   
                textMeshProText.text += " " + array[i];                
            }
            else
            {
                textMeshProTextFinal.text += " " + array[i];
            }
        }

        if (CurrentLevel.indexLevel < 4)
        {
            yield return new WaitForSeconds(4f);
            fadeInChat.SetActive(true);
        }

        else if (CurrentLevel.indexLevel == 4)
        {            
            //yield return new WaitForSeconds(1f);
            //textMeshProTextFinal.enabled = false;
            //textMeshProTextFinal.text = "You:\nI got up the courage and asked for help. Now it feels like home.";
            yield return new WaitForSeconds(4f);
            fadeInEndGame.SetActive(true);
        }       
    }
}
