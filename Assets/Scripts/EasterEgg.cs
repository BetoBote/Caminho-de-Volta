using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    bool jaConquistou = false;

    public GameObject conquistas;
    public GameObject conquistaBolinha;
    public Gerenciador GJ;
    
    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
    }

    public void Abre()
    {
        if(jaConquistou == false) { 
            conquistas.SetActive(true);
            jaConquistou = true;
            StartCoroutine("DesativarPanel");
            GJ.AtivouCq4();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DesativarPanel() {
        yield return new WaitForSeconds(5);
        conquistas.SetActive(false);
    }

}
