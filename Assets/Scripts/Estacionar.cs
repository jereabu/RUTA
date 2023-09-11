using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estacionar : MonoBehaviour
{

    private int wheelsInsideTrigger = 0;

    private bool detected = false;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Wheel"))
        {
            wheelsInsideTrigger++;

            Debug.Log("DENTROOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
        }

        CheckIfAllWheelsInside();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wheel"))
        {
            wheelsInsideTrigger--;
            Debug.Log("FUERAAAAAAAAAAAAAAAAAAAAAAAAAA.");
        }

        CheckIfAllWheelsInside();
    }
    private void CheckIfAllWheelsInside()
    {
   
        if (wheelsInsideTrigger >= 4) 
         {
        
           Debug.Log("Todas las ruedas están dentro del trigger. Nivel completado.");
      
         }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
