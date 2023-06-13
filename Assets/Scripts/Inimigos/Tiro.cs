using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
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

}
