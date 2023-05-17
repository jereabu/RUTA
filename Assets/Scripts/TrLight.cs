using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrLight : MonoBehaviour
{
    //Resources

    [SerializeField] GameObject Redl;
    [SerializeField] GameObject YelL;
    [SerializeField] GameObject GrnL;

    float CRTime;



    // Start is called before the first frame update
    void Start()
    {
        CRTime = 95;
        if (gameObject.tag == "TrafficLVertical")
        {
            //Este set de semaforos inicia en verde

        }else if(gameObject.tag == "TrafficLHorizontal")
        {
            //Este set de semaforos inicia en rojo

        }
        else
        {
            Debug.Log("ERROR; UNTAGGED TRAFFIC LIGHT");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CRTime > 0)
        {
            CRTime -= Time.deltaTime;
        }
        if (CRTime == 15)
        {
            //Amarillo
        }
        if (CRTime <= 0)
        {
            CRTime = 95;
            Debug.Log("Loop");
        }
    }
}
