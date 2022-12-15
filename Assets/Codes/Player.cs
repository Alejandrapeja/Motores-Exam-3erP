using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public int lives;
    public GameObject vida1, vida2, vida3;
    public float posx;
    public float posz;
    public float tiempo;
    public int objetos;
    public float tiempoTotal;

    [SerializeField] private GameObject playerpos;
    [SerializeField] private GameObject lostgame;
    [SerializeField] private TMP_InputField usuariocuadro;
    [SerializeField] private GameObject victoria;

    // Start is called before the first frame update
    void Start()
    {
        objetos = 0;
        tiempo = 0;
        lives = 3;
        setLastPos();
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = tiempo + Time.deltaTime;
        posx = playerpos.transform.position.x;
        posz = playerpos.transform.position.z;
    }


    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "trap")
       {
            Hit();
            loadLastPos();
        }
       else if (other.tag == "control")
        {
            objetos= objetos + 1;
            setLastPos();
            if(objetos==3)
            {
                wingame();
            }

        }
     
    }
        
    public void Hit()
    {
        lives = lives - 1;

        if(lives <= 0)
        {
            lostgame.SetActive(true);
            
        } 
        else
        {
  
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
    public void setLastPos()
    {
        PlayerPrefs.SetFloat("posxSave", posx);
        PlayerPrefs.SetFloat("poszSave", posz);
    }
    public void loadLastPos()
    {
        playerpos.transform.position = new Vector3(posx, 0, posz);
    }
    public void wingame()
    {
        Time.timeScale = 0;
        tiempoTotal = tiempo;
        victoria.SetActive(true);
    }
    public void guardarDatos()
    {
        PlayerPrefs.SetFloat("tiempoSave", tiempoTotal);
        PlayerPrefs.SetString("usuario", usuariocuadro.text);
    }
    
}
