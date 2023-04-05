using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public WheelCollider[] wheels;
    public GameObject[] FrontWheels;
    
    public float steerPower = 100;
    public float motorPower = 100;
    public Rigidbody rb;
    public GameObject CenterOfMass;


    private void Start()
    {
        rb = GetComponent   <Rigidbody>();
        rb.centerOfMass = CenterOfMass.transform.localPosition;
    }


    void FixedUpdate(){
        
        
        foreach(var wheel in wheels){

            wheel.motorTorque = Input.GetAxis("Vertical") * motorPower;
        }

        for(int i = 0; i < wheels.Length; i++){
            if(i < 2){
                wheels[i].steerAngle = Input.GetAxis("Horizontal") * steerPower;

                //Debug.Log(Input.GetAxis("Horizontal"));

                if (FrontWheels[i].transform.localRotation.y < 24 || FrontWheels[i].transform.position.y > -24)
                {
                    FrontWheels[i].transform.localRotation = Quaternion.Euler(0, Input.GetAxis("Horizontal") * steerPower, 0);
                }
                
            }
        }
    }
}
