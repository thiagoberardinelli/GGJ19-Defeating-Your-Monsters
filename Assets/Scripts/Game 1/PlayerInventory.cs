using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject warningPanel;
    public Animator doorAnim;

    private bool hasKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
            hasKey = true;
        else if (other.tag == "Room") 
        { 
            if (hasKey == false) 
            {
                warningPanel.SetActive(true);
            }
            else 
            {
                doorAnim.SetTrigger("EndLevel");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Room") 
        { 
            if (hasKey == false) 
            {
                warningPanel.SetActive(false);
            }
        }
    }
}
