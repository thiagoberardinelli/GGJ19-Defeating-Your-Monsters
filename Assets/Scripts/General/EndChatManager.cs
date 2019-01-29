using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndChatManager : MonoBehaviour
{
    [TextArea(5, 10)]
    public string[] texts;
    public TextMeshProUGUI textMeshProText;
    public float letterPause;
    public float sentencesPause;

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TypeSentence(texts[index]));
    }

    IEnumerator TypeSentence(string sentence)
    {
        yield return new WaitForSeconds(1f);

        sentence = sentence.Replace("\\n", "\n");
        string[] array = sentence.Split(' ');
        textMeshProText.text = array[0];

        for (int i = 1; i < array.Length; ++i)
        {
            yield return new WaitForSeconds(letterPause);
            textMeshProText.text += " " + array[i];
        }
        yield return new WaitForSeconds(sentencesPause);

        if (index < texts.Length)
        {
            index++;
            StartCoroutine(TypeSentence(texts[index]));
        }        
    }
}
