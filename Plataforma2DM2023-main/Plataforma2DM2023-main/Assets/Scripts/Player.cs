using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D Corpo;
    public float Velocidade;
    public SpriteRenderer ImagemPersonagem;
    public int qtd_Pulo = 0;
    private float meuTempoPulo = 0;
    public bool pode_pular = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        Pular();
        Apontar();
    }

    void Mover()
    {
        Velocidade = Input.GetAxis("Horizontal") * 4;
        Corpo.velocity = new Vector2(Velocidade, Corpo.velocity.y);
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
            if(qtd_Pulo <= 2)
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
}
