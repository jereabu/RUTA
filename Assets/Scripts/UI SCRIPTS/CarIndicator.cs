using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CarIndicator : MonoBehaviour
{
    Controller controller;
    public TMP_Text balizas;
    public TMP_Text guinoDer;
    public TMP_Text cambio;
    public TMP_Text guinoIzq;
    public TMP_Text Vel;
void Start()
{
    controller = FindObjectOfType<Controller>();
        
    balizas = GameObject.FindGameObjectWithTag("balizas").GetComponent<TMP_Text>(); 
    guinoDer = GameObject.FindGameObjectWithTag("guinoDer").GetComponent<TMP_Text>(); 
    guinoIzq = GameObject.FindGameObjectWithTag("guinoIzq").GetComponent<TMP_Text>(); 
    Vel = GameObject.FindGameObjectWithTag("Vel").GetComponent<TMP_Text>(); 
    cambio = GameObject.FindGameObjectWithTag("cambio").GetComponent<TMP_Text>();
}
void Update()
{
    balizas.text = "Balizas: " + controller.Balizas;
    guinoDer.text = "Guiño Derecho: " + controller.guinoDer;
    guinoIzq.text = "Guiño Izquierdo: " + controller.guinoIzq;
    Vel.text = "Velocidad: " + Mathf.Floor(controller.motorSpeed / 2f);
    cambio.text = "Cambio: " + Controller.cambio;
}

}