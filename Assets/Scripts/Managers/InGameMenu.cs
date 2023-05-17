using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public static bool enPausa = false;
    public GameObject pauseMenu;
    public GameObject selectMenuGame;
    public GameObject interfazInGame;
    public static InGameMenu Instance;


//ME CAGO EN EL PUTO VIAJERO DE MIERDA DE LOS COJONES SU PUTA MADRE QUE PUTO DOLOR DE CABEZA HACER  ALGO PARA ESTE GILIPOLLA ME VA HACer cambiar todo EL PUTO PROYECTO

    void Awake() 
    {
        if( Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Global.PlayerScript == false)
        {
            if(enPausa)
            {
                ContinuePlay();
            }
            else
            {
                Pause();
            }
        }
        
        if(Global.PauseMenu == true)
        {
            Debug.Log("TUS MUERTOS");
        }
        if(Global.PauseMenu == false)
        {
            Debug.Log("GILIPOLLAs");
        }
    }

    public void ContinuePlay()
    {
        pauseMenu.SetActive(false);
        selectMenuGame.SetActive(false);
        interfazInGame.SetActive(true);
        Time.timeScale = 1f;
        enPausa = false;
        Global.PlayerScript = false;
        Global.PauseMenu = true;
        Cursor.lockState = CursorLockMode.Locked;
        Global.WorldLevels = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        enPausa = true;
        Global.PlayerScript = true;
        Cursor.lockState = CursorLockMode.Confined;
        Global.PauseMenu = false;

    }
    public void ReturnLobby()
    {
        Time.timeScale = 1f;
        Global.PlayerScript = false;
        SceneManager.LoadScene(0);
    }

    public void LevelSelect()
    {
        Debug.Log("bmkdnbboz");
        Time.timeScale = 0f;
        Global.PlayerScript = true;
        selectMenuGame.SetActive(true);
        interfazInGame.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Global.WorldLevels = true;

    }
    public void GoldenLevel()
    {
        Time.timeScale = 1f;
        Global.PlayerScript = false;
        Global.nivel = 5;
        PlayerPrefs.SetInt("LevelMax",Global.nivel);
        SceneManager.LoadScene(Global.nivel);
    }
    
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Global.nivel = 6;
            PlayerPrefs.SetInt("LevelMax",Global.nivel);
            SceneManager.LoadScene(Global.nivel);
        }
    }
}
