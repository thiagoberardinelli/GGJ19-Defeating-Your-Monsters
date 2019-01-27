using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{

    public Animator animator;
       
    private void OnMouseDown()
    {
        animator.Play("EntryGame");
    }
}
