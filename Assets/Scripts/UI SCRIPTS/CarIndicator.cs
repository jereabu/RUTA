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
    public Text RevsXMin;
    public Text guinoIzq;
    public Text Vel;

void Start()
{
    balizas = GameObject.FindGameObjectWithTag("balizas").GetComponent<Text>(); 
    guinoDer = GameObject.FindGameObjectWithTag("guinoDer").GetComponent<Text>(); 
    guinoIzq = GameObject.FindGameObjectWithTag("guinoIzq").GetComponent<Text>(); 
    RevsXMin = GameObject.FindGameObjectWithTag("Revs").GetComponent<Text>(); 
    Vel = GameObject.FindGameObjectWithTag("Vel").GetComponent<Text>(); 
    cambio = GameObject.FindGameObjectWithTag("cambio").GetComponent<Text>();
}
void Update()
{
    RevsXMin = "Revoluciones Por Minuto: " + controller.motorSpeed;
}

}