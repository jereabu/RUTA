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
        Centro.eulerAngles = Vector3.forward * 450 * -controller.InputX;
    }


    void Giro()
    {
        if (controller.InputX < 0.3 || -0.3 > controller.InputX)
            direccion = (Centro.position - transform.position).normalized;
        rotGoal = Quaternion.LookRotation(direccion);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, Velocidad);
    }
}
