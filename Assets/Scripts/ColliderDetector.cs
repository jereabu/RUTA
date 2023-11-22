using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColliderDetector : MonoBehaviour
{

    bool Infringement = false;
    bool WrongWay = false;
    bool Work = false;
    private int Cambio; 
    public GameObject UIInfraccion;
    public TextMeshProUGUI Razon;
    public Controller controller; 

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<Controller>();
        UIInfraccion.SetActive(false);
        
    }

     

    // Update is called once per frame
    void Update()
    {
        

        if (Infringement == true)
        {
            UIInfraccion.SetActive(true);
            Razon.text = "      Has pasado el semáforo en rojo";
            controller.cambio = -1;
        }
        else if (WrongWay == true)
        {
            UIInfraccion.SetActive(true);
            Razon.text = "      Has intentado ir en contramano";
            controller.cambio = -1;
        }
        else if (Work == true)
        {
            UIInfraccion.SetActive(true);
            Razon.text = "        Es una zona de construcción";
            controller.cambio = -1; 
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
        else if (col.gameObject.CompareTag("Work")) 
        {
            Work = true;
        }
    }
}

