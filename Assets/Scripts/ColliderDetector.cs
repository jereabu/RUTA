using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{

    bool Infringement = false;
    bool WrongWay = false; 
    public GameObject UIPasoRojo;
    public GameObject UIContraMano; 

    // Start is called before the first frame update
    void Start()
    {
      
    }

     

    // Update is called once per frame
    void Update()
    {
        if (Infringement == true)
        {
            UIPasoRojo.SetActive(true);
        }
        else if (WrongWay == true)
        {
            UIContraMano.SetActive(true);   
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Blocked"))
        {
            Infringement = true;
        }
        else if (col.gameObject.CompareTag("WrongWay"))
        {
            WrongWay = true;
        }
    }
}

