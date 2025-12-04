using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script va en el main player, se tiene que asignar el minimapa
public class MinimapPlayer : MonoBehaviour
{
    public GameObject minimap;  

    private bool isVisible = true;

    void Update()
    {
        // Shift izquierdo o derecho
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isVisible = !isVisible;
            minimap.SetActive(isVisible);
        }
    }
}
