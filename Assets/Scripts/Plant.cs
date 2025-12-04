using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    Rigidbody rb;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {        
        //rb.isKinematic = true;
        
        StartCoroutine("WaitToDisappear");
    }
    IEnumerator WaitToDisappear()
    {
        yield return new WaitForSeconds(.2f);
        gameObject.SetActive(false);
    }

}
