using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Briars : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Plant>() != null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine("WaitToDisappear");
        }
    }

    //Este script va en el prefab
    IEnumerator WaitToDisappear()
    {
        yield return new WaitForSeconds(7f);
        gameObject.SetActive(false);
    }

}
