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

    public float timerRag;
    private bool actTimer;
    private Animator anim;


    public GameObject playerpos;
    public GameObject lostgame;
    [SerializeField] private TMP_InputField usuariocuadro;
    public GameObject victoria;

    //public CharacterController controller;

    void Start()
    {
        setColliderState(false); //ragdool
        GetComponent<Animator>().enabled = true;
        anim = GetComponent<Animator>();

        objetos = 0;
        tiempo = 0;
        lives = 3;
        tocado = false;
        setLastPos();
        actTimer= false;
        timerRag = 5f;
        timerwin = 5f;
    }
    void Update()
    {
        tiempo = tiempo + Time.deltaTime;
        //activar ragdoll
        if (actTimer==true)
        {
            timerRag -= Time.deltaTime;
            if (timerRag <= 0.0f)
            {
                lostgame.SetActive(true);
                actTimer= false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "trap")
       {
            if (tocado == false) {      
                tocado = true;
                Hit();
            }
            tocado = false;
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

        if (lives == 2)
        {
            vida3.SetActive(false);
            die();
            loadLastPos();
        }
        if (lives == 1)
        {
            vida2.SetActive(false);
            die();
            loadLastPos();
        }
        if (lives <= 0)
        {
            vida1.SetActive(false);
            actTimer = true;
            die();
        }
    }
    public void setLastPos()
    {
        posx = playerpos.transform.position.x;
        posz = playerpos.transform.position.z;
        PlayerPrefs.SetFloat("posxSave", posx);
        PlayerPrefs.SetFloat("poszSave", posz);
    }
    public void loadLastPos()
    {
        //Debug.Log("loading pos"+ PlayerPrefs.GetFloat("posxSave")+" "+ PlayerPrefs.GetFloat("poszSave"));
        playerpos.transform.position = new Vector3(PlayerPrefs.GetFloat("posxSave"), 0f, PlayerPrefs.GetFloat("poszSave"));
        dient();
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
    public void dient()
    {

        GetComponent<Animator>().enabled = true;

        setColliderState(false);
        
    }

    //codigos ragdoll
    public void die()
    {
        //Debug.Log("dying");
        GetComponent<Animator>().enabled = false;

        setColliderState(true);
    }

    void setColliderState(bool state)
    {

        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }
        GetComponent<Collider>().enabled = !state;
    }
}
