using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{

    bool Infringement = false;
    public GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
      
    }

     

    // Update is called once per frame
    void Update()
    {
        if (Infringement == true)
        {
            UI.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Blocked"))
        {
            Infringement = true;
        }
    }
}

