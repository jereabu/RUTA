using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estacionar : MonoBehaviour
{

    private int wheelsInsideTrigger = 0;


    //public Controller controller;

    public flechitas Flechitas;
    public flechitas valor_cambio;
    private int Cambio = 0;
    bool Completado;
    public GameObject UI;

    // Start is called before the first frame update


    void Start()
    {
        valor_cambio = FindObjectOfType<flechitas>();
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(wheelsInsideTrigger);
        Cambio = valor_cambio.cambio;
        

        Debug.Log("valor cambio es: "+Cambio);
        Debug.Log("ruedas: " + wheelsInsideTrigger + "cambio: " + Cambio);

        if (wheelsInsideTrigger == 4 && Cambio == -1)

        {
   
            UI.SetActive(true);    
            Debug.Log("VamoMessi");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Wheel"))
        {
            wheelsInsideTrigger++;

            Debug.Log("DENTRO");
        }

        //CheckIfAllWheelsInside();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wheel"))
        {
            wheelsInsideTrigger--;
            Debug.Log("FUERA.");
        }

        //CheckIfAllWheelsInside();
    }
   
}
