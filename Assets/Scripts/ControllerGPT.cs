using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerGPT : MonoBehaviour
{
    public WheelCollider[] wheels;
    public GameObject[] FrontWheels;
    [SerializeField] float steerPower;
    [SerializeField] float motorPower = 3000;
    [SerializeField] float motorPowerReverse = -1500;
    [SerializeField] float brakePower = 3000;
    [SerializeField] float airResistanceCoefficient = 0.1f;
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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Image BalizasImage = BalizasFoto.GetComponent<Image>();
        Image guinoDerImage = guinoDerFoto.GetComponent<Image>();
        Image guinoIzqImage = guinoIzqFoto.GetComponent<Image>();
        rb.centerOfMass = CenterOfMass.transform.localPosition;
        guinoDerImage.color = Color.grey;
        guinoIzqImage.color = Color.grey;
        BalizasImage.color = Color.grey;
        _initialOrientation = transform.localRotation;
    }

    private void Update()
    {

       
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

            acelerador = rec.lZ;
            acelerador += 32768f;
            acelerador /= 65535f;
            acelerador = 1 - acelerador;
        }

        // Control de las luces direccionales
        if (Input.GetKeyUp(KeyCode.UpArrow) && !guinoIzq && !Balizas)
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
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !guinoDer && !Balizas)
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
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !guinoDer && !guinoIzq)
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
        }

        // Control de cambios
        if (!Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.E) && cambiable && cambio < 5)
        {
            cambio++;
        }
        else if (cambio >= 5)
        {
            cambiazo = false;
        }

        // Control de las luces direccionales visuales
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
        foreach (var wheel in wheels)
        {
            // Aplicar fuerza de tracción y frenado
            float motorTorque = 0;
            if (acelerador > 0)
            {
                motorTorque = acelerador * motorPower;
            }
            else if (acelerador < 0)
            {
                motorTorque = acelerador * motorPowerReverse;
            }
            wheel.motorTorque = motorTorque;

            // Aplicar fuerza de frenado
            float brakeTorque = freno * brakePower;
            wheel.brakeTorque = brakeTorque;

            // Aplicar resistencia del aire (simplificado)
            Vector3 velocity = rb.velocity;
            Vector3 airResistance = -velocity.normalized * velocity.sqrMagnitude * airResistanceCoefficient;
            rb.AddForce(airResistance);
        }
        // Arrancar el auto
        if (Input.GetKey(KeyCode.Q) && cambiable && cambio >= 0 && cambiazo)
        {
            rb.constraints = RigidbodyConstraints.None;
            cambio -= 1;
            cambiazo = false;
        }

        // Control de cambios y marcha atrás
        if (Input.GetKey(KeyCode.W) == false && Input.GetKeyDown(KeyCode.E) && cambiable && cambiazo)
        {
            cambio += 1;
            cambiazo = false;
        }
        else if (Input.GetKey(KeyCode.W) == false && frenable && Input.GetKey(KeyCode.R))
        {
            cambio = 0; // Reversa
        }
        else if (Input.GetKey(KeyCode.W) == false && frenable && Input.GetKey(KeyCode.F))
        {
            cambio = -1; // Punto muerto
        }

        foreach (var wheel in wheels)
        {
            if (cambio == 1) // Cambio 1
            {
                if (acelerador > 0.1f || wheel.motorTorque == 0 && freno <= 0.4f)
                {
                    wheel.motorTorque = (acelerador * motorPower);
                }
            }
            if (cambio == 2) // Cambio 2
            {
                if (acelerador > 0.5f || wheel.motorTorque == 0 && freno <= 0.4f)
                {
                    wheel.motorTorque = (acelerador * motorPower);
                }
            }
            if (cambio == 3) // Cambio 3
            {
                if (acelerador > 0.5f || wheel.motorTorque == 0 && freno <= 0.4f)
                {
                    wheel.motorTorque = (acelerador * motorPower);
                }
            }
            if (cambio == 4) // Cambio 4
            {
                if (acelerador > 0.5f || wheel.motorTorque == 0 && freno <= 0.4f)
                {
                    wheel.motorTorque = (acelerador * motorPower);
                }
            }
            if (cambio == 5) // Cambio 5
            {
                if (acelerador > 0.5f || wheel.motorTorque == 0 && freno <= 0.4f)
                {
                    wheel.motorTorque = (acelerador * motorPower);
                }
            }
            if (cambio == 0) // Reversa
            {
                wheel.motorTorque = acelerador * motorPowerReverse;
            }
            if (cambio == -1) // Punto Muerto o freno de mano
            {
                wheel.motorTorque = acelerador * 0;
                acelerador = 0;
                freno = 0;
            }
            if (freno > 0.001f)
            {
                wheel.motorTorque = wheel.motorTorque / 3;
                wheel.brakeTorque = freno * brakePower;
            }
            else
            {
                wheel.brakeTorque = 0;
            }
            motorSpeed = wheel.motorTorque;
        }

        for (int i = 0; i < wheels.Length; i++)
        {
            if (i < 2)
            {
                wheels[i].steerAngle = (InputX * steerPower) / 2;
                if (FrontWheels[i].transform.localRotation.y < 30 || FrontWheels[i].transform.localRotation.y > -30)
                {
                    FrontWheels[i].transform.localRotation = Quaternion.Euler(0, (InputX * steerPower) / 2, 0);
                }
            }
        }
    }
}


