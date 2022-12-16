using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public GameObject optionsScreen;

    public OptionsController settingsPanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void MostrarOpciones()
    {
        optionsScreen.SetActive(true);
    }
    public void ReloadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
