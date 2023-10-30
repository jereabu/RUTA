using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    Vector3 rot = Vector3.zero;
    float DayTime = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rot.x = DayTime * Time.deltaTime;
        transform.Rotate(rot, Space.World);
    }
}
