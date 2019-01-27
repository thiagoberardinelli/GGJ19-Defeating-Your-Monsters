using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monster;

    public Animator doorAnim;

    public void Spawn()
    {
        doorAnim.SetTrigger("Open");
        Instantiate(monster, transform.position, Quaternion.identity);
    }
}
