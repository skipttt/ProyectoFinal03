using System.Collections.Generic;
using UnityEngine;

// Ret�cula y disparo
public class Gardener : MonoBehaviour
{
    public int poolSize = 10;
    public GameObject PlantPrefab;

    public List<GameObject> createdObjects;

    public Camera cam;
    public Transform origin;

    public float force = 50f;

    private GameObject plant; 

    private void Awake()
    {
        createdObjects = new List<GameObject>();
        FillObjects();
    }

    private void FillObjects()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject instance = Instantiate(PlantPrefab);
            instance.SetActive(false);
            createdObjects.Add(instance);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //bot�n izquierdo del mouse
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        plant = GetBullet();

        if (plant == null)
        {
            Debug.Log("No hay balas libres");
            return;
        }

        plant.transform.position = origin.position;
        plant.transform.rotation = origin.rotation;

        plant.SetActive(true);

        Rigidbody rb = plant.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero; //limpia la velocidad
        rb.AddForce(origin.forward * force, ForceMode.Impulse);
    }

    private GameObject GetBullet()
    {
        for (int i = 0; i < createdObjects.Count; i++)
        {
            if (!createdObjects[i].activeInHierarchy)
            {
                return createdObjects[i];
            }
        }
        return null;
    }
}







/*
// Referencia al InputAction de Move
using UnityEditor.Timeline.Actions;
using UnityEngine.InputSystem;

using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

//ret�cula y disparo

public class Reticule : MonoBehaviour
{
    public int poolSize = 5;
    public GameObject bulletPrefab;
    public List<GameObject> createdObjects;

    public InputAction moveMouseAction;
    public float speed = 3f;
    public float pos_X, pos_Y;

    public Camera cam;
    public Vector3 pos;



    private void OnEnable()
    {
        //clickAction = InputSystem.actions.FindAction("click");
        moveMouseAction = InputSystem.actions.FindAction("mousepos");

    }

    private void OnDisable()
    {

    }

    public void Update()
    {

        Vector3 clickPosition = moveMouseAction.ReadValue<Vector2>();

        //clickPosition.z = Camera.main.nearClipPlane;

        pos = cam.ScreenToWorldPoint(new Vector3(clickPosition.x, clickPosition.y, 100));
        //Debug.Log("Ahora en " + pos_X);
        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

    private void OnClick(InputAction.CallbackContext context)
    {

    }

    private void moveMouse()
    {

    }

}
*/
