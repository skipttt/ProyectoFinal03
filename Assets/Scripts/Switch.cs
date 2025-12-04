using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject Weapon_1;
    public GameObject Weapon_2;

    
    void Update()
    {
        /**/if (Input.GetKeyDown(KeyCode.Tab))

        {
            //Weapon_1.GetComponent<MeshRenderer>().enabled = true;
            //Weapon_2.GetComponent<MeshRenderer>().enabled = false;

            Weapon_1.SetActive(true);
            Weapon_2.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.Q))    
        {
            //Weapon_1.GetComponent<MeshRenderer>().enabled = false;
            //Weapon_2.GetComponent<MeshRenderer>().enabled = true;

            Weapon_1.SetActive(false);
            Weapon_2.SetActive(true);
        }
    }
}
