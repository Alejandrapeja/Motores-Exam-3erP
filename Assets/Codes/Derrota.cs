using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Derrota : MonoBehaviour
{
    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}