using System.Collections.Generic;
using TMPro;

using UnityEngine;

// Gravity Gun
public class GravityGun : MonoBehaviour
{
    private Transform cam;
    private Transform objectHold;
    private Transform objectAim;

    private float distance = 9f;
    private bool holdingObject;

    private bool holdEnabled = true;

    private void Awake()
    {
        cam = transform.parent;
        //_armAC =transform.Find("Arms").GetComponent<Animator>();
    }


    void Update()
    {
        bool isAimingToObject = isAimingObject();

        if(isAimingToObject)
        {
            if(Input.GetMouseButton(1)) //botón derecho del mouse
            {
                if(!holdingObject && holdEnabled)
                {
                    float d = Vector3.Distance(objectAim.position, transform.position);
                    if(d>2f)
                    {
                        float force = 3f;
                        Vector3 dirToPlayer = cam.position - objectAim.position;
                        Rigidbody rb = objectAim.GetComponent<Rigidbody>();
                        rb.AddForce(dirToPlayer * force, ForceMode.Force);
                    }
                    else
                    {
                        LockObject();
                    }

                }
                
            }
        }

        if(holdingObject)
        {
            if (Input.GetMouseButtonDown(1)) //botón derecho del mouse
            {
                // esto lo suelta
                ReleaseObject(Vector3.zero);
            }
            else if(Input.GetMouseButtonDown(0))  //botón izquierdo del mouse
            {
                //esto lo lanza
                ReleaseObject((transform.forward + Vector3.up * 0.2f).normalized * 20f);
            }
        }
    }

    private void ReleaseObject(Vector3 newVelocity)
    {
        holdingObject = false;
        objectHold.parent = null;

        Rigidbody objectRigidbody = objectHold.GetComponent<Rigidbody>();
        objectRigidbody.useGravity = true;
        objectRigidbody.constraints = RigidbodyConstraints.None;
        objectRigidbody.linearVelocity = newVelocity;

        objectHold = null;
        holdEnabled = false;

        Invoke("EnableHold", 1f);

    }

    private void LockObject()
    {
        holdingObject = true;
        objectHold = objectAim;
        objectAim = null;

        objectHold.position = transform.position + transform.forward * 1.25f;
        objectHold.rotation = transform.rotation;

        Rigidbody objectRigidbody = objectHold.GetComponent<Rigidbody>();
        objectRigidbody.useGravity = false;
        objectRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        objectRigidbody.linearVelocity = Vector3.zero;

        //se vuelve hijo del arma
        objectHold.transform.parent = transform;
    }
    private bool isAimingObject()
    {
        int layerMask = 1 << 9;
        RaycastHit hit;
        bool isAimingObject = Physics.Raycast(cam.position, transform.TransformDirection(Vector3.forward), out hit, distance, layerMask);
        if (isAimingObject)
        {
            objectAim = hit.transform;
        }
        return isAimingObject;
    }

    private void EnableHold() { holdEnabled = true; }
 }



