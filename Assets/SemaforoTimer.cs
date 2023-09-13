using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemaforoTimer : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Trigg;
    public float RTime;
    [SerializeField] private float CRTime;
    void Start()
    {
        CRTime = RTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(CRTime > 0)
        {
            CRTime -= Time.deltaTime;
        }
        if(CRTime <= 0)
        {
            if(Trigg.activeInHierarchy == true)
            {
                Trigg.SetActive(false);
            }
            else
            {
                Trigg.SetActive(true);
            }
            
            
            CRTime = RTime;
        }
    }
}
