using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    [SerializeField] GameObject[] UIElements;
    [SerializeField] GameObject[] MODES; //Mode Selector UI
    [SerializeField] GameObject[] LVLS_1; //Nivel Selector UI 
    [SerializeField] GameObject[] DLVL_1; //Description Nivel1 Selector UI 
    //[SerializeField] GameObject[] DLVL_2; //Description Nivel2 Selector UI 
    [SerializeField] GameObject[] LVL_COM; //Level Completed Selector UI




    //string PreviousScene;

    // Start is called before the first frame update
    void Start()
    {
        UIElements = GameObject.FindGameObjectsWithTag("MenuUI");
        MODES = GameObject.FindGameObjectsWithTag("MODES");
        LVLS_1 = GameObject.FindGameObjectsWithTag("LVLS_1");
        DLVL_1 = GameObject.FindGameObjectsWithTag("DLVL_1");
        //DLVL_2 = GameObject.FindGameObjectsWithTag("DLVL_2");
        LVL_COM = GameObject.FindGameObjectsWithTag("LVL_COM");

        

        for (int i = 0; i < MODES.Length; i++)
        {
            MODES[i].SetActive(false);
        }

        for (int i = 0; i < LVLS_1.Length; i++)
        {
            LVLS_1[i].SetActive(false);
        }

        for (int i = 0; i < DLVL_1.Length; i++)
        {
            DLVL_1[i].SetActive(false);
        }
       
        for (int i = 0; i < LVL_COM.Length; i++)
        {
            LVL_COM[i].SetActive(false);
        }
    }

     
    public void LoadGame(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }
   
    public void OpenModeSelector(bool state)
    {
        for (int i = 0; i < UIElements.Length; i++) 
        {
            UIElements[i].SetActive(state);
        }
        for (int i = 0; i < MODES.Length; i++)
        {
            MODES[i].SetActive(!state);
        }
        for (int i = 0; i < LVLS_1.Length; i++)
        {
            LVLS_1[i].SetActive(false);
        }
        for (int i = 0; i < DLVL_1.Length; i++)
        {
            DLVL_1[i].SetActive(false);
        }
     
        for (int i = 0; i < LVL_COM.Length; i++)
        {
            LVL_COM[i].SetActive(false);
        }

    }

    public void OpenLevelSelector(bool state)
    {
        for (int i = 0; i < UIElements.Length; i++)
        {
            UIElements[i].SetActive(state);
        }
        for (int i = 0; i < LVLS_1.Length; i++)
        {
            LVLS_1[i].SetActive(!state);
        }
        for (int i = 0; i < MODES.Length; i++)
        {
            MODES[i].SetActive(false);
        }
        for (int i = 0; i < DLVL_1.Length; i++)
        {
            DLVL_1[i].SetActive(false);
        }
       
        for (int i = 0; i < LVL_COM.Length; i++)
        {
            LVL_COM[i].SetActive(false);
        }
    }

    public void OpenDescriptionNivel1Selector(bool state)
    {
        for (int i = 0; i < UIElements.Length; i++)
        {
            UIElements[i].SetActive(state);
        }
        
        for (int i = 0; i < DLVL_1.Length; i++)
        {
            DLVL_1[i].SetActive(!state);
        }
        for (int i = 0; i < LVLS_1.Length; i++)
        {
            LVLS_1[i].SetActive(!state);
        }
        for (int i = 0; i < MODES.Length; i++)
        {
            MODES[i].SetActive(false);
        }
       
        for (int i = 0; i < LVL_COM.Length; i++)
        {
            LVL_COM[i].SetActive(false);
        }
    }
    public void OpenDescriptionNivel2Selector(bool state)
    {
        for (int i = 0; i < UIElements.Length; i++)
        {
            UIElements[i].SetActive(state);
        }
     
        for (int i = 0; i < LVLS_1.Length; i++)
        {
            LVLS_1[i].SetActive(!state);
        }
        for (int i = 0; i < MODES.Length; i++)
        {
            MODES[i].SetActive(false);
        }
        for (int i = 0; i < DLVL_1.Length; i++)
        {
            DLVL_1[i].SetActive(false);
        }
        for (int i = 0; i < LVL_COM.Length; i++)
        {
            LVL_COM[i].SetActive(false);
        }

    }

    public void OpenLevelCompletedSelector(bool state)
    {
        for (int i = 0; i < UIElements.Length; i++)
        {
            UIElements[i].SetActive(state);
        }
     
        for (int i = 0; i < LVLS_1.Length; i++)
        {
            LVLS_1[i].SetActive(!false);
        }
        for (int i = 0; i < MODES.Length; i++)
        {
            MODES[i].SetActive(false);
        }
        for (int i = 0; i < DLVL_1.Length; i++)
        {
            DLVL_1[i].SetActive(false);
        }
        for (int i = 0; i < LVL_COM.Length; i++)
        {
            LVL_COM[i].SetActive(!state);
        }

    }
    public void DesactivarOpenLevelCompletedSelector(bool state)
    {
        for (int i = 0; i < LVL_COM.Length; i++)
        {
            LVL_COM[i].SetActive(false);
        }
  
    }
}

