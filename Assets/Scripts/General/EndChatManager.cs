using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class EndChatManager : MonoBehaviour
{
    [TextArea(5, 10)]
    public string[] texts;
    public TextMeshProUGUI textMeshProText;
    public TextMeshProUGUI ggjHashtag;
    public Color ggjHastagColor;
    public float letterPause;
    public float sentencesPause;

    [Header("Buttons")]
    public GameObject homeButton;
    public GameObject quitButton;

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

        if (index < texts.Length - 1)
        {
            index++;
            StartCoroutine(TypeSentence(texts[index]));
        }

        else
        {
            ggjHashtag.text = "<size=150%>#GGJ19";
            ggjHashtag.color = ggjHastagColor;
            homeButton.SetActive(true);
            quitButton.SetActive(true);
        }
    }
}
