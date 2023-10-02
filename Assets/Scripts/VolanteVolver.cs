using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolanteVolver : MonoBehaviour
{
    public Controller controller;
    public Transform Centro;
    public float Velocidad = 0.0001f;
    Quaternion rotGoal;
    Vector3 direccion;
    [SerializeField] float inputX;

    // Update is called once per frame
    void Update()
    {
        //Giro();
        inputX = controller.InputX;
        Centro.eulerAngles = new Vector3(0,0,1) * 450 * - controller.InputX;
        

    }


    
    
}
