using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCar : MonoBehaviour
{
    public Transform path;
    [SerializeField] float speed;
    Vector3 Target;
    GameObject CameraTestEmpty;
    public float RotationSpeed;
    //public float TrackTime;
    //public float StopTrack;
    private List<Transform> nodes;
    private int currectNode = 0;
    void Start()
    {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    void Update()
    {

        transform.position += transform.forward * speed;
        var targetRotation = Quaternion.LookRotation(nodes[currectNode].transform.position - transform.position);
        Vector3 targetEulerAngles = targetRotation.eulerAngles;
        targetEulerAngles.x = 0f;
        targetEulerAngles.z = 0f;
        Quaternion limitedTargetRotation = Quaternion.Euler(targetEulerAngles);
        transform.rotation = Quaternion.Slerp(transform.rotation, limitedTargetRotation, RotationSpeed * Time.deltaTime);
        CheckWaypointDistance();
        /*if (TrackTime > 0)
        {
            TrackTime -= Time.deltaTime;
        }
        if (TrackTime <= 0 && StopTrack > 0)
        {
            StopTrack -= Time.deltaTime;
            var targetRotation = Quaternion.LookRotation(Target - transform.position);

            // Smoothly rotate towards the target point.
            
        }*/
    }

    private void CheckWaypointDistance()
    {
        /*if (Vector3.Distance(transform.position, nodes[currectNode].position) < 5f)
        {
            maxSpeed = 20f;
        }
        else
        {
            maxSpeed = 40f;
        }*/

        if (Vector3.Distance(transform.position, nodes[currectNode].position) < 0.75f)
        {
            if (currectNode == nodes.Count - 1)
            {
                currectNode = 0;
            }
            else
            {
                currectNode++;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        /*if (col.gameObject.tag != "GAU" && col.gameObject.tag != "Ammo" && col.gameObject.tag != "EnemyBullet" && col.gameObject.tag != "Rocket")
        {
            
        }*/
    }
}