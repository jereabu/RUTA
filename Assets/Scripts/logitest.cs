using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logitest : MonoBehaviour
{
    LogitechGSDK.LogiControllerPropertiesData properties;
    public WheelCollider[] wheels;
    public GameObject[] FrontWheels;

    [SerializeField] float steerPower;
    public float motorPower0 = -40;
   /* [SerializeField] float motorPower1 = 100;
    [SerializeField] float motorPower2 = 150;
    [SerializeField] float motorPower3 = 200;
    [SerializeField] float motorPower4 = 250;
    [SerializeField] float motorPower5 = 500;*/
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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = CenterOfMass.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(LogitechGSDK.LogiIsConnected(0));
        
        if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))
        {
           // Debug.Log("Acelerador: " + acelerador);
           // Debug.Log("freno: " + freno);
           // Debug.Log("embrague: " + embrague);

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
                freno = rec.lRz / -32768;
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
        //Gas = Input.GetAxis("Gas") * 100;
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
    private void FixedUpdate()
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            if (i < 2)
            {
                wheels[i].steerAngle = (Input.GetAxis("Horizontal") * steerPower) / 2;

                //Debug.Log(Input.GetAxis("Horizontal"));

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

