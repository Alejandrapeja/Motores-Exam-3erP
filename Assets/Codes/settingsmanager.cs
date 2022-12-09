using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsmanager : MonoBehaviour
{
    public GameObject settings;

    public void CloseSettings()
    {
        GameObject.Find("Menu").SetActive(true);
        settings.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
