using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatManager : MonoBehaviour
{
    public GameObject fadeInChat;
    public GameObject fadeOut;

    public string [] texts;

    public TextMeshProUGUI textMeshProText;

    public TextMeshProUGUI textMeshProTextFinal;

    public float letterPause;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TypeSentence(texts[CurrentLevel.indexLevel - 1]));
        fadeOut.SetActive(true);
    }

    IEnumerator TypeSentence(string sentence)
    {
        yield return new WaitForSeconds(4f);

        sentence = sentence.Replace("\\n", "\n");
        string[] array = sentence.Split(' ');
        textMeshProText.text = array[0];
        
        for (int i = 1; i < array.Length; ++i)
        {
            yield return new WaitForSeconds(letterPause);
            if(CurrentLevel.indexLevel < 4)
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
            //LevelManager.instance.CurrentLevelToGo();
        }
    
    }
}
