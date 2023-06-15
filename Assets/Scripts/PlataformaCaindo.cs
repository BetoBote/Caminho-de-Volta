using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCaindo : MonoBehaviour
{
    public Rigidbody2D corpo;
    float quedaDelay = 2f;
    
    
    void Start()
    {
        corpo = GetComponent<Rigidbody2D>();
    }
    IEnumerable Cair()
    {
        yield return new WaitForSeconds(0.4f);
        corpo.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, quedaDelay);
    }
    private void OnCollisionEnter2D(Collision2D colissao)
    {
        if(colissao.gameObject.tag == "Player")
        {
            StartCoroutine("Cair");
        }
        if(colissao.gameObject.tag == "Espinho")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
