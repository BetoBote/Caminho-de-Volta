using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esqueleto : MonoBehaviour
{
    public int hp = 4;
    public bool podeTomarDano = true;
    private Animator Animacao;
    public float posInicial;
    public float posFinal;
    public bool frente = true;
    private GameObject Jogador;

    bool canAtk = true;

    public float atkCooldown;
    float atkCounter;

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

       // Debug.Log(distance);
        if (distance <= distanceAtk)
        {
            if (canAtk)
            {
                Animacao.SetBool("Atacar", true);
                canAtk = false;
                //MeuAtk.SetActive(true);
                tempo = 0;
            }
            /*if (tempo > 1 && !canAtk)
            {
                  //  Debug.Log("CHAMOU ATAQUE");
                  canAtk = true;
                  Animacao.SetBool("Atacar", true);
                  MeuAtk.SetActive(true);
                  tempo = 0;
            }*/
            /*if (!canAtk)
            {
                atkCounter += Time.deltaTime;
                Animacao.SetBool("Atacar", false);
                if (atkCounter >= atkCooldown)
                {
                    MeuAtk.SetActive(false);
                    atkCounter = 0;
                    canAtk = true;
                }
            }
            else {
                
                canAtk = false;
            }*/
        }
        else if(canAtk == true)
        {
            Animacao.SetBool("Andar", true);
            Animacao.SetBool("Atacar", false);
            MeuAtk.SetActive(false);
            Mover();
        }

        if (!canAtk) 
        {
            atkCounter += Time.deltaTime;
            if (atkCounter >= atkCooldown) 
            {
                atkCounter = 0;
                canAtk = true;
                MeuAtk.SetActive(false);
            }
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

    void Mover()
    {
        Animacao.SetBool("Andar", true);
        if (frente == true)
        {
            //para Onde eu quero IR
            Vector2 destino = new Vector2(posFinal, transform.position.y);
            //Me deslocando
            transform.position = Vector2.MoveTowards(transform.position, destino, 0.003f);
            transform.localScale = new Vector3(1, 1, 1);
            if(Vector2.Distance(transform.position, destino) < 0.2f)
            {
                frente = false;
            }
        }
        if (frente == false)
        {
            //para Onde eu quero IR
            Vector2 destino = new Vector2(posInicial, transform.position.y);
            //Me deslocando
            transform.position = Vector2.MoveTowards(transform.position, destino, 0.003f);
            transform.localScale = new Vector3(-1, 1, 1);
            if (Vector2.Distance(transform.position, destino) < 0.2f)
            {
                frente = true;
            }
        }

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
        canAtk = true;
    }


    void Morto()
    {
        GetComponent<Collider2D>().enabled = false;
        vivo = false;
        Destroy(this.gameObject, 15f);
    }

}
