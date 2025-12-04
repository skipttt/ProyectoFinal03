using Benjathemaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPrefab : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        
        //Debug.Log("ColisiónColisiónColisiónColisiónColisiónColisiónColisión");
        StartCoroutine("WaitToFall");
    }
    //Este script va en el prefab

    IEnumerator WaitToFall()
    {
        yield return new WaitForSeconds(3f);
        
        gameObject.SetActive(false);
    }

}
