using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapo : MonoBehaviour
{
    public int hp = 4;
    public bool podeTomarDano = true;
    private Animator Animacao;
    
    
    public bool frente = true;
    private GameObject Jogador;


    public bool vivo = true;
    private Gerenciador GJ;


    public float tempo = 0;
    public float distanceAtk;
    public GameObject MeuAtk; 

    void Start()
    {
        Animacao = GetComponent<Animator>();
        Jogador = GameObject.FindGameObjectWithTag("Player");
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();


    }

    private void Update()
    {
        tempo += Time.deltaTime;


        if (vivo == true)
        {
            Intel();
        }


        if (GJ.EstadoDoJogo() == true)
        {
            Intel();
        }


    }

    void Intel()
    {
        float distance = Vector2.Distance(transform.position, Jogador.transform.position);

        Debug.Log(distance);
        if (distance <= distanceAtk )
        {

          if (tempo > 3)
            {
                //  Debug.Log("CHAMOU ATAQUE");
                Animacao.SetBool("Atacar", true);
                MeuAtk.SetActive(true);
                tempo = 0;
            }

          else if  (tempo > 0.29 && tempo <= 3 ) {
                Animacao.SetBool("Atacar", false);
               
                MeuAtk.SetActive(false);

               
            }

        }
        else
        {
           
            
        }
        /*else if (Vector2.Distance(transform.position, Jogador.transform.position) <= 2f)
        {
            vendoJogador = true;
            Animacao.SetBool("Andar", false);
        }else if (Vector2.Distance(transform.position, Jogador.transform.position) > 2f)
        {
            vendoJogador = false;
            Animacao.SetBool("Atacar", false);
            atk.SetActive(false);

            Mover();
        }*/
    }

    

    

    private void OnTriggerStay2D(Collider2D colidiu)
    {
        if(colidiu.gameObject.tag == "Ataque")
        {
            if(podeTomarDano == true)
            {
                hp--;
                podeTomarDano = false;
                Animacao.SetTrigger("TomouDano");
                if (hp <= 0)
                {
                    Animacao.SetBool("Morto", true);
                    Morto();
                }
            }
            
        }

        
    }

    public void AcabouImunidade()
    {
        podeTomarDano = true;
    }


    public void AtivaAtk()
    {
        MeuAtk.SetActive(true);
    }

    public void DesativaAtk()
    {
        MeuAtk.SetActive(false);
    }


    void Morto()
    {
        GetComponent<Collider2D>().enabled = false;
        vivo = false;
        Destroy(this.gameObject, 15f);
    }

}
