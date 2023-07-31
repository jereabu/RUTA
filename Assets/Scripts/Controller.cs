using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    LogitechGSDK.LogiControllerPropertiesData properties;
    public WheelCollider[] wheels;
    public GameObject[] FrontWheels;
    logitest logitest;
    [SerializeField] float steerPower;
    public float motorPower0 = -40;
    [SerializeField] float motorPower1 = 30;
    [SerializeField] float motorPower2 = 75;
    [SerializeField] float motorPower3 = 120;
    [SerializeField] float motorPower4 = 160;
    [SerializeField] float motorPower5 = 200;
    public Rigidbody rb;
    public GameObject CenterOfMass;
    public float motorSpeed;
    public int cambio = 1;
    public bool cambiable;
    public bool frenable;
    public bool cambiazo;
    public float freno;
    public float embrague;
    public float acelerador;
    public float InputX;
    public bool guinoDer;
    public bool guinoIzq;
    public bool Balizas;


    private void Start()
    {

        // PARA LA DUREZA DEL CONTROL ES EL MODIFICADOR DE VOLANTE DAMPER FORCE!!!!!!! IMPORTANTE
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = CenterOfMass.transform.localPosition;

    }
    private void Update()
    {
        if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))
        {
            LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(0);
            InputX = rec.lX / 32768f; // 1 0 -1
            if (rec.lY > 0)
            {
                acelerador = 0;
            }
            else if (rec.lY < 0)
            {
                acelerador = rec.lY / -32768f;
            }

            if (rec.lRz > 0)
            {
                freno = 0;
            }
            else if (rec.lRz < 0)
            {
                freno = rec.lRz / -32768f;
            }
            if (rec.rglSlider[0] > 0)
            {
                embrague = 0;
            }
            else if (rec.rglSlider[0] < 0)
            {
                embrague = rec.rglSlider[0] / -32768f;
            }
        }
        //tpear arriba
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.transform.Translate(000, 10, 000);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) && !guinoIzq && !Balizas)
        {
            if (guinoDer == true)
            {
                guinoDer = false;
            }
            else
            {
                guinoDer = true;
            }
            Debug.Log("arriba");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !guinoDer && !Balizas)
        {
            if (guinoIzq == true)
            {
                guinoIzq = false;
            }
            else
            {
                guinoIzq = true;
            }
            Debug.Log("abajo");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !guinoDer && !guinoIzq)
        {
            if (Balizas == true)
            {
                Balizas = false;
            }
            else
            {
                Balizas = true;
            }
            Debug.Log("Balizas");
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
        if (cambio < 5 && embrague > 0 && acelerador <= 0)
        {
            cambiable = true;
            frenable = true;
        }
        //para poner el auto en punto muerto mientras el auto NO esta andando
        else if (cambio >= 5 || embrague <= 0 || acelerador > 0)
        {
            cambiable = false;
            frenable = true;
        }

        //Arrancar el auto
        if (Input.GetKey(KeyCode.Q) && cambiable)
        {
            rb.constraints = RigidbodyConstraints.None;
            cambio = 1;
            Debug.Log("Arrancado");

        }
        // Hacer que funcionen los cambios
        if (/*Input.GetKey(KeyCode.W) == false && Input.GetKeyDown(KeyCode.E) && cambiable */ cambiazo)
        {
            cambio += 1;
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

        //cambiofunc(cambio);
        foreach (var wheel in wheels)
        {
                if (cambio == 1)// Cambio 1
                {
                if (acelerador > 0.5f || wheel.motorTorque == 0 && freno <= 0.4f)
                {
                    wheel.motorTorque = acelerador * motorPower1;
                }
                Debug.Log("Cambio 1");
                }
                if (cambio == 2)// Cambio 2
                {
                if (acelerador > 0.5f || wheel.motorTorque == 0 && freno <= 0.4f)
                {
                    wheel.motorTorque = acelerador * motorPower2;
                }
                Debug.Log("Cambio 2");
                }
                if (cambio == 3)// Cambio 3
                {
                if (acelerador > 0.5f || wheel.motorTorque == 0 && freno <= 0.4f)
                {
                    wheel.motorTorque = acelerador * motorPower3;
                }
                Debug.Log("Cambio 3");
                }
                if (cambio == 4) // Cambio 4
                {
                    if (acelerador > 0.5f || wheel.motorTorque == 0 && freno <= 0.4f)
                        {
                            wheel.motorTorque = acelerador * motorPower4;
                        }
                Debug.Log("Cambio 4");
                }
                if (cambio == 5) // Cambio 5
                {
                    //acelerador += 1;
                    if(acelerador > 0.5f || wheel.motorTorque == 0 && freno <= 0.4f)
                    {
                        wheel.motorTorque = acelerador * motorPower5;
                    }
                    
                    Debug.Log("Cambio 5");
                    //acelerador -= 1;
                }
                if (cambio == 0) //Reversa
                {
                    wheel.motorTorque = acelerador * motorPower0;
                    Debug.Log("Reversa");
                    rb.constraints = RigidbodyConstraints.None;

            }
                if (cambio == -1) //Punto Muerto o freno de mano
                {
                    wheel.motorTorque = acelerador * 0;
                acelerador = 0;
                freno = 0;
                    //Debug.Log("Punto Muerto");
                    //rb.constraints = RigidbodyConstraints.FreezePosition; 
                }
            //Debug.Log(wheel.motorTorque);
            if (freno > 0.3f)
            {
                wheel.motorTorque = wheel.motorTorque / 3;
                 
            }
            motorSpeed = wheel.motorTorque;

            //motorSpeed = wheel.motorTorque;

        }

        for (int i = 0; i < wheels.Length; i++)
        {
            if (i < 2)
            {
                wheels[i].steerAngle = (InputX * steerPower) / 2;

                //Debug.Log(Input.GetAxis("Horizontal"));


                if (FrontWheels[i].transform.localRotation.y < 30 || FrontWheels[i].transform.localRotation.y > -30)
                {
                    //Hace que rote
                    FrontWheels[i].transform.localRotation = Quaternion.Euler(0, (InputX * steerPower) / 2, 0);
                }

            }
        }
    }
    /*public Cambiofunc(int cambio)
    {
        foreach (var wheel in wheels)
        {
            if (cambio == 1)// Cambio 1
            {
                wheel.motorTorque = acelerador * motorPower1;
                Debug.Log("Cambio 1");
            }
            if (cambio == 2)// Cambio 2
            {
                wheel.motorTorque = acelerador * motorPower2;
                Debug.Log("Cambio 2");
            }
            if (cambio == 3)// Cambio 3
            {
                wheel.motorTorque = acelerador * motorPower3;
                Debug.Log("Cambio 3");
            }
            if (cambio == 4) // Cambio 4
            {
                wheel.motorTorque = acelerador * motorPower4;
                Debug.Log("Cambio 4");
            }
            if (cambio == 5) // Cambio 5
            {
                //acelerador += 1;
                if (acelerador > 0.5f || wheel.motorTorque == 0 && freno <= 0.4f)
                {
                    wheel.motorTorque = acelerador * motorPower5;
                }

                Debug.Log("Cambio 5");
                //acelerador -= 1;
            }
            if (cambio == 0) //Reversa
            {
                wheel.motorTorque = acelerador * motorPower0;
                Debug.Log("Reversa");
                rb.constraints = RigidbodyConstraints.None;
            }
            if (cambio == -1) //Punto Muerto o freno de mano
            {
                wheel.motorTorque = acelerador * 0;
                //Debug.Log("Punto Muerto");
                rb.constraints = RigidbodyConstraints.FreezePosition;
            }
             return;
        }
    }*/
}