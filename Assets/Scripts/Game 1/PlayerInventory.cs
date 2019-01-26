using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject warningPanel;

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
                // Animacao de vitoria.
            }
        }
    }
}
