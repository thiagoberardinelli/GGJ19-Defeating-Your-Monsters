using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject warningPanel;
    public GameObject warningPanel2;
    public Animator doorAnim;

    public GameObject snack;

    private bool hasKey;
    private bool hasSnack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            hasKey = true;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Snack")
        {
            hasSnack = true;
            Destroy(other.gameObject);
        }

        else if (other.tag == "Room") 
        { 
            if (hasKey == false) 
            {
                warningPanel.SetActive(true);

            }
            else 
            {
                snack.SetActive(true);

                if (hasSnack)
                {
                    doorAnim.SetTrigger("EndLevel");
                    CurrentLevel.indexLevel = 2;
                }
                else
                {
                    warningPanel2.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Room") 
        {
            warningPanel.SetActive(false);
            warningPanel2.SetActive(false);
        }
    }
}
