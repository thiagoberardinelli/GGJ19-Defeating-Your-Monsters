using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public Color endLineColor;
    public GameObject fadeIn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().canMove = false;
            Camera.main.GetComponent<CameraFollow>().StopFollow();
            Camera.main.backgroundColor = endLineColor;
            CurrentLevel.indexLevel = 4;
            StartCoroutine(PlayCutScene());
        }
    }  

    IEnumerator PlayCutScene() 
    {
        yield return new WaitForSeconds(2f);
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(2f);
        // fazer um fade in
        LevelManager.instance.LoadLevel("Chat");
    }
}
