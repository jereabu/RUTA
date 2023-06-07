using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public WheelCollider[] wheels;
    public GameObject[] FrontWheels;

    [SerializeField] float steerPower;
    public float motorPower0 = -40;
    [SerializeField] float motorPower1 = 100;
    [SerializeField] float motorPower2 = 150;
    [SerializeField] float motorPower3 = 200;
    [SerializeField] float motorPower4 = 250;
    [SerializeField] float motorPower5 = 500;
    public Rigidbody rb;
    public GameObject CenterOfMass;
    public float motorSpeed;
    public int cambio = 1;
    public bool cambiable;
    public bool frenable;
    public bool cambiazo;


    


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = CenterOfMass.transform.localPosition;
        
    }
    private void Update() {
        //tpear arriba
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.transform.Translate(000, 10, 000);
        }
        //cambio +1
        if (!Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.E) && cambiable && cambio < 5)
        {
            Debug.Log("CAMBIAZOOO");
            cambio++;
            //cambiazo = true;
        } 
    //no se puede pegar cambiazo
        else if (cambio >= 5)
        {
            cambiazo = false;
        }
    }


    void FixedUpdate()
    {
        //para poner el auto en punto muerto mientras el auto esta andando, y poder hacer los cambios
        // frenable = freno de mano?
        if (cambio < 5)
        {
            cambiable = true;
            frenable = true;
        }
        //para poner el auto en punto muerto mientras el auto NO esta andando
        else if (cambio >= 5)
        {
            cambiable = false;
            frenable = true;
        }

        //Arrancar el auto
        if (Input.GetKey(KeyCode.Q))
        {
            rb.constraints = RigidbodyConstraints.None; 
            cambio = 1;
            Debug.Log("Arrancado");

        }
        // Hacer que funcionen los cambios
        if (/*Input.GetKey(KeyCode.W) == false && Input.GetKeyDown(KeyCode.E) && cambiable */ cambiazo)
        {
            cambio+=1;
            cambiazo = false;
            Debug.Log("cambio " + cambio);
            
        }

        else if (Input.GetKey(KeyCode.W) == false && frenable && Input.GetKey(KeyCode.R))
        {
            cambio = 0; //Reversa
            Debug.Log("Reversa");
        }
        //punto muerto
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
                    Debug.Log("Cambio 1");
                }
                if (cambio == 2)// Cambio 2
                {
                    wheel.motorTorque = Input.GetAxis("Vertical") * motorPower2;
                    Debug.Log("Cambio 2");
                }
                if (cambio == 3)// Cambio 3
                {
                    wheel.motorTorque = Input.GetAxis("Vertical") * motorPower3;
                    Debug.Log("Cambio 3");
                }
                if (cambio == 4) // Cambio 4
                {
                    wheel.motorTorque = Input.GetAxis("Vertical") * motorPower4;
                    Debug.Log("Cambio 4");
                }
                if (cambio == 5) // Cambio 5
                {
                    wheel.motorTorque = Input.GetAxis("Vertical") * motorPower5;
                    Debug.Log("Cambio 5");
                }
                if (cambio == 0) //Reversa
                {
                    wheel.motorTorque = Input.GetAxis("Vertical") * motorPower0;
                    Debug.Log("Reversa");
                    rb.constraints = RigidbodyConstraints.None;
            }
                if (cambio == -1) //Punto Muerto o freno de mano
                {
                    wheel.motorTorque = Input.GetAxis("Vertical") * 0;
                    Debug.Log("Punto Muerto");
                    rb.constraints = RigidbodyConstraints.FreezePosition; 
                }




                //wheel.motorTorque = Input.GetAxis("Vertical") * motorPower;
                motorSpeed = wheel.motorTorque;
                
            }

            for (int i = 0; i < wheels.Length; i++)
            {
                if (i < 2)
                {
                    wheels[i].steerAngle = (Input.GetAxis("Horizontal") * steerPower) / 2;

                    Debug.Log(Input.GetAxis("Horizontal"));

                    //deberia frenar la rotacion pero no funciona
                    if (FrontWheels[i].transform.localRotation.y < 30 || FrontWheels[i].transform.localRotation.y > -30)
                    {
                        //Hace que rote
                        FrontWheels[i].transform.localRotation = Quaternion.Euler(0, (Input.GetAxis("Horizontal") * steerPower) / 2, 0);
                    }

                }
            }
        }
    }

