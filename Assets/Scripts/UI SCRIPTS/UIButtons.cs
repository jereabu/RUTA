using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    [SerializeField] GameObject[] UIElements;
    [SerializeField] GameObject[] MODES; //Mode Selector UI
    [SerializeField] GameObject[] MLES_1; //Module Selector UI 


    // Start is called before the first frame update
    void Start()
    {
        UIElements = GameObject.FindGameObjectsWithTag("MenuUI");
        MODES = GameObject.FindGameObjectsWithTag("MODES");
        MLES_1 = GameObject.FindGameObjectsWithTag("MLES_1");

        for (int i = 0; i < MODES.Length; i++)
        {
            MODES[i].SetActive(false);
        }

        for (int i = 0; i < MLES_1.Length; i++)
        {
            MLES_1[i].SetActive(false);
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
        for (int i = 0; i < MLES_1.Length; i++)
        {
            MLES_1[i].SetActive(false);
        }
    }

    public void OpenModuleSelector(bool state)
    {
        for (int i = 0; i < UIElements.Length; i++)
        {
            UIElements[i].SetActive(state);
        }
        for (int i = 0; i < MLES_1.Length; i++)
        {
            MLES_1[i].SetActive(!state);
        }
        for (int i = 0; i < MODES.Length; i++)
        {
            MODES[i].SetActive(false);
        }
    }
}

