using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gerenciador : MonoBehaviour
{
    public bool GameLigado = false;
    //public Controlador controlador;
    public GameObject TelaGameOver;
    public GameObject TelaVitoria;
    

    public void Vitoria()
    {
        GameLigado = false;
        TelaVitoria.SetActive(true);
    }
    void Start()
    {
        GameLigado = false;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameLigado == true)
        {
            Time.timeScale = 1;
        }
    }

    public bool EstadoDoJogo()
    {
        return GameLigado;
    }

    
    
        
    
    public void LigarJogo()
    {
        GameLigado = true;
        Time.timeScale = 1;

    }
    
    public void PersonagemMorreu()
    {
        
        TelaGameOver.SetActive(true);
        GameLigado = false;
        Time.timeScale = 0;
        
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(0);
    }
    
}
