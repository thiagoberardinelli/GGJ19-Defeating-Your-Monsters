using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = transform.forward * 6;

        Destroy(this.gameObject, 8);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
