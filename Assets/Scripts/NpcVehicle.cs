using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcVehicle : MonoBehaviour
{

    public NavMeshAgent agent;

    public GameObject Point;
    private Transform[] WalkingPoints;

    public int index = 0;
    
    public float minDistance = 1; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        WalkingPoints = new Transform[Point.transform.childCount];
        for (int i = 0; i < WalkingPoints.Length; i++)
        {
            WalkingPoints[i] = Point.transform.GetChild(i); 
        }
    }

    void Update()
    {
        roam();
    }

    void roam()
    {
        if (Vector3.Distance(transform.position ,WalkingPoints[index].position) < minDistance)
        {
            if (index != WalkingPoints.Length - 1)
            {
                index += 1;
            }
            else 
            {
                //Debug.Log("Set 0");
                index = 0;
            }
               
        }
          
        
        agent.SetDestination(WalkingPoints[index].position); 

        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            /*if (DeathSystem)
            {
                Instantiate(DeathSystem, gameObject.transform.position, Quaternion.identity);
            }*/
            
            Destroy(gameObject);
        }
    }
}
