using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float sensibilidad = 100f;

    public float RotationHorizontal = 0f;
    public float RotationVertical = 0f;
    public Transform player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //para que no se vea el cursor en pantalla
        Cursor.visible = false;
    }

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        RotationHorizontal += MouseX;
        RotationVertical -= MouseY;

        RotationVertical = Mathf.Clamp(RotationVertical, -90f, 90f);

        transform.localRotation = Quaternion.Euler(RotationVertical, 0f, 0f);
        player.Rotate(Vector3.up * MouseX);
    }
}
