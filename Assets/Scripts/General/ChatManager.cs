using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatManager : MonoBehaviour
{
    public string [] texts;

    public TextMeshProUGUI textMeshProText;

    public TextMeshProUGUI textMeshProTextFinal;

    public float letterPause;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(TypeSentence(texts[CurrentLevel.indexLevel - 1]));
    }

    IEnumerator TypeSentence(string sentence)
    {
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

        yield return new WaitForSeconds(4f);

        LevelManager.instance.CurrentLevelToGo();
    }
}
