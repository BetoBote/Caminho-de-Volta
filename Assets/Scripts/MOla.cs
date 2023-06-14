using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOla : MonoBehaviour
{
    public Animator animacao;

    void Start()
    {
        animacao = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "Player")
        {
            animacao.SetBool("Mola", true);
        }
    }
    private void OnCollisionExit2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "Player")
        {
            animacao.SetBool("Mola", false);
        }
    }
}
