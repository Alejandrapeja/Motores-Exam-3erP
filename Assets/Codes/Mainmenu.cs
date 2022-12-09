using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainmenu : MonoBehaviour
{
    public GameObject settings,menu;

   public void OpenSettings()
    {
     settings = GameObject.Find("Objectsbetweenscenes").GetComponent <settingsmanager>().settings;
     settings.SetActive(true);
     menu.SetActive(false);
    }
}
