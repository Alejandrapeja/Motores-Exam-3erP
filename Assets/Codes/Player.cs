using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int lives;
    public GameObject vida1, vida2, vida3;
    private int Health = 100;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void Hit()
    {
        Health = Health - 100; 
        if(Health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        } 
        else
        {
            
            Health = 100;
            if (lives == 2)
            {
                vida3.SetActive(false);
            }
            if (lives == 1)
            {
                vida2.SetActive(false);
            }
        }

        
    }
}
