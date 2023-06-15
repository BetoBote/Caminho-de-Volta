using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoCaindoAnim : MonoBehaviour


{
    public Animator animacao;
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animacao.SetBool("Cair", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
