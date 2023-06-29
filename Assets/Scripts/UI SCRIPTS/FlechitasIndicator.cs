using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FlechitasIndicator : MonoBehaviour
{
    flechitas flechitas;
    public TMP_Text balizas;
    public TMP_Text guinoDer;
    public TMP_Text cambio;
    public TMP_Text guinoIzq;
    public TMP_Text Vel;
void Start()
{
    
    flechitas = FindObjectOfType<flechitas>();
        
    balizas = GameObject.FindGameObjectWithTag("balizas").GetComponent<TMP_Text>(); 
    guinoDer = GameObject.FindGameObjectWithTag("guinoDer").GetComponent<TMP_Text>(); 
    guinoIzq = GameObject.FindGameObjectWithTag("guinoIzq").GetComponent<TMP_Text>(); 
    Vel = GameObject.FindGameObjectWithTag("Vel").GetComponent<TMP_Text>(); 
    cambio = GameObject.FindGameObjectWithTag("cambio").GetComponent<TMP_Text>();
}
void Update()
{
    balizas.text = "Balizas: " + flechitas.Balizas;
    guinoDer.text = "Guiño Derecho: " + flechitas.guinoDer;
    guinoIzq.text = "Guiño Izquierdo: " + flechitas.guinoIzq;
    Vel.text = "Velocidad: " + Mathf.Floor(flechitas.motorSpeed / 2.5f);
    cambio.text = "Cambio: " + flechitas.cambio;
}

}