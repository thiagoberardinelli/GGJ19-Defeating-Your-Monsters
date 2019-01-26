using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;
    private bool stopCam;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopCam) 
        { 
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, player.position.z + offset.z);
            transform.position = newPosition;        
        }
    } 

    public void StopFollow() 
    {
        StartCoroutine(StopFollowCourotine());
    }

    IEnumerator StopFollowCourotine() 
    {
        yield return new WaitForSeconds(1.5f);
        stopCam = true;
    }

}
