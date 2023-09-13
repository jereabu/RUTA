using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUTA : MonoBehaviour
{
    public Color lineColor;

    [SerializeField] private List<Transform> Waypoints = new List<Transform>();

    void OnDrawGizmos()
    {
        Gizmos.color = lineColor;

        Transform[] WaypointsTrfsm = GetComponentsInChildren<Transform>();

        Waypoints = new List<Transform>();

        for(int i = 0; i < WaypointsTrfsm.Length; i++)
        {
            if(WaypointsTrfsm[i] != transform)
            {
                Waypoints.Add(WaypointsTrfsm[i]);
            }
        }

        for(int i = 0; i < Waypoints.Count; i++)
        {
            Vector3 CurrentWaypoint = Waypoints[i].position;
            Vector3 PreviousWaypoint = Vector3.zero;
            if (i > 0)
            {
                PreviousWaypoint = Waypoints[i - 1].position;
            }
            else if (i == 0 && Waypoints.Count > 1)
            {
                PreviousWaypoint = Waypoints[Waypoints.Count - 1].position;
            }
            Gizmos.DrawLine(PreviousWaypoint, CurrentWaypoint);
        }
    }
}
