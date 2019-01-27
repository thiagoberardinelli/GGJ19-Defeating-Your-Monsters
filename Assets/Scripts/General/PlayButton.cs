using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{

    public Animator animator;
    private LevelManager lvlManager;

    private void Start()
    {
        lvlManager = FindObjectOfType<LevelManager>();
    }

    private void OnMouseDown()
    {
        animator.Play("EntryGame");
    }
}
