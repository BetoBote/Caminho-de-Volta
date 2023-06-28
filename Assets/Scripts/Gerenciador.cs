using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gerenciador : MonoBehaviour
{
    public bool GameLigado = false;
    //public Controlador controlador;
    public GameObject TelaGameOver;
    public GameObject TelaVitoria;
    public GameObject TelaConquista;
    public GameObject TelaConquistaBolinha;
    public GameObject TelaConquistaVagalume;
    public GameObject TelaConquistaVidaMaxima;
    public GameObject TelaConquistaTempoRecorde;
    public GameObject TelaConfigurações;
    public GameObject TelaCreditos;
    public GameObject CqGame01;
    public GameObject CqGame02;
    public GameObject CqGame03;
    public GameObject CqGame04;
    public GameObject CqGame05;
    public float meuTempo = 0;
    public Text txtMeuTempo;



    public void Vitoria()
    {
        GameLigado = false;
        TelaVitoria.SetActive(true);
        if(meuTempo <= 60)
        {
            AtivouCq5();
        }
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
            meuTempo += Time.deltaTime;
            float seg = Mathf.FloorToInt(meuTempo % 60);
            float min = Mathf.FloorToInt(meuTempo / 60);
            float mili = (int)(meuTempo * 1000f) % 1000;
            txtMeuTempo.text = string.Format("{0:00}:{1:00}:{2:000}", min, seg, mili);

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

    //ativa a consquita da Bolinha
    public void AtivaConquistaBolinha()
    {
        TelaConquistaBolinha.SetActive(true);
        StartCoroutine("DesativaConquista",TelaConquistaBolinha);
    }

    IEnumerator DesativaConquista(GameObject panel) {
        yield return new WaitForSeconds(5);
        panel.SetActive(false);
    }

    //Ativa a Conquista do vagalume
    public void AtivaConquistaVagalume()
    {
        TelaConquistaVagalume.SetActive(true);
        StartCoroutine("DesativaConquista", TelaConquistaVagalume);
    }
    //Ativa Conquista da Vida Maxima
    public void AtivaConquistaVidaMaxima()
    {
        TelaConquistaVidaMaxima.SetActive(true);
        StartCoroutine("DesativaConquista", TelaConquistaVidaMaxima);
    }
    //Ativa Conquista do Tempo Recorde
    public void AtivaConquistaTempoRecorde()
    {
        TelaConquistaTempoRecorde.SetActive(true);
        StartCoroutine("DesativaConquista", TelaConquistaTempoRecorde);
    }

    //painel vitoria consquistas

    public void AtivouCq1()
    {
        
        CqGame01.GetComponent<Image>().color = Color.white;
            
    }

    public void AtivouCq2()
    {

        CqGame02.GetComponent<Image>().color = Color.white;

    }

    public void AtivouCq3()
    {

        CqGame03.GetComponent<Image>().color = Color.white;

    }

    public void AtivouCq4()
    {

        CqGame04.GetComponent<Image>().color = Color.white;

    }

    public void AtivouCq5()
    {

        CqGame05.GetComponent<Image>().color = Color.white;

    }

    public void AbrirOpcoes()
    {
        TelaConfigurações.SetActive(true);
    }

    public void FecharOpcoes()
    {
        TelaConfigurações.SetActive(false);
    }

    public void AbrirCreditos()
    {
        TelaCreditos.SetActive(true);
    }

    public void FecharCreditos()
    {
        TelaCreditos.SetActive(false);
    }

    public void SairJogo()
    {
        
        Application.Quit();
    }


}
