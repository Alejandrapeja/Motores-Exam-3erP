using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public OptionsController settingsPanel;
    // Start is called before the first frame update
    void Start()
    {
        settingsPanel = GameObject.FindGameObjectWithTag("options").GetComponent<OptionsController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MostrarOpciones()
    {
        settingsPanel.optionsScreen.SetActive(true);
    }
}
