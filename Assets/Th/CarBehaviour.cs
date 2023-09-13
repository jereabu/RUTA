using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    public Transform Path;
    
    public float MaxSteer = 45f;
    private int CurrentNode = 0;

    [SerializeField] private List<Transform> Waypoints;
    public WheelCollider WheelFL;
    public WheelCollider WheelFR;

    void Start()
    {
        Transform[] WaypointsTrfsm = Path.GetComponentsInChildren<Transform>();
        Waypoints = new List<Transform>();

        for (int i = 0; i < WaypointsTrfsm.Length; i++)
        {
            if (WaypointsTrfsm[i] != Path.transform)
            {
                Waypoints.Add(WaypointsTrfsm[i]);
            }
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ApplySteer();
    }

    private void ApplySteer()
    {
        Vector3 RelativeVector = transform.InverseTransformPoint(Waypoints[CurrentNode].position);
        RelativeVector = RelativeVector / RelativeVector.magnitude;
        float NewSteer = (RelativeVector.x / RelativeVector.magnitude) * MaxSteer;
        WheelFL.steerAngle = NewSteer;
        WheelFR.steerAngle = NewSteer;
    }

    private void Drive()
    {
        WheelFL.motorTorque = 100000f;
        WheelFR.motorTorque = 100000f;
    }
}
