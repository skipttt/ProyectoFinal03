using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int poolSize = 5;
    public float Height = 10;

    public GameObject spherePrefab; //Esto es lo que instanciará
    public List<GameObject> createdObjects; //lista de instancias

    private void Awake()
    {
        //Debug.Log("Awake");
        createdObjects = new List<GameObject>();
        FillObjects();

    }

    public void FillObjects()
    {
        //Debug.Log("Fill objects");
        for (int i = 0; i < poolSize; i++)
        {
          
            GameObject instancedObject = Instantiate(spherePrefab);
            instancedObject.SetActive(false);
            createdObjects.Add(instancedObject);
        }

    }

    void Update()
    {
        GetObject();
    }

    public GameObject GetObject() 
    {
        //Debug.Log("GET objects");
        for (int i = 0; i < createdObjects.Count; i++)
        {
            if (!createdObjects[i].activeInHierarchy) //si no está activo el objeto en la jerarquía:
            {
                //Vector3 posMap = new Vector3(Random.Range(-5f, 5f), 10, Random.Range(-5f, 5f));

                createdObjects[i].transform.position = new Vector3(Random.Range(-30f, 30f), Height, Random.Range(-30f, 30f));
                createdObjects[i].SetActive(true);
                return createdObjects[i];
            }
        }
        //si no detecta ninguno inactivo:
        return null;

    }
}
