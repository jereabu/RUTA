using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CarIndicator : MonoBehaviour
{
    Controller controller;

    public TMP_Text cambio;
 
    public TMP_Text Vel;
void Start()
{
    controller = FindObjectOfType<Controller>();
        

    Vel = GameObject.FindGameObjectWithTag("Vel").GetComponent<TMP_Text>(); 
    cambio = GameObject.FindGameObjectWithTag("cambio").GetComponent<TMP_Text>();
}
void Update()
{
        if (controller.cambio == 0)
        {

            Vel.text = "Velocidad: " + Mathf.Floor(controller.motorSpeed / -1f);
            cambio.text = "Cambio: " + "Reversa";
        }
        else if(controller.cambio == -1)
        {
            Vel.text = "Velocidad: " + Mathf.Floor(controller.motorSpeed);
            cambio.text = "Cambio: " + "Punto Muerto";
        }
        else
        {
  
            Vel.text = "Velocidad: " + Mathf.Floor(controller.motorSpeed);
            cambio.text = "Cambio: " + controller.cambio;
        }
}

}