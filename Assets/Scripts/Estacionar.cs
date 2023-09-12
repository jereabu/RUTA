using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estacionar : MonoBehaviour
{

    private int wheelsInsideTrigger = 0;

    private bool detected = false;

    private Controller controller;

    // Start is called before the first frame update


    void Start()
    {
        controller = GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(wheelsInsideTrigger);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Wheel"))
        {
            wheelsInsideTrigger++;

            Debug.Log("DENTRO");
        }

        CheckIfAllWheelsInside();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wheel"))
        {
            wheelsInsideTrigger--;
            Debug.Log("FUERA.");
        }

        CheckIfAllWheelsInside();
    }
    private void CheckIfAllWheelsInside()
    {
   
        if (wheelsInsideTrigger >= 4 && Controller.cambio == -1) 
         {
        
           Debug.Log("Has estacionado correctamente");
      
         }

    }
}