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
    public int vida = 3;
    private bool pode_dano = true;
    private float meuTempoDano = 0;
    public int bolinhas = 0;
    public int vagalumes = 0;
    private Text Vagalume_text;
    private Text Bolinhas_text;
    private Animator animacao;
    
    

    public float barraCoracao = 3;
    public RectTransform imgbarraCoracao;

    private Gerenciador GJ;


    void Start()

    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();

        animacao = GetComponent<Animator>();


        Vagalume_text = GameObject.FindGameObjectWithTag("Vagalume_texto_tag").GetComponent<Text>();
        Bolinhas_text = GameObject.FindGameObjectWithTag("Bolinha_De_Gude_tag").GetComponent<Text>();
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
        

        

        if(Velocidade != 0)
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

        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            velFinal = Velocidade * 2;
        }
        else
        {
            velFinal = Velocidade;
        }

        Corpo.velocity = new Vector2(velFinal, Corpo.velocity.y);

        
       



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
            pode_pular = false;
            qtd_Pulo++;
            if(qtd_Pulo <= 1)
            {
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
        if(gatilho.gameObject.tag == "Pisavel")
        {
            qtd_Pulo = 0;
            pode_pular = true;
            meuTempoPulo = 0;
        }

        if(gatilho.gameObject.tag == "BolinhaDGude")
        {
            Destroy(gatilho.gameObject);
            bolinhas++;
            Bolinhas_text.text = bolinhas.ToString();
        }

        if (gatilho.gameObject.tag == "Vagalume")
        {
            Destroy(gatilho.gameObject);
            vagalumes++;
            Vagalume_text.text = vagalumes.ToString();
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
                




            }
            if(barraCoracao <= 0)
            {
                GJ.PersonagemMorreu();
            }
            
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

    
    
}