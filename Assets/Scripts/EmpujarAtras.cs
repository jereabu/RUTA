using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EmpujarAtras : MonoBehaviour
{
    public float fuerzaAtras = 1000.0f; // La fuerza con la que empujar hacia atrás
    public float distanciaEmpuje = 2000.0f; // La distancia hacia atrás que se moverá el objeto

    public bool chocando = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!chocando)
        {
            chocando = true;
            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 direccionAtras = -collision.contacts[0].normal; // Obtener la dirección opuesta al punto de colisión
            rb.AddForce(direccionAtras * fuerzaAtras, ForceMode.Impulse);
            Invoke("ResetChocando", 1.0f); // Evitar múltiples aplicaciones de fuerza en una colisión continua
        }
    }

    private void ResetChocando()
    {
        chocando = false;
    }
}
