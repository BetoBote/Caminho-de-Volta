using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCaindo : MonoBehaviour
{
    public Rigidbody2D corpo;
    private void OnTriggerEnter2D(Collider2D gatilho)
    {
        if(gatilho.gameObject.tag == "Player")
        {
            corpo.gravityScale = 0;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
