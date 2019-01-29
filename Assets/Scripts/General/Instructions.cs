using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    private float timeLeft = 10f;
    private bool isOff;

    void Update()
    {
        if (!isOff)
        {
            if (timeLeft < 0)
            {
                gameObject.SetActive(false);
                isOff = true;
            }
            else
            {
                timeLeft -= Time.deltaTime;
            }
        }
    }
}
