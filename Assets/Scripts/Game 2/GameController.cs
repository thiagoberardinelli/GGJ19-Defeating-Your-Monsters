using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timer;
    public GameObject fadeIn;
    public GameObject instructions;
    public float timeLeft;

    private float totalTime;

    private void Start()
    {
        totalTime = timeLeft;
    }

    void Update()
    {
        if (timeLeft < 0)
        {
            fadeIn.SetActive(true);
            CurrentLevel.indexLevel = 3;
        }
        else
        {
            timeLeft -= Time.deltaTime;
            timer.text = Mathf.Round(timeLeft).ToString();
            if (timeLeft < totalTime - 10f)
            {
                instructions.SetActive(false);
            }           
        }
    }
}
