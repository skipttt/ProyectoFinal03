using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este codigo va en el prefab, se cambia el colorCode a la gema correspondiente

public class EnergyRock : MonoBehaviour
{
    public int colorCode = 0; // Default Emerald
    // Color Coding:
    // 0 - Emerald
    // 1 - Diamond
    // 2 - Ruby
    // 3 - Saphire


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MainPlayer>() != null)
        {
            //  gameObject.SetActive(false);
            Debug.Log("Inside the player");
        }
    }

}
