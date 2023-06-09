using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logitest1 : MonoBehaviour
{
    LogitechGSDK.LogiControllerPropertiesData properties;
    
    public float freno1, embrague1, acelerador1, InputX1;

    // Start is called before the first frame update
    void Start()
    {
       
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
            
            InputX1 = rec.lX / 32768f; // 1 0 -1
            Debug.Log(Input.GetAxis("Vertical"));
            if (rec.lY > 0)
            {
                acelerador1 = 0;
            }
            else if (rec.lY < 0)
            {
                acelerador1 = rec.lY / -32768f;
            }

            if (rec.lRz > 0)
            {
                
                freno1 = 0;
            }
            else if (rec.lRz < 0)
            {
                freno1 = rec.lRz / -32768f;
            }
            if (rec.rglSlider[0] > 0)
            {
                embrague1 = 0;
            }
            else if (rec.rglSlider[0] < 0)
            {
                embrague1 = rec.rglSlider[0] / -32768f;
            }
          
        }
        
    }
}

