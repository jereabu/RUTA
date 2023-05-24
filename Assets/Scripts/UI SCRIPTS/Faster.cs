using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faster : MonoBehaviour
{

    public GameObject prefab;
    private int Cubos = 5;
    private int Grados = 20;
    // Start is called before the first frame update

    public void Clone()
    {
       
            for (int i = 0; i < Cubos; i++)
            {
                GameObject clon;
                clon = Instantiate(prefab);
                clon.transform.Rotate(0, Grados, 0);
                clon.transform.Translate(5, 10, 0);
                //Destroy(clon, 5f); 
            }
        
        
    }    
}
