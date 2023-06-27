using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeSom : MonoBehaviour
{
    public AudioSource bolinha;
    public AudioSource vagalume;
    public AudioSource powerUp;
    public AudioSource pulo;
    public AudioSource morte;
    public AudioSource SomdeArvore;
    public AudioSource SomDeMola;
    public AudioSource SomDamage;

    public AudioSource somdeFundo;

    public void SomEncerramento()
    {
        morte.Play();
        somdeFundo.enabled = false;

    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
