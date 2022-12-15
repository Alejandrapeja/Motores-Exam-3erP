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
    public bool tocado;

    [SerializeField] private GameObject playerpos;
    public GameObject lostgame;
    [SerializeField] private TMP_InputField usuariocuadro;
    public GameObject victoria;

    // Start is called before the first frame update
    void Start()
    {
        posx = playerpos.transform.position.x;
        posz = playerpos.transform.position.z;
        objetos = 0;
        tiempo = 0;
        lives = 3;
        tocado = false;
        setLastPos();
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = tiempo + Time.deltaTime;
        posx = playerpos.transform.position.x;
        posz = playerpos.transform.position.z;




        
            if (lives == 2)
            {
                vida3.SetActive(false);
            }
            if (lives == 1)
            {
                vida2.SetActive(false);
            }
            if (lives <= 0)
            {
                lostgame.SetActive(true);

            }

        
    }


    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "trap")
       {
            if (tocado == false) {
               Hit();
                loadLastPos();
            }
            tocado = true;
        }
       else if (other.tag == "control")
        {
            objetos= objetos + 1;
            setLastPos();
            if(objetos==3)
            {
                wingame();
            }
            Destroy(other.gameObject);
       
        }
     
    }
        
    public void Hit()
    {
        lives--;
       
    }
    public void setLastPos()
    {
        PlayerPrefs.SetFloat("posxSave", posx);
        PlayerPrefs.SetFloat("poszSave", posz);
    }
    public void loadLastPos()
    {
        float x = PlayerPrefs.GetFloat("posxSave");
        float z = PlayerPrefs.GetFloat("poszSave");
        playerpos.transform.localPosition = new Vector3(x, 1f, z);
        tocado = false;
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
