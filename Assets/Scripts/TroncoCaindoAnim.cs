using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoCaindoAnim : MonoBehaviour


{
    bool colidiu = false;
    public GerenciadorDeSom Som;
    public Animator animacao;
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !colidiu)
        {
            colidiu = true;
            animacao.SetBool("Cair", true);
            Som.SomdeArvore.GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
