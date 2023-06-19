using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rigidbody2D;

    private void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        if(colisao.gameObject.tag == "Pisavel")
        {
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(gameObject, 0f);
            
        }
        if (colisao.gameObject.tag == "Player")
        {
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(gameObject, 0f);

        }

    }

    public void SetSpeed(float speed) 
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = Vector2.right * speed;
    }

}
