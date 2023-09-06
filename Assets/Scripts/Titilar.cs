using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Titilar : MonoBehaviour
{
    public bool blinking = false;
    public float Tiempo;
    public float TiempoBlink = 0.5f;
    public Renderer MR;
    private void Awake()
    {
        Tiempo = TiempoBlink;
        MR = GetComponent<Renderer>();
        MR.enabled = !MR.enabled;
    }
    void Update()
    {
        
            if (Time.fixedTime % .5 < .3)
            {
                MR.enabled = false;
            }
            else
            {
                MR.enabled = true;
            }
        
    }
        /* if (blinking == true)
         {
             Tiempo -= Time.deltaTime;
             MR.enabled = MR.enabled;
             if (Tiempo >= 0)
             {
                 MR.enabled = !MR.enabled;
                 Tiempo = TiempoBlink;

             }
         }
     }
     public void PressBlinker()
     {
         blinking = !blinking;
         if(!blinking )
         {
             Tiempo = TiempoBlink;
             MR.enabled = false;
         }
     }*/
    }
