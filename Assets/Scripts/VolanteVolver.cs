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
        inputX = controller.InputX;

        // Crear una rotación en el eje Z basada en la entrada del controlador
        Quaternion rotacionZ = Quaternion.Euler(0, 0, -controller.InputX * 450);

        // Aplicar la rotación al objeto
        Centro.rotation = rotacionZ;
    }
}
