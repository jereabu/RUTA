using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public AudioSource Audio;
    public GameObject CenterOfMass;
    public float motorSpeed;
    static public int cambio = 1;
    public bool cambiable;
    public bool frenable;
    public bool cambiazo;
    public float freno;
    public float embrague;
    static public float acelerador;
    public float InputX;
    public bool guinoDer;
    public Image guinoDerFoto;
    public bool guinoIzq;
    public Image guinoIzqFoto;
    public bool Balizas;
    public Image BalizasFoto;
    public Color colorInicio = Color.grey;
    public Color colorFinal = Color.white;
    public AudioClip BalizasSFX;
    public Quaternion _initialOrientation;
    public bool girada = false;
   
   
  /*  public Titilar guinoDerReal;
    public Titilar guinoIzqReal;
    public Titilar BalizasReal;*/



    private void Start()
    {
        
        // PARA LA DUREZA DEL CONTROL ES EL MODIFICADOR DE VOLANTE DAMPER FORCE!!!!!!! IMPORTANTE
        rb = GetComponent<Rigidbody>();
        //Audio = GetComponent<AudioSource>();
        Image BalizasImage = BalizasFoto.GetComponent<Image>();
        Image guinoDerImage = guinoDerFoto.GetComponent<Image>();
        Image guinoIzqImage = guinoIzqFoto.GetComponent<Image>();
        rb.centerOfMass = CenterOfMass.transform.localPosition;
        guinoDerImage.color = Color.grey;
        guinoIzqImage.color = Color.grey;
        BalizasImage.color = Color.grey;
        _initialOrientation = transform.localRotation;
       // camera = GameObject.FindGameObjectWithTag("cam");



    }
    private void Update()
    {
        
        /*if (Input.GetKeyDown(KeyCode.T) && !girada)
        {
            camera.transform.rotation = Quaternion.Euler(0f, 120f, 0f);
            Debug.Log("Alguien mas me esta modificando");
            girada = true;
        }
        if (Input.GetKeyDown(KeyCode.T) && girada)
        {
            camera.transform.rotation = Quaternion.Euler(0f, -120f, 0f);
            girada = false;
        }*/
        // Rotar el volante, no el auto
        //if (InputX > 0.03 || InputX < -0.03)
        //{
        //    Volante.transform.Rotate(0, 0, -InputX);
        //}
        /* else
         {
             Volante.transform.localRotation = _initialOrientation;
         }*/
        if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))
        {
            LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(0);
            //C
            InputX = rec.lX / 32768f; // 1 0 -1
            
            embrague = rec.lY;
            embrague += 32768f;
            embrague /= 65535f;
            embrague = 1 - embrague;

            freno = rec.lRz;
            freno += 32768f;
            freno /= 65535f;
            freno = 1 - freno;
            //Debug.Log(freno);

            acelerador = rec.lZ;
            acelerador += 32768f;
            acelerador /= 65535f;
            acelerador = 1 - acelerador;
            //Debug.Log(acelerador);

  
        }
        //tpear arriba
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.transform.Translate(000, 10, 000);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && !guinoIzq && !Balizas)
        {
            if (guinoDer == true)
            {
                Audio.Stop();
                guinoDer = false;
               
            }
            else
            {
                guinoDer = true;
            }
            Debug.Log("arriba");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !guinoDer && !Balizas)
        {
            if (guinoIzq == true)
            {
                Audio.Stop();
                guinoIzq = false;

            }
            else
            {
                guinoIzq = true;
            }
            Debug.Log("abajo");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !guinoDer && !guinoIzq)
        {
            if (Balizas == true)
            {
               
                Audio.Stop();
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
        if (guinoDer == true)
        {
            

            if (!Audio.isPlaying)
                Audio.PlayOneShot(BalizasSFX);
            guinoDerFoto.color = Color.Lerp(colorInicio, colorFinal, Mathf.PingPong(Time.time * 1, 0.5f));
        }
        if (guinoDer == false)
        {
            
            guinoDerFoto.color = colorInicio;
        }
        if (guinoIzq == true)
        {
            if (!Audio.isPlaying)
                Audio.PlayOneShot(BalizasSFX);
            guinoIzqFoto.color = Color.Lerp(colorInicio, colorFinal, Mathf.PingPong(Time.time * 1, 0.5f));
            
        }
        if (guinoIzq == false)
        {
            
            guinoIzqFoto.color = colorInicio;
        }
        if (Balizas == true)
        {
            if (!Audio.isPlaying)
                Audio.PlayOneShot(BalizasSFX);
            BalizasFoto.color = Color.Lerp(colorInicio, colorFinal, Mathf.PingPong(Time.time * 1, 0.5f));
            

        }
        if (Balizas == false)
        {
            
            BalizasFoto.color = colorInicio;
        }
    }
        

    void FixedUpdate()
    {
        
        if (acelerador > 0 && cambio >= 0)
        {
     
        }
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
        if (Input.GetKey(KeyCode.Q) && cambiable && cambio >= 0 && cambiazo)
        {
            rb.constraints = RigidbodyConstraints.None;
            
            cambio -= 1;
            cambiazo = false;
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
                if (acelerador > 0.1f || wheel.motorTorque == 0 && freno <= 0.4f)
                {
                    wheel.motorTorque = (acelerador * motorPower1);
                }
                //Debug.Log("Cambio 1");
                }
                if (cambio == 2)// Cambio 2
                {
                if (acelerador > 0.5f || wheel.motorTorque == 0 && freno <= 0.4f)
                {
                    wheel.motorTorque = (acelerador * motorPower2);
                }
               // Debug.Log("Cambio 2");
                }
                if (cambio == 3)// Cambio 3
                {
                if (acelerador > 0.5f || wheel.motorTorque == 0 && freno <= 0.4f)
                {
                    wheel.motorTorque = (acelerador * motorPower3);
                }
              //  Debug.Log("Cambio 3");
                }
                if (cambio == 4) // Cambio 4
                {
                    if (acelerador > 0.5f || wheel.motorTorque == 0 && freno <= 0.4f)
                        {
                            wheel.motorTorque = (acelerador * motorPower4);
                        }
              //  Debug.Log("Cambio 4");
                }
                if (cambio == 5) // Cambio 5
                {
                    //acelerador += 1;
                    if(acelerador > 0.5f || wheel.motorTorque == 0 && freno <= 0.4f)
                    {
                        wheel.motorTorque = (acelerador * motorPower5);
                    }
                    
                 //   Debug.Log("Cambio 5");
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
            if (freno > 0.001f)
            {
                wheel.motorTorque = wheel.motorTorque / 3;
                wheel.brakeTorque = freno * 100;
            }
            else
            {
                wheel.brakeTorque = 0;
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
}