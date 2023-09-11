using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionRuedas : MonoBehaviour
{
   
    [SerializeField] private BoxCollider detectionArea;

    private void Update()
    {
   
        WheelCollider[] wheelColliders = GetComponentsInChildren<WheelCollider>();
        bool allWheelsInside = true;

        foreach (WheelCollider wheelCollider in wheelColliders)
        {
            Vector3 wheelPosition = wheelCollider.transform.position;

            if (!detectionArea.bounds.Contains(wheelPosition))
            {
                allWheelsInside = false;
                break;
            }
        }

        if (allWheelsInside == true)
        {
            Debug.Log("Todas las ruedas están dentro del área de detección.");
        }
    }
}




