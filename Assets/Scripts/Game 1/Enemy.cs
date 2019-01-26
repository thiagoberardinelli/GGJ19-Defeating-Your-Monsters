using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] wayPoints;
    public float patrolTime;
    public float seconds;
    public float lookSpeed;


    private Vector3 currentPos;
    private Vector3 prevPos;
    private bool isGoing; // is going = true = subindo, is going = false = descendo
    private int currentWayPoint = 0;

    private void Start()
    {
        int randomtWayPoint = Random.Range(0, wayPoints.Length);
        currentWayPoint = randomtWayPoint;
        transform.position = wayPoints[currentWayPoint].position;
        gameObject.SetActive(true);

        StartCoroutine(MoveTroughWayPoints());
    }

    IEnumerator MoveTroughWayPoints() 
    {
        yield return new WaitForSeconds(patrolTime);

        StartCoroutine(Move(wayPoints[currentWayPoint].position));

        yield return new WaitForSeconds(seconds);

        if (currentWayPoint == wayPoints.Length - 1) 
        {
            isGoing = false;
            currentWayPoint--;
        }
        else if (currentWayPoint < wayPoints.Length - 1 && currentWayPoint > 0) 
        {
            if (isGoing == false)
            {
                currentWayPoint--;
            }
            else 
            {
                currentWayPoint++;
            }
        }
        else if (currentWayPoint == 0) 
        {
            isGoing = true;
            currentWayPoint++;
        }
        StartCoroutine(MoveTroughWayPoints());
    }

    IEnumerator Move(Vector3 nextPosition)
    {
        float elapsedTime = 0f;

        Vector3 originalPos = transform.position;

        while (elapsedTime < seconds) 
        { 
            transform.position = Vector3.Lerp(originalPos, nextPosition, elapsedTime/seconds);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    /*private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - prevPos), Time.fixedDeltaTime * lookSpeed);
    }*/
}
