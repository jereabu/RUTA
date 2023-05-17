using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public WheelCollider[] wheels;
    public GameObject[] FrontWheels;

    public float steerPower = 100;
    public float motorPower0 = -40;
    public float motorPower = 100;
    public float motorPower1 = 20;
    public float motorPower2 = 40;
    public float motorPower3 = 60;
    public float motorPower4 = 80;
    public float motorPower5 = 100;
    public Rigidbody rb;
    public GameObject CenterOfMass;
    public float speed;
    public int cambio = 1;
    public bool cambiable;
    public bool frenable;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = CenterOfMass.transform.localPosition;
    }


    void FixedUpdate()
    {
        //para poner el auto en punto muerto mientras el auto esta andando
        if (speed >= 1 && cambio < 5 )
        {
            cambiable = true;
            frenable = true;
        }
        //para poner el auto en punto muerto mientras el auto NO esta andando
        else if (cambio >= 5 && speed >= 1)
        {
            cambiable = false;
            frenable = true;
        }

        //Arrancar el auto
        if (Input.GetKey(KeyCode.Q))
        {
            cambio = 1;
            Debug.Log("Arrancado");

        }
        // Hacer que funcionen los cambios
        if (Input.GetKey(KeyCode.W) == false && Input.GetKeyDown(KeyCode.E) && cambiable )
        {
            cambio++;
            Debug.Log("cambio" + cambio);
            
        }
        else if (Input.GetKey(KeyCode.W) == false && frenable && Input.GetKey(KeyCode.R))
        {
            cambio = 0; //Reversa
            Debug.Log("Reversa");
        }
        else if (Input.GetKey(KeyCode.W) == false && frenable && Input.GetKey(KeyCode.F))
        {
            Debug.Log("Punto muerto");
            cambio = -1;
        }
        
            foreach (var wheel in wheels)
            {
                if (cambio == 1)// Cambio 1
                {
                    wheel.motorTorque = Input.GetAxis("Vertical") * motorPower1;
                }
                if (cambio == 2)// Cambio 2
                {
                    wheel.motorTorque = Input.GetAxis("Vertical") * motorPower2;
                }
                if (cambio == 3)// Cambio 3
                {
                    wheel.motorTorque = Input.GetAxis("Vertical") * motorPower3;
                }
                if (cambio == 4) // Cambio 4
                {
                    wheel.motorTorque = Input.GetAxis("Vertical") * motorPower4;
                }
                if (cambio == 5) // Cambio 5
                {
                    wheel.motorTorque = Input.GetAxis("Vertical") * motorPower5;
                }
                if (cambio == 0) //Reversa
                {
                    wheel.motorTorque = Input.GetAxis("Vertical") * motorPower0;
                }
                if (cambio == -1) //Punto Muerto
                {
                    wheel.motorTorque = Input.GetAxis("Vertical") * 0;
                }




                //wheel.motorTorque = Input.GetAxis("Vertical") * motorPower;
                speed = wheel.motorTorque;
            }

            for (int i = 0; i < wheels.Length; i++)
            {
                if (i < 2)
                {
                    wheels[i].steerAngle = Input.GetAxis("Horizontal") * steerPower;

                    //Debug.Log(Input.GetAxis("Horizontal"));

                    if (FrontWheels[i].transform.localRotation.y < 24 || FrontWheels[i].transform.position.y > -24)
                    {
                        FrontWheels[i].transform.localRotation = Quaternion.Euler(0, Input.GetAxis("Horizontal") * steerPower, 0);
                    }

                }
            }
        }
    }

