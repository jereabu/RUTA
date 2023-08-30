using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoAuto : MonoBehaviour
{
    AudioSource audioSource;
    Controller controller;
    public float minPitch = .05f;
    public  float pitchFromCar;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = minPitch;
        
    }

    // Update is called once per frame
    void Update()
    {
        pitchFromCar = Controller.acelerador;
        if(pitchFromCar < minPitch)
        {
            audioSource.pitch = minPitch;
        }
        else
        {
            audioSource.pitch = pitchFromCar;
        }
    }
}
