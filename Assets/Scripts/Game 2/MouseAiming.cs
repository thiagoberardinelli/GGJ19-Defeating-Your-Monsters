using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAiming : MonoBehaviour
{ 
    Vector3 lookPos;
    Vector3 lookDir;

    public GameObject bullet;

    public Transform bulletSpawnPoint;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100))
        {
            lookPos = hit.point;
        }

        lookDir = lookPos - transform.position;
        lookDir.y = 0;

        transform.LookAt(transform.position + lookDir, Vector3.up);
        
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isAttacking", true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("isAttacking", false);
        }
    }

    public void InstantiateMagic()
    {
        StartCoroutine(WaitAndInstantiate());
    }

    IEnumerator WaitAndInstantiate()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}
