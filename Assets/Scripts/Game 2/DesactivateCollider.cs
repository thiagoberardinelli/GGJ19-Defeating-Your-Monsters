using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateCollider : MonoBehaviour
{

    public static float seconds = 4.5f;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(WaitAndDesactivate());
    }

    IEnumerator WaitAndDesactivate()
    {
        yield return new WaitForSeconds(seconds);
        GetComponent<BoxCollider>().isTrigger = true;

        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
