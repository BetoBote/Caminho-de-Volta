using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Collider2D))]
public class InteragirComBotao : MonoBehaviour
{
    Animator animacao;
    EasterEgg easterEgg;

     void Start()
    {
        animacao = GetComponent<Animator>();
        easterEgg = GetComponent<EasterEgg>();
    }


    private bool podeExecutar;

    // Update is called once per frame
    void Update()
    {
        if (podeExecutar && Input.GetKeyDown(KeyCode.E))
        {
            animacao.SetBool("Aparece", true);
            easterEgg.Abre();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            podeExecutar = true;
        }
        
    }

    
}
