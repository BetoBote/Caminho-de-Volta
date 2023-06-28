using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D Corpo;
    public float Velocidade;
    public SpriteRenderer ImagemPersonagem;
    public int qtd_Pulo = 0;
    private float meuTempoPulo = 0;
    public bool pode_pular = true;
    public float puloMax = 1;
    public int vida = 5;
    private bool pode_dano = true;
    private float meuTempoDano = 0;
    public int bolinhas = 0;
    public int vagalumes = 0;
    private Text Vagalume_text;
    private Text Bolinhas_text;
    private Animator animacao;
    public GerenciadorDeSom Som;
    //public Vector3 posInicial;
    public GameObject botaoPowerUp;
    
    
    

    public float barraCoracao = 5;
    public RectTransform imgbarraCoracao;

    private Gerenciador GJ;


    void Start()

    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();

        animacao = GetComponent<Animator>();


        Vagalume_text = GameObject.FindGameObjectWithTag("Vagalume_texto_tag").GetComponent<Text>();
        Bolinhas_text = GameObject.FindGameObjectWithTag("Bolinha_De_Gude_tag").GetComponent<Text>();

        //transform.position = posInicial;
    }

    // Update is called once per frame
    void Update()
    {
        if(GJ.EstadoDoJogo() == true)
        {
            Mover();
            Pular();
            Apontar();
            //Dano();
            TemporizadorDano();
        }


        
    }

    void Mover()
    {
        Velocidade = Input.GetAxis("Horizontal") * 4;
        float velFinal;
        




        if (Velocidade != 0)
        {
            animacao.SetBool("Andando",true);

        }
        else 
        {
            animacao.SetBool("Andando",false);
        }

        if(Corpo.velocity.y > 1)
        {
            
            animacao.SetBool("Pulando", true);
        }
        if(Corpo.velocity.y < -2)
        {
            animacao.SetBool("Pulando", false);
        }
        



        if (Input.GetKey(KeyCode.F))
        {
            velFinal = Velocidade * 2;
            animacao.SetBool("Correndo", true);
        }
        else
        {
            velFinal = Velocidade;
            animacao.SetBool("Correndo", false);
        }

       float minhavelocidadey  = Corpo.velocity.y;
        if(minhavelocidadey > 10)
        {
            minhavelocidadey = 10;
        }

        Corpo.velocity = new Vector2(velFinal, minhavelocidadey);

        
       



    }


    void Apontar()
    {
        if(Velocidade > 0)
        {
            ImagemPersonagem.flipX = false;
        }
        
        else if(Velocidade < 0)
        {
            ImagemPersonagem.flipX = true;
        }
        
    }
    void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space) && pode_pular == true)
        {
            
            
            qtd_Pulo++;
            if(qtd_Pulo >= puloMax)
            {
                pode_pular = false;
            }
           
            
            if(qtd_Pulo <= puloMax)
            {
                Som.pulo.GetComponent<AudioSource>().Play();
                AcaoPulo();
            }
            
        }
        if(pode_pular == false)
        {
            TemporizadorPulo();
        }
        
    }
    void AcaoPulo()
    {
        Corpo.velocity = new Vector2(Velocidade, 0);
        Corpo.AddForce(transform.up * 300f);
    }

    private void OnTriggerEnter2D(Collider2D gatilho)
    {
        if (gatilho.gameObject.tag == "ataque")
        {
            if (pode_dano == true)
            {
                animacao.SetBool("Danificado", true);

                pode_dano = false;
                vida--;
                Dano();
                botaoPowerUp.SetActive(false);
                Som.SomDamage.GetComponent<AudioSource>().Play();






            }
            if (barraCoracao <= 0)
            {
                Som.morte.GetComponent<AudioSource>().Play();
                GJ.PersonagemMorreu();
                
            }
         
        }

        

        if(gatilho.gameObject.tag == "PuloDuplo")
        {
            Som.powerUp.GetComponent<AudioSource>().Play();
            puloMax = 2;
            Destroy(gatilho.gameObject);
            botaoPowerUp.SetActive(true);
            
        }
       

        if (gatilho.gameObject.tag == "Pisavel")
        {
            qtd_Pulo = 0;
            pode_pular = true;
            meuTempoPulo = 0;
        }

        if(gatilho.gameObject.tag == "BolinhaDGude")
        {
            Som.bolinha.GetComponent<AudioSource>().Play();
            Destroy(gatilho.gameObject);
            bolinhas++;
            Bolinhas_text.text = bolinhas.ToString();
            if(bolinhas >= 5)
            {
                GJ.AtivaConquistaBolinha();
            }
        }

        if (gatilho.gameObject.tag == "Vagalume")
        {
            Som.vagalume.GetComponent<AudioSource>().Play();
            Destroy(gatilho.gameObject);
            vagalumes++;
            Vagalume_text.text = vagalumes.ToString();
            if(vagalumes >= 3)
            {
                GJ.AtivaConquistaVagalume();
            }
        }
        
        if(gatilho.gameObject.tag == "Vitoria")
        {
            GJ.Vitoria();
            if(vida >= 5)
            {
                GJ.AtivaConquistaVidaMaxima();
                GJ.AtivouCq2();

            }
            if(bolinhas >= 5)
            {
                GJ.AtivouCq1();
            }
            if(vagalumes >= 3)
            {
                GJ.AtivouCq3();
            }
            
            
        }
        
        
    }
    void TemporizadorPulo()
    {
        meuTempoPulo += Time.deltaTime;
        if(meuTempoPulo > 0.5f)
        {
            pode_pular = true;
            meuTempoPulo = 0;
        }
    }

    void Dano()
    {
        if(pode_dano == false)
        {
            barraCoracao = barraCoracao - 1;
            imgbarraCoracao.sizeDelta = new Vector2(barraCoracao * 100, 100);
            TemporizadorDano();

        }
    }

    
    void OnCollisionEnter2D(Collision2D colisao)
    {

       

        if(colisao.gameObject.tag == "Inimigo")
        {
            if(pode_dano == true)
            {
                animacao.SetBool("Danificado", true);
                
                pode_dano = false;
                vida--;
                Dano();
                
                Som.SomDamage.GetComponent<AudioSource>().Play();






            }
            if(barraCoracao <= 0)
            {
                Som.SomEncerramento();
                GJ.PersonagemMorreu();
                
            }
            
        }
        if(colisao.gameObject.tag == "Espinho")
        {
            Som.SomEncerramento();
            GJ.PersonagemMorreu();
            


        }

        if (colisao.gameObject.tag == "Mola")
        {
            Som.SomDeMola.GetComponent<AudioSource>().Play();
            Corpo.AddForce(Vector2.up * 1000f);
        }
    }
    void TemporizadorDano()
    {
        meuTempoDano += Time.deltaTime;
        if (meuTempoDano > 0.5f)
        {
            animacao.SetBool("Danificado", false);
            pode_dano = true;
            meuTempoDano = 0;
            
            
        }

    }
    void ManagerCollision(GameObject coll)
    {
        if (coll.CompareTag("mola"))
        {
            Corpo.AddForce(transform.up * 10f);
        }
    }

    


    
    
}