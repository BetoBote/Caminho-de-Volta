using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaCarnivora : MonoBehaviour
{
    public int hp = 4;
    public bool podeTomarDano = true;
    private Animator Animacao;
    public Rigidbody2D Tiro;
    public float velocityTiro;
    public float timeThrowTiro;
    public Transform posDown;
    public Transform posLeft;



    public bool frente = true;
    private GameObject Jogador;


    public bool vivo = true;
    private Gerenciador GJ;


    public float tempo = 0;
    public float distanceAtk;
    public GameObject MeuAtk;
    public GameObject PlayerCheck;

    void Start()
    {
        Animacao = GetComponent<Animator>();
        Jogador = GameObject.FindGameObjectWithTag("Player");
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        InvokeRepeating("AtirarTiro", 0, timeThrowTiro);


    }
    public void AtirarTiro()
    {
        StartCoroutine(DispararTiro());
    }
    IEnumerator DispararTiro()
    {
        yield return new WaitForSeconds(1f);

        Rigidbody2D clone;
        clone = Instantiate(Tiro, posDown.transform.position, posLeft.transform.rotation);
        clone.velocity = transform.TransformDirection(Vector2.down * 6);
        
        Destroy(clone.gameObject, 2f);
        
       


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

        //Debug.Log(distance);
        if (distance <= distanceAtk )
        {

          if (tempo > 3)
            {
                //  Debug.Log("CHAMOU ATAQUE");

                //Animacao.SetBool("Atacando", true);
                Animacao.SetTrigger("Ataque");
                tempo = 0;
            }
        }
        else
        {
            //Animacao.SetBool("Atacando", false);
            

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
    
    
        
        
    

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        Debug.Log(colisao.gameObject.tag);
        if(colisao.gameObject.tag == "Player")
        {
            Animacao.SetBool("Acordando", true);
        }
        /*else
        {
            Animacao.SetBool("Acordando", false);
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
