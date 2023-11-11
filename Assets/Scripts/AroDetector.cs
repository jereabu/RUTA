using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AroDetector : MonoBehaviour
{
    public GameObject[] aros; 
    private int Aro = 1;

    void Start()
    {
        
        for (int i = 1; i < aros.Length; i++)
        {
            aros[i].SetActive(false);
        }
    }

    void Update()
    {
        Debug.Log("El Aro activo es:" + Aro); 
        
        if (Aro < aros.Length)
        {
            aros[Aro].SetActive(true);
        }
     
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Wheel"))
        {
            // Desactivar el aro actual y activar el siguiente si hay uno disponible
            aros[Aro].SetActive(false);
            Aro++;

        }
       
    }
}

