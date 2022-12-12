using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingsmanager : MonoBehaviour
{
    public GameObject settings;
    public GameObject menu;

    public void CloseSettings()
    {
        Scene ascene = SceneManager.GetActiveScene();
        if(ascene.name == "Menu")
        {
            menu.SetActive(true);
            settings.SetActive(false);
        }
        else
        {
            settings.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
