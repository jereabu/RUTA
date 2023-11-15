using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



public class Estacionar : MonoBehaviour
{

    private int wheelsInsideTrigger = 0;


    

    //public flechitas Flechitas;
    //public flechitas controller;
    public Controller controller;
    private int Cambio = 0;
    bool Completado;
    public GameObject UI;
    
    
    
    
   

    // Start is called before the first frame update


    void Start()
    {
        controller = FindObjectOfType<Controller>();
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(wheelsInsideTrigger);
        Cambio = controller.cambio;
        

        Debug.Log("valor cambio es: "+Cambio);
        Debug.Log("ruedas: " + wheelsInsideTrigger + "cambio: " + Cambio);

        if (wheelsInsideTrigger == 4 && Cambio == -1)

        {
   
            UI.SetActive(true);    
            Debug.Log("Estacionado");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Wheel"))
        {
            wheelsInsideTrigger++;

            Debug.Log("DENTRO");
        }

        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wheel"))
        {
            wheelsInsideTrigger--;
            Debug.Log("FUERA.");
        }

      
    }
   
}
