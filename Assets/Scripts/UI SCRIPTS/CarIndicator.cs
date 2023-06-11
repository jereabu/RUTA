using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarIndicator : MonoBehaviour
{
    Controller controller;
    public Text balizas;
    public Text guinoDer;
    public Text cambio;
    public Text guinoIzq;
    public Text Vel;
void Start()
{
    balizas = GameObject.FindGameObjectWithTag("balizas").GetComponent<Text>(); 
    guinoDer = GameObject.FindGameObjectWithTag("guinoDer").GetComponent<Text>(); 
    guinoIzq = GameObject.FindGameObjectWithTag("guinoIzq").GetComponent<Text>(); 
    Vel = GameObject.FindGameObjectWithTag("Vel").GetComponent<Text>(); 
    cambio = GameObject.FindGameObjectWithTag("cambio").GetComponent<Text>();
}
void Update()
{
    balizas.text = "Balizas: " + controller.Balizas;
    guinoDer.text = "Guiño Derecho: " + controller.guinoDer;
    guinoIzq.text = "Guiño Izquierdo: " + controller.guinoIzq;
    Vel.text = "Velocidad: " + controller.motorSpeed;
    cambio.text = "Cambio: " + controller.cambio;
}

}