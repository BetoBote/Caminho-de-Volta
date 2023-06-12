using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{

    public bool gameON = false;

    public GameObject TelaGameOver;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void IniciarJogo()
    {
        gameON = true;
    }

    public bool EstadoJogo()
    {
        return gameON;
    }

    public void PersonagemMorreu()
    {
        TelaGameOver.SetActive(true);
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(0);
    }
}
