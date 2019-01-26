using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbody;

    private Vector3 velocity,rotation;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();

        velocity = new Vector3(0,0,0);
        rotation = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
       // CheckRotation();

        velocity.x = Input.GetAxis("Horizontal");
        velocity.z = Input.GetAxis("Vertical");

        
        rotation.x = velocity.y;
        rotation.y = velocity.x;
        rotation.z = 0;

        /*
        print(velocity);
        transform.rotation = Quaternion.LookRotation(velocity);*/

        if (velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity.normalized), 0.2f);
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        rigidbody.velocity = 3*velocity;
    }

    private void CheckRotation()
    {
        float resultingRotation = 0;
        bool isRotating = false;


        if (Input.GetAxis("Horizontal") > 0)
        {
            isRotating = true;
        }


        if (Input.GetAxis("Horizontal")< 0)
        {
            resultingRotation = (180 * Input.GetAxis("Horizontal"));
            isRotating = true;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            resultingRotation = (270 * Input.GetAxis("Vertical"));
            isRotating = true;
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            resultingRotation = -(90 * Input.GetAxis("Vertical"));
            isRotating = true;
        }

        if(isRotating)
        {
            transform.rotation = Quaternion.AngleAxis(resultingRotation, Vector3.up);
        }
    }
}
