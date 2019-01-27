using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timer;
    float timeLeft = 50f;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timer.text = Mathf.Round(timeLeft).ToString();
        if (timeLeft < 0)
        {
            CurrentLevel.indexLevel = 3;
        }
    }
}
