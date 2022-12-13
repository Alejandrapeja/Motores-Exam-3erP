using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
  public void Quit()
  {
    SceneManager.LoadScene("Menu");
  }

  public void Retry()
  {
    SceneManager.LoadScene("Mapa");
  }
}
