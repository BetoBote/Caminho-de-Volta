using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    bool jaConquistou = false;

    public GameObject conquistas;
    public GameObject conquistaBolinha;
    
    void Start()
    {
        
    }

    public void Abre()
    {
        if(jaConquistou == false) { 
            conquistas.SetActive(true);
            jaConquistou = true;
            StartCoroutine("DesativarPanel");
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
