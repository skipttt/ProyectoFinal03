using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;  

    void Update()
    {
        Vector3 pos = target.position;
        transform.localPosition = new Vector3(pos.x, transform.position.y, pos.z);
    }

}
