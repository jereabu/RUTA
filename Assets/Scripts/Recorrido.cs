using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorrido : MonoBehaviour
{
    public Transform Path;

    [SerializeField] private List<Transform> Waypoints;

    private int CurrentNode = 0;

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
    void Update()
    {
        
    }

    private void CheckWaypointDistance()
    {
        if (Vector3.Distance(transform.position, Waypoints[CurrentNode].position) < 0.5f)
        {
            if (CurrentNode == Waypoints.Count - 1)
            {
                CurrentNode = 0;
            }
            else
            {
                CurrentNode++;
            }
        }
    }
}
