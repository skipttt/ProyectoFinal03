using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainPlayer : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 15f;
    public float gravity = -10;
    public float salto = 2;

    public Transform Ground;
    public float DistanceToGround;
    public LayerMask GroundMask;

    Vector3 speedDown;
    bool OnGround;

    public float TotalStamina = 10;
    private float Health;

    //public float timer = 0;
    public TextMeshProUGUI textoTimer;


    void Start()
    {
        Health = TotalStamina;
    }

    void Update()
    {
        //timer = Health;
        Health -= Time.deltaTime;
        textoTimer.text = "" + Health.ToString("f0");


        OnGround = Physics.CheckSphere(Ground.position, DistanceToGround, GroundMask);
        if (OnGround && speedDown.y < 0)
        {
            speedDown.y = -2;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;

        controller.Move(movement * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && OnGround)
        {
            speedDown.y = Mathf.Sqrt(salto * -2f * gravity);
        }

        speedDown.y += gravity * Time.deltaTime;


        controller.Move(speedDown * Time.deltaTime);

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log(" " + hit.gameObject.name);
        if (hit.gameObject.GetComponent<StaminaPrefab>() != null)
        {
            Debug.Log("TotalStamina" + TotalStamina);
            Debug.Log("Health" + Health);

            if (Health > TotalStamina)
            {
                Debug.Log("Stamina llena");
            }
            else
            {
                Debug.Log("colisión con stamina");
                hit.gameObject.SetActive(false);
                // Esta es la recarga de stamina

                Health = Health + 10;
            }
        }

        if (hit.gameObject.GetComponent<Briars>() != null)
        {

            //Debug.Log("colisión con zarza");
            hit.gameObject.SetActive(false);
            Health = Health - 10;

        }

        if (Health <= 0)
        {
            Debug.Log("YOU'RE DEAD!");
            SceneManager.LoadScene("FailState");
        }
    }


}







