using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class CarEngine : MonoBehaviour {

    public Transform path;
    public float maxSteerAngle = 45f;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public float maxMotorTorque = 80f;
    public float currentSpeed;
    public float maxSpeed = 40f;
    bool WarnCol = false;
    public Rigidbody Rigido;
    public float InmunityTime;
    bool Inmune;
    float CurrentTime;

    private List<Transform> nodes;
    private int currectNode = 0;

    private void Start () {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        //CurrentTime = InmunityTime;
        Rigido = GetComponent<Rigidbody>();

        for (int i = 0; i < pathTransforms.Length; i++) {
            if (pathTransforms[i] != path.transform) {
                nodes.Add(pathTransforms[i]);
            }
        }
    }
	
	private void FixedUpdate () {
        if (!WarnCol)
        {
            Rigido.constraints = RigidbodyConstraints.None;
            ApplySteer();
            Drive();
            CheckWaypointDistance();
        }
        else
        {
            Rigido.constraints = RigidbodyConstraints.FreezeAll;
            
            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
        }

        if(CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
            if (!Inmune)
            {
                Inmune = true;
            }
        }
        else if(CurrentTime <= 0)
        {
            Inmune = false;
        }
        
    }

    private void ApplySteer() 
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currectNode].position);
        //Vector3 newtry = nodes[currectNode].position - transform.position;
        //Debug.DrawRay(wheelFL.transform.position, newtry, Color.green);
        //Debug.DrawRay(wheelFR.transform.position, newtry, Color.green);
        //Debug.DrawLine(wheelFL.transform.position, relativeVector - wheelFL.transform.position, Color.green);
        //Debug.DrawLine(wheelFR.transform.position, relativeVector - wheelFR.transform.position, Color.green);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;
    }

    private void Drive() {
        
        
            currentSpeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 1000;

            if (currentSpeed < maxSpeed)
            {
                wheelFL.motorTorque = maxMotorTorque;
                wheelFR.motorTorque = maxMotorTorque;
            }
            else
            {
                wheelFL.motorTorque = 0;
                wheelFR.motorTorque = 0;
            }
        
        
    }

    private void CheckWaypointDistance() {
        if (Vector3.Distance(transform.position, nodes[currectNode].position) < 5f)
        {
            maxSpeed = 20f;
        }
        else
        {
            maxSpeed = 40f;
        }

        if (Vector3.Distance(transform.position, nodes[currectNode].position) < 0.5f) {
            if(currectNode == nodes.Count - 1) {
                currectNode = 0;
            } else {
                currectNode++;
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Stopper") && !Inmune)
        {
            WarnCol = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Stopper") && !Inmune)
        {
            WarnCol = false;
            CurrentTime = InmunityTime;
        }
    }
}
