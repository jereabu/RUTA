using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public bool WarnCol;
    
    // Start is called before the first frame update
    void Start()
    {
        WarnCol = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Stopper"))
        {
            WarnCol = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Stopper"))
        {
            WarnCol = false;
        }
    }
}
