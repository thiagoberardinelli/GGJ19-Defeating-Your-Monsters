using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] wayPoints;
    public float patrolTime;
    public float velocity;
    public float lookSpeed;


    private Vector3 currentPos;
    private Vector3 prevPos;
    private bool isGoing; // is going = true = subindo, is going = false = descendo
    private int currentWayPoint = 0;

    private Animator anim;

    private Rigidbody rigidbody;

    private void Start()
    {
        int randomtWayPoint = Random.Range(0, wayPoints.Length);
        currentWayPoint = randomtWayPoint;

        currentWayPoint = 0;
        transform.position = wayPoints[currentWayPoint].position;
        gameObject.SetActive(true);

        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        StartCoroutine(MoveTroughWayPoints());
    }

    IEnumerator MoveTroughWayPoints() 
    {
        yield return new WaitForSeconds(patrolTime);

        

        yield return StartCoroutine(Move(wayPoints[currentWayPoint].position));

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
        anim.SetBool("Moving", true);
        float elapsedTime = 0f;

        Vector3 direction;

        direction = (wayPoints[currentWayPoint].position - transform.position).normalized;

        do
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 1f * Time.deltaTime);
            rigidbody.velocity = direction * velocity;
            yield return new WaitForEndOfFrame();
        } while (Vector3.Distance(transform.position, wayPoints[currentWayPoint].position) > 1);

        anim.SetBool("Moving", false);
    }

    /*private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - prevPos), Time.fixedDeltaTime * lookSpeed);
    }*/
}
