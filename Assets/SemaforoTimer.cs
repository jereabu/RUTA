using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemaforoTimer : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject RedL;
    public GameObject GreenL;

    public GameObject Trigg;
    public float RTime;
    [SerializeField] private float CRTime;
    private bool Translated = false;
    void Start()
    {
        CRTime = RTime;
        GreenL.SetActive(false);
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
            if (Translated)
            {
                Trigg.transform.Translate(0, 10, 0);
                Translated = false;
                GreenL.SetActive(false);
                RedL.SetActive(true);
            }
            else
            {
                Trigg.transform.Translate(0, -10, 0);
                Translated = true;
                GreenL.SetActive(true);
                RedL.SetActive(false);
            }
            

            /*if (Trigg.activeInHierarchy == true)
            {
                
            }
            else
            {
                Trigg.SetActive(true);
            }*/
            
            
            CRTime = RTime;
        }
    }
}
