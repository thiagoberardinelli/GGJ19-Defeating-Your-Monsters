using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbody;

    private Vector3 velocity,rotation;

    private Animator anim;

    public float movementSpeed;

    public bool rotate = true;

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
        velocity.x = Input.GetAxis("Horizontal");
        velocity.z = Input.GetAxis("Vertical");
        
        rotation.x = velocity.y;
        rotation.y = velocity.x;
        rotation.z = 0;

        if (velocity != Vector3.zero)
        {
            if(rotate)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity.normalized), 0.2f);
            }

            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        rigidbody.velocity = velocity.normalized * movementSpeed;
    }
}
