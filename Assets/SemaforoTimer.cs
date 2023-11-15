using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemaforoTimer : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject RedL;
    public GameObject GreenL;
    public GameObject YellowL;
    public bool StartsGreen = false;
    public GameObject Trigg;
    private float RTime = 25;
    [SerializeField] private float CRTime;
    private bool Translated = false;
    void Start()
    {
        if (StartsGreen)
        {
            RedL.SetActive(false);
            Trigg.transform.Translate(0, -10, 0);
            Translated = true;
        }
        else
        {
            GreenL.SetActive(false);
        }
        YellowL.SetActive(false);
        CRTime = RTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CRTime > 0)
        {
            CRTime -= Time.deltaTime;
        }
        else if (CRTime <= 25)
        {
            YellowL.SetActive(false);
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
        if (CRTime <= 2 && CRTime > 0 && RedL.activeInHierarchy)
        {
            YellowL.SetActive(true);
        }
        else
        {
            YellowL.SetActive(false);
        }
    }
}
