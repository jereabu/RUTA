using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EmpujarAtras : MonoBehaviour
{
    public float fuerzaAtras = 1000.0f; // La fuerza con la que empujar hacia atr�s
    public float distanciaEmpuje = 2000.0f; // La distancia hacia atr�s que se mover� el objeto

    public bool chocando = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!chocando)
        {
            chocando = true;
            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 direccionAtras = -collision.contacts[0].normal; // Obtener la direcci�n opuesta al punto de colisi�n
            rb.AddForce(direccionAtras * fuerzaAtras, ForceMode.Impulse);
            Invoke("ResetChocando", 1.0f); // Evitar m�ltiples aplicaciones de fuerza en una colisi�n continua
        }
    }

    private void ResetChocando()
    {
        chocando = false;
    }
}
